Imports System.ComponentModel

Public Class frmMain
    Dim myDoc As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Initial() Then
            End
            Exit Sub
        End If
        isComming = False
        Me.tmrScan.Enabled = True
        Me.tmrUpdateUI.Enabled = True
    End Sub

    Private Function Initial()
        On Error GoTo error_process
        myDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\GuoziAlarm"
        If Not My.Computer.FileSystem.DirectoryExists(myDoc) Then
            My.Computer.FileSystem.CreateDirectory(myDoc)
            myDoc = myDoc & "\Events.dat"
            Dim f = System.IO.File.Create(myDoc)
            f.Close()
        Else
            myDoc = myDoc & "\Events.dat"
            If Not System.IO.File.Exists(myDoc) Then
                Dim f = System.IO.File.Create(myDoc)
                f.Close()
            End If
        End If
        Call InitAlarmList()
        Me.btnStop.Enabled = False
        Me.txbRmdHr.Enabled = False
        Me.txbRmdHr2.Enabled = False
        Me.txbRmdHr.ForeColor = Color.Gray
        Me.txbRmdHr2.ForeColor = Color.Gray

        If LoadAlarmData() Then
        End If
        Initial = 0
        Exit Function
error_process:
        Initial = 99
        MsgBox(Err.Description)
    End Function

    Private Sub InitAlarmList()

        Me.grbAlarmList.Height = Me.Height - 62
        Me.grbAlarmList.Width = 770

        Me.lsvAlarmList.Items.Clear()
        Me.lsvAlarmList.FullRowSelect = True
        Me.lsvAlarmList.GridLines = True
        Me.lsvAlarmList.View = View.Details
        Me.lsvAlarmList.Width = Me.grbAlarmList.Width - 15
        Me.lsvAlarmList.Height = Me.grbAlarmList.Height - 35
        Dim sorter As New AlarmListViewSorter(2)
        Me.lsvAlarmList.ListViewItemSorter = sorter
        Me.lsvAlarmList.Sorting = SortOrder.Descending
        Me.lsvAlarmList.Columns.Add("", 0, HorizontalAlignment.Center)
        Me.lsvAlarmList.Columns.Add("Index", 50, HorizontalAlignment.Center)
        Me.lsvAlarmList.Columns.Add("Time", 200, HorizontalAlignment.Center)
        Me.lsvAlarmList.Columns.Add("Event", 500, HorizontalAlignment.Center)

    End Sub

    Public Sub AlarmListAdd(index As Integer, alarmTime As String, remind As String)
        Dim i As Integer
        Dim listItem As New ListViewItem("")
        listItem.SubItems.Add(index.ToString())
        listItem.SubItems.Add(alarmTime)
        listItem.SubItems.Add(remind)
        Me.lsvAlarmList.Items.Add(listItem)
        Me.lsvAlarmList.Refresh()
        Me.lsvAlarmList.Sort()

        i = 1
        Do While (GetValOfAlarmList(i, 2) <> Nothing)
            SetValOfAlarmList(i, 1, "" & i)
            i = i + 1
        Loop
    End Sub

    Public Sub alarmListDelect(listItem As ListViewItem)
        Me.lsvAlarmList.Items.Remove(listItem)
        Me.lsvAlarmList.Refresh()
        Me.lsvAlarmList.Sort()

        Dim i = 1
        Do While (GetValOfAlarmList(i, 2) <> Nothing)
            SetValOfAlarmList(i, 1, "" & i)
            i = i + 1
        Loop

        If SaveAlarmData() Then
            MsgBox("save data error")
        End If

    End Sub

    Private Function GetValOfAlarmList(row As Integer, col As Integer)
        On Error GoTo error_process
        GetValOfAlarmList = Me.lsvAlarmList.Items.Item(row - 1).SubItems.Item(col).Text
        Exit Function
error_process:
        GetValOfAlarmList = Nothing
    End Function

    Private Function SetValOfAlarmList(row As Integer, col As Integer, val As String)
        On Error GoTo error_process
        Me.lsvAlarmList.Items.Item(row - 1).SubItems.Item(col).Text = val
        Exit Function
error_process:
        SetValOfAlarmList = Nothing
    End Function

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            Me.NotifyIcon1.Visible = True
        Else
            If Me.Width > 1067 Then
                Call UIFull()
            ElseIf Me.Width < 1067 And Me.Width >= 768 Then
                Call UIMiddle()
            Else
                Call UISmall()
            End If
        End If
    End Sub

    Private Sub UIFull()
        Me.grbApro.Visible = False
        Me.btnStop2.Visible = False
        Me.grbAlarmList.Top = 12
        Me.grbAlarmList.Height = Me.Height - 62
        Me.lsvAlarmList.Height = Me.grbAlarmList.Height - 35
        Me.grbAlarmList.Visible = True
        Me.grbApr.Top = 12
        Me.grbApr.Left = 800
        Me.grbApr.Visible = True
        Me.btnStop.Top = 472
        Me.btnStop.Left = 823
        Me.btnStop.Visible = True
    End Sub

    Private Sub UIMiddle()
        Me.grbApro.Visible = True
        Me.btnStop2.Visible = True
        Me.grbAlarmList.Top = 111
        Me.grbAlarmList.Height = Me.Height - 161
        Me.lsvAlarmList.Height = Me.grbAlarmList.Height - 35
        Me.grbAlarmList.Visible = True
        Me.grbApr.Visible = False
        Me.btnStop.Visible = False
    End Sub

    Private Sub UISmall()
        Me.grbApro.Visible = False
        Me.btnStop2.Visible = False
        Me.grbAlarmList.Visible = False
        Me.grbApr.Top = 12
        Me.grbApr.Left = 14
        Me.grbApr.Visible = True
        Me.btnStop.Top = 472
        Me.btnStop.Left = 37
        Me.btnStop.Visible = True
    End Sub

    Private Function LoadAlarmData()
        Dim path = myDoc
        If System.IO.File.Exists(path) Then
            Dim fn = FreeFile()
            Dim strTemp As String
            Dim index As Integer
            Dim time, remind As String
            FileOpen(fn, path, OpenMode.Input)
            Do While Not EOF(fn)
                strTemp = LineInput(fn)
                index = CInt(Mid(strTemp, 1, 3))
                time = Mid(strTemp, 4, 21)
                remind = Mid(strTemp, 25)
                Call AlarmListAdd(index, time, remind)
            Loop
            FileClose(fn)
            LoadAlarmData = 0
        Else
            System.IO.File.Create(path)
            LoadAlarmData = 1
        End If
    End Function

    Public Function SaveAlarmData()
        On Error GoTo error_process
        Dim path = myDoc
        Dim fn = FreeFile()
        Dim i As Integer = 1
        FileOpen(fn, path, OpenMode.Output)
        Do While (GetValOfAlarmList(i, 2) <> Nothing)
            Print(fn, Format(CInt(GetValOfAlarmList(i, 1)), "000") & GetValOfAlarmList(i, 2) & GetValOfAlarmList(i, 3) & vbCrLf)
            i = i + 1
        Loop
        FileClose(fn)
        SaveAlarmData = 0
        Exit Function
error_process:
        SaveAlarmData = 99
    End Function

    Private Sub NotifyIcon1_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseClick
        If e.Button = MouseButtons.Left Then
            Me.Visible = True
            Me.WindowState = FormWindowState.Normal
            Me.NotifyIcon1.Visible = False
            Me.Focus()
        End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.NotifyIcon1.Visible = True
        Me.Hide()
        e.Cancel = True
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        Me.NotifyIcon1.Visible = False
        Me.Focus()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.NotifyIcon1.Visible = False
        If isPlaying Then
            My.Computer.Audio.Stop()
        End If
        End
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        MessageBox.Show("hehe")
    End Sub

    Private Sub Stop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        On Error Resume Next
        Dim i = 1
        Do While (GetValOfAlarmList(i, 2) <> Nothing)
            If Me.lsvAlarmList.Items.Item(i - 1).Tag = ALARM_Passing Then
                Me.lsvAlarmList.Items.Item(i - 1).Tag = ALARM_Passed
            End If
            i = i + 1
        Loop
        If isPlaying Then
            My.Computer.Audio.Stop()
            isPlaying = False
            Me.btnStop.Enabled = False
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim confirm
        confirm = MsgBox("Are you sure want to delete below reminder" & vbCrLf & vbCrLf & Me.lsvAlarmList.SelectedItems.Item(0).SubItems.Item(3).Text, vbOKCancel, "Confirm")
        If confirm = vbOK Then
            Call alarmListDelect(Me.lsvAlarmList.SelectedItems.Item(0))
        End If
    End Sub

    Private Sub ModifyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModifyToolStripMenuItem.Click
        AlarmMgr.Tag = "Modify"
        AlarmMgr.ShowDialog()
    End Sub

    Private Sub DelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        AlarmMgr.Tag = "Add"
        AlarmMgr.ShowDialog()
    End Sub

    Private Sub tmrScan_Tick(sender As Object, e As EventArgs) Handles tmrScan.Tick
        Dim i = 1
        Dim dateTimeStr As String
        Dim dateStr, timeStr As String
        If Me.GetValOfAlarmList(1, 2) = Nothing Then Exit Sub   'empty list

        Do While (Me.GetValOfAlarmList(i, 2) <> Nothing)
            dateTimeStr = Me.GetValOfAlarmList(i, 2)
            dateStr = Mid(dateTimeStr, 1, 10)
            timeStr = Mid(dateTimeStr, 17, 5)
            If AlarmMgr.JudgeTime(dateStr, timeStr) = TIME_Future Then
                Me.lsvAlarmList.Items.Item(i - 1).Tag = ALARM_Aproching
                time_APROCHING_Index = i - 1
                Exit Do
            ElseIf AlarmMgr.JudgeTime(dateStr, timeStr) = TIME_Now Then
                If Me.lsvAlarmList.Items.Item(i - 1).Tag <> ALARM_Passed Then
                    Me.lsvAlarmList.Items.Item(i - 1).Tag = ALARM_Passing
                End If
            Else
                Me.lsvAlarmList.Items.Item(i - 1).Tag = ALARM_Missed
            End If
            i = i + 1
        Loop
        i = 1
    End Sub

    Private Sub tmrUpdateUI_Tick(sender As Object, e As EventArgs) Handles tmrUpdateUI.Tick
        Dim i = 1
        Dim isAlarmPassing = False
        If Me.GetValOfAlarmList(1, 2) = Nothing Then Exit Sub   'empty list

        Do While (GetValOfAlarmList(i, 2) <> Nothing)
            If Me.lsvAlarmList.Items.Item(i - 1).Tag = ALARM_Passing Then
                Me.lsvAlarmList.Items.Item(i - 1).ForeColor = Color.Red
                isAlarmPassing = True
            ElseIf Me.lsvAlarmList.Items.Item(i - 1).Tag = ALARM_Passed Then
                Me.lsvAlarmList.Items.Item(i - 1).ForeColor = Color.Gray
            ElseIf Me.lsvAlarmList.Items.Item(i - 1).Tag = ALARM_Missed Then
                Me.lsvAlarmList.Items.Item(i - 1).ForeColor = Color.Gray
            Else
                If Me.lsvAlarmList.Items.Item(i - 1).Tag = ALARM_Aproching Then
                    Me.lblRemind.Text = GetValOfAlarmList(i, 3)
                End If
                Me.lsvAlarmList.Items.Item(i - 1).ForeColor = Color.Blue
            End If
            i = i + 1
        Loop

        If isAlarmPassing Then
            Me.Focus()
            Me.btnStop.Enabled = True
            If Not isPlaying Then
                My.Computer.Audio.Play(Application.StartupPath & "\sound.wav", AudioPlayMode.BackgroundLoop)
                isPlaying = True
            End If
        Else
        End If

        Dim upcommingTime = GetUpcommingTime()
        If upcommingTime >= 0 Then
            Dim ucTime = upcommingTime
            Dim ucDay = ucTime \ (60 * 24)
            ucTime = ucTime Mod (60 * 24)
            Dim ucHr = ucTime \ 60
            ucTime = ucTime Mod 60
            Dim ucMin = ucTime
            Me.lblCnterDay.Text = ucDay
            Me.lblCntDay2.Text = ucDay
            Me.lblCntHr.Text = ucHr
            Me.lblCntHr2.Text = ucHr
            Me.lblCntMin.Text = ucMin
            Me.lblCntMin2.Text = ucMin
        End If
        If IsNumeric(Trim(Me.txbRmdHr.Text)) Then
            Dim reTime = Val(Trim(Me.txbRmdHr.Text)) * 60
            If reTime > 0 Then
                If upcommingTime < reTime Then
                    Me.lblCnterDay.ForeColor = Color.Orange
                    Me.lblCnterDay.ForeColor = Color.Orange
                    Me.lblCntHr.ForeColor = Color.Orange
                    Me.lblCntHr2.ForeColor = Color.Orange
                    Me.lblCntMin.ForeColor = Color.Orange
                    Me.lblCntMin2.ForeColor = Color.Orange
                    If Not isComming Then
                        Me.Visible = True
                        Me.WindowState = FormWindowState.Normal
                        Me.NotifyIcon1.Visible = False
                        Me.Focus()
                        isComming = True
                    End If
                Else
                    Me.lblCnterDay.ForeColor = Color.Blue
                    Me.lblCnterDay.ForeColor = Color.Blue
                    Me.lblCntHr.ForeColor = Color.Blue
                    Me.lblCntHr2.ForeColor = Color.Blue
                    Me.lblCntMin.ForeColor = Color.Blue
                    Me.lblCntMin2.ForeColor = Color.Blue
                    isComming = False
                End If
            End If
        End If

    End Sub

    Private Function GetUpcommingTime()
        Dim dateTimeStr = Trim(Me.lsvAlarmList.Items.Item(time_APROCHING_Index).SubItems.Item(2).Text)
        If dateTimeStr <> Nothing Then
            Dim dateStr = Mid(dateTimeStr, 1, 10)
            Dim timeStr = Mid(dateTimeStr, 17)
            Dim dTime = DateTime.Parse(dateStr & " " & timeStr)
            Dim nTime = Now
            GetUpcommingTime = DateDiff("n", nTime, dTime)
        Else
            GetUpcommingTime = -1
        End If
    End Function

    Private Sub btnStop2_Click(sender As Object, e As EventArgs) Handles btnStop2.Click
        On Error Resume Next
        Dim i = 1
        Do While (GetValOfAlarmList(i, 2) <> Nothing)
            If Me.lsvAlarmList.Items.Item(i - 1).Tag = ALARM_Passing Then
                Me.lsvAlarmList.Items.Item(i - 1).Tag = ALARM_Passed
            End If
            i = i + 1
        Loop
        If isPlaying Then
            My.Computer.Audio.Stop()
            isPlaying = False
            Me.btnStop.Enabled = False
        End If
    End Sub

    Private Sub txbRmdHr2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txbRmdHr2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Me.txbRmdHr2.ForeColor = Color.Gray
            Me.txbRmdHr2.Enabled = False
            If Trim(Me.txbRmdHr2.Text) = "" Then Me.txbRmdHr2.Text = 0
            Me.txbRmdHr.Text = txbRmdHr2.Text
        End If
    End Sub

    Private Sub txbRmdHr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txbRmdHr.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Me.txbRmdHr.ForeColor = Color.Gray
            Me.txbRmdHr.Enabled = False
            If Trim(Me.txbRmdHr.Text) = "" Then Me.txbRmdHr.Text = 0
            Me.txbRmdHr2.Text = Me.txbRmdHr.Text
        End If
    End Sub

    Private Sub btnRes_Click(sender As Object, e As EventArgs) Handles btnRes.Click
        txbRmdHr.Enabled = True
        txbRmdHr.ForeColor = Color.Black
        txbRmdHr.Focus()
    End Sub

    Private Sub btnRes2_Click(sender As Object, e As EventArgs) Handles btnRes2.Click
        txbRmdHr2.Enabled = True
        txbRmdHr2.ForeColor = Color.Black
        txbRmdHr2.Focus()
    End Sub

    Private Sub lsvAlarmList_MouseUp(sender As Object, e As MouseEventArgs) Handles lsvAlarmList.MouseUp
        If lsvAlarmList.SelectedItems.Count = 0 Then
            Me.DeleteToolStripMenuItem.Enabled = False
            Me.ModifyToolStripMenuItem.Enabled = False
        Else
            Me.DeleteToolStripMenuItem.Enabled = True
            Me.ModifyToolStripMenuItem.Enabled = True
        End If
    End Sub
End Class

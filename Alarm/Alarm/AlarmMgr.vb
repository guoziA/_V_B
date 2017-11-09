Public Class AlarmMgr
    Private Sub tmrTick_Tick(sender As Object, e As EventArgs) Handles tmrTick.Tick
        Static t As Boolean = False
        Me.lblDate.Text = Format(Now, "MM-dd-yyyy(") & Mid(Now.DayOfWeek.ToString, 1, 3) & ")"
        Me.lblTime.Text = Format(Now, "HH    mm")
        If t Then
            Me.lblTick.Visible = False
            t = False
        Else
            Me.lblTick.Visible = True
            t = True
        End If
    End Sub

    Private Sub AlarmMgr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.DateTimePicker1.MinDate = Now.AddDays(-1)
        If Me.Tag = "Modify" Then
            Dim dateTimeStr = frmMain.lsvAlarmList.SelectedItems.Item(0).SubItems.Item(2).Text
            Dim dateSet = DateTime.Parse(Mid(dateTimeStr, 1, 10))
            Dim timeSet = Mid(dateTimeStr, 17)
            Me.DateTimePicker1.Format = DateTimePickerFormat.Custom
            Me.DateTimePicker1.Value = dateSet
            InitTimeComb(timeSet)
            Me.txbRemind.Text = frmMain.lsvAlarmList.SelectedItems.Item(0).SubItems.Item(3).Text
            Me.btnSet.Text = "Save"
        Else
            Me.DateTimePicker1.Format = DateTimePickerFormat.Custom
            Me.DateTimePicker1.Value = Now
            InitTimeComb(Format(Now, "HH:mm"))
            Me.txbRemind.Text = ""
            Me.btnSet.Text = "Add"
        End If
    End Sub

    Private Sub InitTimeComb(timeStr As String)
        Dim i As Int16
        Dim h = CInt(Mid(timeStr, 1, 2))
        Dim m = CInt(Mid(timeStr, 4, 2))
        Me.cmbHour.Items.Clear()
        Me.cmbMinute.Items.Clear()
        For i = 0 To 23
            Me.cmbHour.Items.Add(Format(i, "00"))
        Next
        For i = 0 To 59
            Me.cmbMinute.Items.Add(Format(i, "00"))
        Next
        Me.cmbHour.SelectedIndex = h
        Me.cmbMinute.SelectedIndex = m
    End Sub

    Private Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnSet.Click
        Dim dateSet = Format(Me.DateTimePicker1.Value, "MM/dd/yyyy")
        Dim timeSet = Format(Format(Me.cmbHour.SelectedIndex, "00") & ":" & Format(Me.cmbMinute.SelectedIndex, "00"))
        If JudgeTime(dateSet, timeSet) <> TIME_Future Then
            MsgBox("The target time has passed", vbOKOnly, "Error")
            Exit Sub
        Else
            If Me.Tag = "Modify" Then
                Call frmMain.alarmListDelect(frmMain.lsvAlarmList.SelectedItems.Item(0))
                Call frmMain.AlarmListAdd(0, dateSet & "(" & Mid(Me.DateTimePicker1.Value.DayOfWeek.ToString, 1, 3) & ") " & timeSet, Me.txbRemind.Text)
                If frmMain.SaveAlarmData() Then
                    MsgBox("save data error")
                End If
                Close()
            Else
                If frmMain.lsvAlarmList.Items.Count >= 998 Then
                    MsgBox("List is full, please delete some", vbOKOnly, "Error")
                    Exit Sub
                End If
                Call frmMain.AlarmListAdd(0, dateSet & "(" & Mid(Me.DateTimePicker1.Value.DayOfWeek.ToString, 1, 3) & ") " & timeSet, Me.txbRemind.Text)
                If frmMain.SaveAlarmData() Then
                    MsgBox("save data error")
                End If
            End If
        End If
    End Sub

    Public Function JudgeTime(dateStr As String, timeStr As String)
        Dim dateTimeSet = DateTime.Parse(dateStr & " " & timeStr)
        Dim dateTimeNow = Now
        If DateDiff("n", dateTimeSet, dateTimeNow) < 0 Then
            JudgeTime = TIME_Future
        ElseIf DateDiff("n", dateTimeSet, dateTimeNow) = 0 Then
            JudgeTime = TIME_Now
        Else
            JudgeTime = TIME_Passed
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class
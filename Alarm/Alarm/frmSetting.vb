Public Class frmSetting

    Dim winReg As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Run")
    '读ini API函数
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32
    '写ini API函数
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32
    Dim fileConf As String
    Dim autoBoot As String
    Dim isLoadConfFail As Boolean

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmSetting_Load(sender As Object, e As EventArgs) Handles Me.Load
        On Error GoTo error_process
        If Not ConfigFileIni() Then
            MsgBox("Load config file fail", vbOKOnly, "Fatal")
            Exit Sub
        End If

        Exit Sub
error_process:
        MsgBox(Err.Description)
    End Sub

    Private Function ConfigFileIni()
        On Error GoTo error_process
        Dim isConfExsist As Boolean = True
        fileConf = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\GuoziAlarm"
        If Not My.Computer.FileSystem.DirectoryExists(fileConf) Then
            My.Computer.FileSystem.CreateDirectory(fileConf)
            fileConf = fileConf & "\EventAlarm.ini"
            Dim f = System.IO.File.Create(fileConf)
            f.Close()
            isConfExsist = False
        Else
            fileConf = fileConf & "\EventAlarm.ini"
            If Not System.IO.File.Exists(fileConf) Then
                Dim f = System.IO.File.Create(fileConf)
                f.Close()
                isConfExsist = False
            End If
        End If

        If Not isConfExsist Then
            Dim regValue As String
            If winReg.GetValue("Alarm.exe") <> Nothing Then
                regValue = "True"
            Else
                regValue = "False"
            End If
            Dim file As New System.IO.StreamWriter(fileConf)
            file.WriteLine("[BootSetting]")
            file.WriteLine("BootOnSysStart=" And regValue)
            file.Close()
        End If
        ConfigFileIni = True
        Exit Function
error_process:
        ConfigFileIni = False
    End Function


    Private Function ReadIni(Section As String, key As String, path As String)
        Dim Str As String = LSet(Str, 256)
        Dim length As Long
        length = GetPrivateProfileString(Section, key, "True", Str, Len(Str), path)
        If length <> 0 Then
            ReadIni = Microsoft.VisualBasic.Left(Str, length)
        Else
            ReadIni = "Error"
        End If
    End Function

    Private Function WriteIni(Section As String, key As String, value As String, path As String)
        WriteIni = WritePrivateProfileString(Section, key, value, path)
    End Function

    Private Sub frmSetting_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        isLoadConfFail = LoadConfig()
        If autoBoot = "True" Then
            Me.ckbBoot.Checked = True
        Else
            Me.ckbBoot.Checked = False
        End If
    End Sub

    Private Function LoadConfig()
        Dim strTemp As String
        LoadConfig = False
        fileConf = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\GuoziAlarm\EventAlarm.ini"
        If System.IO.File.Exists(fileConf) Then
            strTemp = ReadIni("BootSetting", "BootOnSysStart", fileConf)
            autoBoot = strTemp
        End If
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        On Error GoTo error_process
        If isLoadConfFail Then
            If Not ConfigFileIni() Then
                MsgBox("Load config file fail", vbOKOnly, "Fatal")
                Exit Sub
            End If
        End If
        fileConf = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\GuoziAlarm\EventAlarm.ini"
        If autoBoot = "False" And Me.ckbBoot.Checked = True Then
            winReg.SetValue("Alarm.exe", Application.StartupPath & "\Alarm.exe")
            WriteIni("BootSetting", "BootOnSysStart", "True", fileConf)
        ElseIf autoBoot = "True" And Me.ckbBoot.Checked = False Then
            winReg.DeleteValue("Alarm.exe")
            WriteIni("BootSetting", "BootOnSysStart", "False", fileConf)
        End If
        Me.Close()
        Exit Sub
error_process:
        MsgBox(Err.Description)
        Me.Close()
    End Sub

End Class
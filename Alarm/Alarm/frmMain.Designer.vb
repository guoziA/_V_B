<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NotifyMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.grbAlarmList = New System.Windows.Forms.GroupBox()
        Me.lsvAlarmList = New System.Windows.Forms.ListView()
        Me.AlistMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModifyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imlListViewH = New System.Windows.Forms.ImageList(Me.components)
        Me.btnStop = New System.Windows.Forms.Button()
        Me.tmrScan = New System.Windows.Forms.Timer(Me.components)
        Me.tmrUpdateUI = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grbApr = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txbRmdHr = New System.Windows.Forms.TextBox()
        Me.lblH = New System.Windows.Forms.Label()
        Me.btnRes = New System.Windows.Forms.Button()
        Me.lblRemind = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCntMin = New System.Windows.Forms.Label()
        Me.lblCntHr = New System.Windows.Forms.Label()
        Me.lblCnterDay = New System.Windows.Forms.Label()
        Me.grbApro = New System.Windows.Forms.GroupBox()
        Me.btnRes2 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txbRmdHr2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblCntMin2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCntHr2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCntDay2 = New System.Windows.Forms.Label()
        Me.btnStop2 = New System.Windows.Forms.Button()
        Me.NotifyMenu.SuspendLayout()
        Me.grbAlarmList.SuspendLayout()
        Me.AlistMenu.SuspendLayout()
        Me.grbApr.SuspendLayout()
        Me.grbApro.SuspendLayout()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.NotifyMenu
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Guozi Alarm"
        '
        'NotifyMenu
        '
        Me.NotifyMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.ExitToolStripMenuItem, Me.ExitToolStripMenuItem1})
        Me.NotifyMenu.Name = "NotifyMenu"
        Me.NotifyMenu.Size = New System.Drawing.Size(148, 70)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.AboutToolStripMenuItem.Text = "Guozi Alarm"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ExitToolStripMenuItem.Text = "About"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(147, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'grbAlarmList
        '
        Me.grbAlarmList.Controls.Add(Me.lsvAlarmList)
        Me.grbAlarmList.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbAlarmList.Location = New System.Drawing.Point(14, 111)
        Me.grbAlarmList.Name = "grbAlarmList"
        Me.grbAlarmList.Size = New System.Drawing.Size(780, 519)
        Me.grbAlarmList.TabIndex = 1
        Me.grbAlarmList.TabStop = False
        Me.grbAlarmList.Text = "Alarm List"
        '
        'lsvAlarmList
        '
        Me.lsvAlarmList.ContextMenuStrip = Me.AlistMenu
        Me.lsvAlarmList.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvAlarmList.Location = New System.Drawing.Point(6, 26)
        Me.lsvAlarmList.Name = "lsvAlarmList"
        Me.lsvAlarmList.Size = New System.Drawing.Size(768, 487)
        Me.lsvAlarmList.SmallImageList = Me.imlListViewH
        Me.lsvAlarmList.TabIndex = 2
        Me.lsvAlarmList.UseCompatibleStateImageBehavior = False
        '
        'AlistMenu
        '
        Me.AlistMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.ModifyToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.AlistMenu.Name = "AlistMenu"
        Me.AlistMenu.Size = New System.Drawing.Size(118, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'ModifyToolStripMenuItem
        '
        Me.ModifyToolStripMenuItem.Name = "ModifyToolStripMenuItem"
        Me.ModifyToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.ModifyToolStripMenuItem.Text = "Modify"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'imlListViewH
        '
        Me.imlListViewH.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imlListViewH.ImageSize = New System.Drawing.Size(50, 50)
        Me.imlListViewH.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnStop
        '
        Me.btnStop.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.Location = New System.Drawing.Point(823, 472)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(200, 53)
        Me.btnStop.TabIndex = 3
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'tmrScan
        '
        Me.tmrScan.Interval = 800
        '
        'tmrUpdateUI
        '
        Me.tmrUpdateUI.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Upcomming Event:"
        '
        'grbApr
        '
        Me.grbApr.Controls.Add(Me.Label9)
        Me.grbApr.Controls.Add(Me.txbRmdHr)
        Me.grbApr.Controls.Add(Me.lblH)
        Me.grbApr.Controls.Add(Me.btnRes)
        Me.grbApr.Controls.Add(Me.lblRemind)
        Me.grbApr.Controls.Add(Me.Label7)
        Me.grbApr.Controls.Add(Me.Label6)
        Me.grbApr.Controls.Add(Me.Label5)
        Me.grbApr.Controls.Add(Me.lblCntMin)
        Me.grbApr.Controls.Add(Me.lblCntHr)
        Me.grbApr.Controls.Add(Me.lblCnterDay)
        Me.grbApr.Controls.Add(Me.Label1)
        Me.grbApr.Location = New System.Drawing.Point(800, 12)
        Me.grbApr.Name = "grbApr"
        Me.grbApr.Size = New System.Drawing.Size(239, 454)
        Me.grbApr.TabIndex = 5
        Me.grbApr.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(70, 417)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 19)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Hour(s)"
        '
        'txbRmdHr
        '
        Me.txbRmdHr.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbRmdHr.Location = New System.Drawing.Point(11, 414)
        Me.txbRmdHr.Name = "txbRmdHr"
        Me.txbRmdHr.Size = New System.Drawing.Size(60, 27)
        Me.txbRmdHr.TabIndex = 15
        Me.txbRmdHr.Text = "24"
        '
        'lblH
        '
        Me.lblH.AutoSize = True
        Me.lblH.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblH.Location = New System.Drawing.Point(6, 392)
        Me.lblH.Name = "lblH"
        Me.lblH.Size = New System.Drawing.Size(108, 19)
        Me.lblH.TabIndex = 14
        Me.lblH.Text = "Remind before:"
        '
        'btnRes
        '
        Me.btnRes.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRes.Location = New System.Drawing.Point(158, 407)
        Me.btnRes.Name = "btnRes"
        Me.btnRes.Size = New System.Drawing.Size(75, 27)
        Me.btnRes.TabIndex = 13
        Me.btnRes.Text = "Reset"
        Me.btnRes.UseVisualStyleBackColor = True
        '
        'lblRemind
        '
        Me.lblRemind.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemind.Location = New System.Drawing.Point(19, 259)
        Me.lblRemind.Name = "lblRemind"
        Me.lblRemind.Size = New System.Drawing.Size(200, 123)
        Me.lblRemind.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(115, 206)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 26)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Minute(s)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(115, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 26)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Hour(s)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(115, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 26)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Day(s)"
        '
        'lblCntMin
        '
        Me.lblCntMin.AutoSize = True
        Me.lblCntMin.Font = New System.Drawing.Font("Calibri", 42.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCntMin.ForeColor = System.Drawing.Color.Blue
        Me.lblCntMin.Location = New System.Drawing.Point(22, 173)
        Me.lblCntMin.Name = "lblCntMin"
        Me.lblCntMin.Size = New System.Drawing.Size(57, 68)
        Me.lblCntMin.TabIndex = 8
        Me.lblCntMin.Text = "0"
        '
        'lblCntHr
        '
        Me.lblCntHr.AutoSize = True
        Me.lblCntHr.Font = New System.Drawing.Font("Calibri", 42.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCntHr.ForeColor = System.Drawing.Color.Blue
        Me.lblCntHr.Location = New System.Drawing.Point(22, 105)
        Me.lblCntHr.Name = "lblCntHr"
        Me.lblCntHr.Size = New System.Drawing.Size(57, 68)
        Me.lblCntHr.TabIndex = 7
        Me.lblCntHr.Text = "0"
        '
        'lblCnterDay
        '
        Me.lblCnterDay.AutoSize = True
        Me.lblCnterDay.Font = New System.Drawing.Font("Calibri", 42.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCnterDay.ForeColor = System.Drawing.Color.Blue
        Me.lblCnterDay.Location = New System.Drawing.Point(22, 37)
        Me.lblCnterDay.Name = "lblCnterDay"
        Me.lblCnterDay.Size = New System.Drawing.Size(57, 68)
        Me.lblCnterDay.TabIndex = 6
        Me.lblCnterDay.Text = "0"
        '
        'grbApro
        '
        Me.grbApro.Controls.Add(Me.btnRes2)
        Me.grbApro.Controls.Add(Me.Label13)
        Me.grbApro.Controls.Add(Me.txbRmdHr2)
        Me.grbApro.Controls.Add(Me.Label12)
        Me.grbApro.Controls.Add(Me.Label11)
        Me.grbApro.Controls.Add(Me.lblCntMin2)
        Me.grbApro.Controls.Add(Me.Label8)
        Me.grbApro.Controls.Add(Me.lblCntHr2)
        Me.grbApro.Controls.Add(Me.Label3)
        Me.grbApro.Controls.Add(Me.lblCntDay2)
        Me.grbApro.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbApro.Location = New System.Drawing.Point(14, 12)
        Me.grbApro.Name = "grbApro"
        Me.grbApro.Size = New System.Drawing.Size(636, 93)
        Me.grbApro.TabIndex = 6
        Me.grbApro.TabStop = False
        Me.grbApro.Text = "Upcomming Event:"
        '
        'btnRes2
        '
        Me.btnRes2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRes2.Location = New System.Drawing.Point(549, 60)
        Me.btnRes2.Name = "btnRes2"
        Me.btnRes2.Size = New System.Drawing.Size(75, 27)
        Me.btnRes2.TabIndex = 19
        Me.btnRes2.Text = "Reset"
        Me.btnRes2.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(567, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 19)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Hour(s)"
        '
        'txbRmdHr2
        '
        Me.txbRmdHr2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbRmdHr2.Location = New System.Drawing.Point(508, 21)
        Me.txbRmdHr2.Name = "txbRmdHr2"
        Me.txbRmdHr2.Size = New System.Drawing.Size(60, 27)
        Me.txbRmdHr2.TabIndex = 17
        Me.txbRmdHr2.Text = "24"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(398, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 19)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Remind before:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(284, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 26)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Min(s)"
        '
        'lblCntMin2
        '
        Me.lblCntMin2.AutoSize = True
        Me.lblCntMin2.Font = New System.Drawing.Font("Calibri", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCntMin2.ForeColor = System.Drawing.Color.Blue
        Me.lblCntMin2.Location = New System.Drawing.Point(235, 34)
        Me.lblCntMin2.Name = "lblCntMin2"
        Me.lblCntMin2.Size = New System.Drawing.Size(36, 42)
        Me.lblCntMin2.TabIndex = 13
        Me.lblCntMin2.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(177, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 26)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Hr(s)"
        '
        'lblCntHr2
        '
        Me.lblCntHr2.AutoSize = True
        Me.lblCntHr2.Font = New System.Drawing.Font("Calibri", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCntHr2.ForeColor = System.Drawing.Color.Blue
        Me.lblCntHr2.Location = New System.Drawing.Point(127, 34)
        Me.lblCntHr2.Name = "lblCntHr2"
        Me.lblCntHr2.Size = New System.Drawing.Size(36, 42)
        Me.lblCntHr2.TabIndex = 11
        Me.lblCntHr2.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(56, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 26)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Day(s)"
        '
        'lblCntDay2
        '
        Me.lblCntDay2.AutoSize = True
        Me.lblCntDay2.Font = New System.Drawing.Font("Calibri", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCntDay2.ForeColor = System.Drawing.Color.Blue
        Me.lblCntDay2.Location = New System.Drawing.Point(6, 34)
        Me.lblCntDay2.Name = "lblCntDay2"
        Me.lblCntDay2.Size = New System.Drawing.Size(36, 42)
        Me.lblCntDay2.TabIndex = 7
        Me.lblCntDay2.Text = "0"
        '
        'btnStop2
        '
        Me.btnStop2.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop2.Location = New System.Drawing.Point(656, 35)
        Me.btnStop2.Name = "btnStop2"
        Me.btnStop2.Size = New System.Drawing.Size(132, 53)
        Me.btnStop2.TabIndex = 7
        Me.btnStop2.Text = "Stop"
        Me.btnStop2.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 537)
        Me.Controls.Add(Me.grbApro)
        Me.Controls.Add(Me.btnStop2)
        Me.Controls.Add(Me.grbApr)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.grbAlarmList)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guozi Alarm"
        Me.NotifyMenu.ResumeLayout(False)
        Me.grbAlarmList.ResumeLayout(False)
        Me.AlistMenu.ResumeLayout(False)
        Me.grbApr.ResumeLayout(False)
        Me.grbApr.PerformLayout()
        Me.grbApro.ResumeLayout(False)
        Me.grbApro.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents NotifyMenu As ContextMenuStrip
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents grbAlarmList As GroupBox
    Friend WithEvents lsvAlarmList As ListView
    Friend WithEvents imlListViewH As ImageList
    Friend WithEvents btnStop As Button
    Friend WithEvents AlistMenu As ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModifyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tmrScan As Timer
    Friend WithEvents tmrUpdateUI As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents grbApr As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txbRmdHr As TextBox
    Friend WithEvents lblH As Label
    Friend WithEvents btnRes As Button
    Friend WithEvents lblRemind As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblCntMin As Label
    Friend WithEvents lblCntHr As Label
    Friend WithEvents lblCnterDay As Label
    Friend WithEvents grbApro As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents lblCntMin2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblCntHr2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblCntDay2 As Label
    Friend WithEvents btnRes2 As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents txbRmdHr2 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnStop2 As Button
End Class

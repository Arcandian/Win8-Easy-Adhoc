<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbSSID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mtbPasswd = New System.Windows.Forms.MaskedTextBox()
        Me.btnSwitchWLAN = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnMinimize = New System.Windows.Forms.Button()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.niMain = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.btnViewPasswd = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Network name (SSID) :"
        '
        'tbSSID
        '
        Me.tbSSID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSSID.Location = New System.Drawing.Point(138, 10)
        Me.tbSSID.Name = "tbSSID"
        Me.tbSSID.Size = New System.Drawing.Size(228, 20)
        Me.tbSSID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Network password :"
        '
        'mtbPasswd
        '
        Me.mtbPasswd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mtbPasswd.Location = New System.Drawing.Point(120, 36)
        Me.mtbPasswd.Name = "mtbPasswd"
        Me.mtbPasswd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.mtbPasswd.Size = New System.Drawing.Size(246, 20)
        Me.mtbPasswd.TabIndex = 3
        '
        'btnSwitchWLAN
        '
        Me.btnSwitchWLAN.Location = New System.Drawing.Point(12, 62)
        Me.btnSwitchWLAN.Name = "btnSwitchWLAN"
        Me.btnSwitchWLAN.Size = New System.Drawing.Size(354, 23)
        Me.btnSwitchWLAN.TabIndex = 4
        Me.btnSwitchWLAN.Text = "Start adhoc WLAN"
        Me.btnSwitchWLAN.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(353, 100)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(3, 16)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(347, 81)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "WLAN is not started !"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnMinimize
        '
        Me.btnMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMinimize.Location = New System.Drawing.Point(12, 207)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(75, 23)
        Me.btnMinimize.TabIndex = 6
        Me.btnMinimize.Text = "Minimize"
        Me.btnMinimize.UseVisualStyleBackColor = True
        '
        'btnQuit
        '
        Me.btnQuit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnQuit.Location = New System.Drawing.Point(291, 207)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(75, 23)
        Me.btnQuit.TabIndex = 9
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'niMain
        '
        Me.niMain.Icon = CType(resources.GetObject("niMain.Icon"), System.Drawing.Icon)
        Me.niMain.Text = "Win8 Easy Adhoc"
        Me.niMain.Visible = True
        '
        'btnViewPasswd
        '
        Me.btnViewPasswd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnViewPasswd.Location = New System.Drawing.Point(93, 207)
        Me.btnViewPasswd.Name = "btnViewPasswd"
        Me.btnViewPasswd.Size = New System.Drawing.Size(92, 23)
        Me.btnViewPasswd.TabIndex = 7
        Me.btnViewPasswd.Text = "View Password"
        Me.btnViewPasswd.UseVisualStyleBackColor = True
        '
        'btnAbout
        '
        Me.btnAbout.Location = New System.Drawing.Point(210, 207)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(75, 23)
        Me.btnAbout.TabIndex = 8
        Me.btnAbout.Text = "About..."
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'mainForm
        '
        Me.AcceptButton = Me.btnSwitchWLAN
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnQuit
        Me.ClientSize = New System.Drawing.Size(377, 242)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnViewPasswd)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnMinimize)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSwitchWLAN)
        Me.Controls.Add(Me.mtbPasswd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbSSID)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "mainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbSSID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents mtbPasswd As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnSwitchWLAN As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnMinimize As System.Windows.Forms.Button
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents niMain As System.Windows.Forms.NotifyIcon
    Friend WithEvents btnViewPasswd As System.Windows.Forms.Button
    Friend WithEvents btnAbout As System.Windows.Forms.Button

End Class

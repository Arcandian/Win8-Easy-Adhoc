Imports System.Diagnostics.Process

Public Class mainForm

    ' Only used for debug. "aps" is used for show consoles during wlan creation process, 
    ' and "waitc" is used for consoles "wait" actions users.
    Private aps As AppWinStyle = AppWinStyle.Hide
    Private waitc As Boolean = False

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form name with assembly informations
        Me.Text = My.Application.Info.AssemblyName & " v. " & My.Application.Info.Version.Major.ToString & "." _
            & My.Application.Info.Version.Minor.ToString & My.Application.Info.Version.Build.ToString
        ' Set notify icon to invisible
        niMain.Visible = False
    End Sub

    Private Sub btnSwitchWLAN_Click(sender As Object, e As EventArgs) Handles btnSwitchWLAN.Click

        ' Check if the text of the button is in start position
        If btnSwitchWLAN.Text = "Start adhoc WLAN" Then
            ' Check if the TextBox of the network name is empty
            If tbSSID.Text <> Nothing Then
                ' Check if the TetxBox of the network password is empty. It do contains 8 characters.
                If mtbPasswd.Text.Length() >= 8 Then
                    ' If all is OK, try to connect
                    Try
                        ' Start a console to execute a command which allow a new hosted network with,
                        ' in parameters, the name set in his TextBox, and same for the password
                        Shell("cmd.exe /K netsh wlan set hostednetwork mode=allow ssid=" + tbSSID.Text + _
                              " key=" + mtbPasswd.Text + " keyUsage=temporary", aps, waitc)
                        ' Start an other console to execute a command which really start the hosted network
                        Shell("cmd.exe /K netsh wlan start hostednetwork", aps, waitc)
                        ' Set a green label with a visual text indicates WLAN status
                        lblStatus.ForeColor = Color.Green
                        lblStatus.Text = "WLAN '" & tbSSID.Text & "' is started !"
                        ' Set a new text in the Button indicates he can stop wlan creation process
                        btnSwitchWLAN.Text = "Stop " & tbSSID.Text & " adhoc WLAN"
                        ' Set TextBoxes in ReadOnly state
                        tbSSID.ReadOnly = True
                        mtbPasswd.ReadOnly = True

                        ' Raise an general Exception if a problem is detected during wlan creation process
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                        MessageBox.Show("Error during WLAN creation process !", "Error", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    ' If the password is null or empty, a message is showed for the user
                    MessageBox.Show("Enter a password for WLAN network. It do contains 8 chars minimum.", "Warning", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                ' If the name of the network is empty, a is showed for the user
                MessageBox.Show("Enter a name for WLAN network.", "Warning", _
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            ' If the Button text equals Stop action...
        ElseIf btnSwitchWLAN.Text = "Stop " & tbSSID.Text & " adhoc WLAN" Then
            ' Execute a command which stop the hosted network
            Shell("cmd.exe /C netsh wlan stop hostednetwork", AppWinStyle.Hide)
            'Shell("cmd.exe /C netsh wlan set hostednetwork mode=disallow ssid=" + tbSSID.Text + _
            '      " key=" + mtbPasswd.Text + " keyUsage=temporary", aps, waitc)

            ' Change the label status in Orange color and notify if the WLAN is stopped
            lblStatus.ForeColor = Color.Orange
            lblStatus.Text = "WLAN '" & tbSSID.Text & "' is stopped."
            ' Re-set Text button to start action
            btnSwitchWLAN.Text = "Start adhoc WLAN"
            ' Deactivate ReadOnly for Textboxes
            tbSSID.ReadOnly = False
            mtbPasswd.ReadOnly = False
        End If
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        ' Dispose this application
        Me.Dispose()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        ' Set form to invisible
        Me.ShowInTaskbar = False
        ' Same for TaskBar
        Me.Visible = False
        ' Show in notification tray
        niMain.Visible = True
    End Sub

    Private Sub niMain_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles niMain.MouseDoubleClick
        ' Set from to visible in TaskBar
        Me.ShowInTaskbar = True
        ' Set form to visible
        Me.Visible = True
        ' Hide icon in system tray
        niMain.Visible = False
    End Sub

    Private Sub btnViewPasswd_Click(sender As Object, e As EventArgs) Handles btnViewPasswd.Click
        ' Show password if is set
        If mtbPasswd.Text <> Nothing Then
            MessageBox.Show("Password is : " & mtbPasswd.Text, "Information", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Password is not set !", "Warning", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        ' Show About form
        frmAbout.ShowDialog()
    End Sub

    Private Sub mainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'Shell("cmd.exe /C netsh wlan set hostednetwork mode=disallow ssid=" + tbSSID.Text + _
        '          " key=" + mtbPasswd.Text + " keyUsage=temporary", aps, waitc)
        ' Stop hosted network if this app is closed
        Shell("cmd.exe /C netsh wlan stop hostednetwork", aps, waitc)
    End Sub
End Class
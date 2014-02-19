Imports System.Diagnostics.Process

Public Class mainForm

    ' Only used for debug. "cperm" is used for show consoles during wlan creation process, 
    ' "cargs" is used for command arguments
    Private cperm As Boolean = False
    Private cargs As String = ""
    Private startWLAN As String = "netsh wlan start hostednetwork"
    Private stopWLAN As String = "netsh wlan stop hostednetwork"
    Private unsetWLANInfos As String = "netsh wlan set hostednetwork mode=disallow ssid= key="

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set form name with assembly informations
        Me.Text = My.Application.Info.AssemblyName & " v. " & My.Application.Info.Version.Major.ToString & "." _
            & My.Application.Info.Version.Minor.ToString & My.Application.Info.Version.Build.ToString + "a"

        ' Set notify icon to invisible
        niMain.Visible = False

        ' If an existing hosted network is present, he's deactivate
        runCmd(stopWLAN, cargs, cperm)

    End Sub

    Private Sub btnSwitchWLAN_Click(sender As Object, e As EventArgs) Handles btnSwitchWLAN.Click

        ' Declares a String contains wlan setter informations
        Dim setWLANInfos As String = "netsh wlan set hostednetwork mode=allow ssid=" + tbSSID.Text + " key=" + mtbPasswd.Text

        ' Check if the text of the button is in start position
        If btnSwitchWLAN.Text = "Start adhoc WLAN" Then

            ' Check if the TextBox of the network name is empty
            If tbSSID.Text <> Nothing Then

                ' Check if the TetxBox of the network password is empty. It do contains 8 characters.
                If mtbPasswd.Text.Length() >= 8 Then
                    ' If all is OK, try to connect :
                    ' Start a console to execute a command which allow a new hosted network with,
                    ' in parameters, the name set in his TextBox, and same for the password
                    runCmd(setWLANInfos, cargs, cperm)

                    ' Start an other console to execute a command which start the hosted network
                    runCmd(startWLAN, cargs, cperm)
                    ' Stop and restart same command for reload properly WLAN informations
                    runCmd(stopWLAN, cargs, cperm)
                    runCmd(startWLAN, cargs, cperm)

                    ' Set a green label with a visual text indicates WLAN status
                    lblStatus.ForeColor = Color.Green
                    lblStatus.Text = "WLAN '" & tbSSID.Text & "' is started !"

                    ' Set a new text in the Button indicates he can stop wlan creation process
                    btnSwitchWLAN.Text = "Stop '" & tbSSID.Text & "' adhoc WLAN"

                    ' Set TextBoxes in ReadOnly state
                    tbSSID.ReadOnly = True
                    mtbPasswd.ReadOnly = True

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
        ElseIf btnSwitchWLAN.Text = "Stop '" & tbSSID.Text & "' adhoc WLAN" Then

            ' Execute a command which stop the hosted network
            runCmd(stopWLAN, cargs, cperm)

            ' Unset WLAN informations
            runCmd(unsetWLANInfos, cargs, cperm)

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

        ' Stop hosted network & unset WLAN infos if this app is closed
        runCmd(stopWLAN, cargs, cperm)
        runCmd(unsetWLANInfos, cargs, cperm)

    End Sub

    ''' <summary>
    ''' This command handles the execution of a cmd with specified strings in parameters
    ''' </summary>
    ''' <param name="command">Command executed by cmd.exe</param>
    ''' <param name="args">Arguments used by the command</param>
    ''' <param name="ispermanent">If True, cmd.exe stay showed on the screen</param>
    ''' <remarks>Inspirated by this topic : http://stackoverflow.com/questions/10261521/how-to-run-dos-cmd-command-prompt-commands-from-vb-net</remarks>
    Private Sub runCmd(command As String, args As String, ispermanent As Boolean)

        ' Create a new Process
        Dim p As Process = New Process()

        ' Create a ProcessStartInfo for 'p'
        Dim pi As ProcessStartInfo = New ProcessStartInfo()

        ' Set arguments for 'pi'
        pi.Arguments = " " + If(ispermanent = True, "/K", "/C") + " " + command + " " + args

        ' Set executable filename for executes commands
        pi.FileName = "cmd.exe"

        ' Raise a MessageBox if an error has occured
        pi.ErrorDialog = True

        ' Hide or not cmd.exe window
        pi.WindowStyle = ProcessWindowStyle.Hidden

        ' Add 'pi' infos to 'p' Process
        p.StartInfo = pi

        ' Start 'p'
        p.Start()

    End Sub

End Class
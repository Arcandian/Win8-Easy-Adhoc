Imports System.Diagnostics.Process

Public Class mainForm

    Private aps As AppWinStyle = AppWinStyle.Hide
    Private waitc As Boolean = False

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.AssemblyName & " v. " & My.Application.Info.Version.Major.ToString & "." _
            & My.Application.Info.Version.Minor.ToString & My.Application.Info.Version.Build.ToString
        niMain.Visible = False
    End Sub

    Private Sub btnSwitchWLAN_Click(sender As Object, e As EventArgs) Handles btnSwitchWLAN.Click

        If btnSwitchWLAN.Text = "Start adhoc WLAN" Then
            If tbSSID.Text <> Nothing Then
                If mtbPasswd.Text.Length() >= 8 Then
                    Try
                        Shell("cmd.exe /K netsh wlan set hostednetwork mode=allow ssid=" + tbSSID.Text + _
                              " key=" + mtbPasswd.Text + " keyUsage=temporary", aps, waitc)
                        Shell("cmd.exe /K netsh wlan start hostednetwork", aps, waitc)
                        lblStatus.ForeColor = Color.Green
                        lblStatus.Text = "WLAN '" & tbSSID.Text & "' is started !"
                        btnSwitchWLAN.Text = "Stop adhoc WLAN"
                        tbSSID.ReadOnly = True
                        mtbPasswd.ReadOnly = True
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                        MessageBox.Show("Error during WLAN creation process !", "Error", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    MessageBox.Show("Enter a password for WLAN network. It do contains 8 chars minimum.", "Warning", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Enter a name for WLAN network.", "Warning", _
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        ElseIf btnSwitchWLAN.Text = "Stop " & tbSSID.Text & " adhoc WLAN" Then
            Shell("cmd.exe /C netsh wlan stop hostednetwork", AppWinStyle.Hide)
            Shell("cmd.exe /C netsh wlan set hostednetwork mode=disallow ssid=" + tbSSID.Text + _
                  " key=" + mtbPasswd.Text + " keyUsage=temporary", aps, waitc)
            lblStatus.ForeColor = Color.Orange
            lblStatus.Text = "WLAN '" & tbSSID.Text & "' is stopped."
            btnSwitchWLAN.Text = "Start adhoc WLAN"
            tbSSID.ReadOnly = False
            mtbPasswd.ReadOnly = False
        End If
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Me.Dispose()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.ShowInTaskbar = False
        Me.Visible = False
        niMain.Visible = True

    End Sub

    Private Sub niMain_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles niMain.MouseDoubleClick
        Me.ShowInTaskbar = True
        Me.Visible = True
        niMain.Visible = False
    End Sub

    Private Sub btnViewPasswd_Click(sender As Object, e As EventArgs) Handles btnViewPasswd.Click
        If mtbPasswd.Text <> Nothing Then
            MessageBox.Show("Password is : " & mtbPasswd.Text, "Information", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Password is not set !", "Warning", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub mainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'Shell("cmd.exe /C netsh wlan set hostednetwork mode=disallow ssid=" + tbSSID.Text + _
        '          " key=" + mtbPasswd.Text + " keyUsage=temporary", aps, waitc)
        Shell("cmd.exe /K netsh wlan stop hostednetwork", aps, waitc)
    End Sub
End Class
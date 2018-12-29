Imports System.ComponentModel
Imports System.IO
Imports System.Windows.SystemParameters
Public Class LoginForm
    Public Token                    'discord bot token ID
    Public ID                       'the bot's user ID (for added security)
    ReadOnly config As String = Directory.GetParent(Directory.GetParent(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData).FullName).FullName & Path.DirectorySeparatorChar & "bot.config"
    Dim animTick As Integer         'ticks for the animation
    Dim ready As Boolean = True     'ready to close (lets the animation run)
    Dim save As Boolean = My.Settings.saveTI
    Dim reader As StreamReader
    Dim writer As StreamWriter
    'On load setup
    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbFull.BackColor = Color.FromArgb(WindowGlassColor.R, WindowGlassColor.G, WindowGlassColor.B)
        pbImg.BackColor = Color.FromArgb(WindowGlassColor.R, WindowGlassColor.G, WindowGlassColor.B)
        If Environment.OSVersion.ToString.ToLower.Contains("unix") Then
            animate.Stop()
        End If
        If File.Exists(config) Then
            reader = My.Computer.FileSystem.OpenTextFileReader(config)
            Try
                ID = reader.ReadLine
                UsernameTextBox.Text = ID
                Token = reader.ReadLine
                PasswordTextBox.Text = Token
                Dim auto As String = reader.ReadLine
                If auto = Nothing Then
                    auto = "No thank you"
                End If
                If ID <> Nothing And Token <> Nothing And auto.StartsWith("T") Or ID <> Nothing And Token <> Nothing And auto.StartsWith("Y") Or ID <> Nothing And Token <> Nothing And auto.StartsWith("t") Or ID <> Nothing And Token <> Nothing And auto.StartsWith("y") Then
                    OK_Click()
                End If
            Catch ex As Exception
                dialog.box("Error loading config", "Load error", vbOK, ex.ToString)
            End Try
            reader.Close()
        Else
            Try
                File.Create(config)
                Threading.Thread.Sleep(2000)
                writer = My.Computer.FileSystem.OpenTextFileWriter(config, True)
                writer.WriteLine("")
                writer.WriteLine("")
                writer.WriteLine("No, thank you. I do not wish to automatically sign in with these credentials")
                writer.Close()
            Catch
            End Try
        End If
        If ID = Nothing Or Token = Nothing Then
            UsernameTextBox.Text = My.Settings.id
            PasswordTextBox.Text = My.Settings.token
        End If
        chkSave.Checked = save
        If Environment.OSVersion.ToString.ToLower.Contains("nt") Then
            Size = New Size(210, 231)
            Location = New Point(My.Computer.Screen.WorkingArea.Width / 2 - Width / 2, My.Computer.Screen.WorkingArea.Height / 2 - Height / 2)
            pbFull.Location = New Point(0, 0)
            pbFull.BringToFront()
        End If
        Tooltip.SetToolTip(UsernameTextBox, "Seemingly random, 18 numeric characters, always numeric" & vbNewLine & "The bot ID is not entirely required, but used as an extra level of security")
        Tooltip.SetToolTip(PasswordTextBox, "Seemingly random, 59 alphanumeric characters, always a '.' at character 25 and 32" & vbNewLine & "The token is more of a ""Password"" for the bot")
        If Ping("discord.gg") = False Then
            Enabled = False
            dialog.box("Lost network connection," & vbNewLine & "Please check connection and try again", "Connection issue", vbOK, "ping discord returned false" & vbNewLine & "internet.connected returned false")
        End If
    End Sub
    'when entries are made
    Private Sub UsernameTextBox_TextChanged(sender As Object, e As EventArgs) Handles UsernameTextBox.TextChanged, PasswordTextBox.TextChanged
        'Do they follow the Discord Token or ID rules (I'll specify them in a .md file) used to be here (moved)
        Token = PasswordTextBox.Text
        'ID = UsernameTextBox.Text
    End Sub
    'link to discord developper console (you can obtain a bot id and token here)
    Private Sub lblReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblReset.LinkClicked
        Process.Start("https://discordapp.com/developers/applications")
    End Sub
    'when failed (called from other form
    Public Sub failed(e As Exception)
        dialog.box("Login failed, check credentials", "Login Failed", vbOK, e.ToString)
        Enabled = True
    End Sub
    'pings an indicated server
    Public Function Ping(e As String) As Boolean
        Try
            Return My.Computer.Network.Ping(e)
        Catch
            Return False
        End Try
    End Function
    'Open animation
    Private Sub animate_Tick(sender As Object, e As EventArgs) Handles animate.Tick
        If Environment.OSVersion.ToString.ToLower.Contains("nt") Then
            animTick += 1
            If animTick > 20 Then
                If Width <= 420 Then
                    Width += 16
                    Location = New Point(My.Computer.Screen.WorkingArea.Width / 2 - Width / 2, My.Computer.Screen.WorkingArea.Height / 2 - Height / 2)
                ElseIf Width > 420 Then
                    Width = 420
                End If
                If pbFull.Width > pbImg.Width Then
                    pbFull.Width -= 8
                Else
                    pbFull.Visible = False
                End If
                If pbFull.Visible = False And Width = 420 Then
                    animate.Stop()
                End If
            End If
        End If
    End Sub
    'close animation
    Private Sub etamina_Tick(sender As Object, e As EventArgs) Handles etamina.Tick
        If Environment.OSVersion.ToString.ToLower.Contains("nt") Then
            animTick -= 1
            If Width > 210 Then
                Width -= 16
                Location = New Point(My.Computer.Screen.WorkingArea.Width / 2 - Width / 2, My.Computer.Screen.WorkingArea.Height / 2 - Height / 2)
            ElseIf Width < 210 Then
                Width = 210
            End If
            If pbFull.Width >= 194 Then
                pbFull.Width = 194
            ElseIf pbFull.Width < pbImg.Width Then
                pbFull.Visible = False
                pbFull.Width += 8
            ElseIf pbFull.Width >= pbImg.Width Then
                pbFull.Visible = True
                pbFull.Width += 8
            End If
            If pbFull.Width = 194 And Width = 210 Then
                If animTick = 0 Then
                    ready = False
                    Close()
                    etamina.Stop()
                End If
            End If
        Else
            ready = False
            Close()
        End If
    End Sub
    'OK
    Private Sub OK_Click() Handles OK.Click
        'If UsernameTextBox.Text = "" Or PasswordTextBox.Text = "" Or PasswordTextBox.TextLength <> 59 Or UsernameTextBox.Text.Length <> 18 Or PasswordTextBox.Text.IndexOf(".") <> 24 Or PasswordTextBox.Text.LastIndexOf(".") <> 31 Or IsNumeric(UsernameTextBox.Text) = False Then
        'dialog.box("Token or ID not valid", "Login Failed", vbOK)
        'Else
        Enabled = False
            main.Show()
        'End If
    End Sub
    'Cancel
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
    'close

    Private Sub login_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If ready Then
            If save Then
                My.Settings.id = UsernameTextBox.Text
                My.Settings.token = PasswordTextBox.Text
            Else
                My.Settings.id = Nothing
                My.Settings.token = Nothing
            End If
            My.Settings.saveTI = save
            My.Settings.Save()
            e.Cancel = ready
            etamina.Start()
        Else
            e.Cancel = ready
        End If
    End Sub

    Private Sub chkSave_CheckedChanged(sender As Object, e As EventArgs) Handles chkSave.CheckedChanged
        save = chkSave.Checked
    End Sub
End Class

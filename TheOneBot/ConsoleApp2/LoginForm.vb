Imports System.ComponentModel

Public Class LoginForm
    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        chkSave.Checked = My.Settings.saveT
        token.Text = My.Settings.saved
        mark()
        Threading.Thread.Sleep(500)
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("Authenticating, please continue in external window")
        Threading.Thread.Sleep(1000)

    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If chkSave.Checked Then
            My.Settings.saveT = True
            My.Settings.saved = token.Text
        Else
            My.Settings.saveT = False
            My.Settings.saved = Nothing
        End If
        My.Settings.Save()
        TheOneBotCLI.token = token.Text
        TheOneBotCLI.log = True
        attemptConnect()
        LogCheck.Start()
        Hide()
    End Sub

    Private Sub LogCheck_Tick(sender As Object, e As EventArgs) Handles LogCheck.Tick
        If TheOneBotCLI.log = False Then
            Show()
            LogCheck.Stop()
        End If
    End Sub

    Private Sub Cancel_Click_1(sender As Object, e As EventArgs) Handles Cancel.Click
        Environment.Exit(0)
    End Sub

End Class

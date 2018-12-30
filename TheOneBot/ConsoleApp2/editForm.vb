Imports System.ComponentModel

Public Class EditForm
    Private Sub EditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If editorPurpose = 0 Then
            Close()
        ElseIf editorPurpose = 1 Then
            txtBox.Text = My.Settings.help
            Text = "TheOneBot Conf GUI - Help"
        End If
    End Sub

    Private Sub EditForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If editorPurpose = 1 Then
            My.Settings.help = txtBox.Text
        End If
        Console.WriteLine("Saving config")
        My.Settings.Save()
        Console.WriteLine("Config saved")
    End Sub
End Class
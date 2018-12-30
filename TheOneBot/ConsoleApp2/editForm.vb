Imports System.ComponentModel
'A multipurpose limited text editor for making direct changes to application settings
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
        Console.WriteLine("Saving config")
        If editorPurpose = 1 Then
            My.Settings.help = txtBox.Text
        End If
        My.Settings.Save()
        Console.WriteLine("Config saved")
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Console.WriteLine("Saving config")
        If editorPurpose = 1 Then
            My.Settings.help = txtBox.Text
            Text = "TheOneBot Conf GUI - Help"
        End If
        My.Settings.Save()
        Console.WriteLine("Config saved")
    End Sub

    Private Sub txtBox_TextChanged(sender As Object, e As EventArgs) Handles txtBox.TextChanged
        If Text.EndsWith("*") = False Then
            Text = Text & "*"
        End If
    End Sub

    Private Sub RevertChangesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RevertChangesToolStripMenuItem.Click
        Console.WriteLine("Reloading config")
        If editorPurpose = 1 Then
            txtBox.Text = My.Settings.help
            Text = "TheOneBot Conf GUI - Help"
        End If
        Console.WriteLine("Config reloaded")
    End Sub
End Class
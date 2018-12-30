Imports System.ComponentModel
'A multipurpose limited text editor for making direct changes to application settings
Public Class EditForm

    'Check what Conf GUI's purpose is in this instance
    Private Sub EditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If editorPurpose = 0 Then
            Close()
        ElseIf editorPurpose = 1 Then
            txtBox.Text = My.Settings.help
            Text = "TheOneBot Conf GUI - Help"
        End If
    End Sub

    'Automatic save on exit
    Private Sub EditForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Console.WriteLine("Saving config")
        If editorPurpose = 1 Then
            My.Settings.help = txtBox.Text
        End If
        My.Settings.Save()
        Console.WriteLine("Config saved")
    End Sub

    'File > save (saves config when requested)
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Console.WriteLine("Saving config")
        If editorPurpose = 1 Then
            My.Settings.help = txtBox.Text
            Text = "TheOneBot Conf GUI - Help"
        End If
        My.Settings.Save()
        Console.WriteLine("Config saved")
    End Sub

    'Mark title bar with an asterix (to indicate work is not saved)
    Private Sub txtBox_TextChanged(sender As Object, e As EventArgs) Handles txtBox.TextChanged
        If Text.EndsWith("*") = False Then
            Text = Text & "*"
        End If
    End Sub

    'Reload changes from last save
    Private Sub RevertChangesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RevertChangesToolStripMenuItem.Click
        Console.WriteLine("Reloading config")
        If editorPurpose = 1 Then
            txtBox.Text = My.Settings.help
            Text = "TheOneBot Conf GUI - Help"
        End If
        Console.WriteLine("Config reloaded")
    End Sub
End Class
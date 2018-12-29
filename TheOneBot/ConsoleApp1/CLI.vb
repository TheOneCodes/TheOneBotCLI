Imports System.Windows.Forms.Application
Module CLI
    Dim wake As String = My.Settings.wake
    Sub Main()
        Console.WriteLine("TheOneBot [Version 0.1]")
        Console.WriteLine("(c) 2018 TheOneCode")
        Console.WriteLine()
        Dim logon As New ClientSecret
        logon.Show()

        Do
            Console.ForegroundColor = ConsoleColor.Green
            Console.Write(ExecutablePath)
            Console.ResetColor()
            Console.Write(wake)
            Console.ReadLine()
        Loop
    End Sub

End Module

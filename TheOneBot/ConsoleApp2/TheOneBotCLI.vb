Imports Discord
Imports Discord.WebSocket
Imports System.Net.NetworkInformation
Module TheOneBotCLI
    Dim discord As DiscordSocketClient
    Public token = ""
    Public log As Boolean
    Dim wake As String = ""
    Dim pingCount As Decimal
    Sub mark()
        Console.Title = "TheOneBot CLI"
        Console.WriteLine("TheOneBot [Version 0.1]")
        Console.WriteLine("(c) 2018 TheOneCode")
        Console.WriteLine()
        Console.WriteLine("Type ""help"" for help")
        Console.WriteLine()
    End Sub
    Sub arm()
        Console.Title = "TheOneBot CLI"
        Console.ForegroundColor = ConsoleColor.Green
        Console.Write(Environment.UserName & "@" & Environment.UserDomainName)
        Console.ResetColor()
        Console.Write(":")
        Console.ForegroundColor = ConsoleColor.Blue
        Console.Write("~")
        Console.ResetColor()
        Console.Write(My.Settings.wake)
    End Sub
    Sub CLI()
        Console.WriteLine("Loading command line interface")
        Threading.Thread.Sleep(1000)
        Console.Clear()
        mark()
        Do
            arm()
            Console.WriteLine(interpret(Console.ReadLine().ToLower, True))
        Loop
    End Sub
    Function interpret(command As String, Optional host As Boolean = False)
        Dim data As String = Nothing
        If command.StartsWith("conf") Then
            If command.StartsWith("conf add question ") Then

            End If
        ElseIf command.StartsWith("ping") Then
            If pingCount = 0 Then
                If command.Length > 4 Then
                    data = command.Replace("ping ", "")
                    Return PingSite(data)
                Else
                    Return PingSite()
                End If
                pingCount += 1
            End If
        ElseIf command.StartsWith("logout") Then
            If host Then
                discord.StopAsync()
                Console.Clear()
                mark()
                Console.WriteLine("Press any key to exit")
                Console.ReadKey()
                exitApp()
                Return "Logged out"
            Else
                Return "(╯°□°）╯︵ ┻━┻ you can not log me out mortal"
            End If
        ElseIf command.Contains("going") Or command.Contains("gonna") Then
            If command.Contains("nword") Or command.Contains("n-word") Or command.Contains("n word") Then
                Return "You cant say that, that's **racist**"
            End If
        ElseIf command.Contains("nigga") Or command.Contains("nibba") Or command.Contains("nibber") Or command.Contains("bibba") Or command.Contains("bibber") Or command.Contains("niger") Or command.Contains("nii") Then
            Return "mrs. Obama, *get down*"
        ElseIf host Then
            Console.ForegroundColor = ConsoleColor.Cyan
            Return "Command " & command & " not available"
            Console.ResetColor()
        End If
    End Function
    Private Function PingSite(Optional address As String = "discord.com")
        If address.Contains("Ping ") = False Then
            Try
                Dim pinger As New Ping
                Dim reply As PingReply = pinger.Send(address)
                Return "Ping to `" & reply.Address.ToString & "` (" & address & ") took `" & reply.RoundtripTime & "`ms"
            Catch ex As Exception

            End Try
        End If
    End Function
    Async Sub attemptConnect()
        Dim good = True
        Dim except As String = ""
        Try
            discord = New DiscordSocketClient(New DiscordSocketConfig)
            AddHandler discord.MessageReceived, AddressOf receiver
            Await discord.LoginAsync(TokenType.Bot, token)
        Catch ex As Exception
            except = ex.ToString
            good = False
        End Try
        If good Then
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("Authentication successful!")
            Await discord.StartAsync
            Console.WriteLine()
            Console.ResetColor()
            CLI()
        Else
            log = False
            Console.WriteLine("Authentication failed " & except)
        End If
    End Sub

    Private Async Function receiver(message As SocketMessage) As Task
        Await message.Channel.SendMessageAsync(interpret(message.Content.ToString.ToLower))
        pingCount = 0
    End Function

    Sub exitApp()
        Environment.Exit(0)
    End Sub
End Module

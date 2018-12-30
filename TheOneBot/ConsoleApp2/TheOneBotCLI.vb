Imports System.Timers
Imports Discord
Imports Discord.WebSocket
Imports System.Net.NetworkInformation
Module TheOneBotCLI
    Private game As Timer = New Timer(8000)
    Dim gameNumber As Boolean = False
    Dim discord As DiscordSocketClient
    Public token = ""
    Public log As Boolean
    Dim wake As String = ""
    Dim pingCount As Decimal
    Public editorPurpose As Single = 0
    Sub mark()
        Console.Title = "TheOneBot CLI"
        Console.WriteLine("TheOneBot [Version 0.1]")
        Console.WriteLine("(c) 2018 TheOneCode")
        Console.WriteLine()
        Console.WriteLine("Type ""help"" for help")
        Console.WriteLine()
    End Sub
    Sub arm()
        wake = My.Settings.wake
        Console.Title = "TheOneBot CLI"
        Console.ForegroundColor = ConsoleColor.Green
        Console.Write(discord.CurrentUser.Username.ToString & "#" & discord.CurrentUser.Discriminator & "@" & Environment.UserDomainName)
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
            Console.ResetColor()
            arm()
            Console.WriteLine(interpret(wake & Console.ReadLine().ToLower, True, True))
        Loop
    End Sub
    Function interpret(command As String, Optional host As Boolean = False, Optional moderator As Boolean = False)
        Dim data As String = Nothing
        If command.StartsWith(wake & "conf") Then
            If command.StartsWith(wake & "conf help") Then
                If host Then
                    Console.WriteLine("Launching editor...")
                    editorPurpose = 1
                    Dim editor As New EditForm
                    Console.WriteLine("Close editor to continue")
                    editor.ShowDialog()
                End If
            End If
        ElseIf command.StartsWith(wake & "help") Then
            Console.ForegroundColor = ConsoleColor.Yellow
            Return My.Settings.help
        ElseIf command.StartsWith(wake & "ping") Then
            If pingCount = 0 Then
                If command.Length > 4 Then
                    data = command.Replace(wake & "ping ", "")
                    Return PingSite(data)
                Else
                    Return PingSite()
                End If
                pingCount += 1
            End If
        ElseIf command.StartsWith(wake & "logout") Then
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
                Return "You cant say that, that's **racist!**"
            End If
        ElseIf command.Contains("nigga") Or command.Contains("nibba") Or command.Contains("nibber") Or command.Contains("bibba") Or command.Contains("bibber") Or command.Contains("niger") Or command.Contains("nii") Then
            My.Settings.nWords += 1
            My.Settings.Save()
            Return "mrs. Obama, *get down*"
        ElseIf host Then
            Console.ForegroundColor = ConsoleColor.Cyan
            Return "Command " & command & " not available"
            Console.ResetColor()
        End If
    End Function
    Private Function PingSite(Optional address As String = "discordapp.com")
        If address.Contains("Ping ") = False Then
            Try
                Dim pinger As New Ping
                Dim reply As PingReply = pinger.Send(address)
                Return "Ping to `" & reply.Address.ToString & "` (" & address & ") took `" & reply.RoundtripTime & "`ms"
            Catch ex As Exception
                Dim pinger As New Ping
                Dim reply As PingReply = pinger.Send("discord.com")
                Return "Ping to `" & reply.Address.ToString & "` (defaulted to discord.com) took `" & reply.RoundtripTime & "`ms"
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
            AddHandler game.Elapsed, AddressOf gameName
            game.AutoReset = True
            game.Enabled = True
            game.Start()
            CLI()
        Else
            log = False
            Console.WriteLine("Authentication failed " & except)
        End If
    End Sub

    Async Sub gameName()
        If gameNumber Then
            Await discord.SetGameAsync("N word count: " & My.Settings.nWords, "https://github.com/TheOneTrueCode/TheOneBot", ActivityType.Playing)
            gameNumber = False
        Else
            Await discord.SetGameAsync("TheOneBot Stable", "https://github.com/TheOneTrueCode/TheOneBot", ActivityType.Playing)
            gameNumber = True
        End If

    End Sub

    Private Async Function receiver(message As SocketMessage) As Task
        If DirectCast(message.Author, SocketGuildUser).GuildPermissions.Administrator Then
            Await message.Channel.SendMessageAsync(interpret(message.Content.ToString.ToLower, False, True))
            Console.WriteLine("admin")
        Else
            Await message.Channel.SendMessageAsync(interpret(message.Content.ToString.ToLower, False, False))
        End If
    End Function

    Sub exitApp()
        Environment.Exit(0)
    End Sub
End Module

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
                    Return "`TheOneBot configuration assistant`" & vbNewLine & "```css" & vbNewLine & wake & "conf help ------------------------------ Returns help dialog on clients, configures main help list on host" & vbNewLine & wake & "conf nword <function>{number} --------- Adjusts TheOneBot's built in nword counter (defaults to host only)" & vbNewLine & vbNewLine & "*Incomplete (more on its way)```"
                Else
                    Return "`TheOneBot configuration assistant`" & vbNewLine & "```css" & vbNewLine & wake & "conf help ------------------------------ Returns help dialog on clients, configures main help list on host" & vbNewLine & wake & "conf nword <function>{number} --------- Adjusts TheOneBot's built in nword counter (defaults to host only)" & vbNewLine & vbNewLine & "*Incomplete (more on its way)```"
                End If
            ElseIf command.StartsWith(wake & "conf nword") And moderator Then
                If command.StartsWith(wake & "conf nword +") Then
                    data = command.Replace(wake & "conf nword +", "")
                    Try
                        My.Settings.nWords += Convert.ToDecimal(data)
                        Return "Added " & data & " nwords!"
                        My.Settings.Save()
                    Catch ex As Exception
                        Return "Failed to add " & data & " nwords to the list"
                    End Try
                ElseIf command.StartsWith(wake & "conf nword -") Then
                    data = command.Replace(wake & "conf nword -", "")
                    Try
                        My.Settings.nWords -= Convert.ToDecimal(data)
                        Return "Removed " & data & " nwords!"
                        My.Settings.Save()
                    Catch ex As Exception
                        Return "Failed to remove " & data & " nwords from the list"
                    End Try
                ElseIf command.StartsWith(wake & "conf nword =") Or command.StartsWith(wake & "conf nword ") Then
                    data = command.Replace(wake & "conf nword ", "")
                    data = data.Replace("=", "")
                    Try
                        My.Settings.nWords = Convert.ToDecimal(data)
                        Return "Set to " & data & " nwords!"
                        My.Settings.Save()
                    Catch ex As Exception
                        Return "Failed to set list to " & data & " nwords"
                    End Try
                Else
                    Return "Improper use of `conf nword`"
                End If
            End If
        ElseIf command.StartsWith(wake & "nword") Then
            Return "Current *nword* count is " & My.Settings.nWords
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
                My.Settings.Save()
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
        ElseIf command.StartsWith("reee") Or command.contains("@everyone") Or command.Contains("@here") Then
            Return "reeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee"
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
        Try
            Dim pinger As New Ping
            Dim reply As PingReply = pinger.Send(address)
            Return "Ping to `" & reply.Address.ToString & "` (" & address & ") took `" & reply.RoundtripTime & "`ms"
        Catch ex As Exception
            Dim pinger As New Ping
            Dim reply As PingReply = pinger.Send("discord.com")
            Return "Ping to `" & reply.Address.ToString & "` (defaulted to discord.com) took `" & reply.RoundtripTime & "`ms"
        End Try
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
        If message.Author.IsBot = False Then
            If DirectCast(message.Author, SocketGuildUser).GuildPermissions.Administrator Then
                Await message.Channel.SendMessageAsync(interpret(message.Content.ToString.ToLower, False, True))
            Else
                Await message.Channel.SendMessageAsync(interpret(message.Content.ToString.ToLower, False, False))
            End If
        End If
    End Function

    Sub exitApp()
        Environment.Exit(0)
    End Sub
End Module

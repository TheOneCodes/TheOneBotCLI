Imports System.Timers
Imports Discord
Imports Discord.WebSocket
Imports System.Net.NetworkInformation
Imports System.IO
Module TheOneBotCLI
    Private game As Timer = New Timer(8000)
    Dim gameNumber As Boolean = False
    Dim discord As DiscordSocketClient
    Public token = ""
    Public log As Boolean
    Dim wake As String = ""
    Public editorPurpose As Single = 0
    Dim rng As Random
    Dim customCommands(100, 1) As String

    'marks the command line
    Sub mark()
        Console.WriteLine("TheOneBot [Version 0.1]")
        Console.WriteLine("(c) 2018 TheOneCode")
        If My.Settings.debug Then
            Console.WriteLine("Debug mode")
            Console.Title = "TheOneBot CLI *Debug mode*"
        Else
            Console.Title = "TheOneBot CLI"
        End If
        Console.WriteLine()
        Console.WriteLine("Type ""help"" for help")
        Console.WriteLine()
    End Sub

    'arms the command line in order to await instructions from the host (server cli)
    Sub arm()
        wake = My.Settings.wake
        If My.Settings.debug Then
            Console.Title = "TheOneBot CLI *Debug mode*"
            Console.ForegroundColor = ConsoleColor.DarkGreen
            Console.Write(discord.CurrentUser.Username.ToString & "#" & discord.CurrentUser.Discriminator)
            Console.ResetColor()
            Console.Write("{debug}")
            Console.ForegroundColor = ConsoleColor.DarkGreen
            Console.Write("@" & Environment.UserDomainName)
        Else
            Console.Title = "TheOneBot CLI"
            Console.ForegroundColor = ConsoleColor.Green
            Console.Write(discord.CurrentUser.Username.ToString & "#" & discord.CurrentUser.Discriminator & "@" & Environment.UserDomainName)
        End If
        Console.ResetColor()
        Console.Write(":")
        Console.ForegroundColor = ConsoleColor.Blue
        Console.Write("~")
        Console.ResetColor()
        Console.Write(My.Settings.wake)
    End Sub

    'The actual Command Line Interface
    Sub CLI()
        loadVariables()
        Console.WriteLine("Loading command line interface")
        Threading.Thread.Sleep(2000)
        Console.Clear()
        mark()
        Threading.Thread.Sleep(500)
        Do
            Console.ResetColor()
            arm()
            Console.WriteLine(interpret(wake & Console.ReadLine().ToLower, True, True, Environment.UserName))
        Loop
    End Sub

    'Interpreter for both internal and external commands (and other fun stuff
    Function interpret(command As String, Optional host As Boolean = False, Optional moderator As Boolean = False, Optional user As String = Nothing, Optional guildID As ULong = Nothing)
        Dim currentWake = Nothing
        If guildID = Nothing Then
            currentWake = wake
        Else
            Dim i As Decimal = 0
            Do
                If customCommands(i, 0) = Nothing Then
                    customCommands(i, 0) = guildID
                    customCommands(i, 1) = wake
                    currentWake = customCommands(i, 1)
                    If My.Settings.debug Then
                        Console.WriteLine()
                        Console.WriteLine("Setup new server id `" & guildID & "` with default wake")
                        arm()
                    End If
                    saveVariables()
                    Exit Do
                Else
                    If customCommands(i, 0) = guildID Then
                        currentWake = customCommands(i, 1)
                        Exit Do
                    End If
                End If
                i += 1
            Loop
        End If
        Dim data As String = Nothing
        If command.StartsWith(currentWake & "conf ") Then
            'CONF
            'The conf command is for seting variables such as the help list
            If command.StartsWith(currentWake & "conf help") Then
                'HELP configures help menu (host) and/or displays the list of commands (client/host)
                If host Then
                    'Only the host can configure the help list
                    Console.WriteLine("Launching editor...")
                    editorPurpose = 1
                    Dim editor As New EditForm
                    Console.WriteLine("Close editor to continue")
                    editor.ShowDialog()
                    Return "`TheOneBot configuration assistant`" & vbNewLine & "```css" & vbNewLine & currentWake & "conf help ------------------------------ Returns help dialog on clients, configures main help list on host" & vbNewLine & currentWake & "conf nword <function>{number} --------- Adjusts TheOneBot's built in nword counter (defaults to host only)" & vbNewLine & vbNewLine & "*Incomplete (more on its way)```"
                Else
                    'Clients get this message (its a list of conf commands)
                    Return "`TheOneBot configuration assistant`" & vbNewLine & "```css" & vbNewLine & currentWake & "conf help ------------------------------ Returns help dialog on clients, configures main help list on host" & vbNewLine & currentWake & "conf nword <function>{number} --------- Adjusts TheOneBot's built in nword counter (defaults to host only)" & vbNewLine & vbNewLine & "*Incomplete (more on its way)```"
                End If
            ElseIf command.StartsWith(currentWake & "conf debug") Then
                If host Then
                    If My.Settings.debug Then
                        My.Settings.debug = False
                        My.Settings.Save()
                        Console.WriteLine("Loading regular mode")
                        Threading.Thread.Sleep(5000)
                        Console.Clear()
                        mark()
                        Return Nothing
                    Else
                        My.Settings.debug = True
                        My.Settings.Save()
                        Console.WriteLine("Loading debug mode")
                        Threading.Thread.Sleep(5000)
                        Console.Clear()
                        mark()
                        Return Nothing
                    End If
                Else
                    Return "`Insufficient permissions`"
                End If
            ElseIf command.StartsWith(currentWake & "conf nword ") Then
                'Configures the NWord counter™
                If moderator Then
                    If command.StartsWith(currentWake & "conf nword +") Then
                        'Adds an NWord offset to the counter
                        data = command.Replace(currentWake & "conf nword +", "")
                        Try
                            My.Settings.nWords += Convert.ToDecimal(data)
                            Return "Added " & data & " nwords!"
                            My.Settings.Save()
                        Catch ex As Exception
                            Return "Failed to add " & data & " nwords to the list"
                        End Try
                    ElseIf command.StartsWith(currentWake & "conf nword -") Then
                        'Subtracts an NWord offset to the counter
                        data = command.Replace(currentWake & "conf nword -", "")
                        Try
                            My.Settings.nWords -= Convert.ToDecimal(data)
                            Return "Removed " & data & " nwords!"
                            My.Settings.Save()
                        Catch ex As Exception
                            Return "Failed to remove " & data & " nwords from the list"
                        End Try
                    ElseIf command.StartsWith(currentWake & "conf nword =") Or command.StartsWith(currentWake & "conf nword ") Then
                        'Sets the NWords
                        data = command.Replace(currentWake & "conf nword ", "")
                        data = data.Replace("=", "")
                        Try
                            My.Settings.nWords = Convert.ToDecimal(data)
                            Return "Set to " & data & " nwords!"
                            My.Settings.Save()
                        Catch ex As Exception
                            Return "Failed to set list to " & data & " nwords"
                        End Try
                    Else
                        'Done wrong
                        Return "Improper use of `" & currentWake & "conf nword`"
                    End If
                Else
                    Return "`Insufficient permissions`"
                End If
            Else
                Return "Improper use of conf, see `" & currentWake & "conf help` for proper usage"
            End If
        ElseIf command.StartsWith(currentWake & "nword") Then
            'NWORD
            'The NWord command lists the NWord count
            Return "Current *nword* count is " & My.Settings.nWords
        ElseIf command.StartsWith(currentWake & "help") Then
            'HELP
            'Returns the help list (that can be edited on the fly)
            Console.ForegroundColor = ConsoleColor.Yellow
            Return My.Settings.help
        ElseIf command.StartsWith(currentWake & "ping") Then
            'PING
            'Returns a milisecond value to specified server (defaults to discord, as thats what the bot will connect to
            If command.Length > 4 Then
                data = command.Replace(currentWake & "ping", "")
                data = data.Replace(" ", "")
                If data = "" Then
                    Return PingSite(host)
                Else
                    Return PingSite(host, data)
                End If
            Else
                Return PingSite()
            End If
        ElseIf command.StartsWith(currentWake & "exit") And host Then
            exitCommand()
        ElseIf command.StartsWith(currentWake & "logout") Then
            'LOGOUT
            'Logs out the bot before exit, this is the proper way to exit as it will tell Discord that it is now Offline
            If host Then
                My.Settings.Save()
                discord.StopAsync()
                Console.Clear()
                mark()
                Return "Logged out, you may now exit with the `exit` command or the Close button"
            Else
                'You can not logout from a client (for obvious reasons) so instead you get a table flip
                Return "(╯°□°）╯︵ ┻━┻ you can not log me out mortal"
            End If
        ElseIf command.StartsWith("ree") Or command.Contains("@everyone") Or command.Contains("@here") Then
            'REEEEEEEEEEEEEEEE
            'Reeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
            Return "reeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee"
        ElseIf command.Contains("going") Or command.Contains("gonna") Or command.Contains("gon") Or command.Contains("make") Or command.Contains("about") Or command.Contains("abot") Then
            'CounterNWord™
            'Designed to prevent NWords as it will kill mrs. Obama
            If command.Contains("nword") Or command.Contains("n-word") Or command.Contains("n word") Then
                Return "You cant say that, that's **racist!**"
            Else
                Return Nothing
            End If
        ElseIf command.Contains("nigga") Or command.Contains("nigor") Or command.Contains("niggor") Or command.Contains("nibba") Or command.Contains("nibber") Or command.Contains("bibba") Or command.Contains("bibber") Or command.Contains("niger") Or command.Contains("nigger") Or command.Contains("nii") Then
            'NWord Counter
            'Adds a number to the count every NWord
            If host = False Then
                If moderator Then
                    My.Settings.nWords += 1
                    My.Settings.Save()
                    If My.Settings.debug Then
                        Console.WriteLine()
                        Console.WriteLine("Nword on `" & guildID & "` from admin user")
                    End If
                    Return "Your an administrator, I expect better of you." & vbNewLine & "*Anyways,* mrs. Obama died, way to go!"
                Else
                    My.Settings.nWords += 1
                    My.Settings.Save()
                    If My.Settings.debug Then
                        Console.WriteLine()
                        Console.WriteLine("Nword on `" & guildID & "` from regular user")
                    End If
                    Return "mrs. Obama, *get down!*"
                End If
            Else
                Return "mrs. Obama, *get down*"
            End If
        ElseIf host Then
            'tells host that they 
            Console.ForegroundColor = ConsoleColor.Cyan
            Return "Command " & command & " not available"
            Console.ResetColor()
        Else
            If My.Settings.debug Then
                Console.WriteLine("Message received but not processed")
            End If
        End If
        Return Nothing
    End Function

    'Ping a site
    Private Function PingSite(Optional host As Boolean = False, Optional address As String = "discord.com")
        Dim a = 1
        Dim results As String = Nothing
        Do Until a = 5
            Try
                Dim pinger As New Ping
                Dim reply As PingReply = pinger.Send(address)
                Dim pinged As String = "Ping `" & a & "` to `" & reply.Address.ToString & "` (" & address & ") took `" & reply.RoundtripTime & "`ms"
                If host Then
                    Console.WriteLine(pinged)
                Else
                    If results <> Nothing Then
                        results = results & vbNewLine
                    End If
                    results = results & pinged
                End If
            Catch ex As Exception
                Dim pinged As String = "Ping `" & a & "` to `" & address & "` failed"
                If host Then
                    Console.WriteLine(pinged)
                Else
                    If results <> Nothing Then
                        results = results & vbNewLine
                    End If
                    results = results & pinged
                End If
            End Try
            a += 1
        Loop
        Return results
    End Function

    'Try to connect to discord
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
            AddHandler AppDomain.CurrentDomain.ProcessExit, AddressOf exitApp
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
            Await discord.SetGameAsync("TheOneBot (Testing mode)", "https://github.com/TheOneTrueCode/TheOneBot", ActivityType.Playing)
            gameNumber = True
        End If
    End Sub

    Private Async Function receiver(message As SocketMessage) As Task
        If message.Author.IsBot = False Then
            Dim mention As Boolean = False
            Dim Channel As SocketGuildChannel = message.Channel
            Dim Guild As SocketGuild = Channel.Guild
            If DirectCast(message.Author, SocketGuildUser).GuildPermissions.Administrator Then
                Await message.Channel.SendMessageAsync(interpret(message.Content.ToString.Replace(":", "").ToLower, False, True, "<@" & message.Author.ToString & ">", Guild.Id))
            Else
                Await message.Channel.SendMessageAsync(interpret(message.Content.ToString.Replace(":", "").ToLower, False, False, "<@" & message.Author.ToString & ">", Guild.Id))
            End If
        End If
    End Function

    Public Sub loadVariables()
        If My.Settings.initialSetup Then
            If My.Settings.debug Then
                Console.WriteLine("Press any key to load:")
                Console.ForegroundColor = ConsoleColor.Yellow
                Console.WriteLine(My.Settings.customCommands)
                Console.ReadKey()
            End If
            Try
                Dim variableLoader As New StringReader(My.Settings.customCommands)
                Dim read As String = Nothing
                Dim varNum As Integer = 0
                If My.Settings.debug Then
                    Console.WriteLine("Attempting to load variables")
                End If
                variableLoader.ReadLine()
                Do
                    read = variableLoader.ReadLine
                    If read = "[end]" Then
                        Exit Do
                    ElseIf read.StartsWith("[") And read.EndsWith("]") Then
                        read = read.Replace("[", "")
                        read = read.Replace("]", "")
                        customCommands(varNum, 0) = read
                        read = variableLoader.ReadLine
                        customCommands(varNum, 1) = read
                        If My.Settings.debug Then
                            Console.WriteLine("Loading custom setting for ID " & read)
                        End If
                    End If
                    varNum += 1
                Loop Until read = "[end]"
                variableLoader.Close()
            Catch ex As Exception
                If My.Settings.debug Then
                    Console.WriteLine("An unknown error has occured:")
                    Console.WriteLine(ex)
                    Console.WriteLine("Attempting repair")
                    Console.ResetColor()
                Else
                    Console.WriteLine("An unknown load error has occured, automatically attempting a reset and repair now.")
                    Console.ResetColor()
                End If
                saveVariables()
            End Try
        Else
            My.Settings.customCommands = "[start]" & vbNewLine & "[end]"
            My.Settings.initialSetup = True
            My.Settings.Save()
        End If

    End Sub

    Private Sub saveVariables()
        Dim stringWrite As String = "[start]" & vbNewLine
        Dim count As Integer = 0
        Do
            If customCommands(count, 0) = Nothing Then
                Exit Do
            Else
                stringWrite = stringWrite & "[" & customCommands(count, 0) & "]" & vbNewLine & customCommands(count, 1) & vbNewLine
            End If
            count += 1
        Loop
        stringWrite = stringWrite & "[end]"
        My.Settings.customCommands = stringWrite
        My.Settings.Save()
        If My.Settings.debug Then
            Console.WriteLine()
            Console.WriteLine("Saved server variables")
            arm()
        End If
    End Sub

    Async Sub exitCommand()
        Await discord.StopAsync()
        Environment.Exit(0)
    End Sub

    Async Sub exitApp(sender As Object, e As EventArgs)
        Await discord.StopAsync()
        Environment.Exit(0)
    End Sub
End Module

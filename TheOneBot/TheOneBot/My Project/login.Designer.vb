<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.lblReset = New System.Windows.Forms.LinkLabel()
        Me.pbImg = New System.Windows.Forms.PictureBox()
        Me.Tooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.animate = New System.Windows.Forms.Timer(Me.components)
        Me.pbFull = New System.Windows.Forms.PictureBox()
        Me.etamina = New System.Windows.Forms.Timer(Me.components)
        Me.chkSave = New System.Windows.Forms.CheckBox()
        CType(Me.pbImg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbFull, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UsernameLabel.Location = New System.Drawing.Point(103, 24)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(265, 23)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "Bot ID:"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PasswordLabel.Location = New System.Drawing.Point(103, 81)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(268, 23)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "Bot token:"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UsernameTextBox.Location = New System.Drawing.Point(103, 44)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(289, 22)
        Me.UsernameTextBox.TabIndex = 1
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PasswordTextBox.Location = New System.Drawing.Point(103, 101)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.PasswordTextBox.Size = New System.Drawing.Size(289, 22)
        Me.PasswordTextBox.TabIndex = 3
        '
        'OK
        '
        Me.OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK.BackColor = System.Drawing.SystemColors.Control
        Me.OK.Location = New System.Drawing.Point(186, 161)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(94, 23)
        Me.OK.TabIndex = 4
        Me.OK.Text = "&OK"
        Me.OK.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(289, 161)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 5
        Me.Cancel.Text = "&Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'lblReset
        '
        Me.lblReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblReset.Location = New System.Drawing.Point(100, 161)
        Me.lblReset.Name = "lblReset"
        Me.lblReset.Size = New System.Drawing.Size(73, 23)
        Me.lblReset.TabIndex = 7
        Me.lblReset.TabStop = True
        Me.lblReset.Text = "Get ID/token"
        Me.lblReset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbImg
        '
        Me.pbImg.BackColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.pbImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbImg.Dock = System.Windows.Forms.DockStyle.Left
        Me.pbImg.Image = Global.TheOneBot.My.Resources.Resources.side
        Me.pbImg.Location = New System.Drawing.Point(0, 0)
        Me.pbImg.Name = "pbImg"
        Me.pbImg.Size = New System.Drawing.Size(97, 192)
        Me.pbImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbImg.TabIndex = 6
        Me.pbImg.TabStop = False
        '
        'Tooltip
        '
        Me.Tooltip.ShowAlways = True
        '
        'animate
        '
        Me.animate.Enabled = True
        Me.animate.Interval = 15
        '
        'pbFull
        '
        Me.pbFull.BackColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.pbFull.Image = Global.TheOneBot.My.Resources.Resources.full
        Me.pbFull.Location = New System.Drawing.Point(-97, 0)
        Me.pbFull.Name = "pbFull"
        Me.pbFull.Size = New System.Drawing.Size(192, 192)
        Me.pbFull.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbFull.TabIndex = 8
        Me.pbFull.TabStop = False
        '
        'etamina
        '
        Me.etamina.Interval = 15
        '
        'chkSave
        '
        Me.chkSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSave.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSave.Location = New System.Drawing.Point(298, 132)
        Me.chkSave.Name = "chkSave"
        Me.chkSave.Size = New System.Drawing.Size(94, 23)
        Me.chkSave.TabIndex = 9
        Me.chkSave.Text = "Save:"
        Me.chkSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSave.UseVisualStyleBackColor = True
        '
        'login
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(404, 192)
        Me.Controls.Add(Me.chkSave)
        Me.Controls.Add(Me.pbImg)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.UsernameTextBox)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.lblReset)
        Me.Controls.Add(Me.pbFull)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "login"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.pbImg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbFull, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbImg As PictureBox
    Friend WithEvents lblReset As LinkLabel
    Friend WithEvents Tooltip As ToolTip
    Friend WithEvents animate As Timer
    Friend WithEvents pbFull As PictureBox
    Friend WithEvents etamina As Timer
    Friend WithEvents chkSave As CheckBox
End Class

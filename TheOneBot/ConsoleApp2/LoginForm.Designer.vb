<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")>
Public Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.token = New System.Windows.Forms.TextBox()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.chkSave = New System.Windows.Forms.CheckBox()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.OK = New System.Windows.Forms.Button()
        Me.lnkHelp = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LogCheck = New System.Windows.Forms.Timer(Me.components)
        Me.Panel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PasswordLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordLabel.ForeColor = System.Drawing.Color.White
        Me.PasswordLabel.Location = New System.Drawing.Point(3, 5)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(179, 23)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "Bot Token:"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'token
        '
        Me.token.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.token.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.token.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.token.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.token.ForeColor = System.Drawing.Color.White
        Me.token.Location = New System.Drawing.Point(7, 31)
        Me.token.Margin = New System.Windows.Forms.Padding(10, 4, 4, 4)
        Me.token.Name = "token"
        Me.token.Size = New System.Drawing.Size(278, 22)
        Me.token.TabIndex = 3
        '
        'Panel
        '
        Me.Panel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Panel.Controls.Add(Me.chkSave)
        Me.Panel.Controls.Add(Me.Cancel)
        Me.Panel.Controls.Add(Me.OK)
        Me.Panel.Controls.Add(Me.PasswordLabel)
        Me.Panel.Controls.Add(Me.token)
        Me.Panel.Location = New System.Drawing.Point(95, 84)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(295, 110)
        Me.Panel.TabIndex = 12
        '
        'chkSave
        '
        Me.chkSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSave.AutoSize = True
        Me.chkSave.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSave.ForeColor = System.Drawing.Color.White
        Me.chkSave.Location = New System.Drawing.Point(189, 5)
        Me.chkSave.Name = "chkSave"
        Me.chkSave.Size = New System.Drawing.Size(92, 23)
        Me.chkSave.TabIndex = 8
        Me.chkSave.Text = "Save token"
        Me.chkSave.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.Color.White
        Me.Cancel.Location = New System.Drawing.Point(191, 68)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 30)
        Me.Cancel.TabIndex = 7
        Me.Cancel.Text = "&Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'OK
        '
        Me.OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK.ForeColor = System.Drawing.Color.White
        Me.OK.Location = New System.Drawing.Point(88, 68)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(94, 30)
        Me.OK.TabIndex = 6
        Me.OK.Text = "&OK"
        Me.OK.UseVisualStyleBackColor = False
        '
        'lnkHelp
        '
        Me.lnkHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkHelp.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lnkHelp.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkHelp.LinkColor = System.Drawing.Color.White
        Me.lnkHelp.Location = New System.Drawing.Point(0, 144)
        Me.lnkHelp.Name = "lnkHelp"
        Me.lnkHelp.Padding = New System.Windows.Forms.Padding(14, 4, 4, 4)
        Me.lnkHelp.Size = New System.Drawing.Size(187, 50)
        Me.lnkHelp.TabIndex = 13
        Me.lnkHelp.TabStop = True
        Me.lnkHelp.Text = "Get Bot Token"
        Me.lnkHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.TheOneBotCLI.My.Resources.Resources.discord
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(187, 192)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'LogCheck
        '
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(391, 192)
        Me.Controls.Add(Me.lnkHelp)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Login"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PasswordLabel As Windows.Forms.Label
    Friend WithEvents token As Windows.Forms.TextBox
    Friend WithEvents Panel As Windows.Forms.Panel
    Friend WithEvents Cancel As Windows.Forms.Button
    Friend WithEvents OK As Windows.Forms.Button
    Friend WithEvents lnkHelp As Windows.Forms.LinkLabel
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents LogCheck As Windows.Forms.Timer
    Friend WithEvents chkSave As Windows.Forms.CheckBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditForm
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
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditForm))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.txtBox = New System.Windows.Forms.TextBox()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RevertChangesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowMerge = False
        Me.ToolStrip1.BackgroundImage = Global.TheOneBotCLI.My.Resources.Resources.circle
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(5)
        Me.ToolStrip1.Size = New System.Drawing.Size(800, 36)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.RevertChangesToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(42, 23)
        Me.ToolStripDropDownButton1.Text = "File"
        '
        'txtBox
        '
        Me.txtBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.txtBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBox.Font = New System.Drawing.Font("Lucida Console", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBox.ForeColor = System.Drawing.Color.White
        Me.txtBox.Location = New System.Drawing.Point(0, 36)
        Me.txtBox.Multiline = True
        Me.txtBox.Name = "txtBox"
        Me.txtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBox.Size = New System.Drawing.Size(800, 414)
        Me.txtBox.TabIndex = 1
        Me.txtBox.Text = "You should not be able to see this"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(180, 24)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'RevertChangesToolStripMenuItem
        '
        Me.RevertChangesToolStripMenuItem.Name = "RevertChangesToolStripMenuItem"
        Me.RevertChangesToolStripMenuItem.Size = New System.Drawing.Size(180, 24)
        Me.RevertChangesToolStripMenuItem.Text = "Revert changes"
        '
        'EditForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.txtBox)
        Me.Controls.Add(Me.ToolStrip1)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "EditForm"
        Me.ShowIcon = False
        Me.Text = "TheOneBot Conf GUI"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As Windows.Forms.ToolStripDropDownButton
    Friend WithEvents txtBox As Windows.Forms.TextBox
    Friend WithEvents SaveToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents RevertChangesToolStripMenuItem As Windows.Forms.ToolStripMenuItem
End Class

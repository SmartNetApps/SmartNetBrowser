<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PropertiesForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PropertiesForm))
        Me.FaviconBox = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PageNameLabel = New System.Windows.Forms.Label()
        Me.PageTypeLabel = New System.Windows.Forms.Label()
        Me.PageURLTextBox = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.FaviconBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FaviconBox
        '
        resources.ApplyResources(Me.FaviconBox, "FaviconBox")
        Me.FaviconBox.BackColor = System.Drawing.Color.White
        Me.FaviconBox.Name = "FaviconBox"
        Me.FaviconBox.TabStop = False
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'PageNameLabel
        '
        resources.ApplyResources(Me.PageNameLabel, "PageNameLabel")
        Me.PageNameLabel.BackColor = System.Drawing.Color.White
        Me.PageNameLabel.Name = "PageNameLabel"
        '
        'PageTypeLabel
        '
        resources.ApplyResources(Me.PageTypeLabel, "PageTypeLabel")
        Me.PageTypeLabel.Name = "PageTypeLabel"
        '
        'PageURLTextBox
        '
        resources.ApplyResources(Me.PageURLTextBox, "PageURLTextBox")
        Me.PageURLTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.PageURLTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PageURLTextBox.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.PageURLTextBox.DetectUrls = False
        Me.PageURLTextBox.Name = "PageURLTextBox"
        Me.PageURLTextBox.ReadOnly = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PropertiesForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PageURLTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PageTypeLabel)
        Me.Controls.Add(Me.PageNameLabel)
        Me.Controls.Add(Me.FaviconBox)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PropertiesForm"
        Me.ShowInTaskbar = False
        CType(Me.FaviconBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PageNameLabel As Label
    Friend WithEvents PageTypeLabel As Label
    Friend WithEvents PageURLTextBox As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents FaviconBox As PictureBox
End Class

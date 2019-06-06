<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchTextInPageForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchTextInPageForm))
        Me.TextBox1A = New System.Windows.Forms.TextBox()
        Me.Label1A = New System.Windows.Forms.Label()
        Me.Button3A = New System.Windows.Forms.Button()
        Me.TextBox2A = New System.Windows.Forms.TextBox()
        Me.TextBox3A = New System.Windows.Forms.TextBox()
        Me.ComboBox1A = New System.Windows.Forms.ComboBox()
        Me.Button1A = New System.Windows.Forms.Button()
        Me.Button2A = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1A
        '
        resources.ApplyResources(Me.TextBox1A, "TextBox1A")
        Me.TextBox1A.Name = "TextBox1A"
        '
        'Label1A
        '
        resources.ApplyResources(Me.Label1A, "Label1A")
        Me.Label1A.Name = "Label1A"
        '
        'Button3A
        '
        resources.ApplyResources(Me.Button3A, "Button3A")
        Me.Button3A.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3A.Name = "Button3A"
        Me.Button3A.UseVisualStyleBackColor = True
        '
        'TextBox2A
        '
        resources.ApplyResources(Me.TextBox2A, "TextBox2A")
        Me.TextBox2A.Name = "TextBox2A"
        '
        'TextBox3A
        '
        resources.ApplyResources(Me.TextBox3A, "TextBox3A")
        Me.TextBox3A.Name = "TextBox3A"
        '
        'ComboBox1A
        '
        resources.ApplyResources(Me.ComboBox1A, "ComboBox1A")
        Me.ComboBox1A.FormattingEnabled = True
        Me.ComboBox1A.Name = "ComboBox1A"
        '
        'Button1A
        '
        resources.ApplyResources(Me.Button1A, "Button1A")
        Me.Button1A.Name = "Button1A"
        Me.Button1A.UseVisualStyleBackColor = True
        '
        'Button2A
        '
        resources.ApplyResources(Me.Button2A, "Button2A")
        Me.Button2A.Name = "Button2A"
        Me.Button2A.UseVisualStyleBackColor = True
        '
        'SearchTextInPageForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button3A
        Me.Controls.Add(Me.Button2A)
        Me.Controls.Add(Me.Button1A)
        Me.Controls.Add(Me.ComboBox1A)
        Me.Controls.Add(Me.TextBox3A)
        Me.Controls.Add(Me.TextBox2A)
        Me.Controls.Add(Me.Button3A)
        Me.Controls.Add(Me.Label1A)
        Me.Controls.Add(Me.TextBox1A)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SearchTextInPageForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1A As TextBox
    Friend WithEvents Label1A As Label
    Friend WithEvents Button3A As Button
    Friend WithEvents TextBox2A As TextBox
    Friend WithEvents TextBox3A As TextBox
    Friend WithEvents ComboBox1A As ComboBox
    Friend WithEvents Button1A As Button
    Friend WithEvents Button2A As Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExceptionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExceptionForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MessageTextBox = New System.Windows.Forms.RichTextBox()
        Me.DetailsTextBox = New System.Windows.Forms.RichTextBox()
        Me.IgnoreButton = New System.Windows.Forms.Button()
        Me.ForceCloseButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'MessageTextBox
        '
        Me.MessageTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.MessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MessageTextBox.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.MessageTextBox.DetectUrls = False
        resources.ApplyResources(Me.MessageTextBox, "MessageTextBox")
        Me.MessageTextBox.Name = "MessageTextBox"
        Me.MessageTextBox.ReadOnly = True
        '
        'DetailsTextBox
        '
        Me.DetailsTextBox.BackColor = System.Drawing.SystemColors.HighlightText
        Me.DetailsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DetailsTextBox.DetectUrls = False
        resources.ApplyResources(Me.DetailsTextBox, "DetailsTextBox")
        Me.DetailsTextBox.Name = "DetailsTextBox"
        Me.DetailsTextBox.ReadOnly = True
        '
        'IgnoreButton
        '
        Me.IgnoreButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.IgnoreButton, "IgnoreButton")
        Me.IgnoreButton.Name = "IgnoreButton"
        Me.IgnoreButton.UseVisualStyleBackColor = True
        '
        'ForceCloseButton
        '
        resources.ApplyResources(Me.ForceCloseButton, "ForceCloseButton")
        Me.ForceCloseButton.Name = "ForceCloseButton"
        Me.ForceCloseButton.UseVisualStyleBackColor = True
        '
        'ExceptionForm
        '
        Me.AcceptButton = Me.ForceCloseButton
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.IgnoreButton
        Me.Controls.Add(Me.ForceCloseButton)
        Me.Controls.Add(Me.IgnoreButton)
        Me.Controls.Add(Me.DetailsTextBox)
        Me.Controls.Add(Me.MessageTextBox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ExceptionForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents MessageTextBox As RichTextBox
    Friend WithEvents DetailsTextBox As RichTextBox
    Friend WithEvents IgnoreButton As Button
    Friend WithEvents ForceCloseButton As Button
End Class

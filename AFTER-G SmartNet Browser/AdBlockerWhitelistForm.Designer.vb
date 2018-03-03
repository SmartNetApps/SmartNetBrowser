<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdBlockerWhitelistForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdBlockerWhitelistForm))
        Me.WhitelistRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.AbortButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'WhitelistRichTextBox
        '
        resources.ApplyResources(Me.WhitelistRichTextBox, "WhitelistRichTextBox")
        Me.WhitelistRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.WhitelistRichTextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.WhitelistRichTextBox.DetectUrls = False
        Me.WhitelistRichTextBox.Name = "WhitelistRichTextBox"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'SaveButton
        '
        resources.ApplyResources(Me.SaveButton, "SaveButton")
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'AbortButton
        '
        resources.ApplyResources(Me.AbortButton, "AbortButton")
        Me.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AbortButton.Name = "AbortButton"
        Me.AbortButton.UseVisualStyleBackColor = True
        '
        'AdBlockerWhitelistForm
        '
        Me.AcceptButton = Me.SaveButton
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.AbortButton
        Me.Controls.Add(Me.AbortButton)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.WhitelistRichTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AdBlockerWhitelistForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WhitelistRichTextBox As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SaveButton As Button
    Friend WithEvents AbortButton As Button
End Class

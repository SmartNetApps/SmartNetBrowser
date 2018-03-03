<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateBrowserSettingsSecurityPasswordForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateBrowserSettingsSecurityPasswordForm))
        Me.AbortButton = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NewPasswordTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'AbortButton
        '
        Me.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.AbortButton, "AbortButton")
        Me.AbortButton.Name = "AbortButton"
        Me.AbortButton.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        resources.ApplyResources(Me.OKButton, "OKButton")
        Me.OKButton.Name = "OKButton"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'NewPasswordTextBox
        '
        resources.ApplyResources(Me.NewPasswordTextBox, "NewPasswordTextBox")
        Me.NewPasswordTextBox.Name = "NewPasswordTextBox"
        Me.NewPasswordTextBox.UseSystemPasswordChar = True
        '
        'CreateBrowserSettingsSecurityPasswordForm
        '
        Me.AcceptButton = Me.OKButton
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.AbortButton
        Me.Controls.Add(Me.NewPasswordTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.AbortButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreateBrowserSettingsSecurityPasswordForm"
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AbortButton As Button
    Friend WithEvents OKButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents NewPasswordTextBox As TextBox
End Class

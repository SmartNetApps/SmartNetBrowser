<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FavoritesForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FavoritesForm))
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.GoToFavoriteButton = New System.Windows.Forms.Button()
        Me.DeleteButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        resources.ApplyResources(Me.ListBox1, "ListBox1")
        Me.ListBox1.Name = "ListBox1"
        '
        'GoToFavoriteButton
        '
        resources.ApplyResources(Me.GoToFavoriteButton, "GoToFavoriteButton")
        Me.GoToFavoriteButton.Name = "GoToFavoriteButton"
        Me.GoToFavoriteButton.UseVisualStyleBackColor = True
        '
        'DeleteButton
        '
        resources.ApplyResources(Me.DeleteButton, "DeleteButton")
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.UseVisualStyleBackColor = True
        '
        'FavoritesForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.GoToFavoriteButton)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FavoritesForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents GoToFavoriteButton As Button
    Friend WithEvents DeleteButton As Button
End Class

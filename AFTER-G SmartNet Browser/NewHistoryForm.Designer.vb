<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewHistoryForm
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
        Me.components = New System.ComponentModel.Container()
        Me.HistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BrowserHistoryDataSet = New SmartNet_Browser.BrowserHistoryDataSet()
        Me.Delete = New System.Windows.Forms.Button()
        CType(Me.HistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BrowserHistoryDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HistoryBindingSource
        '
        Me.HistoryBindingSource.DataSource = Me.BrowserHistoryDataSet
        Me.HistoryBindingSource.Position = 0
        '
        'BrowserHistoryDataSet
        '
        Me.BrowserHistoryDataSet.DataSetName = "BrowserHistoryDataSet"
        Me.BrowserHistoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Delete
        '
        Me.Delete.Location = New System.Drawing.Point(96, 77)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(156, 23)
        Me.Delete.TabIndex = 0
        Me.Delete.Text = "Supprimer cette entrée"
        Me.Delete.UseVisualStyleBackColor = True
        '
        'NewHistoryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Delete)
        Me.Name = "NewHistoryForm"
        Me.Text = "NewHistoryForm"
        CType(Me.HistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BrowserHistoryDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents HistoryBindingSource As BindingSource
    Friend WithEvents BrowserHistoryDataSet As BrowserHistoryDataSet
    Friend WithEvents Delete As Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewHistoryForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewHistoryForm))
        Me.HistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BrowserHistoryDataSet = New SmartNet_Browser.BrowserHistoryDataSet()
        Me.PrivacySettingsButton = New System.Windows.Forms.Button()
        Me.BrowseToButton = New System.Windows.Forms.Button()
        Me.DeleteEntryButton = New System.Windows.Forms.Button()
        Me.HistoryDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.HistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BrowserHistoryDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HistoryDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HistoryBindingSource
        '
        Me.HistoryBindingSource.DataMember = "History"
        Me.HistoryBindingSource.DataSource = Me.BrowserHistoryDataSet
        '
        'BrowserHistoryDataSet
        '
        Me.BrowserHistoryDataSet.DataSetName = "BrowserHistoryDataSet"
        Me.BrowserHistoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PrivacySettingsButton
        '
        Me.PrivacySettingsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrivacySettingsButton.Location = New System.Drawing.Point(661, 320)
        Me.PrivacySettingsButton.Name = "PrivacySettingsButton"
        Me.PrivacySettingsButton.Size = New System.Drawing.Size(239, 27)
        Me.PrivacySettingsButton.TabIndex = 1
        Me.PrivacySettingsButton.Text = "Accéder aux paramètres de confidentialité"
        Me.PrivacySettingsButton.UseVisualStyleBackColor = True
        '
        'BrowseToButton
        '
        Me.BrowseToButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BrowseToButton.Location = New System.Drawing.Point(498, 320)
        Me.BrowseToButton.Name = "BrowseToButton"
        Me.BrowseToButton.Size = New System.Drawing.Size(157, 27)
        Me.BrowseToButton.TabIndex = 2
        Me.BrowseToButton.Text = "Naviguer vers cette page"
        Me.BrowseToButton.UseVisualStyleBackColor = True
        '
        'DeleteEntryButton
        '
        Me.DeleteEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeleteEntryButton.Location = New System.Drawing.Point(356, 320)
        Me.DeleteEntryButton.Name = "DeleteEntryButton"
        Me.DeleteEntryButton.Size = New System.Drawing.Size(136, 27)
        Me.DeleteEntryButton.TabIndex = 3
        Me.DeleteEntryButton.Text = "Supprimer cette page"
        Me.DeleteEntryButton.UseVisualStyleBackColor = True
        '
        'HistoryDataGridView
        '
        Me.HistoryDataGridView.AllowUserToAddRows = False
        Me.HistoryDataGridView.AutoGenerateColumns = False
        Me.HistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.HistoryDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.HistoryDataGridView.DataSource = Me.HistoryBindingSource
        Me.HistoryDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.HistoryDataGridView.Name = "HistoryDataGridView"
        Me.HistoryDataGridView.ReadOnly = True
        Me.HistoryDataGridView.Size = New System.Drawing.Size(906, 314)
        Me.HistoryDataGridView.TabIndex = 4
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "PageID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "PageID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "PageName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "PageName"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PageURL"
        Me.DataGridViewTextBoxColumn3.HeaderText = "PageURL"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'NewHistoryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 353)
        Me.Controls.Add(Me.HistoryDataGridView)
        Me.Controls.Add(Me.DeleteEntryButton)
        Me.Controls.Add(Me.BrowseToButton)
        Me.Controls.Add(Me.PrivacySettingsButton)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NewHistoryForm"
        Me.Text = "Historique - SmartNet Browser"
        CType(Me.HistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BrowserHistoryDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HistoryDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents HistoryBindingSource As BindingSource
    Friend WithEvents BrowserHistoryDataSet As BrowserHistoryDataSet
    Friend WithEvents PrivacySettingsButton As Button
    Friend WithEvents BrowseToButton As Button
    Friend WithEvents DeleteEntryButton As Button
    Friend WithEvents HistoryDataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
End Class

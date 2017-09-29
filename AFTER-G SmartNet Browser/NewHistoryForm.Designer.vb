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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PageIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PageNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PageURLDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrivacySettingsButton = New System.Windows.Forms.Button()
        Me.BrowseToButton = New System.Windows.Forms.Button()
        Me.DeleteEntryButton = New System.Windows.Forms.Button()
        CType(Me.HistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BrowserHistoryDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PageIDDataGridViewTextBoxColumn, Me.PageNameDataGridViewTextBoxColumn, Me.PageURLDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.HistoryBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 40
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.Size = New System.Drawing.Size(777, 260)
        Me.DataGridView1.TabIndex = 0
        '
        'PageIDDataGridViewTextBoxColumn
        '
        Me.PageIDDataGridViewTextBoxColumn.DataPropertyName = "PageID"
        Me.PageIDDataGridViewTextBoxColumn.HeaderText = "PageID"
        Me.PageIDDataGridViewTextBoxColumn.Name = "PageIDDataGridViewTextBoxColumn"
        Me.PageIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PageNameDataGridViewTextBoxColumn
        '
        Me.PageNameDataGridViewTextBoxColumn.DataPropertyName = "PageName"
        Me.PageNameDataGridViewTextBoxColumn.HeaderText = "PageName"
        Me.PageNameDataGridViewTextBoxColumn.Name = "PageNameDataGridViewTextBoxColumn"
        Me.PageNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PageURLDataGridViewTextBoxColumn
        '
        Me.PageURLDataGridViewTextBoxColumn.DataPropertyName = "PageURL"
        Me.PageURLDataGridViewTextBoxColumn.HeaderText = "PageURL"
        Me.PageURLDataGridViewTextBoxColumn.Name = "PageURLDataGridViewTextBoxColumn"
        Me.PageURLDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PrivacySettingsButton
        '
        Me.PrivacySettingsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrivacySettingsButton.Location = New System.Drawing.Point(532, 266)
        Me.PrivacySettingsButton.Name = "PrivacySettingsButton"
        Me.PrivacySettingsButton.Size = New System.Drawing.Size(239, 27)
        Me.PrivacySettingsButton.TabIndex = 1
        Me.PrivacySettingsButton.Text = "Accéder aux paramètres de confidentialité"
        Me.PrivacySettingsButton.UseVisualStyleBackColor = True
        '
        'BrowseToButton
        '
        Me.BrowseToButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BrowseToButton.Location = New System.Drawing.Point(369, 266)
        Me.BrowseToButton.Name = "BrowseToButton"
        Me.BrowseToButton.Size = New System.Drawing.Size(157, 27)
        Me.BrowseToButton.TabIndex = 2
        Me.BrowseToButton.Text = "Naviguer vers cette page"
        Me.BrowseToButton.UseVisualStyleBackColor = True
        '
        'DeleteEntryButton
        '
        Me.DeleteEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeleteEntryButton.Location = New System.Drawing.Point(227, 266)
        Me.DeleteEntryButton.Name = "DeleteEntryButton"
        Me.DeleteEntryButton.Size = New System.Drawing.Size(136, 27)
        Me.DeleteEntryButton.TabIndex = 3
        Me.DeleteEntryButton.Text = "Supprimer cette page"
        Me.DeleteEntryButton.UseVisualStyleBackColor = True
        '
        'NewHistoryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 299)
        Me.Controls.Add(Me.DeleteEntryButton)
        Me.Controls.Add(Me.BrowseToButton)
        Me.Controls.Add(Me.PrivacySettingsButton)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NewHistoryForm"
        Me.Text = "Historique - SmartNet Browser"
        CType(Me.HistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BrowserHistoryDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents HistoryBindingSource As BindingSource
    Friend WithEvents BrowserHistoryDataSet As BrowserHistoryDataSet
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PageIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PageNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PageURLDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PrivacySettingsButton As Button
    Friend WithEvents BrowseToButton As Button
    Friend WithEvents DeleteEntryButton As Button
End Class

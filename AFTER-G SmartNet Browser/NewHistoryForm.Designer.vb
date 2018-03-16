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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewHistoryForm))
        Me.HistoryListView = New System.Windows.Forms.ListView()
        Me.TitleColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.URLColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FaviconImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.DeleteButton = New System.Windows.Forms.Button()
        Me.OpenPageButton = New System.Windows.Forms.Button()
        Me.OpenOldHistoryButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'HistoryListView
        '
        Me.HistoryListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HistoryListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.TitleColumnHeader, Me.URLColumnHeader})
        Me.HistoryListView.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoryListView.FullRowSelect = True
        Me.HistoryListView.LargeImageList = Me.FaviconImageList
        Me.HistoryListView.Location = New System.Drawing.Point(0, 0)
        Me.HistoryListView.Name = "HistoryListView"
        Me.HistoryListView.Size = New System.Drawing.Size(800, 434)
        Me.HistoryListView.SmallImageList = Me.FaviconImageList
        Me.HistoryListView.StateImageList = Me.FaviconImageList
        Me.HistoryListView.TabIndex = 1
        Me.HistoryListView.UseCompatibleStateImageBehavior = False
        Me.HistoryListView.View = System.Windows.Forms.View.Details
        '
        'TitleColumnHeader
        '
        Me.TitleColumnHeader.Text = "Titre"
        Me.TitleColumnHeader.Width = 409
        '
        'URLColumnHeader
        '
        Me.URLColumnHeader.Text = "Adresse"
        Me.URLColumnHeader.Width = 345
        '
        'FaviconImageList
        '
        Me.FaviconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.FaviconImageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.FaviconImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'DeleteButton
        '
        Me.DeleteButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeleteButton.Location = New System.Drawing.Point(572, 443)
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(217, 31)
        Me.DeleteButton.TabIndex = 4
        Me.DeleteButton.Text = "Supprimer l'entrée sélectionnée"
        Me.DeleteButton.UseVisualStyleBackColor = True
        '
        'OpenPageButton
        '
        Me.OpenPageButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpenPageButton.Location = New System.Drawing.Point(443, 443)
        Me.OpenPageButton.Name = "OpenPageButton"
        Me.OpenPageButton.Size = New System.Drawing.Size(123, 31)
        Me.OpenPageButton.TabIndex = 3
        Me.OpenPageButton.Text = "Ouvrir la page"
        Me.OpenPageButton.UseVisualStyleBackColor = True
        '
        'OpenOldHistoryButton
        '
        Me.OpenOldHistoryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpenOldHistoryButton.Location = New System.Drawing.Point(263, 443)
        Me.OpenOldHistoryButton.Name = "OpenOldHistoryButton"
        Me.OpenOldHistoryButton.Size = New System.Drawing.Size(174, 31)
        Me.OpenOldHistoryButton.TabIndex = 2
        Me.OpenOldHistoryButton.Text = "Ouvrir l'ancien historique"
        Me.OpenOldHistoryButton.UseVisualStyleBackColor = True
        '
        'NewHistoryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 484)
        Me.Controls.Add(Me.OpenOldHistoryButton)
        Me.Controls.Add(Me.OpenPageButton)
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.HistoryListView)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NewHistoryForm"
        Me.Text = "Nouvel historique (expérimental) - SmartNet Browser"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents HistoryListView As ListView
    Friend WithEvents TitleColumnHeader As ColumnHeader
    Friend WithEvents URLColumnHeader As ColumnHeader
    Friend WithEvents FaviconImageList As ImageList
    Friend WithEvents DeleteButton As Button
    Friend WithEvents OpenPageButton As Button
    Friend WithEvents OpenOldHistoryButton As Button
End Class

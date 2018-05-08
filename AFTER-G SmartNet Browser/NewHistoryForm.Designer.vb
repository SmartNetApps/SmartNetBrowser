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
        resources.ApplyResources(Me.HistoryListView, "HistoryListView")
        Me.HistoryListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.TitleColumnHeader, Me.URLColumnHeader})
        Me.HistoryListView.FullRowSelect = True
        Me.HistoryListView.LargeImageList = Me.FaviconImageList
        Me.HistoryListView.Name = "HistoryListView"
        Me.HistoryListView.SmallImageList = Me.FaviconImageList
        Me.HistoryListView.StateImageList = Me.FaviconImageList
        Me.HistoryListView.UseCompatibleStateImageBehavior = False
        Me.HistoryListView.View = System.Windows.Forms.View.Details
        '
        'TitleColumnHeader
        '
        resources.ApplyResources(Me.TitleColumnHeader, "TitleColumnHeader")
        '
        'URLColumnHeader
        '
        resources.ApplyResources(Me.URLColumnHeader, "URLColumnHeader")
        '
        'FaviconImageList
        '
        Me.FaviconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        resources.ApplyResources(Me.FaviconImageList, "FaviconImageList")
        Me.FaviconImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'DeleteButton
        '
        resources.ApplyResources(Me.DeleteButton, "DeleteButton")
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.UseVisualStyleBackColor = True
        '
        'OpenPageButton
        '
        resources.ApplyResources(Me.OpenPageButton, "OpenPageButton")
        Me.OpenPageButton.Name = "OpenPageButton"
        Me.OpenPageButton.UseVisualStyleBackColor = True
        '
        'OpenOldHistoryButton
        '
        resources.ApplyResources(Me.OpenOldHistoryButton, "OpenOldHistoryButton")
        Me.OpenOldHistoryButton.Name = "OpenOldHistoryButton"
        Me.OpenOldHistoryButton.UseVisualStyleBackColor = True
        '
        'NewHistoryForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.OpenOldHistoryButton)
        Me.Controls.Add(Me.OpenPageButton)
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.HistoryListView)
        Me.Name = "NewHistoryForm"
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

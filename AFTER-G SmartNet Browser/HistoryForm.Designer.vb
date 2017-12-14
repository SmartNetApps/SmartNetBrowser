<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HistoryForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HistoryForm))
        Me.BrowsingHistoryListBox = New System.Windows.Forms.ListBox()
        Me.DeleteAllBrowsingHistoryButton = New System.Windows.Forms.Button()
        Me.RemoveSelectedBrowsingButton = New System.Windows.Forms.Button()
        Me.DisplaySelectedBrowsingButton = New System.Windows.Forms.Button()
        Me.HistoryTabControl = New System.Windows.Forms.TabControl()
        Me.BrowsingHistoryTabPage = New System.Windows.Forms.TabPage()
        Me.SearchHistoryTabPage = New System.Windows.Forms.TabPage()
        Me.OpenSearchResultsButton = New System.Windows.Forms.Button()
        Me.DeleteSelectedSearchButton = New System.Windows.Forms.Button()
        Me.DeleteAllSearchHistoryButton = New System.Windows.Forms.Button()
        Me.SearchHistoryListBox = New System.Windows.Forms.ListBox()
        Me.DownloadHistoryTabPage = New System.Windows.Forms.TabPage()
        Me.DownloadAgainButton = New System.Windows.Forms.Button()
        Me.RemoveSelectedDownload = New System.Windows.Forms.Button()
        Me.DeleteAllDownloadHistoryButton = New System.Windows.Forms.Button()
        Me.DownloadHistoryListBox = New System.Windows.Forms.ListBox()
        Me.HistoryTabControl.SuspendLayout()
        Me.BrowsingHistoryTabPage.SuspendLayout()
        Me.SearchHistoryTabPage.SuspendLayout()
        Me.DownloadHistoryTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'BrowsingHistoryListBox
        '
        resources.ApplyResources(Me.BrowsingHistoryListBox, "BrowsingHistoryListBox")
        Me.BrowsingHistoryListBox.FormattingEnabled = True
        Me.BrowsingHistoryListBox.Name = "BrowsingHistoryListBox"
        '
        'DeleteAllBrowsingHistoryButton
        '
        resources.ApplyResources(Me.DeleteAllBrowsingHistoryButton, "DeleteAllBrowsingHistoryButton")
        Me.DeleteAllBrowsingHistoryButton.Name = "DeleteAllBrowsingHistoryButton"
        Me.DeleteAllBrowsingHistoryButton.UseVisualStyleBackColor = True
        '
        'RemoveSelectedBrowsingButton
        '
        resources.ApplyResources(Me.RemoveSelectedBrowsingButton, "RemoveSelectedBrowsingButton")
        Me.RemoveSelectedBrowsingButton.Name = "RemoveSelectedBrowsingButton"
        Me.RemoveSelectedBrowsingButton.UseVisualStyleBackColor = True
        '
        'DisplaySelectedBrowsingButton
        '
        resources.ApplyResources(Me.DisplaySelectedBrowsingButton, "DisplaySelectedBrowsingButton")
        Me.DisplaySelectedBrowsingButton.Name = "DisplaySelectedBrowsingButton"
        Me.DisplaySelectedBrowsingButton.UseVisualStyleBackColor = True
        '
        'HistoryTabControl
        '
        Me.HistoryTabControl.Controls.Add(Me.BrowsingHistoryTabPage)
        Me.HistoryTabControl.Controls.Add(Me.SearchHistoryTabPage)
        Me.HistoryTabControl.Controls.Add(Me.DownloadHistoryTabPage)
        resources.ApplyResources(Me.HistoryTabControl, "HistoryTabControl")
        Me.HistoryTabControl.Name = "HistoryTabControl"
        Me.HistoryTabControl.SelectedIndex = 0
        '
        'BrowsingHistoryTabPage
        '
        Me.BrowsingHistoryTabPage.Controls.Add(Me.DisplaySelectedBrowsingButton)
        Me.BrowsingHistoryTabPage.Controls.Add(Me.BrowsingHistoryListBox)
        Me.BrowsingHistoryTabPage.Controls.Add(Me.RemoveSelectedBrowsingButton)
        Me.BrowsingHistoryTabPage.Controls.Add(Me.DeleteAllBrowsingHistoryButton)
        resources.ApplyResources(Me.BrowsingHistoryTabPage, "BrowsingHistoryTabPage")
        Me.BrowsingHistoryTabPage.Name = "BrowsingHistoryTabPage"
        Me.BrowsingHistoryTabPage.UseVisualStyleBackColor = True
        '
        'SearchHistoryTabPage
        '
        Me.SearchHistoryTabPage.Controls.Add(Me.OpenSearchResultsButton)
        Me.SearchHistoryTabPage.Controls.Add(Me.DeleteSelectedSearchButton)
        Me.SearchHistoryTabPage.Controls.Add(Me.DeleteAllSearchHistoryButton)
        Me.SearchHistoryTabPage.Controls.Add(Me.SearchHistoryListBox)
        resources.ApplyResources(Me.SearchHistoryTabPage, "SearchHistoryTabPage")
        Me.SearchHistoryTabPage.Name = "SearchHistoryTabPage"
        Me.SearchHistoryTabPage.UseVisualStyleBackColor = True
        '
        'OpenSearchResultsButton
        '
        resources.ApplyResources(Me.OpenSearchResultsButton, "OpenSearchResultsButton")
        Me.OpenSearchResultsButton.Name = "OpenSearchResultsButton"
        Me.OpenSearchResultsButton.UseVisualStyleBackColor = True
        '
        'DeleteSelectedSearchButton
        '
        resources.ApplyResources(Me.DeleteSelectedSearchButton, "DeleteSelectedSearchButton")
        Me.DeleteSelectedSearchButton.Name = "DeleteSelectedSearchButton"
        Me.DeleteSelectedSearchButton.UseVisualStyleBackColor = True
        '
        'DeleteAllSearchHistoryButton
        '
        resources.ApplyResources(Me.DeleteAllSearchHistoryButton, "DeleteAllSearchHistoryButton")
        Me.DeleteAllSearchHistoryButton.Name = "DeleteAllSearchHistoryButton"
        Me.DeleteAllSearchHistoryButton.UseVisualStyleBackColor = True
        '
        'SearchHistoryListBox
        '
        resources.ApplyResources(Me.SearchHistoryListBox, "SearchHistoryListBox")
        Me.SearchHistoryListBox.FormattingEnabled = True
        Me.SearchHistoryListBox.Name = "SearchHistoryListBox"
        '
        'DownloadHistoryTabPage
        '
        Me.DownloadHistoryTabPage.Controls.Add(Me.DownloadAgainButton)
        Me.DownloadHistoryTabPage.Controls.Add(Me.RemoveSelectedDownload)
        Me.DownloadHistoryTabPage.Controls.Add(Me.DeleteAllDownloadHistoryButton)
        Me.DownloadHistoryTabPage.Controls.Add(Me.DownloadHistoryListBox)
        resources.ApplyResources(Me.DownloadHistoryTabPage, "DownloadHistoryTabPage")
        Me.DownloadHistoryTabPage.Name = "DownloadHistoryTabPage"
        Me.DownloadHistoryTabPage.UseVisualStyleBackColor = True
        '
        'DownloadAgainButton
        '
        resources.ApplyResources(Me.DownloadAgainButton, "DownloadAgainButton")
        Me.DownloadAgainButton.Name = "DownloadAgainButton"
        Me.DownloadAgainButton.UseVisualStyleBackColor = True
        '
        'RemoveSelectedDownload
        '
        resources.ApplyResources(Me.RemoveSelectedDownload, "RemoveSelectedDownload")
        Me.RemoveSelectedDownload.Name = "RemoveSelectedDownload"
        Me.RemoveSelectedDownload.UseVisualStyleBackColor = True
        '
        'DeleteAllDownloadHistoryButton
        '
        resources.ApplyResources(Me.DeleteAllDownloadHistoryButton, "DeleteAllDownloadHistoryButton")
        Me.DeleteAllDownloadHistoryButton.Name = "DeleteAllDownloadHistoryButton"
        Me.DeleteAllDownloadHistoryButton.UseVisualStyleBackColor = True
        '
        'DownloadHistoryListBox
        '
        resources.ApplyResources(Me.DownloadHistoryListBox, "DownloadHistoryListBox")
        Me.DownloadHistoryListBox.FormattingEnabled = True
        Me.DownloadHistoryListBox.Name = "DownloadHistoryListBox"
        '
        'HistoryForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.HistoryTabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "HistoryForm"
        Me.HistoryTabControl.ResumeLayout(False)
        Me.BrowsingHistoryTabPage.ResumeLayout(False)
        Me.SearchHistoryTabPage.ResumeLayout(False)
        Me.DownloadHistoryTabPage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BrowsingHistoryListBox As ListBox
    Friend WithEvents DeleteAllBrowsingHistoryButton As Button
    Friend WithEvents RemoveSelectedBrowsingButton As Button
    Friend WithEvents DisplaySelectedBrowsingButton As Button
    Friend WithEvents HistoryTabControl As TabControl
    Friend WithEvents BrowsingHistoryTabPage As TabPage
    Friend WithEvents DownloadHistoryTabPage As TabPage
    Friend WithEvents SearchHistoryTabPage As TabPage
    Friend WithEvents SearchHistoryListBox As ListBox
    Friend WithEvents OpenSearchResultsButton As Button
    Friend WithEvents DeleteSelectedSearchButton As Button
    Friend WithEvents DeleteAllSearchHistoryButton As Button
    Friend WithEvents DownloadAgainButton As Button
    Friend WithEvents RemoveSelectedDownload As Button
    Friend WithEvents DeleteAllDownloadHistoryButton As Button
    Friend WithEvents DownloadHistoryListBox As ListBox
End Class

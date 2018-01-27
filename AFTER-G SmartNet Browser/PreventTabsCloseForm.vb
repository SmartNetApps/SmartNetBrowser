Public Class PreventTabsCloseForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles DontAskAgainCheckBox.CheckedChanged
        If DontAskAgainCheckBox.Checked = True Then
            My.Settings.PreventMultipleTabsClose = False
        Else
            My.Settings.PreventMultipleTabsClose = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles CloseTabsButton.Click
        My.Settings.LastClosedTab = ""
        Me.Close()
        My.Settings.Save()
        Try
            End
        Catch ex As Exception
        End Try

    End Sub
End Class
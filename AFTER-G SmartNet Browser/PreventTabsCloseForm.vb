Public Class PreventTabsCloseForm
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
        Me.Close()
        My.Settings.Save()
        Application.Exit()
        End
    End Sub
End Class
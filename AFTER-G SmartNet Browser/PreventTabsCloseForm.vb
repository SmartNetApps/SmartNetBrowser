Public Class PreventTabsCloseForm
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles PreventTabsCloseCheckBox.CheckedChanged
        If PreventTabsCloseCheckBox.Checked = True Then
            My.Settings.PreventMultipleTabsClose = False
        Else
            My.Settings.PreventMultipleTabsClose = True
        End If
    End Sub

    Private Sub Formfermetureonglets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If My.Settings.PreventMultipleTabsClose = True Then
                PreventTabsCloseCheckBox.Checked = CType(0, Boolean)
            Else
                PreventTabsCloseCheckBox.Checked = CType(1, Boolean)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles CloseTabsButton.Click
        Me.Close()
        My.Settings.Save()
        End
    End Sub
End Class
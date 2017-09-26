Public Class HistoryForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.History.Clear()
        ListBox1.Items.Clear()
        BrowserForm.URLBox.Items.Clear()
        If ListBox1.Items.Count = 0 Then
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
        Else
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
        End If
        MsgBox("L'historique du navigateur a bien été effacé.", MsgBoxStyle.Information, "SmartNet Browser")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.History.Remove(CType(ListBox1.SelectedItem, String))
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        BrowserForm.URLBox.Items.Remove(ListBox1.SelectedItem)
        If ListBox1.Items.Count = 0 Then
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
        Else
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate(CType(ListBox1.SelectedItem, String))
        If ListBox1.Items.Count = 0 Then
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
        Else
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
        End If
    End Sub

    Private Sub Formhistorique_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each item In My.Settings.History
            ListBox1.Items.Add(item)
        Next
        If ListBox1.Items.Count = 0 Then
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
        Else
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
        End If
    End Sub

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        If e.KeyCode = Keys.Delete Then
            My.Settings.History.Remove(CType(ListBox1.SelectedItem, String))
            ListBox1.Items.Remove(ListBox1.SelectedItem)
            BrowserForm.URLBox.Items.Remove(ListBox1.SelectedItem)
            If ListBox1.Items.Count = 0 Then
                Button1.Enabled = False
                Button2.Enabled = False
                Button3.Enabled = False
            Else
                Button1.Enabled = True
                Button2.Enabled = True
                Button3.Enabled = True
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            WB.Navigate(ListBox1.SelectedItem.ToString)
            Me.Close()
        End If
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)
        WB.Navigate(ListBox1.SelectedItem.ToString)
        Me.Close()
    End Sub
End Class
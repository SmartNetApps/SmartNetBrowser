Public Class SearchTextInPageForm
    Public Sub New()
        InitializeComponent()
    End Sub

    Dim Elem_Iner_Txt() As String
    Dim ComboDbl_time As Double
    Dim DoNotEnter1A As Boolean
    Public Declare Sub Sleep Lib "kernel32.dll" (ByVal Milliseconds As Integer)
    Dim WB As CustomBrowser = CType(BrowserForm.BrowserTabs.SelectedTab.Tag, CustomBrowser)

    Private Sub InternetGecko_Load(ByVal sender As System.Object, e As EventArgs) Handles MyBase.Load
        Button1A.BackColor = SystemColors.Control
        Button2A.BackColor = SystemColors.Control
        ComboBox1A.BackColor = Color.PaleGoldenrod
        ReDim Elem_Iner_Txt(0)
        TextBox1A.Tag = ""
        TextBox2A.Tag = ""
        TextBox1A.Text = ""
        TextBox2A.Text = "A"
        Me.Location = BrowserForm.BrowserTabs.Location
    End Sub

    Private Sub TextBox1A_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1A.KeyDown
        If Len(TextBox1A.Text) > 0 And e.KeyCode = 13 And TextBox1A.Focus = True Then
            Dim El_In_Txt_Cnt As String = ""
            El_In_Txt_Cnt = Elem_Iner_Txt(0)
            If ((Elem_Iner_Txt.GetUpperBound(0) > 0 Or Len(El_In_Txt_Cnt) > 0)) Then
                Call Button1A_Click(sender, e)
                Label1A.Text = "Entrez du texte, deux caractères minimum"
            Else
                Call Button2A_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub TextBox1A_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1A.TextChanged
        If DoNotEnter1A = True Then
            DoNotEnter1A = False
            GoTo Ends
        End If

        Dim El_In_Txt_Cnt As String = ""
        El_In_Txt_Cnt = Elem_Iner_Txt(0)
        Dim LastText1A As String = TextBox1A.Text.ToString
        Dim LastText2A As String = TextBox2A.Text.ToString
        Sleep(100)
        If (TextBox1A.Focus = True And (Elem_Iner_Txt.GetUpperBound(0) > 0 Or Len(El_In_Txt_Cnt) > 0)) Then
            DoNotEnter1A = True
            TextBox2A.Text = TextBox2A.Tag.ToString
            TextBox1A.Text = TextBox1A.Tag.ToString
            Call Button1A_Click(sender, e)
            Sleep(200)
            Label1A.Text = "Entrez du texte, deux caractères minimum"
            ReDim Elem_Iner_Txt(0)
            DoNotEnter1A = True
            TextBox2A.Text = LastText2A
            TextBox1A.Text = LastText1A
            DoNotEnter1A = False
        End If
        TextBox2A.Tag = TextBox2A.Text
        TextBox1A.Tag = TextBox1A.Text
        If TextBox1A.Focused = True Then
            TextBox1A.SelectionStart = Len(TextBox1A.Text)
            TextBox1A.SelectionLength = Len(TextBox1A.Text)
        End If
Ends:
    End Sub

    Private Sub TextBox2A_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2A.TextChanged

        Dim El_In_Txt_Cnt As String
        El_In_Txt_Cnt = Elem_Iner_Txt(0)     ''Textbox2A and Textbox3A have IDENTICAL CODE

        Dim LastText2A As String = TextBox2A.Text
        Dim LastText1A As String = TextBox1A.Text
        If (Elem_Iner_Txt.GetUpperBound(0) > 0 Or Len(El_In_Txt_Cnt) > 0) Then
            DoNotEnter1A = True
            TextBox2A.Text = TextBox2A.Tag.ToString
            TextBox1A.Text = TextBox1A.Tag.ToString
            DoNotEnter1A = False
            Call Button1A_Click(sender, e)
            ReDim Elem_Iner_Txt(0)
            Label1A.Text = "Entrez du texte, deux caractères minimum"
            DoNotEnter1A = True
            TextBox2A.Text = LastText2A
            TextBox1A.Text = LastText1A
            DoNotEnter1A = False
        End If
    End Sub

    Private Sub TextBox3A_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3A.DoubleClick
        TextBox3A.Text = ""
        ComboBox1A.Text = ""
    End Sub

    Private Sub TextBox3A_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3A.TextChanged

        Dim El_In_Txt_Cnt As String
        El_In_Txt_Cnt = Elem_Iner_Txt(0)       ''Textbox3A and Textbox2A have IDENTICAL CODE

        Dim LastText2A As String = TextBox2A.Text
        Dim LastText1A As String = TextBox1A.Text
        If (Elem_Iner_Txt.GetUpperBound(0) > 0 Or Len(El_In_Txt_Cnt) > 0) Then
            DoNotEnter1A = True
            TextBox2A.Text = TextBox2A.Tag.ToString
            TextBox1A.Text = TextBox1A.Tag.ToString
            DoNotEnter1A = False
            Call Button1A_Click(sender, e)
            ReDim Elem_Iner_Txt(0)
            Label1A.Text = "Entrez du texte, deux caractères minimum"
            DoNotEnter1A = True
            TextBox2A.Text = LastText2A
            TextBox1A.Text = LastText1A
            DoNotEnter1A = False
        End If
    End Sub

    Private Sub ComboBox1A_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1A.Click
        Dim Checkingtiming As Double = Microsoft.VisualBasic.DateAndTime.Timer
        If ComboDbl_time < Checkingtiming - 1.5 And ComboDbl_time > 0 Then
            ComboDbl_time = 0
            GoTo Ends
        End If
        If ComboDbl_time > 0 Then
            If ComboBox1A.BackColor = Color.PaleGoldenrod Then  'Any Changes to Color will have to be-
                ComboBox1A.BackColor = Color.LightPink          'done in 2 other locations as well!
                GoTo MoveOnOut                              'THIS CHANGES THE COLOR OF HIGHLIGHTED TEXT.
            End If
            If ComboBox1A.BackColor = Color.LightBlue Then
                ComboBox1A.BackColor = Color.PaleGoldenrod
            End If
            If ComboBox1A.BackColor = Color.LightPink Then
                ComboBox1A.BackColor = Color.LightBlue
            End If
MoveOnOut:
            ComboDbl_time = 0
            ComboBox1A.Select(0, 0)
            GoTo Ends
        End If
        If ComboDbl_time = 0 Then
            ComboDbl_time = Microsoft.VisualBasic.DateAndTime.Timer
        End If
Ends:
    End Sub

    Private Sub ComboBox1A_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1A.SelectedIndexChanged
        If ComboBox1A.Text.ToString <> "" Then
            Dim El_In_Txt_Cnt As String
            El_In_Txt_Cnt = Elem_Iner_Txt(0)
            If Elem_Iner_Txt.GetUpperBound(0) > 0 Or Len(El_In_Txt_Cnt) > 0 Then
                Call Button1A_Click(sender, e)
                ReDim Elem_Iner_Txt(0)
                Label1A.Text = "Entrez du texte, deux caractères minimum"
            End If
            TextBox3A.Text = Trim(ComboBox1A.Text.ToString)
            ComboBox1A.Text = Nothing
        End If
    End Sub

    Private Sub Button1A_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1A.GotFocus
        If Len(TextBox2A.Tag) > 0 And Len(TextBox1A.Tag) > 0 And (Elem_Iner_Txt.GetUpperBound(0)) > 1 Then
            TextBox1A.Focus()
            DoNotEnter1A = True
            TextBox2A.Text = TextBox2A.Tag.ToString
            TextBox1A.Text = TextBox1A.Tag.ToString
            DoNotEnter1A = False
        End If
    End Sub

    Private Sub Button1A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1A.Click
        If Button1A.BackColor <> SystemColors.Control Or Button2A.BackColor <> SystemColors.Control Then
            GoTo Exit_Sub
        End If

        On Error Resume Next
        Dim El_In_Txt_Cnt As String
        Dim Original_Html As String
        Dim Pos1 As Integer
        Dim Elem_Html_Used As Integer
        Dim Tag_Selection As Integer
        El_In_Txt_Cnt = Elem_Iner_Txt(0)

        Label1A.Text = "Entrez du texte, deux caractères minimum"
        Dim TagsType As String = "A"
        If (Elem_Iner_Txt.GetUpperBound(0) > 0 Or Len(El_In_Txt_Cnt) > 0) Then
            Dim TagsName As String = ""
            Button1A.BackColor = Color.IndianRed
            Application.DoEvents()
            TagsType = ""
            Dim HiLiteColor As String
            Dim Combo1_Cnt As Integer = ComboBox1A.Items.Count - 1
            HiLiteColor = ComboBox1A.Tag.ToString
            TagsType = "A"
            Original_Html = Elem_Iner_Txt(0).ToString
            Pos1 = InStr(Original_Html, "||")
            If Pos1 > 0 Then
                TagsType = Trim(Mid(Original_Html, 1, Pos1 - 1))
            End If

            Dim InnerHtml_txt As String = ""
            Dim Search_Word As String
            Search_Word = TextBox1A.Text
            If Len(TextBox1A.Text) = 0 And Len(TextBox1A.Tag) > 0 Then
                Search_Word = TextBox1A.Tag.ToString
            End If

Run_Next_Tag:

            If (Elem_Iner_Txt.GetUpperBound(0) > 0 Or Len(El_In_Txt_Cnt) > 0) Then
                Original_Html = Elem_Iner_Txt(0)
                For Each elem As Gecko.GeckoHtmlElement In WB.Document.GetElementsByTagName(TagsType)
                    If IsNothing(elem) = False Then
                        InnerHtml_txt = elem.InnerHtml
                        If Len(InnerHtml_txt) > 0 And InStr(LCase(InnerHtml_txt), LCase(Search_Word)) > 0 And Len(Search_Word) > 0 _
                    And InStr(1, LCase(InnerHtml_txt), LCase("<img src=")) = 0 _
                     And InStr(1, LCase(elem.InnerHtml.ToString), "img alt=") = 0 And InStr(1, LCase(elem.InnerHtml.ToString), "<input") = 0 _
                  And InStr(1, LCase(elem.InnerHtml.ToString), "createelement") = 0 And InStr(1, LCase(InnerHtml_txt), LCase("<h2 class=")) = 0 _
                   And InStr(LCase(InnerHtml_txt), LCase(HiLiteColor)) > 0 And Elem_Iner_Txt.GetUpperBound(0) >= Elem_Html_Used Then

                            Original_Html = Elem_Iner_Txt(Elem_Html_Used)  'Html string saved during search
                            Pos1 = InStr(Original_Html, "||")
                            If Pos1 > 0 Then
                                TagsName = Trim(Mid(Original_Html, 1, Pos1 - 1))
                                Original_Html = Trim(Mid(Original_Html, Pos1 + 2, Len(Original_Html) - (Pos1 + 1)))
                                If Pos1 > 0 And LCase(TagsType) = LCase(TagsName) And Len(Original_Html) > 0 Then
                                    elem.InnerHtml = Original_Html
                                    Elem_Html_Used = Elem_Html_Used + 1
                                End If
                            End If
                        End If
                    End If
                Next
            End If

            Tag_Selection = 0     'Restores or Clears, Only TagNames Used During HighLighting Search

            For i = 0 To CInt(Elem_Iner_Txt.GetUpperBound(0))
                Original_Html = Elem_Iner_Txt(i).ToString
                Pos1 = InStr(Original_Html, "||")
                If Pos1 > 0 Then
                    TagsName = Trim(Mid(Original_Html, 1, Pos1 - 1))
                End If
                If LCase(TagsName) = LCase(TagsType) Then
                    Tag_Selection = 1
                End If
                If Tag_Selection = 1 And LCase(TagsName) <> LCase(TagsType) And i - 1 < CInt(Elem_Iner_Txt.GetUpperBound(0)) Then
                    Original_Html = Elem_Iner_Txt(i).ToString
                    Pos1 = InStr(Original_Html, "||")
                    If Pos1 > 0 Then
                        TagsName = Trim(Mid(Original_Html, 1, Pos1 - 1))
                    End If
                    If Len(TagsType) > 0 And LCase(TagsName) <> LCase(TagsType) Then
                        TagsType = UCase(TagsName)
                        GoTo Run_Next_Tag
                    End If
                End If
            Next i
            ReDim Elem_Iner_Txt(0)  'Clears All Html Stored
        End If

        Button1A.BackColor = SystemColors.Control
Exit_Sub:
    End Sub

    Private Sub Button2A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2A.Click

        If Button1A.BackColor <> SystemColors.Control Or Button2A.BackColor <> SystemColors.Control Then
            GoTo Exit_Sub  'Exits Sub If Currently processing Searching or Clearing Search
        End If

        Dim El_In_Txt_Cnt As String
        El_In_Txt_Cnt = Elem_Iner_Txt(0)
        If Elem_Iner_Txt.GetUpperBound(0) > 0 Or Len(El_In_Txt_Cnt) > 0 Then
            Call Button1A_Click(sender, e)
        End If
        If Len(Trim(TextBox1A.Text)) < 2 Then
            GoTo Ends
        End If
        On Error Resume Next
        ReDim Elem_Iner_Txt(0)
        Dim TagsType As String = ""
        DoNotEnter1A = True
        TextBox1A.Text = Trim(TextBox1A.Text)
        DoNotEnter1A = False
        Dim Pos1 As Integer
        Dim Pos2 As Integer
        Dim Pos3 As Integer
        Dim Pos4 As Integer
        Dim Pos5 As Integer
        Dim Pos6 As Integer
        Dim Combo1_Cnt As Integer = ComboBox1A.Items.Count - 1
        Dim LookUp_Cnt As Integer
        Dim InnerHtml_txt As String = ""
        Dim Temp_Word As String = ""
        Dim ComboBoxListTxt As String = ""
        Dim ComboList As Boolean
        Dim TextToHilight As String = ""
        Dim Word_To_Check As String
        Dim Combine_Html_Txt As String = ""
        Dim InBetweenTxt As String = ""
        Dim Text_Content As String = ""
        Dim Elem_Html_Used As Integer
        Dim Words_In_Html_Cnt As Integer
        Dim Ok_To_Use As Boolean
        Dim More_Than_One_Instance As Integer
        Dim Loop_Times As Integer
        Dim Elem_Name As String = ""
        Dim Last_Pos6 As Integer

        Button2A.BackColor = Color.IndianRed
        Application.DoEvents()

        If Button1A.Tag.ToString = "0" Then
            ComboBox1A.Items.Clear()
            For Each elem As Gecko.GeckoElement In WB.Document.GetElementsByTagName("*")
                If IsNothing(elem) = False Then
                    Temp_Word = elem.TagName()        'looks for all the TagNames Availiable and stores
                    ComboList = False                    'Only looks one time, for each page Searched
                    If ComboBox1A.Items.Count > 0 Then
                        For i = 0 To ComboBox1A.Items.Count - 1
                            If Len(ComboBox1A.Items(0).ToString) > 0 Then
                                ComboBoxListTxt = ComboBox1A.Items(i).ToString
                                If InStr(CStr(ComboBoxListTxt), Temp_Word) > 0 And ComboBoxListTxt = Temp_Word Then
                                    ComboList = True
                                End If
                            End If
                        Next i
                    End If

                    If ComboList = False Then
                        ComboBox1A.Items.Add(Temp_Word)
                    End If
                End If
            Next
            Button1A.Tag = "1"
        End If

        ''Time allowed to search before exiting if Looping
        Dim Start_Time_Count As Double = Microsoft.VisualBasic.DateAndTime.Timer + 15

        Application.DoEvents()
        Label1A.Text = "Mot non trouvé"

        Dim Combo_BackColor As String = ""

        If ComboBox1A.BackColor = Color.PaleGoldenrod Then  ''3 choices of Search Highlight BackColor
            Combo_BackColor = "(255, 255, 25)"               'Colors Must Remain in this format.
        End If


        If ComboBox1A.BackColor = Color.LightBlue Then     'Any Changes to Color will have to be-
            Combo_BackColor = "(100, 220, 235)"            'done in 2 other locations as well!
        End If

        If ComboBox1A.BackColor = Color.LightPink Then
            Combo_BackColor = "(245, 200, 200)"
        End If

        ComboBox1A.Tag = Combo_BackColor        ''Color is stored for Removing HighLights later      
        LookUp_Cnt = 0
        TagsType = "A"  'Starting search default tag.

Run_Next_Tag:

        For Each elem As Gecko.GeckoHtmlElement In WB.Document.GetElementsByTagName(TagsType)
            If IsNothing(elem) = False Then
                InnerHtml_txt = elem.InnerHtml.ToString
                If (Len(elem.InnerHtml) > 1000 And InStr(1, LCase(elem.InnerHtml.ToString), "href") > 0) Then
                    GoTo Bypass ' if line has, href in it, with a long text string, Probably not best to use.
                End If

                If InStr(LCase(elem.InnerHtml.ToString), "color:black;background:rgb") > 0 Then
                    If InStr(LCase(elem.InnerHtml.ToString), "color:black;background:rgb") > 0 Then
                        If InStr(LCase(elem.InnerHtml.ToString), Combo_BackColor) > 0 Then
                            If InStr(LCase(elem.InnerHtml.ToString), ";font-weight:bold") > 0 Then
                                GoTo Bypass  'bypasses if it has already been HighLighted
                            End If
                        End If
                    End If
                End If

                Ok_To_Use = True

                If InStr(elem.InnerHtml, "<") > 0 And Len(elem.InnerHtml.ToString) < 1000 And
                    InStr(1, LCase(elem.InnerHtml.ToString), LCase("href=")) > 0 And Len(TextBox1A.Text) > 0 _
                    And InStr(1, LCase(elem.InnerHtml), LCase(TextBox1A.Text)) > 0 Then
                    Ok_To_Use = False
                    Pos1 = InStr(elem.InnerHtml, "<")
                    InnerHtml_txt = elem.InnerHtml.ToString
Next_Word_Chk:
                    If Pos1 > 0 And Pos1 < Len(InnerHtml_txt) Then
                        Pos2 = InStr(Pos1 + 1, InnerHtml_txt, ">")
                        If Pos2 > Pos1 Then
                            Pos1 = InStr(Pos1 + 2, elem.InnerHtml, "<")
                            If Pos1 > Pos2 Then
                                Word_To_Check = Mid(elem.InnerHtml, Pos2 + 1, Pos1 - (Pos2 + 1))
                                If Len(TextBox1A.Text) > 0 And InStr(1, LCase(Word_To_Check), LCase(TextBox1A.Text)) > 0 Then
                                    Ok_To_Use = True    'If a regular statement is found to Highlight, NOT Html.
                                End If
                                Pos1 = Pos1 + 2
                            End If
                            If Pos1 > 2 Then
                                GoTo Next_Word_Chk
                            End If
                        End If
                    End If
                End If


                If InStr(1, LCase(elem.InnerHtml.ToString), "img src=") > 0 Or InStr(1, LCase(elem.InnerHtml.ToString), "img alt=") > 0 _
      Or InStr(1, LCase(elem.InnerHtml.ToString), "<input") > 0 Or InStr(1, LCase(elem.InnerHtml.ToString), "createelement") > 0 _
    Or InStr(1, LCase(elem.InnerHtml.ToString), LCase("<h2 class=")) > 0 Or InStr(1, LCase(elem.InnerHtml.ToString), "img class=") > 0 _
    Or Ok_To_Use = False Then
                    GoTo Bypass 'Bypass if any element causes problems HighLighting
                End If
            End If

            If IsNothing(elem) = False Then
                InnerHtml_txt = elem.InnerHtml.ToString
                Pos5 = 0
                Loop_Times = 0
                Elem_Name = elem.TagName
                Words_In_Html_Cnt = 0
                More_Than_One_Instance = 0
                Combine_Html_Txt = ""
                If Len(TextBox1A.Text) > 0 And InStr(1, LCase(InnerHtml_txt), LCase(TextBox1A.Text)) > 0 And
                    (Elem_Name = TagsType) Then
                    Pos6 = 1
                    Pos1 = InStr(elem.InnerHtml, "<")    'Looks at Java or Html Strings, Breaking out Text Only
                    Last_Pos6 = 0
                    Pos3 = 0
                    If InStr(1, LCase(elem.InnerHtml.ToString), "href") > 0 And InStr(InnerHtml_txt, ">") > 0 Then
                        If Pos3 > Pos2 And Math.Abs(Pos3 - Pos2) < Len(TextBox1A.Text) Or (Pos3 = 0 And Pos1 > 0) Then
checkAgain:                 '''''''''''''''''''''''''''''''''CheckAgain'''' 
                            Pos2 = InStr(Pos3 + 1, InnerHtml_txt, ">")
                            Pos3 = InStr((Pos2 + 1), elem.InnerHtml, "<")
                            If Pos3 > Pos2 And Math.Abs(Pos3 - Pos2) < Len(TextBox1A.Text) Then
                                GoTo checkAgain
                            End If   'Checks So html Text, is not Used in part of the Search
                        End If
                        If (Pos3 - Pos2) >= Len(TextBox1A.Text) And Pos3 > 0 And Pos2 > 0 Then
                            InBetweenTxt = Mid(InnerHtml_txt, Pos2, Pos3 - Pos2)
                            If InStr(Pos2, LCase(InnerHtml_txt), LCase(TextBox1A.Text)) <= Pos3 Then
                                Pos1 = Pos3
                                Pos2 = 0
                                Pos3 = 0
                            Else
                                GoTo checkAgain    'Checks So html Text, is not Used in part of the Search
                            End If
                        End If
                        If Pos1 < 2 Then
                            GoTo Bypass
                        End If
                    End If

LoopText:           ''''''''''''''''''''''''''''''''' LoopText''
                    Ok_To_Use = True
                    InBetweenTxt = ""
                    Pos4 = 0
                    If Pos1 > 0 And Pos1 < Len(InnerHtml_txt) Then
                        Pos2 = InStr(Pos1 + 1, InnerHtml_txt, ">")
                    End If
                    If Start_Time_Count < Microsoft.VisualBasic.DateAndTime.Timer Then
                        GoTo Ends 'Exit if runs too long
                    End If
                    Pos4 = InStr(1, LCase(InnerHtml_txt), LCase(TextBox1A.Text))
                    If Pos4 > 0 Then
                        Pos4 = InStr(Pos4 + 1, LCase(InnerHtml_txt), LCase(TextBox1A.Text))
                    End If

                    If Pos4 > 0 And Pos6 > 0 Then
                        Pos4 = InStr(Pos6, LCase(InnerHtml_txt), LCase(TextBox1A.Text)) + 1
                        If (Pos4 > Pos6 And Pos6 > 0) Or (Last_Pos6 < Pos4 And Last_Pos6 > 0) Or (Last_Pos6 >= Pos6 And Last_Pos6 > 0) Then
                            If Last_Pos6 >= Pos6 And Pos4 < Pos6 Then
                                Pos6 = Pos6
                                Last_Pos6 = Last_Pos6 + 2
                                Pos2 = 0
                            Else
                                Pos6 = Pos4
                                Pos1 = 0
                                Pos2 = 0
                            End If
                        End If
                    End If
                    Pos4 = 0
                    If Pos6 = 1 Then
                        Pos6 = 0
                    End If

                    If (Pos1 > 0 And Pos2 > Pos1 And (Pos2 - Pos1) > 0) Or Pos6 > 0 Then
                        If (Pos1 > 0 And Pos2 > Pos1 And (Pos2 - Pos1) > 0) Then
                            InBetweenTxt = Mid(elem.InnerHtml, Pos1, Pos2 - (Pos1 - 1))
                            Pos3 = InStr((Pos2 + 1), elem.InnerHtml, "<")
                        End If
                        If Pos6 > 0 And (Pos1 = 0 Or Pos2 = 0) Then
                            Pos2 = Pos6 - 2
                            Pos1 = Pos2 - Len(TextBox1A.Text)
                            If Pos1 < 1 Then
                                Pos1 = 1
                            End If
                            If Pos2 < 1 Then
                                Pos2 = 0
                            End If
                            Pos3 = Pos2 + Len(TextBox1A.Text) + 2
                        End If

                        If (Pos3 > Pos2) Then
                            InBetweenTxt = Mid(InnerHtml_txt, Pos2 + 1, Pos3 - (Pos2 + 1))
                            If Len(InBetweenTxt.Trim(CChar(InBetweenTxt))) > 0 Then
                                If InStr(LCase(InBetweenTxt), LCase(TextBox1A.Text)) > 0 Then
                                    TextToHilight = Mid(InnerHtml_txt, Pos2 + 1, Len(TextBox1A.Text))
                                    'Determines Ucase_Lcase Spelling By Looking at actual Text
                                    If LCase(TextToHilight) <> LCase(TextBox1A.Text) And Pos2 > 0 Then
                                        InBetweenTxt = Mid(InnerHtml_txt, Pos2, 1)
                                        Pos2 = InStr(Pos2 + 1, LCase(InnerHtml_txt), LCase(TextBox1A.Text)) - 1
                                        If Pos2 < InStr(Pos2 + 1, LCase(InnerHtml_txt), "<") And InBetweenTxt = ">" Then
                                            TextToHilight = Mid(InnerHtml_txt, Pos2 + 1, Len(TextBox1A.Text))
                                        End If
                                    End If

                                    Pos4 = InStr(Pos3, LCase(InnerHtml_txt), LCase(TextBox1A.Text))
                                    If Pos4 = 0 Then
                                        If Pos6 > 0 And Pos2 = 0 Then
                                            Pos2 = Pos2 + 1
                                        End If
                                        Pos5 = InStr(Pos2, LCase(InnerHtml_txt), LCase(TextBox1A.Text)) - 1
                                    End If
                                    If Last_Pos6 > Pos6 + 1 Then
                                        Pos4 = 0
                                        Last_Pos6 = 0
                                        Pos6 = 0
                                        Pos4 = 0
                                        Pos3 = 0
                                    End If
                                    If Last_Pos6 < Pos6 And (Pos6 > 0 Or InStr(Last_Pos6 + (Len(TextBox1A.Text) - 1), LCase(InnerHtml_txt), LCase(TextBox1A.Text)) > 1) Then
                                        If Last_Pos6 <= Pos6 Then
                                            Pos1 = Last_Pos6
                                            Last_Pos6 = Pos6
                                            Pos4 = 1
                                        Else
                                            Last_Pos6 = 0
                                        End If
                                    End If
                                    If (More_Than_One_Instance = 0 Or Len(Combine_Html_Txt) < Len(TextBox1A.Text) + 1) Then
                                        Combine_Html_Txt = Mid(InnerHtml_txt, 1, Pos2) & "<span style='color:black;background:rgb" & Combo_BackColor & ";font-weight:bold'>" + TextToHilight + "</span>"
                                        Label1A.Text = CStr(Val(Label1A.Text) + 1) + " correspondance(s)"
                                    Else
                                        If Pos2 > Len(TextBox1A.Text) + 1 And Pos4 > 0 And Len(Combine_Html_Txt) > 1 Then
                                            Combine_Html_Txt = Combine_Html_Txt & Mid(InnerHtml_txt, (Pos1 + Len(TextBox1A.Text) - 1), Pos2 - (Pos1 + Len(TextBox1A.Text) - 2)) & "<span style='color:black;background:rgb" & Combo_BackColor & ";font-weight:bold'>" + TextToHilight + "</span>"
                                            Label1A.Text = CStr(Val(Label1A.Text) + 1) + " correspondance(s)"
                                        End If
                                    End If
                                    Words_In_Html_Cnt = Words_In_Html_Cnt + 1
                                    If InStr(LCase(TextToHilight), LCase(TextBox1A.Text)) > 0 Then
                                        More_Than_One_Instance = More_Than_One_Instance + 1
                                    End If
                                End If
                            End If
                        End If
                        'Inserts HighLight INFO into Original Html or Java Script
                        If Pos4 = 0 And Len(Combine_Html_Txt) > 0 And More_Than_One_Instance > 0 And Pos5 > 0 Then
                            If Pos2 > Len(TextBox1A.Text) + 1 Then
                                Combine_Html_Txt = Combine_Html_Txt + elem.InnerHtml.Substring(Pos5 + Len(TextBox1A.Text))
                                InnerHtml_txt = elem.InnerHtml.ToString
                                elem.InnerHtml = Combine_Html_Txt
                                Label1A.Text = CStr(Val(Label1A.Text) + 1) + " correspondance(s)"
                                If Elem_Html_Used > Elem_Iner_Txt.GetUpperBound(0) Then
                                    ReDim Preserve Elem_Iner_Txt(Elem_Iner_Txt.GetUpperBound(0) + 1)
                                End If
                                Elem_Iner_Txt(Elem_Html_Used) = TagsType & "||" & InnerHtml_txt   'Save Orignal Html Text
                                Elem_Html_Used = Elem_Html_Used + 1
                                Pos3 = 0
                            End If
                        End If

                        If Start_Time_Count < Microsoft.VisualBasic.DateAndTime.Timer Then
                            GoTo Ends
                        End If

                        If Pos6 > 0 And Pos2 = 1 Then
                            Pos2 = 2
                        End If
                        If Pos6 > 1 Then
                            If InStr(Pos6 + 1, LCase(InnerHtml_txt), LCase(TextBox1A.Text)) > 0 Then
                                GoTo LoopText ' goes to next part of Text in a Html String
                            Else
                                Pos1 = 0
                            End If
                        End If

                        If Pos3 > 0 Then
                            Pos1 = Pos3
                            Loop_Times = Loop_Times + 1
                            If Loop_Times > 600 Then
                                Loop_Times = 0  '' Stops from looping forever!
                                GoTo Bypass
                            End If
                            GoTo LoopText
                        End If
                    End If

                    If Pos4 = 0 And Len(Combine_Html_Txt) = 0 And More_Than_One_Instance = 0 And Pos3 = 0 And Pos5 = 0 And InStr(LCase(InnerHtml_txt), LCase(TextBox1A.Text)) > 0 Then
                        Pos1 = InStr(LCase(InnerHtml_txt), LCase(TextBox1A.Text)) - 1
                        If InStr(LCase(InnerHtml_txt), LCase(TextBox1A.Text)) = 1 Then
                            Pos1 = 1
                            TextToHilight = Mid(InnerHtml_txt, 1, Len(TextBox1A.Text))
                        Else
                            TextToHilight = Mid(InnerHtml_txt, Pos1 + 1, Len(TextBox1A.Text))
                        End If

                        InnerHtml_txt = elem.InnerHtml.ToString

                        If Pos1 > 0 Then    'If only HighLighting one Word in a normally Structured Statement Of Text.
                            Pos1 = InStr(LCase(InnerHtml_txt), LCase(TextBox1A.Text)) - 1
                            elem.InnerHtml = elem.InnerHtml.Substring(0, Pos1 - 0) + "<span style='color:black;background:rgb" & Combo_BackColor & ";font-weight:bold'>" + TextToHilight + "</span>" + elem.InnerHtml.Substring(Pos1 + Len(TextBox1A.Text))
                            If Elem_Html_Used > Elem_Iner_Txt.GetUpperBound(0) Then
                                ReDim Preserve Elem_Iner_Txt(Elem_Iner_Txt.GetUpperBound(0) + 1)
                            End If
                            Label1A.Text = CStr(Val(Label1A.Text) + 1) + " correspondance(s)"
                            Elem_Iner_Txt(Elem_Html_Used) = TagsType & "||" & InnerHtml_txt  'Used later to restore Original Text.
                            Elem_Html_Used = Elem_Html_Used + 1
                        End If
                    End If
                End If
            End If
Bypass:
        Next
        If TagsType = "A" And LookUp_Cnt = 0 Then
            LookUp_Cnt = 1
            TagsType = "P"   'After looking at Tag Types "A" Cycles through "P"
            GoTo Run_Next_Tag   'Below Cycle through Other Types of Tag's If Availiable in ComboBox List.
        End If

        Application.DoEvents()

        If Len(TextBox3A.Text) > 0 And LookUp_Cnt = 1 Then
            TextBox2A.Text = UCase(TextBox3A.Text)
        End If
        If LookUp_Cnt < 1 Then
            LookUp_Cnt = 1
        End If
        If LookUp_Cnt = 1 And TagsType = "P" And LCase(TextBox2A.Text) <> "a" And LCase(TextBox2A.Text) <> "p" And Len(TextBox2A.Text) > 0 And LCase(TextBox2A.Text) <> "div" Then
            TagsType = UCase(TextBox2A.Text)
            LookUp_Cnt = 2
            GoTo Run_Next_Tag        'Loops through Some of the Availiable Tag Names.
        Else
            If LookUp_Cnt < 2 Then
                LookUp_Cnt = 2
            End If
        End If
        If LookUp_Cnt < 2 Then
            LookUp_Cnt = 2
        End If
        If LookUp_Cnt = 2 And Button2A.BackColor <> Color.AliceBlue And Button2A.BackColor <> Color.Aqua Then
            For i = Combo1_Cnt To 0 Step -1
                If LCase(ComboBox1A.Items(i).ToString) = "pre" Or LCase(ComboBox1A.Items(i).ToString) = "tr" Or Mid(ComboBox1A.Items(i).ToString, 1, 1) = "H" And IsNumeric(Mid(ComboBox1A.Items(i).ToString, 2, 1)) = True Then
                    TagsType = ComboBox1A.Items(i).ToString
                    Combo1_Cnt = i - 1
                    GoTo Run_Next_Tag         'Loops through Some of the Availiable Tag Names.   
                End If
            Next i
            Button2A.BackColor = Color.Aqua
        End If

        If LookUp_Cnt < 3 Then
            LookUp_Cnt = 3
        End If


        If LookUp_Cnt = 3 And Button2A.BackColor <> Color.AliceBlue And LCase(TextBox2A.Text) <> "td" And LCase(TextBox2A.Text) <> "div" And LCase(TextBox2A.Text) <> "a" And LCase(TextBox2A.Text) <> "p" And LCase(TextBox2A.Text) <> "div" And Len(TextBox2A.Text) > 0 And UCase(TextBox2A.Text) <> TagsType Then
            Button2A.BackColor = Color.AliceBlue
            TagsType = UCase(TextBox2A.Text)     'Loops through Personally Selected Combobox List of Availiable Tag Names.   
            GoTo Run_Next_Tag
        End If

Ends:
        Button2A.BackColor = SystemColors.Control  'Sets button Back to Starting Color
Exit_Sub:

    End Sub

    Private Sub Button3A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3A.Click
        ComboBox1A.Items.Clear()
        TextBox2A.Text = ""
        TextBox3A.Text = ""
        Me.Close()
    End Sub

    Private Sub ComboBox1A_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1A.TextChanged
        ComboBox1A.Text = "Double-clic pour changer la couleur du surlignage"
    End Sub
End Class
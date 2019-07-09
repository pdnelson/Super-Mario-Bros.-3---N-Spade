Public Class frmSMB3
    Dim intCount As Integer = 0
    Dim intCoin10 As Integer = 0
    Dim intCoin20 As Integer = 0
    Dim intShroom As Integer = 0
    Dim intFlower As Integer = 0
    Dim intStar As Integer = 0
    Dim int1UP As Integer = 0
    Dim intLives As Integer = 10
    Dim intMatch As Integer = 0
    Dim intRound As Integer = 1
    Dim intBoard(5, 2)
    Dim strPos(17) As String

    Private Sub frmPenny_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Randomize()
        hideCards()
        lblMatched.Text = "Matches: 0" & vbCrLf & "  Round: 1" & vbCrLf & "  Tries: " & intLives
    End Sub
    Private Sub btnButton_Click(sender As System.Object, e As System.EventArgs) Handles _
        btn1.Click, _
        btn2.Click, _
        btn3.Click, _
        btn4.Click, _
        btn5.Click, _
        btn6.Click, _
        btn7.Click, _
        btn8.Click, _
        btn9.Click, _
        btn10.Click, _
        btn11.Click, _
        btn12.Click, _
        btn13.Click, _
        btn14.Click, _
        btn15.Click, _
        btn17.Click, _
        btn18.Click, _
        btn19.Click
        Dim btnButton As Button = sender

        intCount += 1
        Dim intRow As Integer = Val(btnButton.Tag.Chars(0))
        Dim intCol As Integer = Val(btnButton.Tag.Chars(2))
        Static btnButton2 As Button
        btnButton.Enabled = False
        If intCount = 1 Then
            btnButton2 = sender
            btnButton2.Enabled = False
        End If

        If (intBoard(intRow, intCol) = 1 Or intBoard(intRow, intCol) = 2 Or intBoard(intRow, intCol) = 3 Or intBoard(intRow, intCol) = 4) Then
            btnButton.BackgroundImage = My.Resources.CCoin10
            intCoin10 += 1
        ElseIf intBoard(intRow, intCol) = 5 Or intBoard(intRow, intCol) = 6 Or intBoard(intRow, intCol) = 7 Or intBoard(intRow, intCol) = 8 Then
            btnButton.BackgroundImage = My.Resources.CCoin20
            intCoin20 += 1
        ElseIf intBoard(intRow, intCol) = 9 Or intBoard(intRow, intCol) = 10 Or intBoard(intRow, intCol) = 11 Or intBoard(intRow, intCol) = 12 Then
            btnButton.BackgroundImage = My.Resources.Cmushroom
            intShroom += 1
        ElseIf intBoard(intRow, intCol) = 13 Or intBoard(intRow, intCol) = 14 Then
            btnButton.BackgroundImage = My.Resources.CFlower
            intFlower += 1
        ElseIf intBoard(intRow, intCol) = 15 Or intBoard(intRow, intCol) = 16 Then
            btnButton.BackgroundImage = My.Resources.CStar
            intStar += 1
        ElseIf intBoard(intRow, intCol) = 17 Or intBoard(intRow, intCol) = 18 Then
            btnButton.BackgroundImage = My.Resources.C1up
            int1UP += 1
        End If
        If intCount = 2 And (intStar = 2 Or intFlower = 2 Or intShroom = 2 Or intCoin20 = 2 Or intCoin10 = 2) Then
            MessageBox.Show("Nice! That's a match!")
            intCount = 0
            intCoin10 = 0
            intCoin20 = 0
            intShroom = 0
            intFlower = 0
            intStar = 0
            int1UP = 0
            intMatch += 1
            If intMatch Mod 9 = 0 Then
                MessageBox.Show("Congratulations on beating round " & intRound & "! I will give you 5 more lives to help you beat round " & intRound + 1 & ". Good luck!")
                intLives += 5
                intRound += 1
                lblMatched.Text = "Matches: " & intMatch & vbCrLf & "  Round: " & intRound & vbCrLf & "  Tries: " & intLives
                hideCards()
            End If
        ElseIf intCount = 2 And int1UP = 2 Then
            MessageBox.Show("Nice! That's a match! You also got an extra life!")
            intCount = 0
            intCoin10 = 0
            intCoin20 = 0
            intShroom = 0
            intFlower = 0
            intStar = 0
            int1UP = 0
            intLives += 1
            intMatch += 1
            If intMatch Mod 9 = 0 Then
                MessageBox.Show("Congratulations on beating round " & intRound & "! I will give you 5 more lives to help you beat round " & intRound + 1 & ". Good luck!")
                intLives += 5
                intRound += 1
                lblMatched.Text = "Matches: " & intMatch & vbCrLf & "  Round: " & intRound & vbCrLf & "  Tries: " & intLives
                hideCards()
            End If
        ElseIf intCount = 2 Then
            MessageBox.Show("No match...")
            intCount = 0
            intCoin10 = 0
            intCoin20 = 0
            intShroom = 0
            intFlower = 0
            intStar = 0
            int1UP = 0
            btnButton.BackgroundImage = My.Resources.CN
            btnButton2.BackgroundImage = My.Resources.CN
            btnButton.Enabled = True
            btnButton2.Enabled = True
            intLives -= 1
        End If
        lblMatched.Text = "Matches: " & intMatch & vbCrLf & "  Round: " & intRound & vbCrLf & "  Tries: " & intLives
        Console.WriteLine(intMatch & vbCrLf)


        If intLives = 0 Then
            btn1.Enabled = False
            btn2.Enabled = False
            btn3.Enabled = False
            btn4.Enabled = False
            btn5.Enabled = False
            btn6.Enabled = False
            btn7.Enabled = False
            btn8.Enabled = False
            btn9.Enabled = False
            btn10.Enabled = False
            btn11.Enabled = False
            btn12.Enabled = False
            btn13.Enabled = False
            btn14.Enabled = False
            btn15.Enabled = False
            btn17.Enabled = False
            btn18.Enabled = False
            btn19.Enabled = False
            showBoard()
            MessageBox.Show("Oh no! You lost. Click on ""Reset"" to start another game!")
        End If


    End Sub

    Private Sub hideCards()
        intBoard(0, 0) = 0
        intBoard(1, 0) = 0
        intBoard(2, 0) = 0
        intBoard(3, 0) = 0
        intBoard(4, 0) = 0
        intBoard(5, 0) = 0
        intBoard(0, 1) = 0
        intBoard(1, 1) = 0
        intBoard(2, 1) = 0
        intBoard(3, 1) = 0
        intBoard(4, 1) = 0
        intBoard(5, 1) = 0
        intBoard(0, 2) = 0
        intBoard(1, 2) = 0
        intBoard(2, 2) = 0
        intBoard(3, 2) = 0
        intBoard(4, 2) = 0
        intBoard(5, 2) = 0
        btn1.Enabled = True
        btn2.Enabled = True
        btn3.Enabled = True
        btn4.Enabled = True
        btn5.Enabled = True
        btn6.Enabled = True
        btn7.Enabled = True
        btn8.Enabled = True
        btn9.Enabled = True
        btn10.Enabled = True
        btn11.Enabled = True
        btn12.Enabled = True
        btn13.Enabled = True
        btn14.Enabled = True
        btn15.Enabled = True
        btn17.Enabled = True
        btn18.Enabled = True
        btn19.Enabled = True
        Dim intPosXY(1) As Integer
        intPosXY(0) = 0
        intPosXY(1) = 0

        'Coin10 1 Position
        intPosXY(0) = Int(Rnd() * 6)
        intPosXY(1) = Int(Rnd() * 3)
        intBoard(intPosXY(0), intPosXY(1)) = 1
        strPos(0) = "" & intPosXY(0) & "," & intPosXY(1)

        'Coin10 2 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) = 1
        intBoard(intPosXY(0), intPosXY(1)) = 2
        strPos(1) = "" & intPosXY(0) & "," & intPosXY(1)

        'Coin10 3 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[21]"
        intBoard(intPosXY(0), intPosXY(1)) = 3
        strPos(2) = "" & intPosXY(0) & "," & intPosXY(1)

        'Coin10 4 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[321]"
        intBoard(intPosXY(0), intPosXY(1)) = 4
        strPos(3) = "" & intPosXY(0) & "," & intPosXY(1)

        'Coin20 1 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[4321]"
        intBoard(intPosXY(0), intPosXY(1)) = 5
        strPos(4) = "" & intPosXY(0) & "," & intPosXY(1)


        'Coin20 2 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[54321]"
        intBoard(intPosXY(0), intPosXY(1)) = 6
        strPos(5) = "" & intPosXY(0) & "," & intPosXY(1)

        'Coin20 3 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[654321]"
        intBoard(intPosXY(0), intPosXY(1)) = 7
        strPos(6) = "" & intPosXY(0) & "," & intPosXY(1)

        'Coin20 4 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[7654321]"
        intBoard(intPosXY(0), intPosXY(1)) = 8
        strPos(7) = "" & intPosXY(0) & "," & intPosXY(1)

        'Shroom 1 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[87654321]"
        intBoard(intPosXY(0), intPosXY(1)) = 9
        strPos(8) = "" & intPosXY(0) & "," & intPosXY(1)

        'Shroom 2 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[987654321]"
        intBoard(intPosXY(0), intPosXY(1)) = 10
        strPos(9) = "" & intPosXY(0) & "," & intPosXY(1)

        'Shroom 3 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[987654321]" Or intBoard(intPosXY(0), intPosXY(1)) = 10
        intBoard(intPosXY(0), intPosXY(1)) = 11
        strPos(10) = "" & intPosXY(0) & "," & intPosXY(1)

        'Shroom 4 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[987654321]" Or intBoard(intPosXY(0), intPosXY(1)) = 10 Or intBoard(intPosXY(0), intPosXY(1)) = 11
        intBoard(intPosXY(0), intPosXY(1)) = 12
        strPos(11) = "" & intPosXY(0) & "," & intPosXY(1)

        'Flower 1 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[987654321]" Or intBoard(intPosXY(0), intPosXY(1)) = 10 Or intBoard(intPosXY(0), intPosXY(1)) = 11 Or intBoard(intPosXY(0), intPosXY(1)) = 12
        intBoard(intPosXY(0), intPosXY(1)) = 13
        strPos(12) = "" & intPosXY(0) & "," & intPosXY(1)

        'Flower 2 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[987654321]" Or intBoard(intPosXY(0), intPosXY(1)) = 10 Or intBoard(intPosXY(0), intPosXY(1)) = 11 Or intBoard(intPosXY(0), intPosXY(1)) = 12 Or intBoard(intPosXY(0), intPosXY(1)) = 13
        intBoard(intPosXY(0), intPosXY(1)) = 14
        strPos(13) = "" & intPosXY(0) & "," & intPosXY(1)

        'Star 1 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[987654321]" Or intBoard(intPosXY(0), intPosXY(1)) = 10 Or intBoard(intPosXY(0), intPosXY(1)) = 11 Or intBoard(intPosXY(0), intPosXY(1)) = 12 Or intBoard(intPosXY(0), intPosXY(1)) = 13 Or intBoard(intPosXY(0), intPosXY(1)) = 14
        intBoard(intPosXY(0), intPosXY(1)) = 15
        strPos(14) = "" & intPosXY(0) & "," & intPosXY(1)

        'Star 2 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[987654321]" Or intBoard(intPosXY(0), intPosXY(1)) = 10 Or intBoard(intPosXY(0), intPosXY(1)) = 11 Or intBoard(intPosXY(0), intPosXY(1)) = 12 Or intBoard(intPosXY(0), intPosXY(1)) = 13 Or intBoard(intPosXY(0), intPosXY(1)) = 14 Or intBoard(intPosXY(0), intPosXY(1)) = 15
        intBoard(intPosXY(0), intPosXY(1)) = 16
        strPos(15) = "" & intPosXY(0) & "," & intPosXY(1)

        '1-UP 1 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[987654321]" Or intBoard(intPosXY(0), intPosXY(1)) = 10 Or intBoard(intPosXY(0), intPosXY(1)) = 11 Or intBoard(intPosXY(0), intPosXY(1)) = 12 Or intBoard(intPosXY(0), intPosXY(1)) = 13 Or intBoard(intPosXY(0), intPosXY(1)) = 14 Or intBoard(intPosXY(0), intPosXY(1)) = 15 Or intBoard(intPosXY(0), intPosXY(1)) = 16
        intBoard(intPosXY(0), intPosXY(1)) = 17
        strPos(16) = "" & intPosXY(0) & "," & intPosXY(1)

        '1-UP 2 position
        Do
            intPosXY(0) = Int(Rnd() * 6)
            intPosXY(1) = Int(Rnd() * 3)
        Loop While intBoard(intPosXY(0), intPosXY(1)) Like "[987654321]" Or intBoard(intPosXY(0), intPosXY(1)) = 10 Or intBoard(intPosXY(0), intPosXY(1)) = 11 Or intBoard(intPosXY(0), intPosXY(1)) = 12 Or intBoard(intPosXY(0), intPosXY(1)) = 13 Or intBoard(intPosXY(0), intPosXY(1)) = 14 Or intBoard(intPosXY(0), intPosXY(1)) = 15 Or intBoard(intPosXY(0), intPosXY(1)) = 16 Or intBoard(intPosXY(0), intPosXY(1)) = 17
        intBoard(intPosXY(0), intPosXY(1)) = 18
        strPos(17) = "" & intPosXY(0) & "," & intPosXY(1)
        btn1.BackgroundImage = My.Resources.CN
        btn2.BackgroundImage = My.Resources.CN
        btn3.BackgroundImage = My.Resources.CN
        btn4.BackgroundImage = My.Resources.CN
        btn5.BackgroundImage = My.Resources.CN
        btn6.BackgroundImage = My.Resources.CN
        btn7.BackgroundImage = My.Resources.CN
        btn8.BackgroundImage = My.Resources.CN
        btn9.BackgroundImage = My.Resources.CN
        btn10.BackgroundImage = My.Resources.CN
        btn11.BackgroundImage = My.Resources.CN
        btn12.BackgroundImage = My.Resources.CN
        btn13.BackgroundImage = My.Resources.CN
        btn14.BackgroundImage = My.Resources.CN
        btn15.BackgroundImage = My.Resources.CN
        btn17.BackgroundImage = My.Resources.CN
        btn18.BackgroundImage = My.Resources.CN
        btn19.BackgroundImage = My.Resources.CN

    End Sub

    Private Sub btnToss_Click(sender As System.Object, e As System.EventArgs) Handles btnToss.Click
        intCount = 0
        intCoin10 = 0
        intCoin20 = 0
        intShroom = 0
        intFlower = 0
        intStar = 0
        int1UP = 0
        intLives = 10
        intMatch = 0
        intRound = 1
        lblMatched.Text = "Matches: 0" & vbCrLf & "  Round: 1" & vbCrLf & "  Tries: " & intLives
        hideCards()
    End Sub
    Private Sub showBoard()
        Dim ctl As Control
        For Each ctl In Me.Controls
            If TypeOf ctl Is Button Then
                If ctl.Tag = strPos(0) Or ctl.Tag = strPos(1) Or ctl.Tag = strPos(2) Or ctl.Tag = strPos(3) Then
                    ctl.BackgroundImage = My.Resources.CCoin10
                ElseIf ctl.Tag = strPos(4) Or ctl.Tag = strPos(5) Or ctl.Tag = strPos(6) Or ctl.Tag = strPos(7) Then
                    ctl.BackgroundImage = My.Resources.CCoin20
                ElseIf ctl.Tag = strPos(8) Or ctl.Tag = strPos(9) Or ctl.Tag = strPos(10) Or ctl.Tag = strPos(11) Then
                    ctl.BackgroundImage = My.Resources.Cmushroom
                ElseIf ctl.Tag = strPos(12) Or ctl.Tag = strPos(13) Then
                    ctl.BackgroundImage = My.Resources.CFlower
                ElseIf ctl.Tag = strPos(14) Or ctl.Tag = strPos(15) Then
                    ctl.BackgroundImage = My.Resources.CStar
                ElseIf ctl.Tag = strPos(16) Or ctl.Tag = strPos(17) Then
                    ctl.BackgroundImage = My.Resources.C1up
                End If
            End If
        Next ctl
    End Sub
End Class
Public Class Form1

    Private Const CONSTV = 0
    Private Const ACC = 1
    Private Const MULTINOMIAL = 2
    Private Const COS = 3
    Private Const SIN = 4

    Private Const ANGLE_STEP = 2 * Math.PI / 36
    Private Const PI2 = 2 * Math.PI

    Dim motionLaw As Integer
    Dim h1 As Double
    Dim s0 As Double
    Dim r0 As Double
    Dim rr As Double
    Dim e0 As Double
    Dim angle_push As Double
    Dim angle_far As Double
    Dim angle_back As Double

    Dim x As Double
    Dim y As Double

    Dim x0 As Double
    Dim y0 As Double

    Dim xb As Single
    Dim yb As Single

    Dim s As Double


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim r As Double

        Dim bm As New Bitmap(591, 658)
        Dim camGraphics As Graphics = Graphics.FromImage(bm)


        Try
            h1 = TextBox1.Text
            e0 = TextBox2.Text
            r0 = TextBox3.Text
            angle_push = TextBox4.Text * Math.PI / 180
            angle_far = TextBox5.Text * Math.PI / 180
            angle_back = TextBox6.Text * Math.PI / 180
            rr = TextBox7.Text

            '判断e0的正负
            e0 = getE()
            '获得运动规律
            motionLaw = mLaw()

            If motionLaw = MULTINOMIAL Then
                MessageBox.Show("还没做！")
                Return
            End If

            '计算s0
            s0 = Math.Sqrt(Math.Pow(r0, 2) + Math.Pow(e0, 2))

            RichTextBox1.Text = ""
            PictureBox1.Image = Nothing

            For angle = 0 To PI2 Step ANGLE_STEP

                Call getXY(rr, angle)
                If angle > 0 Then

                    r = Math.Sqrt(Math.Pow(xb, 2) + Math.Pow(yb, 2)) '到原点距离

                    'RichTextBox1.AppendText("angle = " & Format(angle * 180 / Math.PI, "###0.000") & ", r = " & Format(r, "###0.000") & Chr(13))

                    '放大
                    r = 4 * r

                    Dim px As Single
                    px = r * Math.Cos(angle) + 260
                    Dim py As Single
                    py = r * Math.Sin(angle) + 290

                    camGraphics.FillRectangle(Brushes.Black, px, py, 2.0F, 2.0F)
                End If
                PictureBox1.Image = bm
            Next
            camGraphics.FillEllipse(Brushes.Black, 260.0F, 290.0F, 5.0F, 5.0F)
            PictureBox1.Image = bm
        Catch ex As Exception
            MessageBox.Show("请输入数值！")
        End Try


    End Sub

    Private Sub getXY(ByVal rr As Double, ByVal angle As Double)        '计算b点轮廓线

        getTheoreticalXY(angle, False)

        If angle > 0 Then
            Dim dx, dy, factorx, factory As Double

            getTheoreticalXY(angle - ANGLE_STEP, True)

            dx = Math.Abs(x - x0)
            dy = Math.Abs(y - y0)

            factorx = rr * (dy / ANGLE_STEP) / Math.Sqrt(Math.Pow(dx / ANGLE_STEP, 2) + Math.Pow(dy / ANGLE_STEP, 2))
            factory = rr * (dx / ANGLE_STEP) / Math.Sqrt(Math.Pow(dx / ANGLE_STEP, 2) + Math.Pow(dy / ANGLE_STEP, 2))

            If (Math.PI / 2) < angle And angle <= (Math.PI) Then
                xb = x - factorx
                yb = y + factory
            ElseIf (Math.PI) < angle And angle <= (3 * Math.PI / 2) Then
                xb = x + factorx
                yb = y + factory
            ElseIf (3 * Math.PI / 2) < angle And angle < (PI2) Then
                xb = x + factorx
                yb = y - factory
            Else
                xb = x - factorx
                yb = y - factory

            End If
        End If

    End Sub

    Private Sub getTheoreticalXY(ByVal angle As Double, ByVal ispre_x As Boolean)     '计算理论轮廓线

        s = getS(motionLaw, angle, h1, angle_push, angle_far, angle_back)

        If ispre_x Then
            x0 = (s + s0) * Math.Sin(angle) + e0 * Math.Cos(angle)
            y0 = (s + s0) * Math.Cos(angle) - e0 * Math.Sin(angle)

        Else
            x = (s + s0) * Math.Sin(angle) + e0 * Math.Cos(angle)
            y = (s + s0) * Math.Cos(angle) - e0 * Math.Sin(angle)
            RichTextBox1.AppendText(angle * 180 / Math.PI & "    " & s & Chr(13))
        End If

    End Sub

    Private Function mLaw() As Integer     '选择运动规律

        If RadioButton1.Checked Then
            mLaw = CONSTV
        ElseIf RadioButton2.Checked Then
            mLaw = ACC
        ElseIf RadioButton3.Checked Then
            mLaw = MULTINOMIAL
        ElseIf RadioButton4.Checked Then
            mLaw = COS
        Else
            mLaw = SIN

        End If
    End Function

    Private Function getE() As Double  '判断e的正负
        If (CheckBox1.Checked And CheckBox2.Checked) Or ((Not CheckBox1.Checked) And (Not CheckBox2.Checked)) Then
            getE = Math.Abs(e0)
        Else
            getE = -Math.Abs(e0)
        End If

    End Function

    Private Function getS(ByRef MotionLaw As Integer, ByRef angle As Double, ByRef h As Double,
                     ByRef angle_p As Double, ByRef angle_f As Double, ByRef angle_b As Double) As Double  '计算s

        Select Case MotionLaw

            Case CONSTV
                '等速
                If 0 < angle And angle <= angle_p Then
                    getS = h * angle / angle_p

                ElseIf angle_p < angle And angle <= (angle_b + angle_far) Then
                    getS = h

                ElseIf (angle_p + angle_f) < angle And angle <= (angle_p + angle_f + angle_b) Then
                    getS = h - h * (angle - (angle_p + angle_f)) / angle_b

                Else
                    getS = 0

                End If
            Case ACC
                '等加速度
                If 0 < angle And angle <= angle_p Then
                    getS = 2 * h * Math.Pow(angle, 2) / Math.Pow(angle_p, 2)

                ElseIf angle_p < angle And angle <= (angle_b + angle_far) Then
                    getS = h

                ElseIf (angle_p + angle_f) < angle And angle <= (angle_p + angle_f + angle_b) Then
                    getS = h - 2 * h * Math.Pow((angle - (angle_p + angle_f)), 2) / Math.Pow(angle_p, 2)

                Else
                    getS = 0
                End If
            Case MULTINOMIAL
                getS = 0        '多项式 不写】
            Case COS
                '余弦
                If 0 < angle And angle <= angle_p Then
                    getS = h / 2 - h * Math.Cos(Math.PI * angle / angle_p) / 2

                ElseIf angle_p < angle And angle <= (angle_b + angle_far) Then
                    getS = h

                ElseIf (angle_p + angle_f) < angle And angle <= (angle_p + angle_f + angle_b) Then
                    getS = h / 2 + h * Math.Cos(Math.PI * (angle - (angle_p + angle_f)) / angle_b) / 2

                Else
                    getS = 0
                End If
            Case Else
                '正弦
                If 0 < angle And angle <= angle_p Then
                    getS = h * angle / angle_p - (h * Math.Sin(PI2 * angle / angle_p)) / PI2

                ElseIf angle_p < angle And angle <= (angle_b + angle_far) Then
                    getS = h

                ElseIf (angle_p + angle_f) < angle And angle <= (angle_p + angle_f + angle_b) Then
                    getS = h - h * (angle - (angle_p + angle_f)) / angle_b + h * Math.Sin(PI2 * (angle - (angle_p + angle_f))) / PI2

                Else
                    getS = 0

                End If
        End Select

    End Function
End Class

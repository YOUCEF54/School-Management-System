Imports LiveCharts
Imports LiveCharts.Defaults
Imports LiveCharts.Wpf




Imports System.Data.SqlClient
Public Class Form1
    Dim x As Integer
    Dim int As Integer
    Dim f As String
    Private Property MoveFrom As Boolean
    Private Property MoveForm_MousePosition As Point

    Dim cn As New SqlConnection("Data Source=DESKTOP-1V5IDJB\SQLEXPRESS;Initial Catalog=GT_NOTES;Integrated Security=True")



    Public Sub CountV()
        cn.Open()
        Dim cmd As New SqlCommand("select ville , count(*)  from ETUDIANT group by ville order by count(*) ", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        While dr.Read

            Guna2HtmlLabel6.Text = dr(0)

        End While
        cn.Close()
    End Sub
    Public Sub CountE()
        cn.Open()
        Dim cmd As New SqlCommand("select Count(*) from ETUDIANT ", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        While dr.Read
            Guna2HtmlLabel3.Text = dr(0) & " Etudiants"
            int = dr(0)
        End While
        cn.Close()
    End Sub

    Public Sub Countboy()
        cn.Open()
        Dim b = Guna2HtmlLabel3.Text
        Dim cmd As New SqlCommand("select Count(*) from ETUDIANT where genre = 'male'", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()

        If int = 0 Then

            msg.Show()

        Else While dr.Read
                x = ((dr(0) * 100) / int)
                ''Guna2CircleProgressBar1.Value = x
            End While

        End If
        cn.Close()
    End Sub

    Public Sub Countgirl()


        cn.Open()
        Dim b = Guna2HtmlLabel3.Text
        Dim cmd As New SqlCommand("select Count(*) from ETUDIANT where genre = 'female'", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        If int = 0 Then

            msg.Show()

        Else While dr.Read
                x = ((dr(0) * 100) / int)
                ''Guna2CircleProgressBar2.Value = x
            End While
        End If

        cn.Close()
    End Sub



    Private Sub remplissage()
        cn.Open()
        Dim cmd As New SqlCommand("select * from ETUDIANT order by ville ", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        While dr.Read
            DataGridView.Guna2DataGridView1.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), "null", dr(5))
        End While

        cn.Close()

    End Sub


    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs)

    End Sub





    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        Dim response As Integer

        response = MessageBox.Show("êtes-vous sûr de vouloir quitter ?", "Exit application",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If response = vbYes Then
            Application.ExitThread()

        End If
    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CountV()
        CountE()
        remplissage()
        Guna2ShadowForm1.SetShadowForm(Me)
        Countboy()
        Countgirl()
        Timer1.Enabled = True
        chart()

    End Sub

    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Guna2PictureBox3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Guna2Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveFrom = True
            Me.Cursor = Cursors.Default
            MoveForm_MousePosition = e.Location
        End If
    End Sub

    Private Sub Guna2Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Guna2Panel1.MouseUp
        If e.Button = MouseButtons.Left Then
            MoveFrom = False
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Guna2Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2Panel1.MouseMove
        If MoveFrom Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
        End If
    End Sub




    Private Sub Guna2Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Guna2PictureBox4_Click_1(sender As Object, e As EventArgs) Handles Guna2PictureBox4.Click
        If Guna2Panel2.Width = 58 Then
            Guna2Panel8.Width = 1005
            Guna2Panel8.Location = New Point(371, 134)
            Guna2HtmlLabel10.Visible = True
            Guna2HtmlLabel1.Visible = False
            Guna2ImageButton1.Visible = False
            Guna2Button7.Visible = True
            Guna2Panel2.Visible = False
            Guna2Panel2.Width = 364
            DataGridView.Guna2DataGridView1.Location = New Point(379, 143)
            DataGridView.Guna2DataGridView1.Width = 1110
            Animator1.ShowSync(Guna2Panel2)


        Else
            Guna2Panel8.Location = New Point(64, 134)
            Guna2Panel8.Width = 1312
            Guna2HtmlLabel1.Visible = True
            Guna2HtmlLabel10.Visible = False
            Guna2Panel2.Visible = False
            Guna2Panel2.Width = 58
            DataGridView.Guna2DataGridView1.Location = New Point(76, 143)
            DataGridView.Guna2DataGridView1.Width = 1413
            Guna2Button7.Visible = False
            Animator2.ShowSync(Guna2Panel2)
            Guna2ImageButton1.Visible = True

        End If
    End Sub

    Private Sub Guna2Button1_Click_1(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        AjoutForm.Show()
    End Sub

    Private Sub Guna2Button2_Click_1(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        SuppForm.Show()
    End Sub

    Private Sub Guna2Button3_Click_1(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        updatForm.Show()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs)
        LoginForm.Show()
    End Sub

    Private Sub Guna2Button5_Click_1(sender As Object, e As EventArgs) Handles Guna2Button5.Click

        DataGridView.Show()
    End Sub



    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        settingsFrom.Show()
    End Sub



    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs) Handles Guna2Button10.Click
        Matier.Show()
    End Sub

    Private Sub Guna2ImageButton2_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click

    End Sub

    Private Sub Guna2ImageButton2_Click_1(sender As Object, e As EventArgs) Handles Guna2ImageButton2.Click
        LoginForm.Show()
    End Sub

    Private Sub Guna2TileButton2_Click(sender As Object, e As EventArgs) Handles Guna2TileButton2.Click
        Call remplissage()
        Call Countboy()
        Call Countgirl()
        Call CountE()
    End Sub

    Private Sub Guna2TileButton1_Click(sender As Object, e As EventArgs) Handles Guna2TileButton1.Click
        Dim response As Integer

        response = MessageBox.Show("êtes-vous sûr de vouloir suprimer tout les donnees ?", "suprimer tout",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If response = vbYes Then
            cn.Open()

            Dim cmd As New SqlCommand("delete  from ETUDIANT", cn)
            cmd.ExecuteNonQuery()
            cn.Close()
            Call Countboy()
            Call Countgirl()
            Call CountE()

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Guna2HtmlLabel11.Text = Date.Now.ToString("hh:mm") & " pm"
    End Sub

    Private Sub Guna2Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel3.Paint

    End Sub

    Private Sub Guna2Button6_Click_1(sender As Object, e As EventArgs) Handles Guna2Button6.Click






    End Sub





    Private Sub chart()
        CartesianChart1.Series = New SeriesCollection From {
            New LineSeries With {
                .Values = New ChartValues(Of ObservablePoint) From {
                    New ObservablePoint(0, 10),
                    New ObservablePoint(4, 7),
                    New ObservablePoint(5, 3),
                    New ObservablePoint(7, 6),
                    New ObservablePoint(10, 8)
                },
                .PointGeometrySize = 25
            },
            New LineSeries With {
                .Values = New ChartValues(Of ObservablePoint) From {
                    New ObservablePoint(0, 2),
                    New ObservablePoint(2, 5),
                    New ObservablePoint(3, 6),
                    New ObservablePoint(6, 8),
                    New ObservablePoint(10, 5)
                },
                .PointGeometrySize = 15
             },
             New LineSeries With {
                .Values = New ChartValues(Of ObservablePoint) From {
                    New ObservablePoint(0, 4),
                    New ObservablePoint(5, 5),
                    New ObservablePoint(7, 7),
                    New ObservablePoint(9, 10),
                    New ObservablePoint(10, 9)
                },
                .PointGeometrySize = 15
             }
        }
    End Sub

End Class

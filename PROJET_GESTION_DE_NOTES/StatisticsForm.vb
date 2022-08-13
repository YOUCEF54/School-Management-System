Imports System.Data.SqlClient
Public Class StatisticsForm

    Dim x As Integer

    Dim int As Integer
    Private Property MoveFrom As Boolean
    Private Property MoveForm_MousePosition As Point


    ReadOnly cn As New SqlConnection("Data Source=DESKTOP-1V5IDJB\SQLEXPRESS;Initial Catalog=GT_NOTES;Integrated Security=True")

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
            Guna2HtmlLabel3.Text = dr(0)
            Int = dr(0)
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
            Form1.Show()
            MessageBox.Show("the table is empty !")

        Else While dr.Read
                x = ((dr(0) * 100) / int)
                Guna2CircleProgressBar1.Value = x
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
            Form1.Show()
            MessageBox.Show("the table is empty !")

        Else While dr.Read
                x = ((dr(0) * 100) / int)
                Guna2CircleProgressBar2.Value = x
            End While
        End If

        cn.Close()
    End Sub
    Private Sub StatisticsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CountV()
        Countboy()
        CountE()
        Countgirl()
        Guna2ShadowForm1.SetShadowForm(Me)




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



End Class
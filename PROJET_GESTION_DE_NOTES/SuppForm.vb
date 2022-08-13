Imports System.Data.SqlClient
Public Class SuppForm
    Private Property MoveFrom As Boolean
    Private Property MoveForm_MousePosition As Point

    Dim cn As New SqlConnection("Data Source=DESKTOP-1V5IDJB\SQLEXPRESS;Initial Catalog=GT_NOTES;Integrated Security=True")
    Private Sub remplissage()

        Dim cmd As New SqlCommand("select * from ETUDIANT", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        While dr.Read
            DataGridView.Guna2DataGridView1.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(6), dr(5))
        End While



    End Sub

    Private Sub scomb()
        cn.Open()
        Dim cmd As New SqlCommand("select * from ETUDIANT", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        Guna2ComboBox1.Items.Clear()

        While dr.Read

            Guna2ComboBox1.Items.Add(dr(0))


        End While
        cn.Close()
    End Sub


    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.Close()
    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click

        cn.Open()
        Dim cmd As New SqlCommand("select * from ETUDIANT where CodeEtudiant = @CodeEtudiant ", cn)
        cmd.Parameters.Add("@CodeEtudiant", SqlDbType.VarChar).Value = Guna2ComboBox1.Text
        Dim adabter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adabter.Fill(table)

        Dim cd As New SqlCommand("delete from ETUDIANT where CodeEtudiant='" & Guna2ComboBox1.Text & "'", cn)
        cd.ExecuteNonQuery()
        DataGridView.Guna2DataGridView1.Rows.Clear()
        Call remplissage()

        cn.Close()
        StatisticsForm.CountE()
        StatisticsForm.Countboy()
        StatisticsForm.Countgirl()




    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2ShadowForm1.SetShadowForm(Me)
        Call scomb()
    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint

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

    Private Sub Guna2HtmlLabel1_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel1.Click

    End Sub

    Private Sub Guna2ComboBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class
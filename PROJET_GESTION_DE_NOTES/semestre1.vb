Imports System.Data.SqlClient
Public Class semestre1
    Dim code As String
    Private Property MoveFrom As Boolean
    Private Property MoveForm_MousePosition As Point

    Dim cn As New SqlConnection("Data Source=DESKTOP-1V5IDJB\SQLEXPRESS;Initial Catalog=GT_NOTES;Integrated Security=True")

    Private Sub Remplissage()
        cn.Open()
        Dim cmd As New SqlCommand("select * from EVALUER", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        While dr.Read
            DataGridView.Guna2DataGridView1.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
        End While

        cn.Close()

    End Sub

    Private Sub Rcomb1()
        Guna2ShadowForm1.SetShadowForm(Me)
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

    Private Sub Rcomb2()
        Guna2ShadowForm1.SetShadowForm(Me)
        cn.Open()
        Dim cmd As New SqlCommand("select * from MATIAIRE", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        Guna2ComboBox2.Items.Clear()

        While dr.Read

            Guna2ComboBox2.Items.Add(dr(0))


        End While

        cn.Close()
    End Sub



    Private Sub semestre1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Rcomb1()
        Call Rcomb2()

    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        MessageBox.Show(code)
        If Guna2TextBox1.TextLength = 0 Or Guna2TextBox2.TextLength = 0 Then

            Guna2TextBox1.BorderColor = Color.Red
            Guna2TextBox2.BorderColor = Color.Red


        Else
            cn.Open()
            Dim cmd As New SqlCommand("insert into EVALUER values ('" & Guna2ComboBox1.Text & "',
                                                                    '" & Guna2ComboBox2.Text & "',
                                                                    " & Guna2TextBox1.Text & " ,
                                                                    '" & Guna2TextBox2.Text & "',
                                                                    '" & Guna2ComboBox4.Text & "',
                                                                    '" & Guna2ComboBox3.Text & "' )", cn)

            cmd.ExecuteNonQuery()
            cn.Close()
            DataGridView.Guna2DataGridView1.Rows.Clear()
            Call Remplissage()
        End If

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.Close()
    End Sub

    Private Sub Guna2ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2ComboBox1.SelectedIndexChanged

    End Sub
End Class
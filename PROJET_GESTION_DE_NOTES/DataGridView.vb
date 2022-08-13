Imports System.Data.SqlClient
Public Class DataGridView
    Dim cn As New SqlConnection("Data Source=DESKTOP-1V5IDJB\SQLEXPRESS;Initial Catalog=GT_NOTES;Integrated Security=True")

    Private Sub remplissage()
        cn.Open()
        Dim cmd As New SqlCommand("select * from ETUDIANT order by ville ", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        While dr.Read
            Guna2DataGridView1.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), "null", dr(5))
        End While

        cn.Close()

    End Sub

    Private Sub FilterData()
        cn.Open()

        Dim cmd As New SqlCommand("select * from ETUDIANT where CONCAT(Nom, Prenom, ville ) like '%" & Guna2TextBox1.Text & "%'", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        While dr.Read
            Guna2DataGridView1.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), "null", dr(5))
        End While
        cn.Close()
    End Sub
    Private Sub DataGridView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2DataGridView1.Rows.Clear()
        remplissage()
    End Sub

    Private Sub Guna2TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged
        Guna2DataGridView1.Rows.Clear()
        FilterData()
    End Sub
End Class
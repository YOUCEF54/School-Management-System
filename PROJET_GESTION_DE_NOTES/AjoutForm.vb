
Imports System.Data.SqlClient

Public Class AjoutForm
    Dim todaye, dp As Integer


    Private Property MoveFrom As Boolean
    Private Property MoveForm_MousePosition As Point

    ReadOnly cn As New SqlConnection("Data Source=DESKTOP-1V5IDJB\SQLEXPRESS;Initial Catalog=GT_NOTES;Integrated Security=True")

    Private Sub Ajout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2ShadowForm1.SetShadowForm(Me)

    End Sub


    Private Sub Remplissage()
        cn.Open()
        Dim cmd As New SqlCommand("select * from ETUDIANT", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        While dr.Read
            DataGridView.Guna2DataGridView1.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(6), dr(5))
        End While

        cn.Close()

    End Sub
    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        If Guna2TextBox1.TextLength = 0 Or Guna2TextBox2.TextLength = 0 Or Guna2TextBox3.TextLength = 0 Or Guna2DateTimePicker1.ToString.Length = 0 Then

            Guna2TextBox1.BorderColor = Color.Red
            Guna2TextBox2.BorderColor = Color.Red
            Guna2TextBox3.BorderColor = Color.Red
            Guna2DateTimePicker1.BorderColor = Color.Red
            Guna2ComboBox2.BorderColor = Color.Red
            Guna2ComboBox1.BorderColor = Color.Red

        Else
            cn.Open()
            Dim cmd As New SqlCommand("select * from ETUDIANT where CodeEtudiant = '" & Guna2TextBox1.Text & "'", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                If dr(0) = Guna2TextBox1.Text Then
                    MessageBox.Show("existe befor!")
                    Guna2TextBox1.Clear()
                    Guna2TextBox2.Clear()
                    Guna2TextBox3.Clear()
                Else
                    Dim age As Integer
                    todaye = Date.Today.Year
                    dp = Guna2DateTimePicker1.Value.Year
                    age = todaye - dp

                    cn.Open()
                    Dim cd As New SqlCommand("insert into ETUDIANT values ('" & Guna2TextBox1.Text & "',
                                                                '" & Guna2TextBox2.Text & "',
                                                                '" & Guna2TextBox3.Text & "',
                                                                '" & Guna2DateTimePicker1.MinDate & "',
                                                                '" & Guna2ComboBox2.Text & "',
                                                                '" & Guna2ComboBox1.Text & "',
                                                                " & age & ")", cn)
                    cd.ExecuteNonQuery()
                    cn.Close()
                    DataGridView.Guna2DataGridView1.Rows.Clear()
                    Call Remplissage()
                    popmsg.Show()
                End If
            End While

            cn.Close()

        End If
        StatisticsForm.CountE()
        StatisticsForm.Countboy()
        StatisticsForm.Countgirl()


    End Sub

    Private Sub Timer()
        Me.Close()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.Close()
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
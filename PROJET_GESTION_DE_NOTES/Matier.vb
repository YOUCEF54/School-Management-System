Imports System.Data.SqlClient
Public Class Matier
    Private Property MoveFrom As Boolean
    Private Property MoveForm_MousePosition As Point

    ReadOnly cn As New SqlConnection("Data Source=DESKTOP-1V5IDJB\SQLEXPRESS;Initial Catalog=GT_NOTES;Integrated Security=True")
    Private Sub Matier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2ShadowForm1.SetShadowForm(Me)
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

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.Close()
    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        If Guna2TextBox1.TextLength = 0 Or Guna2TextBox2.TextLength = 0 Or Guna2TextBox3.TextLength = 0 Then

            Guna2TextBox1.BorderColor = Color.Red
            Guna2TextBox2.BorderColor = Color.Red
            Guna2TextBox3.BorderColor = Color.Red


        Else

            cn.Open()
            Dim cmd As New SqlCommand("insert into MATIAIRE values ('" & Guna2TextBox1.Text & "',
                                                                '" & Guna2TextBox2.Text & "',
                                                                " & Guna2TextBox3.Text & ")", cn)
            cmd.ExecuteNonQuery()
            cn.Close()
        End If
        Me.Close()
    End Sub
End Class
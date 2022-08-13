Imports System.Data.SqlClient
Public Class LoginForm
    Private Property MoveFrom As Boolean
    Private Property MoveForm_MousePosition As Point





    Private Sub Guna2Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Guna2Panel2.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveFrom = True
            Me.Cursor = Cursors.Default
            MoveForm_MousePosition = e.Location
        End If
    End Sub

    Private Sub Guna2Panel2_MouseUp(sender As Object, e As MouseEventArgs) Handles Guna2Panel2.MouseUp
        If e.Button = MouseButtons.Left Then
            MoveFrom = False
            Me.Cursor = Cursors.Default
        End If
    End Sub



    Private Sub Guna2Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2Panel2.MouseMove
        If MoveFrom Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
        End If
    End Sub




    Private Sub Guna2Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles Guna2Panel3.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveFrom = True
            Me.Cursor = Cursors.Default
            MoveForm_MousePosition = e.Location
        End If
    End Sub


    Private Sub Guna2Panel3_MouseUp(sender As Object, e As MouseEventArgs) Handles Guna2Panel3.MouseUp
        If e.Button = MouseButtons.Left Then
            MoveFrom = False
            Me.Cursor = Cursors.Default
        End If
    End Sub




    Private Sub Guna2Panel3_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2Panel3.MouseMove
        If MoveFrom Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
        End If
    End Sub



    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2ShadowForm1.SetShadowForm(Me)
    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        Close()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click


        Dim cn As New SqlConnection("Data Source=DESKTOP-1V5IDJB\SQLEXPRESS;Initial Catalog=GT_NOTES;Integrated Security=True")
        Dim cmd As New SqlCommand("select * from Professeur where username = @username and ID = @ID", cn)
        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = Guna2TextBox2.Text
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Guna2TextBox1.Text
        Dim adabter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adabter.Fill(table)


        If table.Rows.Count() <= 0 Then

            Guna2TextBox1.Clear()
            Guna2TextBox2.Clear()
            MessageBox.Show("Username or password are invalid")
        Else
            Close()
            Form1.Hide()
            ProfSpace.Show()
        End If
    End Sub

    Private Sub Guna2Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel2.Paint

    End Sub

    Private Sub LoginForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        Dim cn As New SqlConnection("Data Source=DESKTOP-1V5IDJB\SQLEXPRESS;Initial Catalog=GT_NOTES;Integrated Security=True")
        Dim cmd As New SqlCommand("select * from Professeur where username = @username and ID = @ID", cn)
        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = Guna2TextBox2.Text
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Guna2TextBox1.Text
        Dim adabter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adabter.Fill(table)


        If table.Rows.Count() <= 0 Then

            Guna2TextBox1.Clear()
            Guna2TextBox2.Clear()
            MessageBox.Show("Username or password are invalid")
        Else
            Close()
            Form1.Hide()
            ProfSpace.Show()
        End If
    End Sub
End Class
Imports System.Data.SqlClient
Public Class updatForm
    Private Property MoveFrom As Boolean
    Private Property MoveForm_MousePosition As Point

    Dim cn As New SqlConnection("Data Source=DESKTOP-1V5IDJB\SQLEXPRESS;Initial Catalog=GT_NOTES;Integrated Security=True")




    Private Sub remplissage()
        cn.Open()
        Dim cmd As New SqlCommand("select * from ETUDIANT", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        While dr.Read
            DataGridView.Guna2DataGridView1.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(6), dr(5))
        End While

        cn.Close()

    End Sub
    Private Sub modifier()
        cn.Open()
        Dim cmd As New SqlCommand("update ETUDIANT set Nom = '" & Guna2TextBox2.Text & "' where CodeEtudiant = '" & Guna2ComboBox3.Text & "';
                                   update ETUDIANT set Prenom = '" & Guna2TextBox3.Text & "' where CodeEtudiant =' " & Guna2ComboBox3.Text & "';
                                   update ETUDIANT set Date_nais = '" & Guna2TextBox4.Text & "' where CodeEtudiant =' " & Guna2ComboBox3.Text & "';
                                   update ETUDIANT set ville = '" & Guna2ComboBox2.Text & "' where CodeEtudiant = '" & Guna2ComboBox3.Text & "';
                                   update ETUDIANT set genre = '" & Guna2ComboBox1.Text & "' where CodeEtudiant = '" & Guna2ComboBox3.Text & "';", cn)
        cmd.ExecuteReader()

        cn.Close()
        DataGridView.Guna2DataGridView1.Rows.Clear()
        Call remplissage()
    End Sub
    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        Call modifier()

        Guna2ComboBox3.BorderColor = Color.Green
        Guna2TextBox2.BorderColor = Color.Green
        Guna2TextBox3.BorderColor = Color.Green
        Guna2TextBox4.BorderColor = Color.Green
        Guna2ComboBox2.BorderColor = Color.Green
        Guna2ComboBox1.BorderColor = Color.Green


    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2ShadowForm1.SetShadowForm(Me)

        cn.Open()
        Dim cmd As New SqlCommand("select * from ETUDIANT", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        Guna2ComboBox3.Items.Clear()

        While dr.Read

            Guna2ComboBox3.Items.Add(dr(0))


        End While
        cn.Close()


        'Dim index As Integer
        'Index = DataGridView.Guna2DataGridView1.CurrentCell.RowIndex
        'Guna2TextBox1.Text = DataGridView.Guna2DataGridView1.Rows(index).Cells(0).Value.ToString
        'Guna2TextBox2.Text = DataGridView.Guna2DataGridView1.Rows(index).Cells(1).Value.ToString
        'Guna2TextBox3.Text = DataGridView.Guna2DataGridView1.Rows(index).Cells(2).Value.ToString
        'Guna2TextBox4.Text = DataGridView.Guna2DataGridView1.Rows(index).Cells(3).Value.ToString
        'Guna2ComboBox2.Text = DataGridView.Guna2DataGridView1.Rows(index).Cells(4).Value.ToString
        'Guna2ComboBox1.Text = DataGridView.Guna2DataGridView1.Rows(index).Cells(5).Value.ToString
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

    Private Sub Guna2ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2ComboBox3.SelectedIndexChanged
        MessageBox.Show("OK!")
    End Sub
End Class
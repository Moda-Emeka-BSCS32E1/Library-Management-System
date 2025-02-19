﻿Imports System.Data.OleDb

Public Class List_of_Students

    Private Sub List_of_Students_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\emeka\Documents\Shauna-Library-Management-System-main\Shauna Library Management System.accdb"

        ' Verify the file path
        If Not System.IO.File.Exists("C:\Users\emeka\Documents\Shauna-Library-Management-System-main\Shauna Library Management System.accdb") Then
            MessageBox.Show("Database file not found!")
            Return
        End If

        Using connection As New OleDbConnection(connectionString)
            Try
                connection.Open()
                Dim command As New OleDbCommand("SELECT * FROM Students", connection)
                Dim adapter As New OleDbDataAdapter(command)
                Dim dataset As New DataSet()
                adapter.Fill(dataset, "Students")

                ' Assuming you have a DataGridView or similar control to display data
                ' For example: DataGridView1.DataSource = dataset.Tables("Students")

                ' Populate the dataset in the table adapter
                Me.StudentsTableAdapter.Fill(Me.Students_Dataset.Students)
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try

        End Using
    End Sub


    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Me.StudentsBindingSource.Filter = "[LAST NAME]  like '%" & txtSearch.Text & "'"
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

        Home_Page.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        Home_Page.Show()
        Me.Hide()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Students.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        Students.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        List_of_Books.Show()
        Me.Hide()

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        List_of_Books.Show()
        Me.Hide()

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Books.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        Books.Show()
        Me.Hide()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

        Issue_of_Books.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

        Issue_of_Books.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Return_of_Books.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Return_of_Books.Show()
        Me.Hide()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

        Missing_of_Books.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click

        Missing_of_Books.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("Are you sure to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            LogIn.Show()
            Me.Close()

        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        StudentsTableAdapter.Update(Students_Dataset.Students)

        Me.StudentsTableAdapter.Fill(Me.Students_Dataset.Students)
    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click
        If MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        StudentsBindingSource.MovePrevious()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        StudentsBindingSource.MoveNext()
    End Sub

End Class
Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CbJurusan.Items.Add("Sistem Informasi")
        CbJurusan.Items.Add("Ilmu Komputer")
        CbJurusan.Items.Add("Manajemen Informatika")
    End Sub

    Private Sub CbJurusan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbJurusan.SelectedIndexChanged
        Dim Jurusan As String = CbJurusan.SelectedItem
        CbMataKuliah.Items.Clear()
        Select Case (Jurusan)
            Case "Sistem Informasi"
                CbMataKuliah.Items.Add("Logika Informatika")
                CbMataKuliah.Items.Add("Matematika Diskrit")
                CbMataKuliah.Items.Add("Aljabar Liner")
            Case "Ilmu Komputer"
                CbMataKuliah.Items.Add("Kecerdasan Buatan")
                CbMataKuliah.Items.Add("IOT")
                CbMataKuliah.Items.Add("Robotika")
            Case "Manajemen Informatika"
                CbMataKuliah.Items.Add("Pemrograman Desktop")
                CbMataKuliah.Items.Add("OOP")
                CbMataKuliah.Items.Add("Pemrograman Web")
        End Select
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i = 1 To 10
            ListBox1.Items.Add(i)
        Next i
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer = 1

        Do While (i < 10)
            ListBox1.Items.Add(i)
            i = i + 1
        Loop


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim i As Integer = 1

        Do
            ListBox1.Items.Add(i)
            i = i + 1
        Loop Until (i > 10)
    End Sub
End Class
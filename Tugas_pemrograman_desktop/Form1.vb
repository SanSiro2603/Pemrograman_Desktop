Public Class Form1

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        Dim nim As String = txtNIP.Text
        Dim nama As String = txtNama.Text
        Dim fakultas As String = cmbFakultas.SelectedItem.ToString()
        Dim jurusan As String = cmbJurusan.SelectedItem.ToString()
        Dim jeniskelamin As String = " "

        If rablaki.Checked Then
            jeniskelamin = "Laki-Laki"
        ElseIf rabperempuan.Checked Then
            jeniskelamin = ""
        End If


        MessageBox.Show("Hai : " & nim & vbCrLf &
                        "Nip : " & nama & vbCrLf &
                        "Fakultas : " & fakultas & vbCrLf &
                        "Jurusan : " & jurusan & vbCrLf &
                        "Jenis Kelamin : " & jeniskelamin, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class

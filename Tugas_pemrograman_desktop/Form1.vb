Public Class Form1

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        Dim nim As String = txtNIP.Text
        Dim nama As String = txtNama.Text
        Dim fakultas As String = cmbFakultas.SelectedItem.ToString()
        Dim jurusan As String = cmbJurusan.SelectedItem.ToString()

        MessageBox.Show("Hai : " & nim & vbCrLf &
                        "Nip : " & nama & vbCrLf &
                        "Fakultas : " & fakultas & vbCrLf &
                        "Jurusan : " & jurusan, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class

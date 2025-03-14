Public Class Tugas3

    Private Sub Tugas3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbFakultas.Items.Add("FMIPA")
        cmbFakultas.Items.Add("FEB")
        cmbFakultas.Items.Add("FKIP")
    End Sub

    Private Sub txtNIP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIP.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        Dim nip As Long
        If Not Long.TryParse(txtNIP.Text.Trim(), nip) Then
            Exit Sub
        End If
        Dim nama As String = txtNama.Text.Trim()
        Dim fakultas As String = cmbFakultas.Text.Trim()
        Dim jurusan As String = cmbJurusan.Text.Trim()
        Dim tugas As Double = Double.Parse(txtTugas.Text)
        Dim uts As Double = Double.Parse(txtUts.Text)
        Dim uas As Double = Double.Parse(txtUas.Text)

        Dim total As Double = (tugas * 0.3) + (uts * 0.3) + (uas * 0.4)

        Dim grade As String

        If total >= 78 Then
            grade = "A"
        ElseIf total >= 65 Then
            grade = "B"
        ElseIf total >= 50 Then
            grade = "C"
        ElseIf total >= 40 Then
            grade = "D"
        Else
            grade = "E"
        End If

        Dim jenisKelamin As String = ""
        If rablaki.Checked Then
            jenisKelamin = "Laki-Laki"
        ElseIf rabperempuan.Checked Then
            jenisKelamin = "Perempuan"
        Else
            MessageBox.Show("Silakan pilih jenis kelamin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        MessageBox.Show("Hai : " & nama & vbCrLf &
                        "NIP : " & nip & vbCrLf &
                        "Jenis Kelamin : " & jenisKelamin & vbCrLf &
                        "Fakultas : " & fakultas & vbCrLf &
                        "Jurusan : " & jurusan & vbCrLf &
                        "Nilai Akhir: " & total.ToString() & vbCrLf &
                        "GRADE: " & grade,
                        "Informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
    End Sub

    Private Sub cmbFakultas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFakultas.SelectedIndexChanged
        Dim fakultas As String = cmbFakultas.SelectedItem
        cmbJurusan.Items.Clear()
        Select Case (fakultas)
            Case "FMIPA"
                cmbJurusan.Items.Add("Matematika")
                cmbJurusan.Items.Add("Kimia")
                cmbJurusan.Items.Add("Biologi")
                cmbJurusan.Items.Add("Fisika")
                cmbJurusan.Items.Add("Ilmu Komputer")
            Case "FKIP"
                cmbJurusan.Items.Add("Pendidikan Teknologi Informasi")
                cmbJurusan.Items.Add("Pendidikan Fisika")
                cmbJurusan.Items.Add("Pendidikan Kimia")
                cmbJurusan.Items.Add("Pendidikan Bahasa Indonesia")
                cmbJurusan.Items.Add("Pendidikan Bahasa Inggris")
            Case "FEB"
                cmbJurusan.Items.Add("Akuntansi")
                cmbJurusan.Items.Add("Manajemen")
                cmbJurusan.Items.Add("Ekonomi Pembangunan")
        End Select
    End Sub
End Class
Public Class Tugas3

    Private Sub Tugas3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbJurusan.Items.Add("Manajemen Informatika")
        cmbJurusan.Items.Add("Ilmu Komputer")
        cmbJurusan.Items.Add("Sistem Informasi")
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
                        "Jurusan : " & jurusan & vbCrLf &
                        "Nilai Akhir: " & total.ToString() & vbCrLf &
                        "GRADE: " & grade,
                        "Informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
    End Sub

    Private Sub cmbFakultas_SelectedIndexChanged(sender As Object, e As EventArgs)
    End Sub


    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        txtNIP.Clear()
        txtNama.Clear()
        cmbJurusan.SelectedIndex = -1
        cmbmatkul.SelectedIndex = -1
        txtTugas.Clear()
        txtUts.Clear()
        txtUas.Clear()
        lblgrade.Text = " -GRADE- "
        txtNIP.Enabled = True
        txtNIP.Focus()
        rablaki.Checked = False
        rabperempuan.Checked = False
    End Sub

    Private Sub cmbJurusan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJurusan.SelectedIndexChanged
        Dim fakultas As String = cmbJurusan.SelectedItem
        cmbmatkul.Items.Clear()
        Select (fakultas)
            Case "Manajemen Informatika"
                cmbmatkul.Items.Add("Pemrograman Desktop")
                cmbmatkul.Items.Add("Pemrograman WEB Lanjut")
                cmbmatkul.Items.Add("Keamanan Sistem Informasi")
            Case "Ilmu Komputer"
                cmbmatkul.Items.Add("Kecerdasan Buatan")
                cmbmatkul.Items.Add("Aljabar Linear")
            Case "Sistem Informasi"
                cmbmatkul.Items.Add("Pemrograman Web")
                cmbmatkul.Items.Add("PBO")
        End Select
    End Sub

    Private Sub dgvdata_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdata.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim row As DataGridViewRow = dgvdata.Rows(e.RowIndex)

            txtNIP.Text = row.Cells("dgnip").Value.ToString()
            txtNama.Text = row.Cells("dgnama").Value.ToString()

            If row.Cells("dgjeniskelamin").Value.ToString() = "Laki-Laki" Then
                rablaki.Checked = True
            Else
                rabperempuan.Checked = True
            End If

            cmbJurusan.Text = row.Cells("dgjurusan").Value.ToString()
            cmbmatkul.Text = row.Cells("dgmatkul").Value.ToString()
            lblgrade.Text = row.Cells("dggrade").Value.ToString()

            txtNIP.Enabled = False
        End If
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If txtNIP.Text = "" Or txtNama.Text = "" Or cmbmatkul.Text = "" Or (Not rablaki.Checked And Not rabperempuan.Checked) Then
            MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim rowIndex As Integer = -1
        For Each row As DataGridViewRow In dgvdata.Rows
            If row.Cells("dgnip").Value IsNot Nothing AndAlso row.Cells("dgnip").Value.ToString() = txtNIP.Text Then
                rowIndex = row.Index
                Exit For
            End If
        Next

        If rowIndex = -1 Then
            dgvdata.Rows.Add(txtNIP.Text, txtNama.Text, If(rablaki.Checked, "Laki-Laki", "Perempuan"), cmbJurusan.Text, cmbJurusan.Text, lblgrade.Text)
        Else
            dgvdata.Rows(rowIndex).Cells("dgnip").Value = txtNIP.Text
            dgvdata.Rows(rowIndex).Cells("dgnama").Value = txtNama.Text
            dgvdata.Rows(rowIndex).Cells("dgjeniskelamin").Value = If(rablaki.Checked, "Laki-Laki", "Perempuan")
            dgvdata.Rows(rowIndex).Cells("dgjurusan").Value = cmbJurusan.Text
            dgvdata.Rows(rowIndex).Cells("dgmatkul").Value = cmbmatkul.Text
            dgvdata.Rows(rowIndex).Cells("dggrade").Value = lblgrade.Text
        End If
        btnnew.PerformClick()
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If dgvdata.SelectedRows.Count > 0 Then
            Dim confirm As DialogResult = MessageBox.Show("Apakah yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirm = DialogResult.Yes Then
                dgvdata.Rows.RemoveAt(dgvdata.SelectedRows(0).Index)
                btnnew.PerformClick()
            End If
        Else
            MessageBox.Show("Pilih data yang ingin dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub txtTugas_TextChanged(sender As Object, e As EventArgs) Handles txtTugas.TextChanged
        UpdateGrade()
    End Sub

    Private Sub UpdateGrade()
        Dim tugas, uts, uas As Double
        If Double.TryParse(txtTugas.Text, tugas) AndAlso Double.TryParse(txtUts.Text, uts) AndAlso Double.TryParse(txtUas.Text, uas) Then
            Dim total As Double = (tugas * 0.3) + (uts * 0.3) + (uas * 0.4)
            Dim grade As String

            Select Case total
                Case Is >= 78
                    grade = "A"
                Case Is >= 65
                    grade = "B"
                Case Is >= 50
                    grade = "C"
                Case Is >= 40
                    grade = "D"
                Case Else
                    grade = "E"
            End Select

            lblgrade.Text = " " & grade
        Else
            lblgrade.Text = " -GRADE- "
        End If
    End Sub

    Private Sub txtUts_TextChanged(sender As Object, e As EventArgs) Handles txtUts.TextChanged
        UpdateGrade()
    End Sub

    Private Sub txtUas_TextChanged(sender As Object, e As EventArgs) Handles txtUas.TextChanged
        UpdateGrade()
    End Sub

    Private Sub lblgrade_Click(sender As Object, e As EventArgs) Handles lblgrade.Click

    End Sub

    Private Sub cmbmatkul_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbmatkul.SelectedIndexChanged

    End Sub

    Private Sub dgvdata_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdata.CellContentDoubleClick

    End Sub
End Class
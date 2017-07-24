Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not ProsesBisnis.ProsesBisnis.Work.f.Exists Then
            Response.Redirect("dbconf.aspx")
        End If
        Label1.Text = "Masukan Panjang"
        Label2.Text = "Masukan Lebar"
    End Sub

    Protected Sub panjang_TextChanged(sender As Object, e As EventArgs) Handles panjang.TextChanged
        Dim i As Int32
        If Int32.TryParse(panjang.Text, i) Then
            panjang.ForeColor = Drawing.Color.Black
        Else
            panjang.ForeColor = Drawing.Color.Red
        End If
        validasiKan()
    End Sub

    Private Sub validasiKan()
        s.Enabled = panjang.ForeColor = Drawing.Color.Black And lebar.ForeColor = Drawing.Color.Black
    End Sub

    Protected Sub lebar_TextChanged(sender As Object, e As EventArgs) Handles lebar.TextChanged
        Dim i As Int32
        If Int32.TryParse(lebar.Text, i) Then
            lebar.ForeColor = Drawing.Color.Black
        Else
            lebar.ForeColor = Drawing.Color.Red
        End If
        validasiKan()
    End Sub

    Protected Sub s_Click(sender As Object, e As EventArgs) Handles s.Click
        Dim p As Int32 = Int32.Parse(panjang.Text)
        Dim l As Int32 = Int32.Parse(lebar.Text)
        Dim luas As Int32 = p * l
        metune.Text = "Luas : " & luas
    End Sub
End Class
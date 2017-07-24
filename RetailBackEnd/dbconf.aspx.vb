Public Class dbconf
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub dbserv_ServerChange(sender As Object, e As EventArgs)
        validasiKan()
    End Sub

    Private Sub validasiKan()
        Dim i As Int32
        If Int32.TryParse(porte.Value, i) Then
            s.Disabled = i < 1000 AndAlso namene.Value = "" AndAlso dbserv.Value = "" AndAlso username.Value = ""
        End If
    End Sub

    Protected Sub Text1_ServerChange(sender As Object, e As EventArgs)
        validasiKan()
    End Sub

    Protected Sub username_ServerChange(sender As Object, e As EventArgs)
        validasiKan()
    End Sub

    Protected Sub s_ServerClick(sender As Object, e As EventArgs)
        Try
            Dim d As ProsesBisnis.ProsesBisnis.DBConf = New ProsesBisnis.ProsesBisnis.DBConf
            d.Hoste = dbserv.Value
            d.Namae = namene.Value
            d.Passe = sandi.Value
            d.Porte = Int32.Parse(porte.Value)
            d.Usere = username.Value
            ProsesBisnis.ProsesBisnis.Work.createDB(d)
            ProsesBisnis.ProsesBisnis.Work.writeConfig(d)
            Response.Redirect("default.aspx")
        Catch ex As Exception
            pesan.InnerHtml = "Error internal server"
            ProsesBisnis.ProsesBisnis.Work.hindar(ex, Request.UserHostAddress)
        End Try
    End Sub
End Class
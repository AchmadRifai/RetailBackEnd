Imports System.IO
Imports System.Xml
Imports MySql.Data.MySqlClient

Namespace ProsesBisnis
    Public Module Work
        Public f As FileInfo = New FileInfo("config.xml")

        Public Sub hindar(ex As Exception, r As String)
            Dim t As DateTimeOffset = New DateTimeOffset
            Dim f As FileInfo = New FileInfo("error/" & r & "/" & t.Year & "-" & t.Month & "-" & t.Day & "/" &
                                            t.Hour & "-" & t.Minute & "-" & t.Second & ".log")
            Dim d As XmlDocument = New XmlDocument()
            Dim e As XmlElement = d.CreateElement("error")
            d.AppendChild(e)
            e.AppendChild(genXML(d, ex.HelpLink, "helplink"))
            e.AppendChild(genXML(d, ex.Message, "message"))
            e.AppendChild(genXML(d, ex.Source, "source"))
            e.AppendChild(genXML(d, ex.StackTrace, "stack"))
            simpanXML(d, f)
        End Sub

        Private Sub simpanXML(d As XmlDocument, f As FileInfo)
            If Not f.Directory.Exists Then buatDir(f.Directory)
            If f.Exists Then f.Delete()
            Dim s As XmlWriterSettings = New XmlWriterSettings
            s.CheckCharacters = True
            s.CloseOutput = True
            s.DoNotEscapeUriAttributes = True
            s.Encoding = Text.Encoding.Default
            s.Indent = True
            s.IndentChars = "  "
            Dim w As XmlWriter = XmlWriter.Create(f.Create(), s)
            d.WriteContentTo(w)
            w.Close()
        End Sub

        Public Sub writeConfig(d As DBConf)
            Dim doc As XmlDocument = New XmlDocument
            Dim e As XmlElement = doc.CreateElement("config")
            e.AppendChild(genXML(doc, d.Hoste, "host"))
            e.AppendChild(genXML(doc, d.Namae, "nama"))
            e.AppendChild(genXML(doc, d.Passe, "pass"))
            e.AppendChild(genXML(doc, "" & d.Porte, "port"))
            e.AppendChild(genXML(doc, d.Usere, "user"))
            doc.AppendChild(e)
            simpanXML(doc, f)
        End Sub

        Public Sub createDB(d As DBConf)
            Dim s As String = "server=" & d.Hoste & ";database=mysql;uid=" & d.Usere & ";pwd=" & d.Passe & ";port=" & d.Porte
            Dim c As MySqlConnection = New MySqlConnection(s)
            Dim sql As String = "create database " & d.Hoste
            Dim co As MySqlCommand = New MySqlCommand(sql, c)
            co.ExecuteNonQuery()
            c.Close()
            strukturDB(d.genConn)
        End Sub

        Private Sub strukturDB(c As MySqlConnection)
            c.Close()
        End Sub

        Private Function genXML(d As XmlDocument, v As String, n As String) As XmlNode
            Dim e As XmlElement = d.CreateElement(n)
            e.InnerText = v
            Return e
        End Function

        Private Sub buatDir(d As DirectoryInfo)
            If Not d.Parent.Exists Then buatDir(d.Parent)
            d.Create()
        End Sub
    End Module

    Public Class DBConf
        Private host, nama, user, pass As String
        Private port As Int32

        Public Function genConn() As MySql.Data.MySqlClient.MySqlConnection
            Dim s As String = "server=" & host & ";database=" & nama & ";uid=" & user & ";pwd=" & pass & ";port=" & port
            Dim c As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection(s)
            c.Open()
            Return c
        End Function

        Property Porte As Int32
            Get
                Return port
            End Get
            Set(value As Int32)
                port = value
            End Set
        End Property

        Property Passe As String
            Get
                Return pass
            End Get
            Set(value As String)
                pass = value
            End Set
        End Property

        Property Usere As String
            Get
                Return user
            End Get
            Set(value As String)
                user = value
            End Set
        End Property

        Property Namae As String
            Get
                Return nama
            End Get
            Set(value As String)
                nama = value
            End Set
        End Property

        Property Hoste As String
            Get
                Return host
            End Get
            Set(value As String)
                host = value
            End Set
        End Property
    End Class
End Namespace
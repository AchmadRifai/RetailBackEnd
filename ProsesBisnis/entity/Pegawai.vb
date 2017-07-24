Imports MySql.Data.MySqlClient

Namespace entity
    Public Class Pegawai
        Private id, nm, almt, jab, ket As String
        Private hire As Date
        Private del, blok, log As Boolean

        Public Sub New()
            hire = Date.Today
            del = False
            blok = False
            log = False
        End Sub

        Public Sub New(ByVal k As String, ByRef c As MySqlConnection)
            Dim sql As String = "select*from pegawai where kode=@kode"
            Dim co As MySqlCommand = New MySqlCommand(sql, c)
            co.Parameters.Add(New MySqlParameter("kode", k))
            Dim r As MySqlDataReader = co.ExecuteReader
            If r.NextResult Then
                fillData(r)
            End If
            r.Close()
        End Sub

        Private Sub fillData(r As MySqlDataReader)
            id = r.GetString("kode")
            nm = r.GetString("nama")
            almt = r.GetString("alamat")
            jab = r.GetString("jabatan")
            ket = r.GetString("kete")
            hire = r.GetDateTime("masuk")
            del = r.GetBoolean("deleted")
            blok = r.GetBoolean("blocked")
            log = r.GetBoolean("kerja")
        End Sub

        Property Kode As String
            Get
                Return id
            End Get
            Set(value As String)
                id = value
            End Set
        End Property
        Property Nama As String
            Get
                Return nm
            End Get
            Set(value As String)
                nm = value
            End Set
        End Property
        Property Alamat As String
            Get
                Return almt
            End Get
            Set(value As String)
                almt = value
            End Set
        End Property
        Property Jabatan As String
            Get
                Return jab
            End Get
            Set(value As String)
                jab = value
            End Set
        End Property
        Property Kete As String
            Get
                Return ket
            End Get
            Set(value As String)
                ket = value
            End Set
        End Property
        Property Masuk As Date
            Get
                Return hire
            End Get
            Set(value As Date)
                hire = value
            End Set
        End Property
        Property Deleted As Boolean
            Get
                Return del
            End Get
            Set(value As Boolean)
                del = value
            End Set
        End Property
        Property Blocked As Boolean
            Get
                Return blok
            End Get
            Set(value As Boolean)
                blok = value
            End Set
        End Property
        Property Kerja As Boolean
            Get
                Return log
            End Get
            Set(value As Boolean)
                log = value
            End Set
        End Property
    End Class

    Public Class Jabatan
        Private kd, nm, ket, tgs As String
        Private gj As Money.Money(Of Numerics.BigInteger)
        Private jum, kap As Int64
        Private del As Boolean

        Public Sub New()
            del = False
        End Sub

        Public Sub New(ByVal k As String, ByRef c As MySqlConnection)
            Dim sql As String = "select*from jabatan where kode=@kode"
            Dim co As New MySqlCommand(sql, c)
            co.Parameters.Add(New MySqlParameter("kode", k))
            Dim r As MySqlDataReader = co.ExecuteReader
            If r.NextResult Then
                fillData(r)
            End If
            r.Close()
        End Sub

        Private Sub fillData(r As MySqlDataReader)
            kd = r.GetString("kode")
            nm = r.GetString("nama")
            ket = r.GetString("kete")
            tgs = r.GetString("tugas")
            gj = New Money.Money(Of Numerics.BigInteger)(r.GetUInt64("gaji"))
            jum = r.GetInt64("jumlah")
            kap = r.GetInt64("kapasitas")
            del = r.GetBoolean("deleted")
        End Sub

        Property Kode As String
            Get
                Return kd
            End Get
            Set(value As String)
                kd = value
            End Set
        End Property
        Property Nama As String
            Get
                Return nm
            End Get
            Set(value As String)
                nm = value
            End Set
        End Property
        Property Kete As String
            Get
                Return ket
            End Get
            Set(value As String)
                ket = value
            End Set
        End Property
        Property Tugas As String
            Get
                Return tgs
            End Get
            Set(value As String)
                tgs = value
            End Set
        End Property
        Property Gaji As Money.Money(Of Numerics.BigInteger)
            Get
                Return gj
            End Get
            Set(value As Money.Money(Of Numerics.BigInteger))
                gj = value
            End Set
        End Property
        Property Jumlah As Int64
            Get
                Return jum
            End Get
            Set(value As Int64)
                jum = value
            End Set
        End Property
        Property Kapasitas As Int64
            Get
                Return kap
            End Get
            Set(value As Int64)
                kap = value
            End Set
        End Property
        Property Deleted As Boolean
            Get
                Return del
            End Get
            Set(value As Boolean)
                del = value
            End Set
        End Property
    End Class

    Public Class Aset
        Private kd, nm, tipe As String
        Private jum As Money.Money(Of Numerics.BigInteger)
        Private ikii, del As Boolean

        Public Sub New()
            del = False
            ikii = False
        End Sub

        Public Sub New(ByVal k As String, ByRef c As MySqlConnection)
            Dim sql As String = "select*from aset where kode=@kode"
            Dim co As New MySqlCommand(sql, c)
            co.Parameters.Add(New MySqlParameter("kode", k))
            Dim r As MySqlDataReader = co.ExecuteReader
            If r.NextResult Then
                fillData(r)
            End If
            r.Close()
        End Sub

        Private Sub fillData(r As MySqlDataReader)
            kd = r.GetString("kode")
            nm = r.GetString("nama")
            tipe = r.GetString("t")
            jum = New Money.Money(Of Numerics.BigInteger)(r.GetInt64("jumlah"))
            ikii = r.GetBoolean("titik")
            del = r.GetBoolean("deleted")
        End Sub

        Property Kode As String
            Get
                Return kd
            End Get
            Set(value As String)
                kd = value
            End Set
        End Property
        Property Nama As String
            Get
                Return nm
            End Get
            Set(value As String)
                nm = value
            End Set
        End Property
        Property T As String
            Get
                Return tipe
            End Get
            Set(value As String)
                tipe = value
            End Set
        End Property
        Property Jumlah As Money.Money(Of Numerics.BigInteger)
            Get
                Return jum
            End Get
            Set(value As Money.Money(Of Numerics.BigInteger))
                jum = value
            End Set
        End Property
        Property Titik As Boolean
            Get
                Return ikii
            End Get
            Set(value As Boolean)
                ikii = value
            End Set
        End Property
        Property Deleted As Boolean
            Get
                Return del
            End Get
            Set(value As Boolean)
                del = value
            End Set
        End Property
    End Class

    Public Class Hutang
        Private kd, kete, kpd, jam As String
        Private jum As Money.Money(Of Numerics.BigInteger)
        Private b As UInt16
        Private t As Date
        Private del, lu As Boolean

        Public Sub New()
            t = Date.Today
            del = False
            lu = False
        End Sub

        Public Sub New(k As String, ByRef c As MySqlConnection)
            Dim sql As String = "select*from hutang where kode=@kode"
            Dim co As New MySqlCommand(sql, c)
            co.Parameters.Add(New MySqlParameter("kode", k))
            Dim r As MySqlDataReader = co.ExecuteReader
            If r.NextResult Then
                fillData(r)
            End If
            r.Close()
        End Sub

        Private Sub fillData(r As MySqlDataReader)
            kd = r.GetString("kode")
            kete = r.GetString("ket")
            kpd = r.GetString("kepada")
            jam = r.GetString("jaminan")
            jum = New Money.Money(Of Numerics.BigInteger)(r.GetInt64("jumlah"))
            b = r.GetUInt64("bunga")
            t = r.GetDateTime("tgl")
            del = r.GetBoolean("deleted")
            lu = r.GetBoolean("lunas")
        End Sub

        Property Kode As String
            Get
                Return kd
            End Get
            Set(value As String)
                kd = value
            End Set
        End Property
        Property Ket As String
            Get
                Return kete
            End Get
            Set(value As String)
                kete = value
            End Set
        End Property
        Property Kepada As String
            Get
                Return kpd
            End Get
            Set(value As String)
                kpd = value
            End Set
        End Property
        Property Jaminan As String
            Get
                Return jam
            End Get
            Set(value As String)
                jam = value
            End Set
        End Property
        Property Jumlah As Money.Money(Of Numerics.BigInteger)
            Get
                Return jum
            End Get
            Set(value As Money.Money(Of Numerics.BigInteger))
                jum = value
            End Set
        End Property
        Property Bunga As UInt64
            Get
                Return b
            End Get
            Set(value As UInt64)
                b = value
            End Set
        End Property
        Property Tgl As Date
            Get
                Return t
            End Get
            Set(value As Date)
                t = value
            End Set
        End Property
        Property Deleted As Boolean
            Get
                Return del
            End Get
            Set(value As Boolean)
                del = value
            End Set
        End Property
        Property Lunas As Boolean
            Get
                Return lu
            End Get
            Set(value As Boolean)
                lu = value
            End Set
        End Property
    End Class

    Public Class Barang
        Private kd, nm, mrk, sat As String
        Private stk As UInt32
        Private hrg As Money.Money(Of Numerics.BigInteger)
        Private del As Boolean

        Public Sub New()
            del = False
        End Sub

        Public Sub New(k As String, ByRef c As MySqlConnection)
            Dim sql As String = "select*from barang where kode=@kode"
            Dim co As New MySqlCommand(sql, c)
            co.Parameters.Add(New MySqlParameter("kode", k))
            Dim r As MySqlDataReader = co.ExecuteReader
            If r.NextResult Then
                fillData(r)
            End If
            r.Close()
        End Sub

        Private Sub fillData(r As MySqlDataReader)
            kd = r.GetString("kode")
            nm = r.GetString("nama")
            mrk = r.GetString("merk")
            sat = r.GetString("satuan")
            stk = r.GetUInt32("stok")
            hrg = New Money.Money(Of Numerics.BigInteger)(r.GetUInt64("harga"))
            del = r.GetBoolean("deleted")
        End Sub

        Property Kode As String
            Get
                Return kd
            End Get
            Set(value As String)
                kd = value
            End Set
        End Property
        Property Nama As String
            Get
                Return nm
            End Get
            Set(value As String)
                nm = value
            End Set
        End Property
        Property Merk As String
            Get
                Return mrk
            End Get
            Set(value As String)
                mrk = value
            End Set
        End Property
        Property Satuan As String
            Get
                Return sat
            End Get
            Set(value As String)
                sat = value
            End Set
        End Property
        Property Stok As UInt32
            Get
                Return stk
            End Get
            Set(value As UInt32)
                stk = value
            End Set
        End Property
        Property Harga As Money.Money(Of Numerics.BigInteger)
            Get
                Return hrg
            End Get
            Set(value As Money.Money(Of Numerics.BigInteger))
                hrg = value
            End Set
        End Property
        Property Deleted As Boolean
            Get
                Return del
            End Get
            Set(value As Boolean)
                del = value
            End Set
        End Property
    End Class

    Public Class Suplier
        Private kd, nm, almt, tlp As String
        Private del, blk As Boolean

        Public Sub New()
            del = False
            blk = False
        End Sub

        Public Sub New(k As String, ByRef c As MySqlConnection)
            Dim sql As String = "select*from suplier where kode=@kode"
            Dim co As New MySqlCommand(sql, c)
            co.Parameters.Add(New MySqlParameter("kode", k))
            Dim r As MySqlDataReader = co.ExecuteReader
            If r.NextResult Then
                fillData(r)
            End If
            r.Close()
        End Sub

        Private Sub fillData(r As MySqlDataReader)
            kd = r.GetString("kode")
            nm = r.GetString("nama")
            almt = r.GetString("alamat")
            tlp = r.GetString("telepon")
            del = r.GetBoolean("deleted")
            blk = r.GetBoolean("blocked")
        End Sub

        Property Kode As String
            Get
                Return kd
            End Get
            Set(value As String)
                kd = value
            End Set
        End Property
        Property Nama As String
            Get
                Return nm
            End Get
            Set(value As String)
                nm = value
            End Set
        End Property
        Property Alamat As String
            Get
                Return almt
            End Get
            Set(value As String)
                almt = value
            End Set
        End Property
        Property Telepon As String
            Get
                Return tlp
            End Get
            Set(value As String)
                tlp = value
            End Set
        End Property
        Property Deleted As Boolean
            Get
                Return del
            End Get
            Set(value As Boolean)
                del = value
            End Set
        End Property
        Property Blocked As Boolean
            Get
                Return blk
            End Get
            Set(value As Boolean)
                blk = value
            End Set
        End Property
    End Class

    Public Class Pelanggan
        Private kd, nm, almt, tlp, bns As String
        Private dsc As UInt16
        Private del, blk As Boolean

        Public Sub New()
            del = False
            blk = False
        End Sub

        Public Sub New(k As String, ByRef c As MySqlConnection)
            Dim sql As String = "select*from pelanggan where kode=@kode"
            Dim co As New MySqlCommand(sql, c)
            co.Parameters.Add(New MySqlParameter("kode", k))
            Dim r As MySqlDataReader = co.ExecuteReader
            If r.NextResult Then
                fillData(r)
            End If
            r.Close()
        End Sub

        Private Sub fillData(r As MySqlDataReader)
            kd = r.GetString("kode")
            nm = r.GetString("nama")
            almt = r.GetString("alamat")
            tlp = r.GetString("telepon")
            bns = r.GetString("bonus")
            dsc = r.GetUInt16("diskon")
            del = r.GetBoolean("deleted")
            blk = r.GetBoolean("blocked")
        End Sub

        Property Kode As String
        Property Nama As String
        Property Alamat As String
        Property Telepon As String
        Property Bonus As String
        Property Diskon As UInt16
        Property Deleted As Boolean
        Property Blocked As Boolean
            Get
                Return blk
            End Get
            Set(value As Boolean)
                blk = value
            End Set
        End Property
    End Class
End Namespace
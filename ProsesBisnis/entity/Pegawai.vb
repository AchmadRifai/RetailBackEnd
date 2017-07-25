Imports MySql.Data.MySqlClient

Namespace entity
    Public Class Pegawai
        Private id, nm, almt, jab, ket, pass As String
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
            pass = r.GetString("password")
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
        Property Password As String
            Get
                Return pass
            End Get
            Set(value As String)
                pass = value
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
            gj = New Money.Money(Of Numerics.BigInteger)(r.GetUInt64("gaji"), Money.Currency.IDR)
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
        Private ikii, del, mt As Boolean

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
            jum = New Money.Money(Of Numerics.BigInteger)(r.GetInt64("jumlah"), Money.Currency.IDR)
            ikii = r.GetBoolean("titik")
            del = r.GetBoolean("deleted")
            mt = r.GetBoolean("metu")
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
        Property Metu As Boolean
            Get
                Return mt
            End Get
            Set(value As Boolean)
                mt = value
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
            jum = New Money.Money(Of Numerics.BigInteger)(r.GetInt64("jumlah"), Money.Currency.IDR)
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
            hrg = New Money.Money(Of Numerics.BigInteger)(r.GetUInt64("harga"), Money.Currency.IDR)
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
        Private kd, nm, almt, tlp, bns, pass As String
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
            pass = r.GetString("password")
        End Sub

        Property Kode As String
            Get
                Return kd
            End Get
            Set(value As String)
                kd = value
            End Set
        End Property
        Property Password As String
            Get
                Return pass
            End Get
            Set(value As String)
                pass = value
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
        Property Bonus As String
            Get
                Return bns
            End Get
            Set(value As String)
                bns = value
            End Set
        End Property
        Property Diskon As UInt16
            Get
                Return dsc
            End Get
            Set(value As UInt16)
                dsc = value
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

    Public Class Paket
        Private kd, nm, k As String
        Private dsk As UInt16
        Private kap, jum As UInt32
        Private aw, akh As Date
        Private del, ent As Boolean

        Public Sub New()
            aw = Date.Today
            del = False
            ent = False
            akh = Nothing
        End Sub

        Public Sub New(k As String, ByRef c As MySqlConnection)
            Dim sql As String = "select*from paket where kode=@kode"
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
            k = r.GetString("ket")
            dsk = r.GetUInt16("diskon")
            kap = r.GetUInt32("kapasitas")
            jum = r.GetUInt32("jumlah")
            aw = r.GetDateTime("awal")
            akh = r.GetDateTime("akhir")
            del = r.GetBoolean("deleted")
            ent = r.GetBoolean("entek")
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
        Property Ket As String
            Get
                Return k
            End Get
            Set(value As String)
                k = value
            End Set
        End Property
        Property Diskon As UInt16
            Get
                Return dsk
            End Get
            Set(value As UInt16)
                dsk = value
            End Set
        End Property
        Property Kapasitas As UInt32
            Get
                Return kap
            End Get
            Set(value As UInt32)
                kap = value
            End Set
        End Property
        Property Jumlah As UInt32
            Get
                Return jum
            End Get
            Set(value As UInt32)
                jum = value
            End Set
        End Property
        Property Awal As Date
            Get
                Return aw
            End Get
            Set(value As Date)
                aw = value
            End Set
        End Property
        Property Akhir As Date
            Get
                Return akh
            End Get
            Set(value As Date)
                akh = value
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
        Property Entek As Boolean
            Get
                Return ent
            End Get
            Set(value As Boolean)
                ent = value
            End Set
        End Property
    End Class

    Public Class Parkir
        Private kd, pos, k As String
        Private pk, del As Boolean

        Public Sub New()
            del = False
            pk = False
        End Sub

        Public Sub New(k As String, ByRef c As MySqlConnection)
            Dim sql As String = "select*from parkir where kode=@kode"
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
            pos = r.GetString("posisi")
            k = r.GetString("ket")
            pk = r.GetBoolean("pakai")
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
        Property Posisi As String
            Get
                Return pos
            End Get
            Set(value As String)
                pos = value
            End Set
        End Property
        Property Ket As String
            Get
                Return k
            End Get
            Set(value As String)
                k = value
            End Set
        End Property
        Property Pakai As Boolean
            Get
                Return pk
            End Get
            Set(value As Boolean)
                pk = value
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

    Public Class Pengeluaran
        Private kd, m, k As String
        Private t As Date
        Private nmr As UInt16
        Private jum As Money.Money(Of Numerics.BigInteger)
        Private del As Boolean

        Public Sub New()
            t = Date.Now
            del = False
        End Sub

        Public Sub New(k As String, ByRef c As MySqlConnection)
            Dim sql As String = "select*from pengeluaran where kode=@kode"
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
            m = r.GetString("moro")
            k = r.GetString("ket")
            t = r.GetDateTime("tgl")
            nmr = r.GetUInt16("nomor")
            del = r.GetBoolean("deleted")
            jum = New Money.Money(Of Numerics.BigInteger)(r.GetUInt64("jumlah"), Money.Currency.IDR)
        End Sub

        Property Kode As String
            Get
                Return kd
            End Get
            Set(value As String)
                kd = value
            End Set
        End Property
        Property Moro As String
            Get
                Return m
            End Get
            Set(value As String)
                m = value
            End Set
        End Property
        Property Ket As String
            Get
                Return k
            End Get
            Set(value As String)
                k = value
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
        Property Nomor As UInt16
            Get
                Return nmr
            End Get
            Set(value As UInt16)
                nmr = value
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
        Property Jumlah As Money.Money(Of Numerics.BigInteger)
            Get
                Return jum
            End Get
            Set(value As Money.Money(Of Numerics.BigInteger))
                jum = value
            End Set
        End Property
    End Class

    Public Class Pendapatan
        Private kd, k As String
        Private t As Date
        Private jum As Money.Money(Of Numerics.BigInteger)
        Private del As Boolean

        Public Sub New()
            t = Date.Today
            del = False
        End Sub

        Public Sub New(k As String, ByRef c As MySqlConnection)
            Dim sql As String = "select*from pendapatan where kode=@kode"
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
            k = r.GetString("ket")
            t = r.GetDateTime("tgl")
            jum = New Money.Money(Of Numerics.BigInteger)(r.GetUInt64("jum"), Money.Currency.IDR)
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
        Property Ket As String
            Get
                Return k
            End Get
            Set(value As String)
                k = value
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
        Property Jumlah As Money.Money(Of Numerics.BigInteger)
            Get
                Return jum
            End Get
            Set(value As Money.Money(Of Numerics.BigInteger))
                jum = value
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

    Public Class Gaji
        Private kd, peg, bln As String
        Private thn As UInt32
        Private jum As Money.Money(Of Numerics.BigInteger)
        Private del As Boolean

        Public Sub New()
            Dim t As Date = Date.Now
            bln = "" & t.Month
            thn = t.Year
            del = False
        End Sub

        Public Sub New(k As String, ByRef c As MySqlConnection)
            Dim sql As String = "select*from gaji where kode=@kode"
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
            peg = r.GetString("pegawai")
            bln = r.GetString("bulan")
            thn = r.GetUInt32("tahun")
            jum = New Money.Money(Of Numerics.BigInteger)(r.GetUInt64("jumlah"), Money.Currency.IDR)
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
        Property Pegawai As String
            Get
                Return peg
            End Get
            Set(value As String)
                peg = value
            End Set
        End Property
        Property Bulan As String
            Get
                Return bln
            End Get
            Set(value As String)
                bln = value
            End Set
        End Property
        Property Tahun As UInt32
            Get
                Return thn
            End Get
            Set(value As UInt32)
                thn = value
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
        Property Deleted As Boolean
            Get
                Return del
            End Get
            Set(value As Boolean)
                del = value
            End Set
        End Property
    End Class

    Public Class BonusPegawai
        Private kd, peg, bln As String
        Private thn As UInt32
        Private jum As Money.Money(Of Numerics.BigInteger)
        Private del As Boolean

        Public Sub New()
            Dim t As Date = Date.Now
            bln = "" & t.Month
            thn = t.Year
            del = False
        End Sub

        Public Sub New(k As String, ByRef c As MySqlConnection)
            Dim sql As String = "select*from bonuspegawai where kode=@kode"
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
            peg = r.GetString("pegawai")
            bln = r.GetString("bulan")
            thn = r.GetUInt32("tahun")
            jum = New Money.Money(Of Numerics.BigInteger)(r.GetUInt64("jumlah"), Money.Currency.IDR)
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
        Property Pegawai As String
            Get
                Return peg
            End Get
            Set(value As String)
                peg = value
            End Set
        End Property
        Property Bulan As String
            Get
                Return bln
            End Get
            Set(value As String)
                bln = value
            End Set
        End Property
        Property Tahun As UInt32
            Get
                Return thn
            End Get
            Set(value As UInt32)
                thn = value
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
        Property Deleted As Boolean
            Get
                Return del
            End Get
            Set(value As Boolean)
                del = value
            End Set
        End Property
    End Class

    Public Class Jejak
        Private peg, ak, sum As String
        Private t As DateTime
        Private del As Boolean

        Public Sub New()
            t = DateAndTime.Now
            del = False
        End Sub

        Property Pegawai As String
            Get
                Return peg
            End Get
            Set(value As String)
                peg = value
            End Set
        End Property
        Property Aksi As String
            Get
                Return ak
            End Get
            Set(value As String)
                ak = value
            End Set
        End Property
        Property Sumber As String
            Get
                Return sum
            End Get
            Set(value As String)
                sum = value
            End Set
        End Property
        Property Waktu As DateTime
            Get
                Return t
            End Get
            Set(value As DateTime)
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
    End Class

    Public Class Jual
        Private kd, pel As String
        Private t As Date
        Private kem, tot, ak As Money.Money(Of Numerics.BigInteger)
        Private del As Boolean

        Public Sub New()
            t = Date.Now
            del = False
            kem = New Money.Money(Of Numerics.BigInteger)(0, Money.Currency.IDR)
            tot = New Money.Money(Of Numerics.BigInteger)(0, Money.Currency.IDR)
            ak = New Money.Money(Of Numerics.BigInteger)(0, Money.Currency.IDR)
        End Sub

        Public Sub New(k As String, ByRef c As MySqlConnection)
            Dim sql As String = "select*from jual where kode=@kode"
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
            pel = r.GetString("pelanggan")
            t = r.GetDateTime("tgl")
            kem = New Money.Money(Of Numerics.BigInteger)(r.GetUInt64("kembali"), Money.Currency.IDR)
            tot = New Money.Money(Of Numerics.BigInteger)(r.GetUInt64("total"), Money.Currency.IDR)
            ak = New Money.Money(Of Numerics.BigInteger)(r.GetUInt64("akeh"), Money.Currency.IDR)
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
        Property Pelanggan As String
            Get
                Return pel
            End Get
            Set(value As String)
                pel = value
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
        Property Kembali As Money.Money(Of Numerics.BigInteger)
            Get
                Return kem
            End Get
            Set(value As Money.Money(Of Numerics.BigInteger))
                kem = value
            End Set
        End Property
        Property Total As Money.Money(Of Numerics.BigInteger)
            Get
                Return tot
            End Get
            Set(value As Money.Money(Of Numerics.BigInteger))
                tot = value
            End Set
        End Property
        Property Akeh As Money.Money(Of Numerics.BigInteger)
            Get
                Return ak
            End Get
            Set(value As Money.Money(Of Numerics.BigInteger))
                ak = value
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

    Public Class ItemJual
        Private ju, br As String
        Private sat, tot As Money.Money(Of Numerics.BigInteger)
        Private dsk, jum As UInt32
        Private del As Boolean

        Public Sub New()
            del = False
        End Sub

        Property Jual As String
            Get
                Return ju
            End Get
            Set(value As String)
                ju = value
            End Set
        End Property
        Property Barang As String
            Get
                Return br
            End Get
            Set(value As String)
                br = value
            End Set
        End Property
        Property Satuan As Money.Money(Of Numerics.BigInteger)
            Get
                Return sat
            End Get
            Set(value As Money.Money(Of Numerics.BigInteger))
                sat = value
            End Set
        End Property
        Property Total As Money.Money(Of Numerics.BigInteger)
            Get
                Return tot
            End Get
            Set(value As Money.Money(Of Numerics.BigInteger))
                tot = value
            End Set
        End Property
        Property Diskon As UInt32
            Get
                Return dsk
            End Get
            Set(value As UInt32)
                dsk = value
            End Set
        End Property
        Property Jumlah As UInt32
            Get
                Return jum
            End Get
            Set(value As UInt32)
                jum = value
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

    Public Class Pasok
        Private kd, sup, k, str As String
        Private t As Date
        Private del As Boolean

        Public Sub New()
            t = Date.Now
            del = False
        End Sub

        Public Sub New(k As String, ByRef c As MySqlConnection)
            Dim sql As String = "select*from pasok where kode=@kode"
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
            sup = r.GetString("suplier")
            k = r.GetString("ket")
            str = r.GetString("struk")
            t = r.GetDateTime("tgl")
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
        Property Suplier As String
            Get
                Return sup
            End Get
            Set(value As String)
                sup = value
            End Set
        End Property
        Property Ket As String
            Get
                Return k
            End Get
            Set(value As String)
                k = value
            End Set
        End Property
        Property Struk As String
            Get
                Return str
            End Get
            Set(value As String)
                str = value
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
    End Class

    Public Class ItemPasok
        Private pas, brg As String
        Private sat, tot As Money.Money(Of Numerics.BigInteger)
        Private jum As UInt32
        Private del As Boolean

        Public Sub New()
            del = False
        End Sub

        Property Pasok As String
            Get
                Return pas
            End Get
            Set(value As String)
                pas = value
            End Set
        End Property
        Property Barang As String
            Get
                Return brg
            End Get
            Set(value As String)
                brg = value
            End Set
        End Property
        Property Satuan As Money.Money(Of Numerics.BigInteger)
            Get
                Return sat
            End Get
            Set(value As Money.Money(Of Numerics.BigInteger))
                sat = value
            End Set
        End Property
        Property Total As Money.Money(Of Numerics.BigInteger)
            Get
                Return tot
            End Get
            Set(value As Money.Money(Of Numerics.BigInteger))
                tot = value
            End Set
        End Property
        Property Jumlah As UInt32
            Get
                Return jum
            End Get
            Set(value As UInt32)
                jum = value
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

    Public Class Parkiran
        Private pl, lap As String
        Private aw, akh As DateTime
        Private byr As Money.Money(Of Numerics.BigInteger)
        Private del As Boolean

        Public Sub New()
            aw = DateTime.Now
            akh = Nothing
            del = False
        End Sub

        Property Plat As String
            Get
                Return pl
            End Get
            Set(value As String)
                pl = value
            End Set
        End Property
        Property Lapangan As String
            Get
                Return lap
            End Get
            Set(value As String)
                lap = value
            End Set
        End Property
        Property Awal As DateTime
            Get
                Return aw
            End Get
            Set(value As DateTime)
                aw = value
            End Set
        End Property
        Property Akhir As DateTime
            Get
                Return akh
            End Get
            Set(value As DateTime)
                akh = value
            End Set
        End Property
        Property Bayar As Money.Money(Of Numerics.BigInteger)
            Get
                Return byr
            End Get
            Set(value As Money.Money(Of Numerics.BigInteger))
                byr = value
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
End Namespace
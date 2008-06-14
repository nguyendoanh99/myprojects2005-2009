Public Class PhanCongDTO
#Region "ATTRIBUTES"
    Private m_MaPhanCong As String
    Private m_MaLopHoc As String
    Private m_MaMonHoc As String
    Private m_MaGiaoVien As String
    Private m_SoTietHocTuan As Byte
    Private m_SoTietHocLienTiepToiThieu As Byte
    Private m_SoTietHocLienTiepToiDa As Byte
    Private m_SoBuoiHocToiThieu As Byte
    Private m_SoBuoiHocToiDa As Byte

#End Region

#Region "PROPERTIES"
    Public Property MaPhanCong() As String
        Get
            Return m_MaPhanCong
        End Get
        Set(ByVal value As String)
            m_MaPhanCong = value
        End Set
    End Property

    Public Property MaLopHoc() As String
        Get
            Return m_MaLopHoc
        End Get
        Set(ByVal value As String)
            m_MaLopHoc = value
        End Set
    End Property

    Public Property MaMonHoc() As String
        Get
            Return m_MaMonHoc
        End Get
        Set(ByVal value As String)
            m_MaMonHoc = value
        End Set
    End Property

    Public Property MaGiaoVien() As String
        Get
            Return m_MaGiaoVien
        End Get
        Set(ByVal value As String)
            m_MaGiaoVien = value
        End Set
    End Property

    Public Property SoTietHocTuan() As Byte
        Get
            Return m_SoTietHocTuan
        End Get
        Set(ByVal value As Byte)
            m_SoTietHocTuan = value
        End Set
    End Property

    Public Property SoTietHocLienTiepToiThieu() As Byte
        Get
            Return m_SoTietHocLienTiepToiThieu
        End Get
        Set(ByVal value As Byte)
            m_SoTietHocLienTiepToiThieu = value
        End Set
    End Property

    Public Property SoTietHocLienTiepToiDa() As Byte
        Get
            Return m_SoTietHocLienTiepToiDa
        End Get
        Set(ByVal value As Byte)
            m_SoTietHocLienTiepToiDa = value
        End Set
    End Property

    Public Property SoBuoiHocToiThieu() As Byte
        Get
            Return m_SoBuoiHocToiThieu
        End Get
        Set(ByVal value As Byte)
            m_SoBuoiHocToiThieu = value
        End Set
    End Property

    Public Property SoBuoiHocToiDa() As Byte
        Get
            Return m_SoBuoiHocToiDa
        End Get
        Set(ByVal value As Byte)
            m_SoBuoiHocToiDa = value
        End Set
    End Property
#End Region

#Region "CONTRUCTIONS"
    Public Sub New()

    End Sub

    Public Sub New(ByVal row As DataRow)
        If (row.ItemArray.Length <> 9) Then
            Return
        End If

        Try
            Me.MaPhanCong = row("MaPhanCong")
            Me.MaLopHoc = row("MaLopHoc")
            Me.MaMonHoc = row("MaMonHoc")
            Me.MaGiaoVien = row("MaGiaoVien")
            Me.SoTietHocTuan = row("SoTietHocTuan")
            Me.SoTietHocLienTiepToiThieu = row("SoTietHocLienTiepToiThieu")
            Me.SoTietHocLienTiepToiDa = row("SoTietHocLienTiepToiDa")
            Me.SoBuoiHocToiThieu = row("SoBuoiHocToiThieu")
            Me.SoBuoiHocToiDa = row("SoBuoiHocToiDa")

        Catch ex As Exception

        End Try

    End Sub

#End Region
End Class

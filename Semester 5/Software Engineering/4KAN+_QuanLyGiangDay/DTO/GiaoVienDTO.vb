Public Class GiaoVienDTO

#Region "ATTRIBUTES"
    Private m_MaGiaoVien As String
    Private m_HoTenGiaoVien As String
    Private m_TenTat As String
    Private m_DiaChi As String
    Private m_DienThoai As String
#End Region

#Region "PROPERTIES"
    Public Property MaGiaoVien() As String
        Get
            Return m_MaGiaoVien
        End Get
        Set(ByVal value As String)
            m_MaGiaoVien = value
        End Set
    End Property

    Public Property HoTenGiaoVien() As String
        Get
            Return m_HoTenGiaoVien
        End Get
        Set(ByVal value As String)
            m_HoTenGiaoVien = value
        End Set
    End Property

    Public Property TenTat() As String
        Get
            Return m_TenTat
        End Get
        Set(ByVal value As String)
            m_TenTat = value
        End Set
    End Property

    Public Property DiaChi() As String
        Get
            Return m_DiaChi
        End Get
        Set(ByVal value As String)
            m_DiaChi = value
        End Set
    End Property

    Public Property DienThoai() As String
        Get
            Return m_DienThoai
        End Get
        Set(ByVal value As String)
            m_DienThoai = value
        End Set
    End Property
#End Region

#Region "METHODS"

    Public Overrides Function ToString() As String
        Return Me.HoTenGiaoVien
    End Function

#End Region
#Region "Constructors"
    Public Sub New()
        MaGiaoVien = ""
        HoTenGiaoVien = ""
        TenTat = ""
        DiaChi = ""
        DienThoai = ""
    End Sub

    Public Sub New(ByVal maGV As String, ByVal hotenGV As String, ByVal tTat As String, ByVal dChi As String, ByVal dThoai As String)
        MaGiaoVien = maGV
        HoTenGiaoVien = hotenGV
        TenTat = tTat
        DiaChi = dChi
        DienThoai = dThoai
    End Sub
#End Region
End Class

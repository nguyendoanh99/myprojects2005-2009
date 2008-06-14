Public Class RangBuocGiaoVienDTO
#Region "ATTRIBUTES"
    Private m_MaRangBuocGiaovien As String
    Private m_MaGiaoVien As String
    Private m_Thu As Byte
    Private m_TietHoc As Byte
    Private m_TrangThai As Byte
#End Region

#Region "PROPERTIES"
    Public Property MaRangBuocGiaovien() As String
        Get
            Return m_MaRangBuocGiaovien
        End Get
        Set(ByVal value As String)
            m_MaRangBuocGiaovien = value
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

    Public Property Thu() As Byte
        Get
            Return m_Thu
        End Get
        Set(ByVal value As Byte)
            m_Thu = value
        End Set
    End Property

    Public Property TietHoc() As Byte
        Get
            Return m_TietHoc
        End Get
        Set(ByVal value As Byte)
            m_TietHoc = value
        End Set
    End Property

    Public Property TrangThai() As Byte
        Get
            Return m_TrangThai
        End Get
        Set(ByVal value As Byte)
            m_TrangThai = value
        End Set
    End Property
#End Region
End Class

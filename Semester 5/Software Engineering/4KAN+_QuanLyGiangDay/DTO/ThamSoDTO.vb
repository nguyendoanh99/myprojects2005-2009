Public Class ThamSoDTO
#Region "ATTRIBUTES"
    Private m_SoTietToiDaTrongNgay As Byte
    Private m_TietGay As Byte
    Private m_SoTietToiDaDuocHocTrongNgay As Byte
#End Region

#Region "PROPERTIES"
    Public Property SoTietToiDaTrongNgay() As Byte
        Get
            Return m_SoTietToiDaTrongNgay
        End Get
        Set(ByVal value As Byte)
            m_SoTietToiDaTrongNgay = value
        End Set
    End Property

    Public Property TietGay() As Byte
        Get
            Return m_TietGay
        End Get
        Set(ByVal value As Byte)
            m_TietGay = value
        End Set
    End Property

    Public Property SoTietToiDaDuocHocTrongNgay() As Byte
        Get
            Return m_SoTietToiDaDuocHocTrongNgay
        End Get
        Set(ByVal value As Byte)
            m_SoTietToiDaDuocHocTrongNgay = value
        End Set
    End Property
#End Region
End Class

Public Class LichLopHocDTO
#Region "ATTRIBUTES"
    Private m_MaLichLopHoc As String
    Private m_MaPhanCong As String
    Private m_Thu As Byte
    Private m_TietHocBatDau As Byte
    Private m_SoTietHoc As Byte
#End Region

#Region "PROPERTIES"
    Public Property MaLichLopHoc() As String
        Get
            Return m_MaLichLopHoc
        End Get
        Set(ByVal value As String)
            m_MaLichLopHoc = value
        End Set
    End Property

    Public Property MaPhanCong() As String
        Get
            Return m_MaPhanCong
        End Get
        Set(ByVal value As String)
            m_MaPhanCong = value
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

    Public Property TietHocBatDau() As Byte
        Get
            Return m_TietHocBatDau
        End Get
        Set(ByVal value As Byte)
            m_TietHocBatDau = value
        End Set
    End Property

    Public Property SoTietHoc() As Byte
        Get
            Return m_SoTietHoc
        End Get
        Set(ByVal value As Byte)
            m_SoTietHoc = value
        End Set
    End Property
#End Region
End Class

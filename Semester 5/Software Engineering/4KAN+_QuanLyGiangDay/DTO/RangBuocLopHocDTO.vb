Public Class RangBuocLopHocDTO
#Region "ATTRIBUTES"
    Private m_MaRangBuocLopHoc As String
    Private m_MaLopHoc As String
    Private m_Thu As Byte
    Private m_TietHoc As Byte
    Private m_TrangThai As Byte
#End Region

#Region "PROPERTIES"
    Public Property MaRangBuocLopHoc() As String
        Get
            Return m_MaRangBuocLopHoc
        End Get
        Set(ByVal value As String)
            m_MaRangBuocLopHoc = value
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

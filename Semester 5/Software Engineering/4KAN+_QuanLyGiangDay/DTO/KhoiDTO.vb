Public Class KhoiDTO
#Region "ATTRIBUTES"
    Private m_MaKhoi As String
    Private m_TenKhoi As String
#End Region

#Region "PROPERTIES"
    Public Property MaKhoi() As String
        Get
            Return m_MaKhoi
        End Get
        Set(ByVal value As String)
            m_MaKhoi = value
        End Set
    End Property

    Public Property TenKhoi() As String
        Get
            Return m_TenKhoi
        End Get
        Set(ByVal value As String)
            m_TenKhoi = value
        End Set
    End Property
#End Region

End Class

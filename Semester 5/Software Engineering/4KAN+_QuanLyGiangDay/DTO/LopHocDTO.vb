Public Class LopHocDTO
#Region "ATTRIBUTES"
    Private m_MaLopHoc As String
    Private m_TenLopHoc As String
    Private m_MaKhoi As String
#End Region

#Region "PROPERTIES"
    Public Property MaLopHoc() As String
        Get
            Return m_MaLopHoc
        End Get
        Set(ByVal value As String)
            m_MaLopHoc = value
        End Set
    End Property

    Public Property TenLopHoc() As String
        Get
            Return m_TenLopHoc
        End Get
        Set(ByVal value As String)
            m_TenLopHoc = value
        End Set
    End Property

    Public Property MaKhoi() As String
        Get
            Return m_MaKhoi
        End Get
        Set(ByVal value As String)
            m_MaKhoi = value
        End Set
    End Property
#End Region

    Public Overrides Function ToString() As String
        Return Me.TenLopHoc
    End Function

End Class

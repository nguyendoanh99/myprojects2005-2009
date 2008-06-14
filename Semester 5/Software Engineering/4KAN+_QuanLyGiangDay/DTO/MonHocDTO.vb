Public Class MonHocDTO
#Region "ATTRIBUTES"
    Private m_MaMonHoc As String
    Private m_TenMonHoc As String
    Private m_QuyDinhSoTietHocLienTiepToiThieu As Byte
    Private m_QuyDinhSoTietHocLienTiepToiDa As Byte
#End Region

#Region "PROPERTIES"
    Public Property MaMonHoc() As String
        Get
            Return m_MaMonHoc
        End Get
        Set(ByVal value As String)
            m_MaMonHoc = value
        End Set
    End Property

    Public Property TenMonHoc() As String
        Get
            Return m_TenMonHoc
        End Get
        Set(ByVal value As String)
            m_TenMonHoc = value
        End Set
    End Property

    Public Property QuyDinhSoTietHocLienTiepToiThieu() As Byte
        Get
            Return m_QuyDinhSoTietHocLienTiepToiThieu
        End Get
        Set(ByVal value As Byte)
            m_QuyDinhSoTietHocLienTiepToiThieu = value
        End Set
    End Property

    Public Property QuyDinhSoTietHocLienTiepToiDa() As Byte
        Get
            Return m_QuyDinhSoTietHocLienTiepToiDa
        End Get
        Set(ByVal value As Byte)
            m_QuyDinhSoTietHocLienTiepToiDa = value
        End Set
    End Property
#End Region

    Public Overrides Function ToString() As String
        Return Me.TenMonHoc
    End Function

End Class

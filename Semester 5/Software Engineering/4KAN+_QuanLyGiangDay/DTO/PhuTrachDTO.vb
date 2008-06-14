Public Class PhuTrachDTO
#Region "ATTRIBUTES"
    Private m_MaPhuTrach As String
    Private m_MaGiaoVien As String
    Private m_MaMonHoc As String
#End Region

#Region "PROPERTIES"
    Public Property MaPhuTrach() As String
        Get
            Return m_MaPhuTrach
        End Get
        Set(ByVal value As String)
            m_MaPhuTrach = value
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

    Public Property MaMonHoc() As String
        Get
            Return m_MaMonHoc
        End Get
        Set(ByVal value As String)
            m_MaMonHoc = value
        End Set
    End Property
#End Region
#Region "Constructors"
    Public Sub New()
        MaPhuTrach = ""
        MaGiaoVien = ""
        MaMonHoc = ""
    End Sub

    Public Sub New(ByVal maPT As String, ByVal maGV As String, ByVal maMH As String)
        MaPhuTrach = maPT
        MaGiaoVien = maGV
        MaMonHoc = maMH
    End Sub
#End Region
End Class

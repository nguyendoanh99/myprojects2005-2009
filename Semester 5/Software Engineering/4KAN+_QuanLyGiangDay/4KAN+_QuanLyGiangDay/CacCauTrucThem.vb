Public Class TagOfCell
#Region "ATTRIBUTES"
    Private mMaPhanCong As String ' Ma phan cong dang duoc chon
    Private mMaLichLopHoc As String ' Ma lich hoc tuong ung
#End Region
#Region "PROPERTIES"
    Public Property MaLichLopHoc() As String
        Get
            Return mMaLichLopHoc
        End Get
        Set(ByVal value As String)
            mMaLichLopHoc = value
        End Set
    End Property
    Public Property MaPhanCong() As String
        Get
            Return mMaPhanCong
        End Get
        Set(ByVal value As String)
            mMaPhanCong = value
        End Set
    End Property
#End Region
#Region "CONTRUCTIONS"
    Public Sub New()
        MaPhanCong = ""
        MaLichLopHoc = ""
    End Sub

    Public Sub New(ByVal _MaPhanCong As String, ByVal _MaLichLopHoc As String)
        MaPhanCong = _MaPhanCong
        MaLichLopHoc = _MaLichLopHoc
    End Sub

#End Region
End Class
Public Class ItemOfComboBox
#Region "ATTRIBUTES"
    Private m_MaPhanCong As String ' Ma phan cong dang duoc chon
    Private m_Chuoi As String
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
    Public Property Chuoi() As String
        Get
            Return m_Chuoi
        End Get
        Set(ByVal value As String)
            m_Chuoi = value
        End Set
    End Property
#End Region
#Region "CONTRUCTIONS"
    Public Sub New()
        MaPhanCong = ""
        Chuoi = ""
    End Sub

    Public Sub New(ByVal _Chuoi As String, ByVal _MaPhanCong As String)
        MaPhanCong = _MaPhanCong
        Chuoi = _Chuoi
    End Sub

#End Region

End Class
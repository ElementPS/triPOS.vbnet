
Public NotInheritable Class HttpValue
#Region "Constructors and Destructors"

    Public Sub New()
    End Sub

    Public Sub New(key As String, value As String)
        Me.Key = key
        Me.Value = value
    End Sub

#End Region

#Region "Public Properties"

    Public Property Key() As String
        Get
            Return m_Key
        End Get
        Set
            m_Key = Value
        End Set
    End Property
    Private m_Key As String

    Public Property Value() As String
        Get
            Return m_Value
        End Get
        Set
            m_Value = Value
        End Set
    End Property
    Private m_Value As String

#End Region
End Class

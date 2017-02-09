
Imports System.Runtime.Serialization
Imports System.Xml.Serialization


''' <summary>
'''     Warnings that occurred during the request.
''' </summary>
<DataContract(Name:="warning")>
    Public Class ApiWarning
#Region "Public Properties"

        ''' <summary>
        '''     A developerMessage of the error
        ''' </summary>
        <DataMember(Name:="developerMessage")>
        <XmlElement("developerMessage")>
        Public Property DeveloperMessage() As String
            Get
                Return m_DeveloperMessage
            End Get
            Set
                m_DeveloperMessage = Value
            End Set
        End Property
        Private m_DeveloperMessage As String

        ''' <summary>
        '''     A developerMessage of the error
        ''' </summary>
        <DataMember(Name:="userMessage")>
        <XmlElement("userMessage")>
        Public Property UserMessage() As String
            Get
                Return m_UserMessage
            End Get
            Set
                m_UserMessage = Value
            End Set
        End Property
        Private m_UserMessage As String

#End Region
    End Class


Imports System.Runtime.Serialization
Imports System.Xml.Serialization

''' <summary>
'''     Errors that occurred during the request.
''' </summary>
<DataContract(Name:="error")>
    Public Class ApiError
#Region "Public Properties"

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
        '''     Code associated with the error if it exists
        ''' </summary>
        <DataMember(Name:="errorType")>
        <XmlElement("errorType")>
        Public Property ErrorType() As String
            Get
                Return m_ErrorType
            End Get
            Set
                m_ErrorType = Value
            End Set
        End Property
        Private m_ErrorType As String

        ''' <summary>
        '''     The body of the exception message.
        ''' </summary>
        <DataMember(Name:="exceptionMessage")>
        <XmlElement("exceptionMessage")>
        Public Property ExceptionMessage() As String
            Get
                Return m_ExceptionMessage
            End Get
            Set
                m_ExceptionMessage = Value
            End Set
        End Property
        Private m_ExceptionMessage As String

        ''' <summary>
        '''     The full name of the exception
        ''' </summary>
        <DataMember(Name:="exceptionTypeFullName")>
        <XmlElement("exceptionTypeFullName")>
        Public Property ExceptionTypeFullName() As String
            Get
                Return m_ExceptionTypeFullName
            End Get
            Set
                m_ExceptionTypeFullName = Value
            End Set
        End Property
        Private m_ExceptionTypeFullName As String

        ''' <summary>
        '''     The short name of the exception
        ''' </summary>
        <DataMember(Name:="exceptionTypeShortName")>
        <XmlElement("exceptionTypeShortName")>
        Public Property ExceptionTypeShortName() As String
            Get
                Return m_ExceptionTypeShortName
            End Get
            Set
                m_ExceptionTypeShortName = Value
            End Set
        End Property
        Private m_ExceptionTypeShortName As String

#End Region
    End Class

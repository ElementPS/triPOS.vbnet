
Imports System.Runtime.Serialization
Imports System.Xml.Serialization


''' <summary>
'''     The properties of a signature.
''' </summary>
<DataContract(Name:="signature")>
    Public Class Signature
        ''' <summary>
        '''     The byte array of the signature in the format specified by Format.
        ''' </summary>
        <DataMember(Name:="data")>
        <XmlElement("data")>
        Public Property SignatureData() As Byte()
            Get
                Return m_SignatureData
            End Get
            Set
                m_SignatureData = Value
            End Set
        End Property
        Private m_SignatureData As Byte()

        ''' <summary>
        '''     The format of the signature
        ''' </summary>
        <DataMember(Name:="format")>
        <XmlElement("format")>
        Public Property SignatureFormat() As String
            Get
                Return m_SignatureFormat
            End Get
            Set
                m_SignatureFormat = Value
            End Set
        End Property
        Private m_SignatureFormat As String

        ''' <summary>
        '''     Indicates why a signature is or is not present
        ''' </summary>
        <DataMember(Name:="statusCode")>
        <XmlElement("statusCode")>
        Public Property SignatureStatusCode() As String
            Get
                Return m_SignatureStatusCode
            End Get
            Set
                m_SignatureStatusCode = Value
            End Set
        End Property
        Private m_SignatureStatusCode As String
    End Class

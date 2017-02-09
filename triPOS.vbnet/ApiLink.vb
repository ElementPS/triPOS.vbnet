
Imports System.Runtime.Serialization
Imports System.Xml.Serialization

''' <summary>
'''     A hypermedia link
''' </summary>
<DataContract(Name:="link")>
    Public Class ApiLink
#Region "Public Properties"

        ''' <summary>
        '''     Gets or sets the href.
        ''' </summary>
        <DataMember(Name:="href")>
        <XmlElement("href")>
        Public Property Href() As String
            Get
                Return m_Href
            End Get
            Set
                m_Href = Value
            End Set
        End Property
        Private m_Href As String

        ''' <summary>
        '''     Gets or sets the method.
        ''' </summary>
        <DataMember(Name:="method")>
        <XmlElement("method")>
        Public Property Method() As String
            Get
                Return m_Method
            End Get
            Set
                m_Method = Value
            End Set
        End Property
        Private m_Method As String

        ''' <summary>
        '''     Gets or sets the relation.
        ''' </summary>
        <DataMember(Name:="rel")>
        <XmlElement("rel")>
        Public Property Relation() As String
            Get
                Return m_Relation
            End Get
            Set
                m_Relation = Value
            End Set
        End Property
        Private m_Relation As String

#End Region
    End Class

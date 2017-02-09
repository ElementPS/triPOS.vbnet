
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports System.Xml.Serialization


''' <summary>
'''     Contains all of the processor response items
''' </summary>
<DataContract(Name:="_processor")>
    Public Class Processor
        ''' <summary>
        '''     A list of messages from the processor
        ''' </summary>
        <DataMember(Name:="processorLogs")>
        <XmlArray(ElementName:="processorLogs")>
        <XmlArrayItem(ElementName:="log")>
        Public Property ProcessorLogs() As List(Of String)
            Get
                Return m_ProcessorLogs
            End Get
            Set
                m_ProcessorLogs = Value
            End Set
        End Property
        Private m_ProcessorLogs As List(Of String)

        ''' <summary>
        '''     The processor response. In the case of Express, this is the raw XML returned by the Express platform.
        ''' </summary>
        <DataMember(Name:="processorRawResponse")>
        <XmlElement("processorRawResponse")>
        Public Property ProcessorRawResponse() As String
            Get
                Return m_ProcessorRawResponse
            End Get
            Set
                m_ProcessorRawResponse = Value
            End Set
        End Property
        Private m_ProcessorRawResponse As String

        ''' <summary>
        '''     Reference number of the transaction
        ''' </summary>
        <DataMember(Name:="processorReferenceNumber")>
        <XmlElement("processorReferenceNumber")>
        Public Property ProcessorReferenceNumber() As String
            Get
                Return m_ProcessorReferenceNumber
            End Get
            Set
                m_ProcessorReferenceNumber = Value
            End Set
        End Property
        Private m_ProcessorReferenceNumber As String

        ''' <summary>
        '''     Set to true if the request to the processor has failed
        ''' </summary>
        <DataMember(Name:="processorRequestFailed")>
        <XmlElement("processorRequestFailed")>
        Public Property ProcessorRequestFailed() As Boolean
            Get
                Return m_ProcessorRequestFailed
            End Get
            Set
                m_ProcessorRequestFailed = Value
            End Set
        End Property
        Private m_ProcessorRequestFailed As Boolean

        ''' <summary>
        '''     Set to true if the sale was approved by the processor
        ''' </summary>
        <DataMember(Name:="processorRequestWasApproved")>
        <XmlElement("processorRequestWasApproved")>
        Public Property ProcessorRequestWasApproved() As Boolean
            Get
                Return m_ProcessorRequestWasApproved
            End Get
            Set
                m_ProcessorRequestWasApproved = Value
            End Set
        End Property
        Private m_ProcessorRequestWasApproved As Boolean

        ''' <summary>
        '''     The response code received from the processor
        ''' </summary>
        <DataMember(Name:="processorResponseCode")>
        <XmlElement("processorResponseCode")>
        Public Property ProcessorResponseCode() As ProcessorResponseCode
            Get
                Return m_ProcessorResponseCode
            End Get
            Set
                m_ProcessorResponseCode = Value
            End Set
        End Property
        Private m_ProcessorResponseCode As ProcessorResponseCode

        ''' <summary>
        '''     A message sent from the processor
        ''' </summary>
        <DataMember(Name:="processorResponseMessage")>
        <XmlElement("processorResponseMessage")>
        Public Property ProcessorResponseMessage() As String
            Get
                Return m_ProcessorResponseMessage
            End Get
            Set
                m_ProcessorResponseMessage = Value
            End Set
        End Property
        Private m_ProcessorResponseMessage As String
    End Class

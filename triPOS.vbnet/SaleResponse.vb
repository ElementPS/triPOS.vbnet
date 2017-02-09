
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports System.Xml.Serialization


''' <summary>
'''     The response returned from a card sale request
''' </summary>
<Serializable>
    <XmlRoot("saleResponse", [Namespace]:="http://tripos.vantiv.com/2014/09/TriPos.Api")>
    <DataContract(Name:="saleResponse")>
    Public Class SaleResponse
#Region "Public Properties"

        ''' <summary>
        '''     The cashback amount the card holder wants
        ''' </summary>
        <DataMember(Name:="cashbackAmount")>
        <XmlElement("cashbackAmount")>
        Public Property CashbackAmount() As Decimal
            Get
                Return m_CashbackAmount
            End Get
            Set
                m_CashbackAmount = Value
            End Set
        End Property
        Private m_CashbackAmount As Decimal

        ''' <summary>
        '''     The surcharge amount that was added to the transaction
        ''' </summary>
        <DataMember(Name:="debitSurchargeAmount")>
        <XmlElement("debitSurchargeAmount")>
        Public Property DebitSurchargeAmount() As Decimal
            Get
                Return m_DebitSurchargeAmount
            End Get
            Set
                m_DebitSurchargeAmount = Value
            End Set
        End Property
        Private m_DebitSurchargeAmount As Decimal

        ''' <summary>
        '''     The amount approved by the processor. This is the actual amount that will be charged or credited.
        ''' </summary>
        <DataMember(Name:="approvedAmount")>
        <XmlElement("approvedAmount")>
        Public Property ApprovedAmount() As Decimal
            Get
                Return m_ApprovedAmount
            End Get
            Set
                m_ApprovedAmount = Value
            End Set
        End Property
        Private m_ApprovedAmount As Decimal

        ''' <summary>
        '''     The convenience fee added to the transaction
        ''' </summary>
        <DataMember(Name:="convenienceFeeAmount")>
        <XmlElement("convenienceFeeAmount")>
        Public Property ConvenienceFeeAmount() As Decimal
            Get
                Return m_ConvenienceFeeAmount
            End Get
            Set
                m_ConvenienceFeeAmount = Value
            End Set
        End Property
        Private m_ConvenienceFeeAmount As Decimal

        ''' <summary>
        '''     The original amount sent for the transaction
        ''' </summary>
        <DataMember(Name:="subTotalAmount")>
        <XmlElement("subTotalAmount")>
        Public Property SubTotalAmount() As Decimal
            Get
                Return m_SubTotalAmount
            End Get
            Set
                m_SubTotalAmount = Value
            End Set
        End Property
        Private m_SubTotalAmount As Decimal

        ''' <summary>
        '''     The tip amount added to the transaction
        ''' </summary>
        <DataMember(Name:="tipAmount")>
        <XmlElement("tipAmount")>
        Public Property TipAmount() As Decimal
            Get
                Return m_TipAmount
            End Get
            Set
                m_TipAmount = Value
            End Set
        End Property
        Private m_TipAmount As Decimal

        ''' <summary>
        '''     The card account number
        ''' </summary>
        <DataMember(Name:="accountNumber")>
        <XmlElement("accountNumber")>
        Public Property AccountNumber() As String
            Get
                Return m_AccountNumber
            End Get
            Set
                m_AccountNumber = Value
            End Set
        End Property
        Private m_AccountNumber As String

        ''' <summary>
        '''     The BIN entry that matched the account number
        ''' </summary>
        <DataMember(Name:="binValue")>
        <XmlElement("binValue")>
        Public Property BinValue() As String
            Get
                Return m_BinValue
            End Get
            Set
                m_BinValue = Value
            End Set
        End Property
        Private m_BinValue As String

        ''' <summary>
        '''     The card holder name
        ''' </summary>
        <DataMember(Name:="cardHolderName")>
        <XmlElement("cardHolderName")>
        Public Property CardHolderName() As String
            Get
                Return m_CardHolderName
            End Get
            Set
                m_CardHolderName = Value
            End Set
        End Property
        Private m_CardHolderName As String

        ''' <summary>
        '''     The card logo (e.g. Visa, Mastercard, etc)
        ''' </summary>
        <DataMember(Name:="cardLogo")>
        <XmlElement("cardLogo")>
        Public Property CardLogo() As String
            Get
                Return m_CardLogo
            End Get
            Set
                m_CardLogo = Value
            End Set
        End Property
        Private m_CardLogo As String

        ''' <summary>
        '''     The currency code used in the transaction
        ''' </summary>
        <DataMember(Name:="currencyCode")>
        <XmlElement("currencyCode")>
        Public Property CurrencyCode() As String
            Get
                Return m_CurrencyCode
            End Get
            Set
                m_CurrencyCode = Value
            End Set
        End Property
        Private m_CurrencyCode As String

        ''' <summary>
        '''     Description of how card was entered: Keyed, Swiped, Chip
        ''' </summary>
        <DataMember(Name:="entryMode")>
        <XmlElement("entryMode")>
        Public Property EntryMode() As String
            Get
                Return m_EntryMode
            End Get
            Set
                m_EntryMode = Value
            End Set
        End Property
        Private m_EntryMode As String

        ''' <summary>
        '''     Description of how card payment type: None, Credit, Debit
        ''' </summary>
        <DataMember(Name:="paymentType")>
        <XmlElement("paymentType")>
        Public Property PaymentType() As String
            Get
                Return m_PaymentType
            End Get
            Set
                m_PaymentType = Value
            End Set
        End Property
        Private m_PaymentType As String

        ''' <summary>
        '''     The signature data
        ''' </summary>
        <DataMember(Name:="signature")>
        <XmlElement("signature")>
        Public Property Signature() As Signature
            Get
                Return m_Signature
            End Get
            Set
                m_Signature = Value
            End Set
        End Property
        Private m_Signature As Signature

        ''' <summary>
        '''     The ID of the terminal used during the transaction
        ''' </summary>
        <DataMember(Name:="terminalId")>
        <XmlElement("terminalId")>
        Public Property TerminalId() As String
            Get
                Return m_TerminalId
            End Get
            Set
                m_TerminalId = Value
            End Set
        End Property
        Private m_TerminalId As String

        ''' <summary>
        '''     The total amount of the transaction
        ''' </summary>
        <DataMember(Name:="totalAmount")>
        <XmlElement("totalAmount")>
        Public Property TotalAmount() As Decimal
            Get
                Return m_TotalAmount
            End Get
            Set
                m_TotalAmount = Value
            End Set
        End Property
        Private m_TotalAmount As Decimal

        ''' <summary>
        '''     Approval number from the processor
        ''' </summary>
        <DataMember(Name:="approvalNumber")>
        <XmlElement("approvalNumber")>
        Public Property ApprovalNumber() As String
            Get
                Return m_ApprovalNumber
            End Get
            Set
                m_ApprovalNumber = Value
            End Set
        End Property
        Private m_ApprovalNumber As String

        ''' <summary>
        '''     Set to true if the overall sale was approved (not declined by the card)
        ''' </summary>
        <DataMember(Name:="isApproved")>
        <XmlElement("isApproved")>
        Public Property IsApproved() As Boolean
            Get
                Return m_IsApproved
            End Get
            Set
                m_IsApproved = Value
            End Set
        End Property
        Private m_IsApproved As Boolean

        ''' <summary>
        '''     Response information from the processor
        ''' </summary>
        <DataMember(Name:="_processor")>
        <XmlElement("_processor")>
        Public Property ProcessorResponse() As Processor
            Get
                Return m_ProcessorResponse
            End Get
            Set
                m_ProcessorResponse = Value
            End Set
        End Property
        Private m_ProcessorResponse As Processor

        ''' <summary>
        '''     The status code for the transaction
        ''' </summary>
        <DataMember(Name:="statusCode")>
        <XmlElement("statusCode")>
        Public Property StatusCode() As String
            Get
                Return m_StatusCode
            End Get
            Set
                m_StatusCode = Value
            End Set
        End Property
        Private m_StatusCode As String

        ''' <summary>
        '''     Transaction date/time in ISO8601 format
        ''' </summary>
        <DataMember(Name:="transactionDateTime")>
        <XmlElement("transactionDateTime")>
        Public Property TransactionDateTime() As String
            Get
                Return m_TransactionDateTime
            End Get
            Set
                m_TransactionDateTime = Value
            End Set
        End Property
        Private m_TransactionDateTime As String

        ''' <summary>
        '''     The transaction ID from the processor
        ''' </summary>
        <DataMember(Name:="transactionId")>
        <XmlElement("transactionId")>
        Public Property TransactionId() As String
            Get
                Return m_TransactionId
            End Get
            Set
                m_TransactionId = Value
            End Set
        End Property
        Private m_TransactionId As String

        ''' <summary>
        '''     A list of errors that occurred
        ''' </summary>
        <DataMember(Name:="_errors")>
        <XmlArray(ElementName:="_errors")>
        <XmlArrayItem(ElementName:="error")>
        Public Property Errors() As List(Of ApiError)
            Get
                Return m_Errors
            End Get
            Set
                m_Errors = Value
            End Set
        End Property
        Private m_Errors As List(Of ApiError)

        ''' <summary>
        '''     Indicates if there are errors
        ''' </summary>
        <DataMember(Name:="_hasErrors")>
        <XmlElement("_hasErrors")>
        Public Property HasErrors() As Boolean
            Get
                Return Me.Errors IsNot Nothing AndAlso Me.Errors.Count > 0
            End Get

            ' Do nothing, but needed for DataContract
            Set
            End Set
        End Property

        ''' <summary>
        '''     Gets or sets the links.
        ''' </summary>
        <DataMember(Name:="_links")>
        <XmlArray(ElementName:="_links")>
        <XmlArrayItem(ElementName:="link")>
        Public Property Links() As List(Of ApiLink)
            Get
                Return m_Links
            End Get
            Set
                m_Links = Value
            End Set
        End Property
        Private m_Links As List(Of ApiLink)

        ''' <summary>
        '''     A list of log entries detailing what happened during the request. Ideally only used during development or
        '''     troubleshooting as this can be quite verbose.
        ''' </summary>
        <DataMember(Name:="_logs")>
        <XmlArray(ElementName:="_logs")>
        <XmlArrayItem(ElementName:="log")>
        Public Property Logs() As List(Of String)
            Get
                Return m_Logs
            End Get
            Set
                m_Logs = Value
            End Set
        End Property
        Private m_Logs As List(Of String)

        ''' <summary>
        '''     The type of object held in the result, if any
        ''' </summary>
        <DataMember(Name:="_type")>
        <XmlElement("_type")>
        Public Property Type() As String
            Get
                Return m_Type
            End Get
            Set
                m_Type = Value
            End Set
        End Property
        Private m_Type As String

        ''' <summary>
        '''     Gets or sets the warnings.
        ''' </summary>
        <DataMember(Name:="_warnings")>
        <XmlArray(ElementName:="_warnings")>
        <XmlArrayItem(ElementName:="warning")>
        Public Property Warnings() As List(Of ApiWarning)
            Get
                Return m_Warnings
            End Get
            Set
                m_Warnings = Value
            End Set
        End Property
        Private m_Warnings As List(Of ApiWarning)

#End Region
    End Class

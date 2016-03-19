
Imports System.Runtime.Serialization
Imports System.Xml.Serialization

''' <summary>
'''     The request passed in for a card sale
''' </summary>
<DataContract(Name:="saleRequest")>
    <XmlRoot("saleRequest", [Namespace]:="http://tripos.vantiv.com/2014/09/TriPos.Api")>
    Public Class SaleRequest
#Region "Public Properties"

        ''' <summary>
        '''     Gets or sets the address.
        ''' </summary>
        <DataMember(Name:="address")>
        <XmlElement("address")>
        Public Property Address() As Address
            Get
                Return m_Address
            End Get
            Set
                m_Address = Value
            End Set
        End Property
        Private m_Address As Address

        ''' <summary>
        '''     The default amount of cashback. This amount is added to the TotalAmount before the cardholder is charged.
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
        '''     The convenience fee amount of the transaction. This amount is added to the TotalAmount before the cardholder is
        '''     charged.
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
        '''     The EMV fallback reason of the transaction.
        ''' </summary>
        <DataMember(Name:="emvFallbackReason")>
        <XmlElement("emvFallbackReason")>
        Public Property EmvFallbackReason() As String
            Get
                Return m_EmvFallbackReason
            End Get
            Set
                m_EmvFallbackReason = Value
            End Set
        End Property
        Private m_EmvFallbackReason As String

        ''' <summary>
        '''     The tip amount of the transaction. This amount is added to the TotalAmount before the cardholder is charged.
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
        '''     The amount of the transaction
        ''' </summary>
        <DataMember(Name:="transactionAmount")>
        <XmlElement("transactionAmount")>
        Public Property TransactionAmount() As Decimal
            Get
                Return m_TransactionAmount
            End Get
            Set
                m_TransactionAmount = Value
            End Set
        End Property
        Private m_TransactionAmount As Decimal

        ''' <summary>
        '''     The clerk number
        ''' </summary>
        <DataMember(Name:="clerkNumber")>
        <XmlElement("clerkNumber")>
        Public Property ClerkNumber() As String
            Get
                Return m_ClerkNumber
            End Get
            Set
                m_ClerkNumber = Value
            End Set
        End Property
        Private m_ClerkNumber As String

        ''' <summary>
        '''     The configuration section
        ''' </summary>
        <DataMember(Name:="configuration", IsRequired:=False)>
        <XmlElement("configuration")>
        Public Property Configuration() As Configuration
            Get
                Return m_Configuration
            End Get
            Set
                m_Configuration = Value
            End Set
        End Property
        Private m_Configuration As Configuration

        ''' <summary>
        '''     Required. Specifies which lane to use for the card sale.
        ''' </summary>
        <DataMember(Name:="laneId")>
        <XmlElement("laneId")>
        Public Property LaneId() As Integer
            Get
                Return m_LaneId
            End Get
            Set
                m_LaneId = Value
            End Set
        End Property
        Private m_LaneId As Integer

        ''' <summary>
        '''     The reference number for the transaction
        ''' </summary>
        <DataMember(Name:="referenceNumber")>
        <XmlElement("referenceNumber")>
        Public Property ReferenceNumber() As String
            Get
                Return m_ReferenceNumber
            End Get
            Set
                m_ReferenceNumber = Value
            End Set
        End Property
        Private m_ReferenceNumber As String

        ''' <summary>
        '''     The shift id
        ''' </summary>
        <DataMember(Name:="shiftId")>
        <XmlElement("shiftId")>
        Public Property ShiftId() As String
            Get
                Return m_ShiftId
            End Get
            Set
                m_ShiftId = Value
            End Set
        End Property
        Private m_ShiftId As String

        ''' <summary>
        '''     The ticket number.
        ''' </summary>
        <DataMember(Name:="ticketNumber")>
        <XmlElement("ticketNumber")>
        Public Property TicketNumber() As String
            Get
                Return m_TicketNumber
            End Get
            Set
                m_TicketNumber = Value
            End Set
        End Property
        Private m_TicketNumber As String

    Public Shared Function GetSaleRequest() As SaleRequest

        Dim request = New SaleRequest()
        request.Configuration = New Configuration()
        request.Address = New Address()

        request.Address.BillingAddress1 = "123 Sample Street"
        request.Address.BillingAddress2 = "Suite 101"
        request.Address.BillingCity = "Chandler"
        request.Address.BillingState = "AZ"
        request.Address.BillingPostalCode = "85224"

        request.ClerkNumber = "Clerk101"
        request.Configuration.CurrencyCode = "Usd"
        request.EmvFallbackReason = "None"
        request.LaneId = 9999
        request.Configuration.MarketCode = "Retail"
        request.Configuration.AllowPartialApprovals = False
        request.Configuration.CheckForDuplicateTransactions = True
        request.ReferenceNumber = "Ref000001"
        request.ShiftId = "ShiftA"
        request.TicketNumber = "T0000001"
        request.TransactionAmount = 3.25D

        Return request

    End Function


#End Region
End Class

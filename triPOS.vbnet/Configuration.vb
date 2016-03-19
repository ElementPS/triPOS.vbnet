
Imports System.Runtime.Serialization
Imports System.Xml.Serialization

''' <summary>
'''     The set of properties that override values in the triPOS.config file
''' </summary>
<DataContract(Name:="Configuration")>
    Public Class Configuration
        ''' <summary>
        '''     If set to true, partial approvals are allowed.
        ''' </summary>
        <DataMember(Name:="allowPartialApprovals", IsRequired:=True)>
        <XmlElement("allowPartialApprovals")>
        Public Property AllowPartialApprovals() As System.Nullable(Of Boolean)
            Get
                Return m_AllowPartialApprovals
            End Get
            Set
                m_AllowPartialApprovals = Value
            End Set
        End Property
        Private m_AllowPartialApprovals As System.Nullable(Of Boolean)

        ''' <summary>
        '''     If set to true, disables duplicate checking for the transactions.
        ''' </summary>
        <DataMember(Name:="checkForDuplicateTransactions", IsRequired:=True)>
        <XmlElement("checkForDuplicateTransactions")>
        Public Property CheckForDuplicateTransactions() As System.Nullable(Of Boolean)
            Get
                Return m_CheckForDuplicateTransactions
            End Get
            Set
                m_CheckForDuplicateTransactions = Value
            End Set
        End Property
        Private m_CheckForDuplicateTransactions As System.Nullable(Of Boolean)

        ''' <summary>
        '''     The currency code of the transaction
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
        '''     The market code of the transaction. Default, AutoRental, DirectMarketing, ECommerce, FoodRestaurant, HotelLodging, Petroleum, Retail, Qsr
        ''' </summary>
        <DataMember(Name:="marketCode")>
        <XmlElement("marketCode")>
        Public Property MarketCode() As String
            Get
                Return m_MarketCode
            End Get
            Set
                m_MarketCode = Value
            End Set
        End Property
        Private m_MarketCode As String
    End Class


Imports System.Runtime.Serialization
Imports System.Xml.Serialization
Imports Newtonsoft.Json

''' <summary>
''' The properties of a billing and shipping address.
''' </summary>
Public Class Address
    ''' <summary>
    '''     Gets or sets the street address used for billing purposes.
    ''' </summary>
    <DataMember(Name:="billingAddress1")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("billingAddress1")>
    Public Property BillingAddress1() As String
        Get
            Return m_BillingAddress1
        End Get
        Set
            m_BillingAddress1 = Value
        End Set
    End Property
    Private m_BillingAddress1 As String

    ''' <summary>
    '''     Gets or sets the street address used for billing purposes.
    ''' </summary>
    <DataMember(Name:="billingAddress2")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("billingAddress2")>
    Public Property BillingAddress2() As String
        Get
            Return m_BillingAddress2
        End Get
        Set
            m_BillingAddress2 = Value
        End Set
    End Property
    Private m_BillingAddress2 As String

    ''' <summary>
    '''     Gets or sets the name of the city used for billing purposes.
    ''' </summary>
    <DataMember(Name:="billingCity")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("billingCity")>
    Public Property BillingCity() As String
        Get
            Return m_BillingCity
        End Get
        Set
            m_BillingCity = Value
        End Set
    End Property
    Private m_BillingCity As String

    ''' <summary>
    '''     Gets or sets the e-mail address used for billing purposes.
    ''' </summary>
    <DataMember(Name:="billingEmail")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("billingEmail")>
    Public Property BillingEmail() As String
        Get
            Return m_BillingEmail
        End Get
        Set
            m_BillingEmail = Value
        End Set
    End Property
    Private m_BillingEmail As String

    ''' <summary>
    '''     Gets or sets the name used for billing purposes.
    ''' </summary>
    <DataMember(Name:="billingName")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("billingName")>
    Public Property BillingName() As String
        Get
            Return m_BillingName
        End Get
        Set
            m_BillingName = Value
        End Set
    End Property
    Private m_BillingName As String

    ''' <summary>
    '''     Gets or sets the phone number used for billing purposes. The recommended format is (800)555-1212.
    ''' </summary>
    <DataMember(Name:="billingPhone")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("billingPhone")>
    Public Property BillingPhone() As String
        Get
            Return m_BillingPhone
        End Get
        Set
            m_BillingPhone = Value
        End Set
    End Property
    Private m_BillingPhone As String

    ''' <summary>
    '''     Gets or sets the postal code used for billing purposes.
    ''' </summary>
    <DataMember(Name:="billingPostalCode")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("billingPostalCode")>
    Public Property BillingPostalCode() As String
        Get
            Return m_BillingPostalCode
        End Get
        Set
            m_BillingPostalCode = Value
        End Set
    End Property
    Private m_BillingPostalCode As String

    ''' <summary>
    '''     Gets or sets the name of the state used for billing purposes. This value may be any 2 character state code or the
    '''     full state name.
    ''' </summary>
    <DataMember(Name:="billingState")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("billingState")>
    Public Property BillingState() As String
        Get
            Return m_BillingState
        End Get
        Set
            m_BillingState = Value
        End Set
    End Property
    Private m_BillingState As String

    ''' <summary>
    '''     Gets or sets the street address used for shipping purposes.
    ''' </summary>
    <DataMember(Name:="shippingAddress1")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("shippingAddress1")>
    Public Property ShippingAddress1() As String
        Get
            Return m_ShippingAddress1
        End Get
        Set
            m_ShippingAddress1 = Value
        End Set
    End Property
    Private m_ShippingAddress1 As String

    ''' <summary>
    '''     Gets or sets the street address used for shipping purposes.
    ''' </summary>
    <DataMember(Name:="shippingAddress2")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("shippingAddress2")>
    Public Property ShippingAddress2() As String
        Get
            Return m_ShippingAddress2
        End Get
        Set
            m_ShippingAddress2 = Value
        End Set
    End Property
    Private m_ShippingAddress2 As String

    ''' <summary>
    '''     Gets or sets the name of the city used for shipping purposes.
    ''' </summary>
    <DataMember(Name:="shippingCity")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("shippingCity")>
    Public Property ShippingCity() As String
        Get
            Return m_ShippingCity
        End Get
        Set
            m_ShippingCity = Value
        End Set
    End Property
    Private m_ShippingCity As String

    ''' <summary>
    '''     Gets or sets the e-mail address used for shipping purposes.
    ''' </summary>
    <DataMember(Name:="shippingEmail")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("shippingEmail")>
    Public Property ShippingEmail() As String
        Get
            Return m_ShippingEmail
        End Get
        Set
            m_ShippingEmail = Value
        End Set
    End Property
    Private m_ShippingEmail As String

    ''' <summary>
    '''     Gets or sets the name used for shipping purposes.
    ''' </summary>
    <DataMember(Name:="shippingName")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("shippingName")>
    Public Property ShippingName() As String
        Get
            Return m_ShippingName
        End Get
        Set
            m_ShippingName = Value
        End Set
    End Property
    Private m_ShippingName As String

    ''' <summary>
    '''     Gets or sets the phone number used for shipping purposes. The recommended format is (800)555-1212
    ''' </summary>
    <DataMember(Name:="shippingPhone")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("shippingPhone")>
    Public Property ShippingPhone() As String
        Get
            Return m_ShippingPhone
        End Get
        Set
            m_ShippingPhone = Value
        End Set
    End Property
    Private m_ShippingPhone As String

    ''' <summary>
    '''     Gets or sets the postal code used for shipping purposes.
    ''' </summary>
    <DataMember(Name:="shippingPostalCode")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("shippingPostalCode")>
    Public Property ShippingPostalCode() As String
        Get
            Return m_ShippingPostalCode
        End Get
        Set
            m_ShippingPostalCode = Value
        End Set
    End Property
    Private m_ShippingPostalCode As String

    ''' <summary>
    '''     Gets or sets the name of the state used for shipping purposes. This value may be any 2 character state code or the
    '''     full state name.
    ''' </summary>
    <DataMember(Name:="shippingState")>
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    <XmlElement("shippingState")>
    Public Property ShippingState() As String
        Get
            Return m_ShippingState
        End Get
        Set
            m_ShippingState = Value
        End Set
    End Property
    Private m_ShippingState As String
End Class

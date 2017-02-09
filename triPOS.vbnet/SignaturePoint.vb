Imports System.Drawing
Imports System.Net
Imports System.Runtime.InteropServices


''' <summary>
'''     Contains the properties and methods necessary to handle signature point data
''' </summary>
<StructLayout(LayoutKind.Sequential, Pack:=1, Size:=4)>
Public Class SignaturePoint
    Inherits Object
    ''' <summary>
    '''     Pen up point.
    ''' </summary>
    Public Shared ReadOnly PenUp As New SignaturePoint(-1, -1)

    ''' <summary>
    '''     Empty point.
    ''' </summary>
    Public Shared ReadOnly Empty As New SignaturePoint(0, 0)

    ''' <summary>
    '''     Initializes a new instance of the <see cref="SignaturePoint" /> class.
    ''' </summary>
    ''' <param name="x">
    '''     The x.
    ''' </param>
    ''' <param name="y">
    '''     The y.
    ''' </param>
    Public Sub New(x As Short, y As Short)
        Me.X = x

        Me.Y = y
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the <see cref="SignaturePoint" /> class.
    ''' </summary>
    ''' <param name="x">
    '''     The x.
    ''' </param>
    ''' <param name="y">
    '''     The y.
    ''' </param>
    Public Sub New(x As Integer, y As Integer)
        Me.New(CShort(x), CShort(y))
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the <see cref="SignaturePoint" /> class.
    ''' </summary>
    ''' <param name="point">
    '''     The point.
    ''' </param>
    Public Sub New(point As SignaturePoint)
        Me.New(point.X, point.Y)
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the <see cref="SignaturePoint" /> class.
    ''' </summary>
    ''' <param name="data">
    '''     The data.
    ''' </param>
    ''' <param name="index">
    '''     The index.
    ''' </param>
    ''' <param name="bigEndian">
    '''     The big endian.
    ''' </param>
    Public Sub New(data As Byte(), index As Integer, bigEndian As Boolean)
        Me.New(DirectCast(ByteArrayToStructure(data, index, GetType(SignaturePoint)), SignaturePoint))
        If bigEndian Then
            Me.X = IPAddress.NetworkToHostOrder(Me.X)

            Me.Y = IPAddress.NetworkToHostOrder(Me.Y)
        End If
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the <see cref="SignaturePoint" /> class.
    ''' </summary>
    Public Sub New()
        Me.New(Empty)
    End Sub

    ''' <summary>
    '''     Gets or sets the x.
    ''' </summary>
    Public Property X() As Short
        Get
            Return m_X
        End Get
        Set
            m_X = Value
        End Set
    End Property
    Private m_X As Short

    ''' <summary>
    '''     Gets or sets the y.
    ''' </summary>
    Public Property Y() As Short
        Get
            Return m_Y
        End Get
        Set
            m_Y = Value
        End Set
    End Property
    Private m_Y As Short

    ''' <summary>
    '''     Gets the point.
    ''' </summary>
    Public ReadOnly Property Point() As Point
        Get
            Return New Point(Me.X, Me.Y)
        End Get
    End Property

    ''' <summary>
    '''     Gets a value indicating whether is pen up.
    ''' </summary>
    Public ReadOnly Property IsPenUp() As Boolean
        Get
            Return Me.Equals(PenUp)
        End Get
    End Property

    ''' <summary>
    '''     Gets a value indicating whether is empty.
    ''' </summary>
    Public ReadOnly Property IsEmpty() As Boolean
        Get
            Return Me.Equals(Empty)
        End Get
    End Property

    ''' <summary>
    '''     Determines whether the specified object is equal to the current object.
    ''' </summary>
    ''' <param name="obj">
    '''     The object to compare with the current object.
    ''' </param>
    ''' <returns>
    '''     true if the specified object is equal to the current object; otherwise, false.
    ''' </returns>
    Public Overrides Function Equals(obj As Object) As Boolean
        Return DirectCast(obj, SignaturePoint).X = Me.X AndAlso DirectCast(obj, SignaturePoint).Y = Me.Y
    End Function

    ''' <summary>
    '''     Gets the hash code.
    ''' </summary>
    ''' <returns>
    '''     The hash code.
    ''' </returns>
    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode()
    End Function

    ''' <summary>
    '''     The to string.
    ''' </summary>
    ''' <returns>
    '''     The <see cref="String" />.
    ''' </returns>
    Public Overrides Function ToString() As String
        Return "{" + Me.X + "," + Me.Y + "}"
    End Function

    ''' <summary>
    '''     The byte array to structure.
    ''' </summary>
    ''' <param name="source">
    '''     The source.
    ''' </param>
    ''' <param name="sourceIndex">
    '''     The source index.
    ''' </param>
    ''' <param name="destinationType">
    '''     The destination type.
    ''' </param>
    ''' <param name="length">
    '''     The length.
    ''' </param>
    ''' <returns>
    '''     The <see cref="Object" />.
    ''' </returns>
    Private Shared Function ByteArrayToStructure(source As Byte(), sourceIndex As Integer, destinationType As Type, Optional length As Integer = 0) As Object
        If length <= 0 Then
            length = Marshal.SizeOf(destinationType)
        End If

        Dim unmanagedMemory As IntPtr = Marshal.AllocHGlobal(length)

        Marshal.Copy(source, sourceIndex, unmanagedMemory, length)

        Dim returnValue As Object = Marshal.PtrToStructure(unmanagedMemory, destinationType)

        Marshal.FreeHGlobal(unmanagedMemory)

        Return returnValue
    End Function
End Class


Imports System.Collections.Generic
Imports System.Drawing
Imports System.Runtime.InteropServices

Public Class SignatureBuild
#Region "Fields"

    ''' <summary>
    '''     The format selected by the user.
    ''' </summary>
    Private format As String = String.Empty

    ''' <summary>
    '''     The maximum signature point.
    ''' </summary>
    Private maximumSignaturePoint As SignaturePoint

    ''' <summary>
    '''     The minimum signature point.
    ''' </summary>
    Private minimumSignaturePoint As SignaturePoint

    ''' <summary>
    '''     The signature format.
    ''' </summary>
    Private sigFormat As SignatureFormat

    ''' <summary>
    '''     The signature points.
    ''' </summary>
    Private signaturePoints As SignaturePoint()

#End Region

#Region "Enums"

    ''' <summary>
    '''     The signaturePoints signatureFormat.
    ''' </summary>
    Public Enum SignatureFormat
        ''' <summary>
        '''     The ASCII 3 byte.
        ''' </summary>
        Ascii3Byte

        ''' <summary>
        '''     The points big endian.
        ''' </summary>
        PointsBigEndian

        ''' <summary>
        '''     The points little endian.
        ''' </summary>
        PointsLittleEndian
    End Enum

#End Region

#Region "Public Methods and Operators"

    Public Function GetSignatureBitmap(padding As Integer) As Bitmap
        If Me.signaturePoints IsNot Nothing Then
            Dim bitmap = New Bitmap((Me.maximumSignaturePoint.X - Me.minimumSignaturePoint.X) + (padding * 2), (Me.maximumSignaturePoint.Y - Me.minimumSignaturePoint.Y) + (padding * 2))

            Dim bmpGraphics As Graphics = Graphics.FromImage(bitmap)

            bmpGraphics.Clear(Color.White)

            Dim pen = New Pen(Color.Red, 1.8F)

            Dim lastSignaturePoint As SignaturePoint = SignaturePoint.PenUp

            For Each signaturePoint__1 As SignaturePoint In Me.signaturePoints
                If Not signaturePoint__1.IsPenUp AndAlso Not lastSignaturePoint.IsPenUp Then
                    Dim x1 As Integer = (lastSignaturePoint.X - Me.minimumSignaturePoint.X) + padding

                    Dim y1 As Integer = (lastSignaturePoint.Y - Me.minimumSignaturePoint.Y) + padding

                    Dim x2 As Integer = (signaturePoint__1.X - Me.minimumSignaturePoint.X) + padding

                    Dim y2 As Integer = (signaturePoint__1.Y - Me.minimumSignaturePoint.Y) + padding

                    bmpGraphics.DrawLine(pen, x1, y1, x2, y2)
                End If

                lastSignaturePoint = signaturePoint__1
            Next

            Return bitmap
        End If

        Return Nothing
    End Function

    ''' <summary>
    '''     Set the signature data.
    ''' </summary>
    ''' <param name="data">
    '''     The signature data.
    ''' </param>
    Public Sub SetData(data As Byte())
        Select Case Me.sigFormat
            Case SignatureFormat.Ascii3Byte
                Me.ConvertAscii3Byte(data)
                Exit Select

            Case SignatureFormat.PointsLittleEndian, SignatureFormat.PointsBigEndian
                Me.ConvertPoints(data, 0)
                Exit Select
            Case Else

                Me.signaturePoints = Nothing
                Exit Select
        End Select
    End Sub

    ''' <summary>
    '''     Sets the signature format based on the item selected from the dropdown.
    ''' </summary>
    ''' <param name="formatInput">
    '''     The signature format.
    ''' </param>
    Public Sub SetFormat(formatInput As String)
        Me.format = formatInput

        Select Case Me.format
            Case "Ascii3Byte"
                Me.sigFormat = SignatureFormat.Ascii3Byte
                Exit Select
            Case "PointsBigEndian"
                Me.sigFormat = SignatureFormat.PointsBigEndian
                Exit Select
            Case "PointsLittleEndian"
                Me.sigFormat = SignatureFormat.PointsLittleEndian
                Exit Select
            Case Else
                Me.signaturePoints = Nothing
                Exit Select
        End Select
    End Sub

#End Region

#Region "Methods"

    ''' <summary>
    '''     Converts 3 byte ASCII data to the signature points array.
    ''' </summary>
    ''' <param name="data">
    '''     The 3 byte ASCII data.
    ''' </param>
    Private Sub ConvertAscii3Byte(data As Byte())
        Me.signaturePoints = Nothing

        Dim points = New List(Of SignaturePoint)()

        Me.minimumSignaturePoint = New SignaturePoint(Short.MaxValue, Short.MaxValue)

        Me.maximumSignaturePoint = New SignaturePoint(Short.MinValue, Short.MinValue)

        Dim signaturePoint__1 As SignaturePoint = SignaturePoint.Empty

        For dataIndex As Integer = 0 To data.Length - 1
            ' pen up
            If data(dataIndex) = &H70 Then
                points.Add(SignaturePoint.PenUp)

                signaturePoint__1 = SignaturePoint.Empty
            ElseIf data(dataIndex) >= &H60 AndAlso data(dataIndex) <= &H6F Then
                If (data.Length - dataIndex) < 4 Then
                    Throw New Exception("Invalid input data!")
                End If

                signaturePoint__1 = New SignaturePoint(CShort((((data(dataIndex) - &H60) And &HC) << 7) Or ((data(dataIndex + 1) - &H20) << 3) Or (((data(dataIndex + 3) - &H20) And &H38) >> 3)), CShort((((data(dataIndex) - &H60) And &H3) << 9) Or ((data(dataIndex + 2) - &H20) << 3) Or ((data(dataIndex + 3) - &H20) And &H7)))

                ' incremented to 4 at end of loop
                dataIndex += 3

                If points.Count = 0 Then
                    points.Add(SignaturePoint.PenUp)
                End If

                points.Add(New SignaturePoint(signaturePoint__1.X, signaturePoint__1.Y))

                Me.SetMinMaxSignaturePoint(signaturePoint__1)
            Else
                If (data.Length - dataIndex) < 3 Then
                    Throw New Exception("Invalid input data!")
                End If

                Dim dx = CShort((CShort(data(dataIndex) - &H20) << 3) Or ((CShort(data(dataIndex + 2) - &H20) And &H38) >> 3))

                ' may have to sign extend offset
                dx = CShort(CShort(dx << 7) >> 7)

                dataIndex += 1

                Dim dy = CShort((CShort(data(dataIndex) - &H20) << 3) Or (CShort(data(dataIndex + 1) - &H20) And &H7))

                ' may have to sign extend offset
                dy = CShort(CShort(dy << 7) >> 7)

                dataIndex += 1

                signaturePoint__1.X += dx

                signaturePoint__1.Y += dy

                If points.Count = 0 Then
                    points.Add(SignaturePoint.PenUp)
                End If

                points.Add(New SignaturePoint(signaturePoint__1.X, signaturePoint__1.Y))

                Me.SetMinMaxSignaturePoint(signaturePoint__1)
            End If
        Next

        Me.signaturePoints = points.ToArray()

        For Each point As SignaturePoint In Me.signaturePoints
            If Not point.IsPenUp Then
                point.Y = CShort(Me.maximumSignaturePoint.Y - point.Y + Me.minimumSignaturePoint.Y)
            End If
        Next
    End Sub

    ''' <summary>
    '''     Converts the points data to an array of SignaturePoints.
    ''' </summary>
    ''' <param name="data">
    '''     The points data.
    ''' </param>
    ''' <param name="startIndex">
    '''     The index within data to start the conversion.
    ''' </param>
    Private Sub ConvertPoints(data As Byte(), startIndex As Integer)
        Me.signaturePoints = Nothing

        Dim points = New List(Of SignaturePoint)()

        Me.minimumSignaturePoint = New SignaturePoint(Short.MaxValue, Short.MaxValue)

        Me.maximumSignaturePoint = New SignaturePoint(Short.MinValue, Short.MinValue)

        Dim signaturePoint__1 As SignaturePoint = SignaturePoint.Empty

        Dim dataIndex As Integer = startIndex
        While dataIndex < data.Length
            If (data.Length - dataIndex) >= Marshal.SizeOf(GetType(SignaturePoint)) Then
                signaturePoint__1 = New SignaturePoint(data, dataIndex, Me.sigFormat = SignatureFormat.PointsBigEndian)

                points.Add(signaturePoint__1)

                If Not signaturePoint__1.IsPenUp Then
                    Me.SetMinMaxSignaturePoint(signaturePoint__1)
                End If
            End If
            dataIndex += Marshal.SizeOf(GetType(SignaturePoint))
        End While

        Me.signaturePoints = points.ToArray()
    End Sub

    ''' <summary>
    '''     Sets the maximum and minimum X/Y signature points which are used to create the bounding box for the bitmap
    ''' </summary>
    ''' <param name="signaturePoint">The signature point to evaluate</param>
    Private Sub SetMinMaxSignaturePoint(signaturePoint As SignaturePoint)
        If signaturePoint.X > Me.maximumSignaturePoint.X Then
            Me.maximumSignaturePoint.X = signaturePoint.X
        End If

        If signaturePoint.X < Me.minimumSignaturePoint.X Then
            Me.minimumSignaturePoint.X = signaturePoint.X
        End If

        If signaturePoint.Y > Me.maximumSignaturePoint.Y Then
            Me.maximumSignaturePoint.Y = signaturePoint.Y
        End If

        If signaturePoint.Y < Me.minimumSignaturePoint.Y Then
            Me.minimumSignaturePoint.Y = signaturePoint.Y
        End If
    End Sub

#End Region
End Class

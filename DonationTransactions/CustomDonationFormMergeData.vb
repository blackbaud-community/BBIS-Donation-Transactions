Public Class CustomDonationFormMergeData
    Inherits BBNCExtensions.API.Merge.MergeData

    'create the datasource for our custom merge fields
    'then pass an instance of this class in the arguments
    'to Me.API.Transactions.RecordDonation(...) from your 
    'custom donation part

    Private mData As BBNCExtensions.API.Transactions.PaymentArgs

    Private mTotal As Single
    Private mQuantity As Single

    Public Sub New(ByVal Total As Single, ByVal quantity As Integer)
        mTotal = Total
        mQuantity = quantity
    End Sub

    Public Overrides Function GetDataForField(ByVal fieldId As Integer) As String
        Select Case CType(fieldId, CustomDonationFormMergeFields.EMyFieldIds)
            Case CustomDonationFormMergeFields.EMyFieldIds.Premium
                If mQuantity = 1 Then
                    Return "a pair of Flip Flops"
                Else
                    Return String.Format("{0} pairs of Flip Flops", mQuantity)
                End If

                'could support sending different gifts based on amount given:

                'If mTotal > 0 And mTotal < 100 Then
                '    Return "a free T-shirt"
                'ElseIf mTotal > 100 And mTotal < 1000 Then
                '    Return "a free weekend in Myrtle Beach"
                'ElseIf mTotal > 1000 And mTotal < 10000 Then
                '    Return "a Gucci Gift Certificate"
                'Else
                '    Return "a new Lexus."
                'End If

            Case CustomDonationFormMergeFields.EMyFieldIds.Link
                Return "<a href='http://labs.blackbaud.com'>Visit Labs</a>"
            Case Else
                Return ""
        End Select

    End Function

End Class

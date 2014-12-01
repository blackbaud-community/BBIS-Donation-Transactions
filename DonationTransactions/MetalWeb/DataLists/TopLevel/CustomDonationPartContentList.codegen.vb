Option Infer On
Option Strict On

Imports bbAppFxWebAPI = Blackbaud.AppFx.WebAPI



Namespace DataLists

    Namespace [TopLevel]

		    ''' <summary>
    ''' Provides WebApi access to the "Custom Donation Part Content List" catalog feature.  Returns all Custom Donation Part Content records.
    ''' </summary>
<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2010.7.1.0")> _
        Public NotInheritable Class [CustomDonationPartContentList]

            Private Sub New()
                'this is a static class (only shared methods) that should never be instantiated.
            End Sub

            Private Shared ReadOnly _specId As Guid = New Guid("cf6e8ec0-2f06-4944-9dbd-07db8526bba2")
            ''' <summary>
            ''' The DataList ID value for the "Custom Donation Part Content List" datalist
            ''' </summary>
            Public Shared ReadOnly Property SpecId() As Guid
                Get
                    Return _specId
                End Get
            End Property

			Private Shared ReadOnly _rowFactoryDelegate As Blackbaud.AppFx.WebAPI.DataListRowFactoryDelegate(Of [CustomDonationPartContentListRow]) = AddressOf CreateListRow

            Private Shared Function CreateListRow(ByVal rowValues As String()) As [CustomDonationPartContentListRow]
                Return New [CustomDonationPartContentListRow](rowValues)
            End Function

            Public Shared Function CreateRequest(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider) As bbAppFxWebAPI.ServiceProxy.DataListLoadRequest
                Return Blackbaud.AppFx.WebAPI.DataListServices.CreateDataListLoadRequest(provider, [CustomDonationPartContentList].SpecId)
            End Function
            
            Public Shared Function GetRows(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider  ) As CustomDonationPartContentListRow()

				

                Dim request = CreateRequest(provider)

				
				
				 
				
                Return GetRows(provider, request)

            End Function

            Public Shared Function GetRows(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal request As bbAppFxWebAPI.ServiceProxy.DataListLoadRequest) As CustomDonationPartContentListRow()
                Return bbAppFxWebAPI.DataListServices.GetListRows(Of [CustomDonationPartContentListRow])(provider, _rowFactoryDelegate, request)
            End Function

        End Class

#Region "Row Data Class"

		<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2010.7.1.0")> _
		<System.Serializable> _
        Public NotInheritable Class [CustomDonationPartContentListRow]

            
Private [_ID] As System.Guid
Public Property [ID] As System.Guid
    Get
        Return Me.[_ID]
    End Get
    Set
        Me.[_ID] = value 
    End Set
End Property

Private [_EMAILTEMPLATEID] As Integer
Public Property [EMAILTEMPLATEID] As Integer
    Get
        Return Me.[_EMAILTEMPLATEID]
    End Get
    Set
        Me.[_EMAILTEMPLATEID] = value 
    End Set
End Property

Private [_APPEALID] As Integer
Public Property [APPEALID] As Integer
    Get
        Return Me.[_APPEALID]
    End Get
    Set
        Me.[_APPEALID] = value 
    End Set
End Property

Private [_MERCHANTACCOUNTID] As System.Guid
Public Property [MERCHANTACCOUNTID] As System.Guid
    Get
        Return Me.[_MERCHANTACCOUNTID]
    End Get
    Set
        Me.[_MERCHANTACCOUNTID] = value 
    End Set
End Property

Private [_FUNDID] As Integer
Public Property [FUNDID] As Integer
    Get
        Return Me.[_FUNDID]
    End Get
    Set
        Me.[_FUNDID] = value 
    End Set
End Property

Private [_PRICE] As Decimal
Public Property [PRICE] As Decimal
    Get
        Return Me.[_PRICE]
    End Get
    Set
        Me.[_PRICE] = value 
    End Set
End Property




			Public Sub New()
				Mybase.New()
			End Sub

            Friend Sub New(ByVal dataListRowValues() As String)

                Blackbaud.AppFx.WebAPI.DataListServices.ValidateDataListOutputColumnCount(5, dataListRowValues, CustomDonationPartContentList.SpecId)

Me.[_ID] = Blackbaud.AppFx.DataListUtility.DataListStringValueToGuid(dataListRowValues(0))

Me.[_EMAILTEMPLATEID] = Blackbaud.AppFx.DataListUtility.DataListStringValueToInt(dataListRowValues(1))

Me.[_APPEALID] = Blackbaud.AppFx.DataListUtility.DataListStringValueToInt(dataListRowValues(2))

Me.[_MERCHANTACCOUNTID] = Blackbaud.AppFx.DataListUtility.DataListStringValueToGuid(dataListRowValues(3))

Me.[_FUNDID] = Blackbaud.AppFx.DataListUtility.DataListStringValueToInt(dataListRowValues(4))

Me.[_PRICE] = Blackbaud.AppFx.DataListUtility.DataListStringValueToDec(dataListRowValues(5))



            End Sub

        End Class
        
#End Region


  
    End Namespace

End Namespace



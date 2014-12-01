Option Infer On
Option Strict Off

Imports bbAppFxWebAPI = Blackbaud.AppFx.WebAPI



Namespace ViewForms

    Namespace [CustomDonationPartContent]
    
		    ''' <summary>
    ''' Provides WebApi access to the "Custom Donation Part Content View Form" catalog feature.  Used for viewing a given Custom Donation Part Content
    ''' </summary>
<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2010.7.1.0")> _
        Public NotInheritable Class [CustomDonationPartContentViewForm]

            Private Sub New()
            End Sub

            Private Shared ReadOnly _specId As Guid = New Guid("cf416013-e527-4758-8fdc-c4239cc74770")

			''' <summary>
			''' The Spec ID value for the "Custom Donation Part Content View Form" ViewForm
			''' </summary>
            Public Shared ReadOnly Property SpecId() As Guid
                Get
                    Return _specId
                End Get
            End Property
 
            Public Shared Function CreateRequest(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider) As bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest
                Return Blackbaud.AppFx.WebAPI.DataFormServices.CreateDataFormLoadRequest(provider, _specId)
            End Function
            
            Public Shared Function LoadData(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider , ByVal recordId As String ) As CustomDonationPartContentViewFormData

				bbAppFxWebAPI.DataFormServices.ValidateRecordId(recordId)

                Dim request = CreateRequest(provider)

				
				
				request.RecordID = recordId

                Return LoadData(provider, request)

            End Function

            Public Shared Function LoadData(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal request As bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest) As CustomDonationPartContentViewFormData
                Return bbAppFxWebAPI.DataFormServices.GetFormData(Of CustomDonationPartContentViewFormData)(provider, request)
            End Function

        End Class

#Region "Data Class"
	
	    ''' <summary>
        ''' Represents the data form field values in the "Custom Donation Part Content View Form" data form.
        ''' </summary>
		<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2010.7.1.0")> _
	    Public NotInheritable Class CustomDonationPartContentViewFormData
			Inherits bbAppFxWebAPI.ViewFormData
		
			Private [_EMAILTEMPLATEID] As Nullable(of Integer)
''' <summary>
''' Optional field. Emailtemplateid
''' </summary>
Public Property [EMAILTEMPLATEID] As Nullable(of Integer)
    Get
        Return Me.[_EMAILTEMPLATEID]
    End Get
    Set
        Me.[_EMAILTEMPLATEID] = value 
    End Set
End Property

Private [_APPEALID] As Nullable(of Integer)
''' <summary>
''' Optional field. Appealid
''' </summary>
Public Property [APPEALID] As Nullable(of Integer)
    Get
        Return Me.[_APPEALID]
    End Get
    Set
        Me.[_APPEALID] = value 
    End Set
End Property

Private [_FUNDID] As Nullable(of Integer)
''' <summary>
''' Optional field. Fundid
''' </summary>
Public Property [FUNDID] As Nullable(of Integer)
    Get
        Return Me.[_FUNDID]
    End Get
    Set
        Me.[_FUNDID] = value 
    End Set
End Property

Private [_PRICE] As Nullable(of Decimal)
''' <summary>
''' Optional field. Price
''' </summary>
Public Property [PRICE] As Nullable(of Decimal)
    Get
        Return Me.[_PRICE]
    End Get
    Set
        Me.[_PRICE] = value 
    End Set
End Property

Private [_MERCHANTACCOUNTID] As Nullable(of System.Guid)
''' <summary>
''' Required field. Merchantaccountid
''' </summary>
Public Property [MERCHANTACCOUNTID] As Nullable(of System.Guid)
    Get
        Return Me.[_MERCHANTACCOUNTID]
    End Get
    Set
        Me.[_MERCHANTACCOUNTID] = value 
    End Set
End Property


	        
			Public Sub New()
				MyBase.New()
			End Sub

			Public Sub New(ByVal reply as bbAppFxWebAPI.ServiceProxy.DataFormLoadReply)
				If (reply IsNot Nothing) AndAlso (reply.DataFormItem IsNot Nothing) Then
					Me.SetValues(reply.DataFormItem)
				End If
			End Sub
        
			Public Sub New(ByVal dataFormItemXml As String)
				MyBase.New()
				Me.SetValuesFromDataFormItem(dataFormItemXml)
			End Sub
        
			Public Overrides ReadOnly Property DataFormInstanceID() As System.Guid
				Get
					Return ViewForms.[CustomDonationPartContent].CustomDonationPartContentViewForm.SpecId
				End Get
			End Property
	    
			Friend Sub SetValues(ByVal dfi As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem)
	            
				
Dim value As Object = Nothing
Dim dfiFieldValue As Blackbaud.AppFx.XmlTypes.DataForms.DataFormFieldValue = Nothing
Dim guidFieldValue As System.Guid
value = Nothing
dfiFieldValue = Nothing
If dfi.TryGetValue("EMAILTEMPLATEID", dfiFieldValue) Then
	If dfiFieldValue IsNot Nothing Then
	value = dfiFieldValue.Value
If (value IsNot Nothing) AndAlso (value IsNot System.DBNull.Value) Then
If TypeOf value Is String Then 
Me.[EMAILTEMPLATEID] = Blackbaud.AppFx.DataListUtility.DataListStringValueToInt(value)

Else
Me.[EMAILTEMPLATEID] = value
End If
End If

	End If

End If

value = Nothing
dfiFieldValue = Nothing
If dfi.TryGetValue("APPEALID", dfiFieldValue) Then
	If dfiFieldValue IsNot Nothing Then
	value = dfiFieldValue.Value
If (value IsNot Nothing) AndAlso (value IsNot System.DBNull.Value) Then
If TypeOf value Is String Then 
Me.[APPEALID] = Blackbaud.AppFx.DataListUtility.DataListStringValueToInt(value)

Else
Me.[APPEALID] = value
End If
End If

	End If

End If

value = Nothing
dfiFieldValue = Nothing
If dfi.TryGetValue("FUNDID", dfiFieldValue) Then
	If dfiFieldValue IsNot Nothing Then
	value = dfiFieldValue.Value
If (value IsNot Nothing) AndAlso (value IsNot System.DBNull.Value) Then
If TypeOf value Is String Then 
Me.[FUNDID] = Blackbaud.AppFx.DataListUtility.DataListStringValueToInt(value)

Else
Me.[FUNDID] = value
End If
End If

	End If

End If

value = Nothing
dfiFieldValue = Nothing
If dfi.TryGetValue("PRICE", dfiFieldValue) Then
	If dfiFieldValue IsNot Nothing Then
	value = dfiFieldValue.Value
If (value IsNot Nothing) AndAlso (value IsNot System.DBNull.Value) Then
If TypeOf value Is String Then 
Me.[PRICE] = Blackbaud.AppFx.DataListUtility.DataListStringValueToDec(value)

Else
Me.[PRICE] = value
End If
End If

	End If

End If

guidFieldValue = System.Guid.Empty
If dfi.TryGetValueForPropertyAssignment("MERCHANTACCOUNTID", guidFieldValue) Then
Me.[MERCHANTACCOUNTID] = guidFieldValue
End If


	            
			End Sub
				
			Public Overrides Sub SetValuesFromDataFormItem(ByVal dataFormItem As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem)
				Me.SetValues(dataFormItem)
			End Sub

			
	 
		End Class

#End Region
    
    End Namespace

End Namespace




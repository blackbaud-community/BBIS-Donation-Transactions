Option Infer On
Option Strict Off

Imports bbAppFxWebAPI = Blackbaud.AppFx.WebAPI



Namespace AddForms

    Namespace [CustomDonationPartContent]
    
		

		    ''' <summary>
    ''' Provides WebApi access to the "Custom Donation Part Content Add Form" catalog feature.  Used for adding a new Custom Donation Part Content
    ''' </summary>
<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2010.7.1.0")> _
        Public NotInheritable Class [CustomDonationPartContentAddForm]

            Private Sub New()
            End Sub

            Private Shared ReadOnly _specId As Guid = New Guid("206b72b1-9e75-4d8e-833a-a0ab0058dba3")

			''' <summary>
			''' The Spec ID value for the "Custom Donation Part Content Add Form" AddForm
			''' </summary>
            Public Shared ReadOnly Property SpecId() As Guid
                Get
                    Return _specId
                End Get
            End Property
 
            Public Shared Function CreateLoadRequest(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider) As bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest
                Return Blackbaud.AppFx.WebAPI.DataFormServices.CreateDataFormLoadRequest(provider, _specId)
            End Function

            ''' <summary>
            ''' Returns an instance of CustomDonationPartContentAddFormData with default data form fields populated.
            ''' </summary>
            ''' <returns>An instance of CustomDonationPartContentAddFormData with the form field properties that have defaults populated with those default values.</returns>
            ''' <remarks>This function will make a web request to the AppFx WebService DataFormLoad method to obtain the default data form field values.</remarks>
            Public Shared Function LoadData(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider ) As CustomDonationPartContentAddFormData

				

                Dim request = CreateLoadRequest(provider)

				
				
				

                Return LoadData(provider, request)

            End Function          

            ''' <summary>
            ''' Returns an instance of CustomDonationPartContentAddFormData with default data form fields populated.
            ''' </summary>
            ''' <returns>An instance of CustomDonationPartContentAddFormData with the form field properties that have defaults populated with those default values.</returns>
            ''' <remarks>This function will make a web request to the AppFx WebService DataFormLoad method to obtain the default data form field values.</remarks>
            Public Shared Function LoadData(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal request As bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest) As CustomDonationPartContentAddFormData
                Return bbAppFxWebAPI.DataFormServices.GetFormData(Of CustomDonationPartContentAddFormData)(provider, request)
            End Function
   
        End Class

#Region "Data Class"

        ''' <summary>
        ''' Represents the data form field values in the "Custom Donation Part Content Add Form" data form.
        ''' </summary>
		<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2010.7.1.0")> _
	    Public NotInheritable Class CustomDonationPartContentAddFormData
			Inherits bbAppFxWebAPI.AddFormData
        
#Region "Constructors"
        
			Public Sub New()
				Mybase.New()
			End Sub

			Friend Sub New(ByVal reply as bbAppFxWebAPI.ServiceProxy.DataFormLoadReply,request as bbAppFxWebAPI.ServiceProxy.DataFormLoadRequest)
				Mybase.New()					
				If (reply IsNot Nothing) AndAlso (reply.DataFormItem IsNot Nothing) Then
					Me.SetValues(reply.DataFormItem)
				End If
			End Sub
        
        	Public Sub New(ByVal dfi as Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem)
				Mybase.New()					
				Me.SetValues(dfi)
			End Sub
			
			Public Sub New(ByVal dataFormItemXml As String)
                MyBase.New()
                Me.SetValuesFromDataFormItem(dataFormItemXml)
            End Sub

#End Region
        
#Region "Form Field Properties"

Private [_EMAILTEMPLATEID] As Nullable(of Integer) = 0
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

Private [_APPEALID] As Nullable(of Integer) = 0
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

Private [_FUNDID] As Nullable(of Integer) = 0
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

Private [_PRICE] As Nullable(of Decimal) = "20"
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

        

#End Region

            Public Overrides ReadOnly Property DataFormInstanceID() As System.Guid
                Get
                    Return AddForms.[CustomDonationPartContent].CustomDonationPartContentAddForm.SpecId
                End Get
            End Property

            Public Overrides Function ToDataFormItem() As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem
                Return Me.BuildDataFormItemForSave()
            End Function
    
			Friend Sub SetValues(ByVal dfi As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem)
				
				If dfi Is Nothing Then Exit Sub
	            
				
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

			Private Function BuildDataFormItemForSave() As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem
        
				Dim dfi As New Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem	 
	                    
				Dim value As Object = Nothing
value = Me.[EMAILTEMPLATEID]
	dfi.SetValueIfNotNull("EMAILTEMPLATEID",value)
value = Me.[APPEALID]
	dfi.SetValueIfNotNull("APPEALID",value)
value = Me.[FUNDID]
	dfi.SetValueIfNotNull("FUNDID",value)
value = Me.[PRICE]
	dfi.SetValueIfNotNull("PRICE",value)
value = Me.[MERCHANTACCOUNTID]
	dfi.SetValueIfNotNull("MERCHANTACCOUNTID",value)

	    
				Return dfi	    
	        
			End Function
			
			Public Overrides Sub SetValuesFromDataFormItem(ByVal dataFormItem As Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem)
                Me.SetValues(dataFormItem)
            End Sub
            
			
	 
		End Class
    
#End Region
    
    End Namespace

End Namespace


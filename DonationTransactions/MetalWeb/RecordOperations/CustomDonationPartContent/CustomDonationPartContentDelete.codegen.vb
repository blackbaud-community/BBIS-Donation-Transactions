Option Infer On
Option Strict On

Imports bbAppFxWebAPI = Blackbaud.AppFx.WebAPI



Namespace RecordOperations

	Namespace [CustomDonationPartContent]
			
    ''' <summary>
    ''' Provides WebApi access to the "Custom Donation Part Content Delete" catalog feature.  Used to delete the given Custom Donation Part Content
    ''' </summary>
<System.CodeDom.Compiler.GeneratedCodeAttribute("BBMetalWeb", "2010.7.1.0")> _
		Public NotInheritable Class [CustomDonationPartContentDelete]

			Private Sub New()
			End Sub

			Private Shared _specId As Guid = New Guid("23be397d-4f09-44eb-9093-a0059de3df80")

			''' <summary>
			''' The Spec ID value for the "Custom Donation Part Content Delete" record operation
			''' </summary>
			Public Shared ReadOnly Property SpecId() As Guid
				Get
					Return _specId
				End Get
			End Property
			
			Public Shared Function CreateRequest(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider) As bbAppFxWebAPI.ServiceProxy.RecordOperationPerformRequest
                Return bbAppFxWebAPI.RecordOpServices.CreateRecordOperationPerformRequest(provider, [CustomDonationPartContentDelete].SpecId)
            End Function			

			Public Shared Sub ExecuteOperation(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider , ByVal recordID As String)
			
				Dim request = CreateRequest(provider)
				
				request.ID = recordID
				
				ExecuteOperation(provider, request)
			End Sub
			
 #If 0 Then    			
			Public Shared Sub ExecuteOperation(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider , ByVal recordID As String )
				Dim request = CreateRequest(provider)
				
				request.ID = recordID
			
				 
			
				ExecuteOperation(provider, request)
			End Sub
 #End If			
			
			Public Shared Sub ExecuteOperation(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider, ByVal request As bbAppFxWebAPI.ServiceProxy.RecordOperationPerformRequest)
				bbAppFxWebAPI.RecordOpServices.ExecuteOperation(provider, request)
			End Sub
			
			Public Shared Function GetPrompt(ByVal provider As bbAppFxWebAPI.AppFxWebServiceProvider , ByVal recordID As String) As String
			
				Dim request = bbAppFxWebAPI.RecordOpServices.CreateGetPromptRequest(provider, [CustomDonationPartContentDelete].SpecId)
				
				request.ID = recordID
			
				Return bbAppFxWebAPI.RecordOpServices.GetPrompt(provider, request)
			End Function
			
		End Class
		


	End Namespace
	
End Namespace



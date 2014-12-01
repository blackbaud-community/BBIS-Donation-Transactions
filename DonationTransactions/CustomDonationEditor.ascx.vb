Imports BBNCExtensions

Partial Public Class CustomDonationEditor
    Inherits BBNCExtensions.Parts.CustomPartEditorBase


    Private mContent As CustomDonationProperties  'not used in this sample

    'infinity metalweb data object class that will hold our content properties
    Private mInfinityContent As EditForms.CustomDonationPartContent.CustomDonationPartContentEditFormData

    'custom view state variables
    Private Const VS_IS_NEW_PART As String = "IsNewPart"

    'messages
    Private Const MERCHANT_ACCOUNT_VALIDATION_MESSAGE As String = "Please select at a merchant account"

    'flag true if first time edit of this part (no content data in db yet)
    Private mIsNewPart As Boolean


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Public Overrides Sub OnLoadContent()
        MyBase.OnLoadContent()

        If Not IsPostBack Then

            'first time load
            Me.API.Utility.MerchantAccount.LoadListWithMerchantAcccounts(ddlMerchantAccounts, True, MyInfinityContent.MERCHANTACCOUNTID)

            'Configure the Campaign/Funds/Appeals picker control provided by the API
            With cfaAppealSelect

                'known issue with CFAServer control: you must set its properties in code behind and
                'NOT in the ascx markup - or suffer an object variable not set error

                'here we are telling it which record type to search (campaigns, funds, or appeals)
                .SearchType = BBNCExtensions.ServerControls.CFAPicker.RecordSearchType.Appeal

                'set CFA picker to currently selected appeal
                .CFAId = MyInfinityContent.APPEALID.ToString
            End With


            With CFADesignationSelect
                'here we are telling it which record type to search (campaigns, funds, or appeals)
                .SearchType = BBNCExtensions.ServerControls.CFAPicker.RecordSearchType.Fund

                'set CFA picker to currently selected designation
                .CFAId = MyInfinityContent.FUNDID.ToString

            End With

            txtPrice.Text = MyInfinityContent.PRICE.Value

        End If

        'this needs to be done on each postback too
        With EmailEditor1

            .TemplateID = MyInfinityContent.EMAILTEMPLATEID

            'add default donation merge fields to email editor
            .MergeFields = BBNCExtensions.Interfaces.EMergeFields.Donation

            'add our custom merge fields to email editor
            .CustomMergeFields = New CustomDonationFormMergeFields

        End With


    End Sub

    Public Overrides Function OnSaveContent(Optional ByVal bDialogIsClosing As Boolean = True) As Boolean

        'write my content properties back to infinity

        If Me.IsValid Then
            Try

                'save the email template first
                Dim TemplateId

                'save email template first, we'll hold on to its ID in our properties
                TemplateId = EmailEditor1.Save

                If Me.IsNewPart Then
                    Dim newContentData = New AddForms.CustomDonationPartContent.CustomDonationPartContentAddFormData
                    With newContentData
                        .RecordID = Me.Content.ContentGuid.ToString
                        .APPEALID = CInt(cfaAppealSelect.CFAId)
                        .FUNDID = CInt(CFADesignationSelect.CFAId)
                        .PRICE = CSng(txtPrice.Text)
                        .EMAILTEMPLATEID = TemplateId
                        .MERCHANTACCOUNTID = New Guid(ddlMerchantAccounts.SelectedValue)
                        .Save(Me.API.AppFxWebServiceProvider)
                    End With
                Else
                    With MyInfinityContent
                        .EMAILTEMPLATEID = TemplateId
                        .APPEALID = CInt(cfaAppealSelect.CFAId)
                        .FUNDID = CInt(CFADesignationSelect.CFAId)
                        .PRICE = CSng(txtPrice.Text)
                        .MERCHANTACCOUNTID = New Guid(ddlMerchantAccounts.SelectedValue)
                        .Save(Me.API.AppFxWebServiceProvider)
                    End With
                End If

                'now that we've saved possible changes to the content we need to clear the 
                'cache so the display control gets it from the db again
                CacheHelper.RemoveObjectFromCache(Me.Content.ContentGuid.ToString)


            Catch ex As Exception
                AddValidationError(ex.Message)
            End Try
        End If

        'all good. return true so editor dialog will close as long as we're still valid
        Return Page.IsValid

    End Function

    Public ReadOnly Property IsValid() As Boolean
        Get

            Page.Validate()

            Dim _isValid = Page.IsValid
            Dim validationMessage = String.Empty

            If Guid.Empty.Equals(New Guid(ddlMerchantAccounts.SelectedValue)) Then
                validationMessage = MERCHANT_ACCOUNT_VALIDATION_MESSAGE
            End If

            If Not String.IsNullOrEmpty(validationMessage) Then
                _isValid = False
                AddValidationError(validationMessage)
            End If

            Return _isValid
        End Get
    End Property

    Private Sub AddValidationError(ByVal errorMessage As String)
        'add our failed validator to the common validation summary on the dialog
        Dim validException As New CustomValidator
        validException.Visible = False
        validException.ErrorMessage = errorMessage
        validException.IsValid = False
        validException.ValidationGroup = Me.ValidationGroup
        Me.Controls.Add(validException)
    End Sub

    Private ReadOnly Property MyInfinityContent As EditForms.CustomDonationPartContent.CustomDonationPartContentEditFormData
        Get
            If mInfinityContent Is Nothing Then
                'fetch my content properties from infinity.

                Try
                    mInfinityContent = EditForms.CustomDonationPartContent.CustomDonationPartContentEditForm.LoadData(Me.API.AppFxWebServiceProvider, Me.Content.ContentGuid.ToString)
                Catch ex As Blackbaud.AppFx.WebAPI.AppFxWebServiceException When ex.DataFormErrorInfo IsNot Nothing AndAlso ex.DataFormErrorInfo.ErrorCode = Blackbaud.AppFx.WebAPI.ServiceProxy.DataFormErrorCode.RecordNotFound
                    'first time I've edited this part - this is OK to fail - we'll create new record
                    'all other (unexptected) errors we won't catch for now 
                End Try

                If mInfinityContent Is Nothing Then

                    'new part - save this to view state - we'll need to know this when we save
                    Me.IsNewPart = True

                    mInfinityContent = New EditForms.CustomDonationPartContent.CustomDonationPartContentEditFormData

                    'set some defaults to load the form with 
                    mInfinityContent.RecordID = Me.Content.ContentGuid.ToString
                    mInfinityContent.APPEALID = 0
                    mInfinityContent.EMAILTEMPLATEID = 0
                    mInfinityContent.MERCHANTACCOUNTID = Guid.Empty

                End If

            End If
            Return mInfinityContent
        End Get
    End Property

    Public Property IsNewPart() As Boolean
        'true if this part's content has not been saved in the infinity db yet
        Get
            If ViewState(VS_IS_NEW_PART) IsNot Nothing Then
                mIsNewPart = CBool(ViewState(VS_IS_NEW_PART))
            End If
            Return mIsNewPart
        End Get
        Set(ByVal value As Boolean)
            ViewState(VS_IS_NEW_PART) = value
        End Set
    End Property

    'not used
    Private ReadOnly Property MyContent() As CustomDonationProperties
        Get
            'in this sample we won't be using this built-in content storage mechanism
            'since we are referencing other CMS and CRM artifacts such as email templates and Appeal Records
            'we're using an infinity table and associated specs and metalweb code to persist our content
            'see MyInfinityContent property above.
            If mContent Is Nothing Then
                mContent = Me.Content.GetContent(GetType(CustomDonationProperties))
                If mContent Is Nothing Then
                    mContent = New CustomDonationProperties
                End If
            End If
            Return mContent
        End Get
    End Property


End Class
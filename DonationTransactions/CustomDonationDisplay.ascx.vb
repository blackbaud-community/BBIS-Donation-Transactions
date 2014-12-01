Imports BBNCExtensions


Partial Public Class CustomDonationDisplay
    Inherits BBNCExtensions.Parts.CustomPartDisplayBase

    Private mInfinityContent As EditForms.CustomDonationPartContent.CustomDonationPartContentEditFormData

    'flag true if part has not been configured
    Private mIsNewPart As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then

            If Me.Content.InDesignMode Then
                'show some sample content?
                'no need to load the form for real while in the CMS page designer
            Else
                InitializeForm()
            End If

            'pull the userspecified caption for the amount due field
            lblCaptionAmount.Text = Me.GetLanguageString("{8c34555c-5d08-419c-ac2b-3bc38b0dde21}")

        End If


    End Sub

    Private Sub InitializeForm()

        'first load of form get args from API with current user data filled in,
        'initializing controls with as much known user bio data as possible. If user is logged in
        'and linked to backoffice then we get the latest name and primary address already
        'filled in on the form. Nice touch.

        imgHeading.ImageUrl = Page.ClientScript.GetWebResourceUrl(GetType(CustomDonationProperties), "InfinityPartSample2.flips.jpg")
        imgThanks.ImageUrl = Page.ClientScript.GetWebResourceUrl(GetType(CustomDonationProperties), "InfinityPartSample2.flips.jpg")

        Dim Args As BBNCExtensions.API.Transactions.PaymentArgs
        Args = Me.API.Transactions.CreatePaymentArgs(True)

        With Args
            tbFirstName.Text = .FirstName
            tbLastName.Text = .LastName
            tbCardHolder.Text = .CreditCardHolderName
            tbStreet.Text = .DonorAddress.StreetAddress
            tbCity.Text = .DonorAddress.City
            tbZip.Text = .DonorAddress.ZIP
            tbEmail.Text = .EmailAddress
            tbPhone.Text = .Phone

            LoadStates(ddlStates, .DonorAddress.StateProvince)

        End With

    End Sub

    Private Sub LoadDesignations()
        If MyInfinityContent IsNot Nothing Then

        End If
    End Sub


    Private Sub LoadStates(ByVal dd As DropDownList, ByVal selectedValue As String)

        'code table numbers can be found in 
        'Blackbaud.PIA.RE7.BBInterfaces in the ECodeTableNumbers enum
        'Blackbaud.PIA.RE7.BBInterfaces is in your \RE\PIA folder of your RE install
        'I used the hex value here, since that what Reflector shows - which I used to peruse
        'Blackbaud.PIA.RE7.BBInterfaces

        'NOTE: even the infinity version of BBNC still uses the "RE7" WebService to get common entities
        'from the CRM - it just uses a version of the service that hits infinity instead of RE7.
        'this abstraction allowed us to implement an infinity version of BBNC relatively quickly

        Me.API.Utility.CodeTables.LoadListWithCodeTableEntries(dd, CInt("&H13B9"), selectedValue, True, True)

    End Sub


    Private Function CreateDonationArgs() As BBNCExtensions.API.Transactions.PaymentArgs

        'Ready to save donation. Start over with empty payment arguments object and fill
        'with data from form.
        Dim oArgs As BBNCExtensions.API.Transactions.PaymentArgs = Me.API.Transactions.CreatePaymentArgs(False)

        With oArgs

            .DemoMode = True  'always return "approved" from CC gateway (don't actually clear the card)
            .MerchantAccountId = 1  'selected mechant account id from bbnc - can get this number from the merchant acocunt display in admin 
            .SkipCardNumberValidation = True  'for testing purposes allows any mindless string of data as acceptable as the cc number.

            .EmailAcknowledgementId = MyInfinityContent.EMAILTEMPLATEID 'the email TemplateID that the emailEditor API server control 
            '(used in our CustomDonationForm editor) gave us when we saved our content for the first time

            'price of 1 pair of flip flops is set in part's content editor
            Dim totalDue As Decimal = CInt(ddlQty.SelectedValue) * MyInfinityContent.PRICE

            'add selected designation
            Dim oDes As New BBNCExtensions.API.Transactions.PaymentArgs.DesignationInfo
            With oDes
                'if you know the fund system record id, use it - automatch will kick in in CRM when
                'we download the transaction
                'If you don't specify a BackofficeID then be sure to use .Description 
                'so CRM will prompt you to look it up when 
                'you download/process the transaction
                'In our case we specified the fund to use in the part's content editor
                .BackofficeId = MyInfinityContent.FUNDID
                .Amount = totalDue
                .Description = ""
            End With

            .Designations.Add(oDes)

            'You can add as many designations (splits) as you like - this sample only allows one
            ''split gift (multiple designations)
            'If cbPoor.Checked Then
            '    oDes = New BBNCExtensions.API.Transactions.PaymentArgs.DesignationInfo
            '    With oDes
            '        .Amount = 1.0
            '        .Description = "Services for the Poor"
            '    End With
            '    .Designations.Add(oDes)
            'End If

            'provide data to email acknowledgement custom merge fields
            .CustomMergeData = New CustomDonationFormMergeData(totalDue, CInt(ddlQty.SelectedValue))


            'tribute
            'This sample does not create a tribute - I hid the tribute section on the form for now
            .IsTribute = (Len(.TributeName) > 0)
            .TributeName = Trim(String.Format("{0} {1}", tbTribFName.Text, tbTribLName.Text))
            .TributeType = tbTribType.Text
            .TributeDesciption = tbTribDesc.Text

            'You can accept comments from the user, or hard code some if you like
            .Comments = ""
            .DonorAddress.City = tbCity.Text
            .DonorAddress.StateProvince = ddlStates.SelectedValue
            .DonorAddress.StreetAddress = tbStreet.Text
            .DonorAddress.ZIP = tbZip.Text
            .EmailAddress = tbEmail.Text
            .FirstName = tbFirstName.Text
            .LastName = tbLastName.Text

            'we selected the appeal to use in the part's editor
            .AppealID = MyInfinityContent.APPEALID

            'only taking credit card pmts in this sample, 
            'but check out the other options...BBNCExtensions.API.Transactions.PaymentArgs.ePaymentMethod enum
            .PaymentMethod = BBNCExtensions.API.Transactions.PaymentArgs.ePaymentMethod.CreditCard
            .CreditCardCSC = tbCSC.Text
            .CreditCardExpirationMonth = ddExpMonth.SelectedValue
            .CreditCardExpirationYear = ddExpYear.SelectedValue
            .CreditCardHolderName = tbCardHolder.Text
            .CreditCardNumber = tbCCNumber.Text
            .CreditCardType = CType(ddCardType.SelectedValue, BBNCExtensions.Interfaces.Services.CreditCardType)

        End With

        'Dim oTest As New CustomDonationFormMergeData("69.00", 69)
        'Me.API.Emails.EmailJob.Send(Me.Page, MyContent.TemplateID, "michael.andrews@blackbaud.com", "Michael", oTest)

        Return oArgs

    End Function

    Private Sub RecordDonation()

        Dim sMessage As String = Nothing

        pnlMessage.Visible = False
        Dim oargs As BBNCExtensions.API.Transactions.PaymentArgs = Me.CreateDonationArgs

        Try
            Dim oReply As BBNCExtensions.API.Transactions.Donations.RecordDonationReply = Me.API.Transactions.RecordDonation(oargs)

            Dim bSuccess As Boolean = True

            If oReply.CreditCardAuthorizationResponse IsNot Nothing Then
                Select Case oReply.CreditCardAuthorizationResponse.ResultCode
                    Case BBNCExtensions.Interfaces.Services.ECreditCardResultCode.Approved
                        bSuccess = True

                    Case BBNCExtensions.Interfaces.Services.ECreditCardResultCode.BBValidationError
                        sMessage = String.Format("Error processing credit card. {0}", oReply.CreditCardAuthorizationResponse.BBValidationErrorCode.ToString)
                        bSuccess = False

                    Case BBNCExtensions.Interfaces.Services.ECreditCardResultCode.GateWayDecline
                        sMessage = "Error processing credit card. Gateway declined."
                        bSuccess = False

                End Select
            Else
                'in demo mode, or non-credit card purchase (pledge)
                bSuccess = True
            End If


            If bSuccess Then
                'spit out an alert with customizable message

                Dim msgThanks = Me.GetLanguageString("{82b89886-0be4-40a7-aa62-0ba995cd62b9}")

                ScriptManager.RegisterStartupScript(Me.Page, GetType(CustomDonationDisplay), "onDonate", String.Format("alert('{0}');", msgThanks), True)
                pnlForm.Visible = False
                pnlThanks.Visible = True
            End If

        Catch exArgOutOfRange As ArgumentOutOfRangeException
            sMessage = exArgOutOfRange.ParamName

        Catch exArg As ArgumentException

            sMessage = exArg.Message

        Catch exWeb As BBNCExtensions.API.WebServiceException

            sMessage = exWeb.Message

        Catch exIncomplete As BBNCExtensions.API.Transactions.Donations.IncompleteDonationTransaction
            'this rare scenario means the card was cleared but a network or other error prevented the donation transaction
            'from being recorded in bbnc. Do NOT want to force user to resubmit form - exit gracefully and figure out what to 
            'do. Maybe log the transaction data to an exception log? 
            sMessage = String.Concat(exIncomplete.Message, " [", exIncomplete.InnerException.Message, "]")

        Catch exAPI As BBNCExtensions.API.Transactions.Donations.RecordDonationException
            sMessage = exAPI.Message

        Catch ex As Exception
            sMessage = ex.Message
        End Try

        If sMessage IsNot Nothing Then
            pnlMessage.Visible = True
            pnlMessage.Controls.Add(New LiteralControl(sMessage))
        End If

    End Sub

    Protected Sub btnDonate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDonate.Click
        RecordDonation()
    End Sub

    Private ReadOnly Property MyInfinityContent As EditForms.CustomDonationPartContent.CustomDonationPartContentEditFormData
        Get
            If mInfinityContent Is Nothing Then

                'first check the cache 
                Dim o As Object = CacheHelper.GetObjectFromCache(Me.Content.ContentGuid.ToString)

                If o IsNot Nothing Then
                    'got it from cache 
                    mInfinityContent = DirectCast(o, EditForms.CustomDonationPartContent.CustomDonationPartContentEditFormData)
                    Return mInfinityContent
                End If

                'not in cache - keep looking

                'fetch my content properties from infinity
                Try
                    mInfinityContent = EditForms.CustomDonationPartContent.CustomDonationPartContentEditForm.LoadData(Me.API.AppFxWebServiceProvider, Me.Content.ContentGuid.ToString)
                Catch ex As Blackbaud.AppFx.WebAPI.AppFxWebServiceException When ex.DataFormErrorInfo IsNot Nothing AndAlso ex.DataFormErrorInfo.ErrorCode = Blackbaud.AppFx.WebAPI.ServiceProxy.DataFormErrorCode.RecordNotFound
                    'first time I've edited this part - this is OK to fail - we'll create new record
                    'all other (unexptected) errors we won't catch for now 
                End Try

                If mInfinityContent Is Nothing Then

                    'small problem...no content saved for this part - this is possibe if the part was created but the
                    'user closed the editor dialog w/out ever saving 

                    mInfinityContent = New EditForms.CustomDonationPartContent.CustomDonationPartContentEditFormData

                    'set some defaults to load the display
                    mInfinityContent.RecordID = Me.Content.ContentGuid.ToString
                    mInfinityContent.APPEALID = 0
                    mInfinityContent.EMAILTEMPLATEID = 0
                    mInfinityContent.MERCHANTACCOUNTID = Guid.Empty

                Else
                    'found and loaded from db
                    'lets cache it now - for me and everyone else 
                    CacheHelper.AddObjectToCache(mInfinityContent, Me.Content.ContentGuid.ToString)
                End If

            End If
            Return mInfinityContent
        End Get
    End Property

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        'spit out javascript to hook up jQuery event for price calculation
        'mySample2 function is decalred in ascx (in the real world it would be in an included script file)

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "mySample2Init", String.Format("$(document).ready(function () {{mySample2({0});}});", MyInfinityContent.PRICE.ToString), True)

    End Sub

    Public Overrides Sub RegisterLanguageFields()
        'define user-editable strings that can be edited on the Language Tab for this part 
        Me.RegisterLanguageField("{8c34555c-5d08-419c-ac2b-3bc38b0dde21}", lblCaptionAmount, "Amount Caption", "Amt Due:", "Field Captions", False)
        Me.RegisterLanguageField("{82b89886-0be4-40a7-aa62-0ba995cd62b9}", Nothing, "Thank you message", "Thanks for flippin out!", "Messages", False)
    End Sub


End Class
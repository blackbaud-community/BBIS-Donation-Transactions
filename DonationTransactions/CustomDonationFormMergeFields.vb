Public Class CustomDonationFormMergeFields
    Inherits BBNCExtensions.API.Merge.MergeFields

    'define the custom merge fields that will be added to the email editor

    'all ids must be unique across categories and individual fields
    'we split them into to emums for readability
    Public Enum EMyFieldCategories
        GiftSummary = 1
    End Enum
    Public Enum EMyFieldIds
        Premium = 2
        Link = 3
    End Enum
    Public Sub New()

        'define hierarchy
        Me.Name = "Alumni Gift"

        With Me.Fields
            'add category(s) first
            'by just adding new MergeField items to my Fields collection
            .Add(EMyFieldCategories.GiftSummary, New BBNCExtensions.API.Merge.MergeField(EMyFieldCategories.GiftSummary, "Alumni Gift"))

            'do the same for fields but provide third parameter = parent field id (which is a category)
            .Add(EMyFieldIds.Premium, New BBNCExtensions.API.Merge.MergeField(EMyFieldIds.Premium, "Gift Description", EMyFieldCategories.GiftSummary))
            .Add(EMyFieldIds.Link, New BBNCExtensions.API.Merge.MergeField(EMyFieldIds.Link, "Link", EMyFieldCategories.GiftSummary))
        End With
    End Sub

End Class

Public Class CacheHelper

    'NOTE: the Blackbaud.Web.Content.Core caching functions referenced in this code have been moved to their
    'own assembly as of 6.40 (2011 Q3 release). They will still be visible through the core assembly but
    'future code should use the new direct path to the soon to be released new assembly 
    'Blackbaud.Appfx.ContentManagement.Plaform.Core.dll - thus allowing you to not require a reference
    'to Blackbaud.Web.Content.Core in the future since ITS BACKWARD COMPATIBILITY CAN NOT BE GUARANTEED.

    Public Shared Function AddObjectToCache(ByVal o As Object, ByVal key As String) As Boolean
        Return Blackbaud.Web.Content.Core.DataObject.AddObjectToCache(o, key)
    End Function

    Public Shared Function GetObjectFromCache(ByVal key As String) As Object
        Return Blackbaud.Web.Content.Core.DataObject.GetObjectFromCache(key)
    End Function

    Public Shared Function RemoveObjectFromCache(ByVal key As String)
        Return Blackbaud.Web.Content.Core.DataObject.RemoveObjectFromCache(Nothing, key)
    End Function


End Class

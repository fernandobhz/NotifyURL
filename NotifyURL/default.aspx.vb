Imports Datta

Public Class notify
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If Not String.IsNullOrEmpty(Me.Request.Url.Query) Then
                Using db As New NoteDB("c:\public\notes.datta")
                    db.Notes.Add(New Note With {.Id = db.Notes.NextId, .Description = System.Web.HttpUtility.UrlDecode(Me.Request.Url.Query.Substring(1)), .Received = Now, .RemoteIP = System.Web.HttpContext.Current.Request.UserHostAddress.ToString})
                    db.SaveChanges()
                End Using
                'Note.Notes.Add(New Note With {.Description = System.Web.HttpUtility.UrlDecode(Me.Request.Url.Query.Substring(1)), .Received = Now, .RemoteIP = System.Web.HttpContext.Current.Request.UserHostAddress.ToString})
            End If
        End If
    End Sub

End Class

Public Class Note
    Property Id As Integer
    Property Received As Date
    Property RemoteIP As String
    Property Description As String

    'Public Shared Notes As New List(Of Note)

    Public Function SelectAll()

        Using db = New NoteDB("c:\public\notes.datta")
            Return db.Notes.ToList().OrderByDescending(Function(x) x.Received).ToList
        End Using

        'Notes = Notes.Take(100).ToList
        'Return Notes
    End Function

End Class

Public Class NoteDB
    Inherits Dattabase

    Sub New(Path As String)
        MyBase.New(Path, "Admin", "")
    End Sub

    Property Notes As Dattable(Of Note)
End Class
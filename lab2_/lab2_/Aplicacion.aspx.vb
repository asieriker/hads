Imports accesodatosSQL.accesodatosSQL


Public Class Aplicacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim startSoundPlayer = New System.Media.SoundPlayer("audios/tieneunnuevofs.wav")
        'startSoundPlayer.Play()
        Dim result As String
        result = conectar()
        Label1.Text = result
    End Sub

End Class
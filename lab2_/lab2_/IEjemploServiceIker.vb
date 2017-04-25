Imports System.ServiceModel

' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de interfaz "IEjemploServiceIker" en el código y en el archivo de configuración a la vez.
<ServiceContract()>
Public Interface IEjemploServiceIker

    <OperationContract()>
    Function GetUsuarios() As System.Data.DataSet

End Interface

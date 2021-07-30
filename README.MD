# Demo .NET

Demo que incluye capacidades de .NET para crear aplicaciones Web con Blazor Server, WinForms, gRPC.

# WeatherApi (gRPC)
Este servicio consulta la api de AccuWeather mediante un Worker Service y cachea los resultados con MemoryCache. Tiene un endpoint gRPC que soporta streaming.

Para ejecutar el proyecto es necesario tener un API KEY de AccuWeather y agregar la misma al UserSecrets como propiedad accuweathertoken

# WeatherClientLib
Proyecto que contiene el archivo protobuf del servicio gRPC y añade extensiones para crear un cliente de la aplicación.

# WeatherConsoleApp
Proyecto de consola que demuestra el llamado al servicio gRPC

# WinForms
Aplicaciones de escritorio con WinForms usando .NET 5 para Windows. La aplicacion fue convertida a .NET Core usando la herramienta try-convert

`dotnet tool install -g try-convert`

Esta aplicación se conecta al servicio gRPC para mostrar los datos del clima actual.

# BlazorWeather.Server
Aplicación Web construida con Blazor Server que consulta los datos del clima desde el servicio gRPC y muestra el resultado en la web. Utiliza una librería razor para demostrar la forma de compartir código y componentes en aplicaciones Blazor.

_Esta demo esta basada en la conferencia de dotnet 2019._
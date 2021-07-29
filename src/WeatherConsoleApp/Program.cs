using System;
using System.Text.Json;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;

namespace WeatherConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Weather.Weather.WeatherClient(channel);

            var reply = client.GetWeather(new Empty());

            var json = JsonSerializer.Serialize(reply);

            Console.WriteLine(json);

            Console.ReadKey();
        }
    }
}
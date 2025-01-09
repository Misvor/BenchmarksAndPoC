using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace FrameworkExaustAllSockets
{
    internal class Program
    {
        // static async Task Main(string[] args)
        // {
        //     Console.WriteLine("Let the carnage begin!");
        //     Console.ReadKey();
        //     var desiredBlockedSockets = 3_500;
        //     //GC.TryStartNoGCRegion(15_000,lohSize: 15_000, false);
        //     for (var i = 0; i < desiredBlockedSockets; i++)
        //     {
        //         var httpClient = new HttpClient();
        //         var socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Tcp);
        //         
        //         var catFact = httpClient.GetAsync("https://localhost:44370/WeatherForecast/Nothing");
        //         GC.KeepAlive(httpClient);
        //         GC.KeepAlive(socket);
        //         Console.WriteLine($"{await catFact} Started!");
        //         Console.WriteLine($"{nameof(httpClient)} number {i} created!");
        //         Console.WriteLine($"{nameof(httpClient)} number is {IPGlobalProperties.GetIPGlobalProperties().GetTcpIPv4Statistics().CurrentConnections} ");
        //         if (i == (desiredBlockedSockets -1))
        //         {
        //            var result = httpClient.GetAsync("https://localhost:44370/WeatherForecast/Nothing");
        //            //GC.EndNoGCRegion();
        //            Console.WriteLine(result);
        //            Console.ReadLine();
        //         }
        //     }
        // }
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Let the carnage begin!");
            Console.ReadKey();
            var messagesToSend = 3_500;
            var largeString = new string('A', 86_000);
            var jsonData = JsonConvert.SerializeObject(largeString);
            var content = new StringContent(jsonData,Encoding.Unicode,"application/json");
            
            for (var i = 0; i < messagesToSend; i++)
            {
                var httpClient = new HttpClient();
                
                var result = await httpClient.PostAsync("https://localhost:44370/WeatherForecast/LargeString", content);
                // It disposes content after sending LOL
                
                Console.WriteLine( await result.Content.ReadAsStringAsync());
            }
        }
    }
}

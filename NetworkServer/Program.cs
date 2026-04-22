using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace NetworkServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string baseIp = "192.168.50.";
            int start = 2;
            int end = 224;

            var activos = await EscanearRangoAsync(baseIp, start, end);

            Console.WriteLine("\nIPs que respondieron al ping:");
            foreach (var ip in activos)
            {
                Console.WriteLine(ip);
            }

            // Guardar resultados en archivo de log
            GuardarResultados(activos, "ips_activas.txt");
            Console.WriteLine($"\nResultados guardados en ips_activas.txt");
        }

        /// <summary>
        /// Escanea un rango de IPs en paralelo usando tareas asíncronas
        /// </summary>
        static async Task<List<string>> EscanearRangoAsync(string baseIp, int start, int end)
        {
            var tasks = new List<Task<(string ip, bool activo)>>();

            for (int i = start; i <= end; i++)
            {
                string ip = baseIp + i;
                tasks.Add(RealizarPingAsync(ip));
            }

            var results = await Task.WhenAll(tasks);

            var activos = new List<string>();
            foreach (var result in results)
            {
                if (result.activo)
                    activos.Add(result.ip);
            }

            return activos;
        }

        /// <summary>
        /// Realiza ping asíncrono a una IP y devuelve si está activa
        /// </summary>
        static async Task<(string ip, bool activo)> RealizarPingAsync(string ipAddress)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = await ping.SendPingAsync(ipAddress, 1000); // timeout 1s
                    return (ipAddress, reply.Status == IPStatus.Success);
                }
            }
            catch
            {
                return (ipAddress, false);
            }
        }

        /// <summary>
        /// Guarda las IPs activas en un archivo de texto
        /// </summary>
        static void GuardarResultados(List<string> activos, string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, true)) // true = append
                {
                    writer.WriteLine($"--- Escaneo realizado el {DateTime.Now} ---");
                    foreach (var ip in activos)
                    {
                        var index = activos.IndexOf(ip) + 1;
                        writer.WriteLine(string.Format("{0}: {1}",index, ip));
                    }
                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar resultados: {ex.Message}");
            }
        }
    }
}

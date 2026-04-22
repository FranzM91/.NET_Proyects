using System.Net.NetworkInformation;

namespace google.server.Business
{
    public class PingSchedulerBusiness
    {
        /**
         * using System;
           using PingMonitorLib;

           class Program
           {
                static void Main(string[] args)
                {
                    var scheduler = new PingScheduler("192.168.50.", 2, 224);
                    scheduler.Start();

                    Console.WriteLine("Ping monitor iniciado. Presiona Enter para detener...");
                    Console.ReadLine();

                    scheduler.Stop();
                }
            }
         */

        private Timer _timer;
        private readonly string _baseIp;
        private readonly int _start;
        private readonly int _end;
        private readonly string _logFile;
        public PingSchedulerBusiness(string baseIp, int start, int end, string logFile = "ips_activas.txt")
        {
            _baseIp = baseIp;
            _start = start;
            _end = end;
            _logFile = logFile;
        }

        public void Start()
        {
            _timer = new Timer(async _ => await EjecutarTarea(), null, 0, 2000);
        }

        /// <summary>
        /// Detiene el cron job
        /// </summary>
        public void Stop()
        {
            _timer?.Dispose();
        }

        private async Task EjecutarTarea()
        {
            var activos = await EscanearRangoAsync(_baseIp, _start, _end);
            GuardarResultados(activos, _logFile);
        }

        private async Task<List<string>> EscanearRangoAsync(string baseIp, int start, int end)
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

        private async Task<(string ip, bool activo)> RealizarPingAsync(string ipAddress)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = await ping.SendPingAsync(ipAddress, 1000);
                    return (ipAddress, reply.Status == IPStatus.Success);
                }
            }
            catch
            {
                return (ipAddress, false);
            }
        }

        private void GuardarResultados(List<string> activos, string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    writer.WriteLine($"--- Escaneo realizado el {DateTime.Now} ---");
                    foreach (var ip in activos)
                    {
                        writer.WriteLine(ip);
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

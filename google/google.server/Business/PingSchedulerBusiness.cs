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
        private readonly List<string> allIps;
        //private readonly string logFile;
        private readonly UsuarioBusiness usuarioBusiness;
        public PingSchedulerBusiness(string logFile = "ips_activas.txt")
        {
            this.allIps = new List<string>();
            //this.logFile = logFile;
            usuarioBusiness = new UsuarioBusiness();
        }

        public void Start()
        {
            var usuarios = usuarioBusiness.getAllIps();
            allIps.AddRange(allIps);
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
            var fueraDeServicio = await EscanearRangoAsync(allIps);
            GuardarResultados(fueraDeServicio);
        }

        private async Task<List<string>> EscanearRangoAsync(List<string> allIps)
        {
            var tasks = new List<Task<(string ip, bool activo)>>();

            foreach (var ip in allIps)
            {
                tasks.Add(RealizarPingAsync(ip));
            }

            var results = await Task.WhenAll(tasks);

            var fueraDeServicio = new List<string>();
            foreach (var result in results)
            {
                if (!result.activo)
                    fueraDeServicio.Add(result.ip); // TODO: Guardar ip que estan fuera de servicio
            }

            return fueraDeServicio;
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

        private void GuardarResultados(List<string> fueraDeServicio)
        {
            //try
            //{
            //    using (StreamWriter writer = new StreamWriter(fileName, true))
            //    {
            //        writer.WriteLine($"--- Escaneo realizado el {DateTime.Now} ---");
            //        foreach (var ip in activos)
            //        {
            //            writer.WriteLine(ip);
            //        }
            //        writer.WriteLine();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error al guardar resultados: {ex.Message}");
            //}
            foreach (var item in fueraDeServicio)
            {
                var usuarioEntity = usuarioBusiness.getByIp(item);
                if (usuarioEntity != null)
                {
                    usuarioEntity.status = false;
                    usuarioBusiness.Save(usuarioEntity);
                }
            }
        }
    }
}

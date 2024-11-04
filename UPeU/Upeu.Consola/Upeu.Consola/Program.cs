using System;
using upea.server;
using upea.server.Business;

namespace Upeu.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
            Console.WriteLine("Porfavor ingrese su usuario!");
            var usuario = Console.ReadLine();
            Console.WriteLine("Porfavor ingrese su contraseña!");
            var password = Console.ReadLine();
            var data = new Usuario()
            {
                nombre = usuario,
                password = password,
            };

            // validar si el usuario es valido
            Console.WriteLine("Estamos validando las credenciales...");
            var resultUsuario = usuarioBusiness.ValidarUsuario(data);
            if (resultUsuario)
            {
                Console.WriteLine("Credenciales validas!");
                Console.WriteLine("Por favor ingrese al cotrolador que necesita ingresar");
                var controlador = Console.ReadLine();
                /**
                 * compra, venta, gestion  -- Controladores disponibles
                 */
                var resultControlador = usuarioBusiness.ValidarControlador(data, controlador);
                if (resultControlador)
                {
                    Console.WriteLine("Tiene Acceso al controlador!");
                    Console.WriteLine("Bienvenido al Sistema");
                }
                else
                {
                    Console.WriteLine("No autorizado al controlador!");
                }
            }
            else
            {
                Console.WriteLine("Credenciales invalidas!");
            }
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAutomotrizProgramacionII.Client
{
    internal class ClientSingleton
    {
        private static ClientSingleton instance;
        private HttpClient client;
        public ClientSingleton()
        {
            client = new HttpClient();
        }
        public static ClientSingleton ObtenerCliente() {
            if (instance == null) instance = new ClientSingleton();
            return instance;
        }
    }
}

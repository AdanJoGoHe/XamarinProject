using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Collections.ObjectModel;
using oldSolutions.Modelo;
namespace oldSolutions.Vista
{
    class HttpCliente
    {
        private const string _http = "http://";
        private const string _ipLocal = "serex.ddns.net";
        private const string _puerto = ":3000/";
        private string _Url; 
        private readonly HttpClient _response = new HttpClient(); //Instancia HttpClient. (System.Net.Http)        

        
        public HttpClient Response { get => _response; }
        public string Url { get => _Url; private set { _Url = value; } }
        
        // La url representa la ruta a llamar
        public HttpCliente(string url)
        {
            this.Url = _http + _ipLocal + _puerto + url;            
        }
    }
}


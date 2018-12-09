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
        
        private const string _ipLocal = "192.168.1.76";
        private string _Url; //This url is a free public api intended for demos
        private HttpClient _response = new HttpClient(); //Creating a new instance of HttpClient. (Microsoft.Net.Http)        

        
        public HttpClient Response { get => _response; }
        public string Url { get => _Url; private set { _Url = value; } }
        public ObservableCollection<PostOperador> Posts { get; set ; }

        public HttpCliente(string url)
        {
            this.Url = "http://" + _ipLocal + ":3000/" + url;
        }


    }
}

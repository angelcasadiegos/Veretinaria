﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class RespuestaConsultaServicio
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public IList<Servicio> servicios { get; set; }
    }

    public class ResponseBusquedaServicio
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Servicio servicio { get; set; }
    }

}


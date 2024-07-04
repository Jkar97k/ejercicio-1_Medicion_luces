using Api.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.service
{
    public class PatronLucesService : IPatronLucesService
    {
        private static PatronLuces _patronLuces = new PatronLuces();

        public bool ConfiguracionLuces(PatronLuces patron)
        {
            try
            {
                _patronLuces = patron;
                return true; 
            }
            catch 
            {
                return false; 
            }
        }

        public PatronLuces ObtenerConfiguracion()
        {
            return _patronLuces;
        }
    }
}

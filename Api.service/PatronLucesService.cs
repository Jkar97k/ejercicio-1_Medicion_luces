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

        public int ConfiguracionLuces(PatronLuces patron)
        {
            try
            {
                if (patron == null) return 0;

                _patronLuces = patron;

                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }


        }

        public PatronLuces ObtenerConfiguracion()
        {
            return _patronLuces;
        }
    }
}

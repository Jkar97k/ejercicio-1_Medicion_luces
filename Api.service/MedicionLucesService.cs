using Api.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.service
{
    public class MedicionLucesService : IMedicionLucesService
    {
        private readonly IPatronLucesService _patronLucesService;
        public List<string> LucesConMedicionRequerida { get; } = new List<string>();
        public List<string> LucesConMedicionNoRequerida { get; } = new List<string>();

        public MedicionLucesService(IPatronLucesService patronLucesService)
        {
            _patronLucesService = patronLucesService;
        }

        public object Validacion(MedicionLuz medicion)
        {
            // Limpiar las listas antes de realizar la validación
            LucesConMedicionRequerida.Clear();
            LucesConMedicionNoRequerida.Clear();

            var patron = _patronLucesService.ObtenerConfiguracion();

            // Validación para Int_Baja_Izq_1

            if (!patron.Int_Baja_Izq_1 && medicion.Int_Baja_Izq_1 != null)
            {
                LucesConMedicionNoRequerida.Add(nameof(medicion.Int_Baja_Izq_1));
            }
            else if (patron.Int_Baja_Izq_1 && (medicion.Int_Baja_Izq_1 == null || medicion.Int_Baja_Izq_1 <= 0))
            {
                LucesConMedicionRequerida.Add(nameof(medicion.Int_Baja_Izq_1));
            }

            // Validación para Inc_Baja_Izq_1
            if (!patron.Inc_Baja_Izq_1 && medicion.Inc_Baja_Izq_1 != null)
            {
                LucesConMedicionNoRequerida.Add(nameof(medicion.Inc_Baja_Izq_1));
            }
            else if (patron.Inc_Baja_Izq_1 && (medicion.Inc_Baja_Izq_1 == null || medicion.Inc_Baja_Izq_1 <= 0))
            {
                LucesConMedicionRequerida.Add(nameof(medicion.Inc_Baja_Izq_1));
            }

            // Validación para Int_Baja_Der_1
            if (!patron.Int_Baja_Der_1 && medicion.Int_Baja_Der_1 != null)
            {
                LucesConMedicionNoRequerida.Add(nameof(medicion.Int_Baja_Der_1));
            }
            else if (patron.Int_Baja_Der_1 && (medicion.Int_Baja_Der_1 == null || medicion.Int_Baja_Der_1 <= 0))
            {
                LucesConMedicionRequerida.Add(nameof(medicion.Int_Baja_Der_1));
            }

            // Crear el objeto de respuesta
            var respuesta = new
            {
                LucesRequeridas = LucesConMedicionRequerida,
                LucesNoRequeridas = LucesConMedicionNoRequerida
            };

            // Devolver el objeto de respuesta
            return respuesta;
        }

    }
}

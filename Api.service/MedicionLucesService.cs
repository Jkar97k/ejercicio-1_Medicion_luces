using Api.Entidades;
using Api.Interfaces;
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
        private readonly IapiLogger<MedicionLucesService> _logger;

        public MedicionLucesService(IPatronLucesService patronLucesService, IapiLogger<MedicionLucesService> logger)
        {
            _patronLucesService = patronLucesService;
            _logger = logger;
        }

        public IList<string> LucesConMedicionRequerida { get; } = new List<string>();
        public IList<string> LucesConMedicionNoRequerida { get; } = new List<string>();

        public object Validacion(MedicionLuz medicion)
        {
            // Limpiar las listas antes de realizar la validación
            LucesConMedicionRequerida.Clear();
            LucesConMedicionNoRequerida.Clear();

            var patron = _patronLucesService.ObtenerConfiguracion();
     
            _logger.loadInformation($"{nameof(patron)} Se Cargo Correctamente");

            // Validación para Int_Baja_Izq_1

            if (!patron.Int_Baja_Izq_1 && medicion.Int_Baja_Izq_1 != null)
            {
                LucesConMedicionNoRequerida.Add(nameof(medicion.Int_Baja_Izq_1));

                _logger.loadWarning($"{nameof(medicion.Int_Baja_Izq_1)} Se agrega a la lista LucesConMedicionNoRequerida");
            }
            else if (patron.Int_Baja_Izq_1 && (medicion.Int_Baja_Izq_1 == null || medicion.Int_Baja_Izq_1 <= 0))
            {
                LucesConMedicionRequerida.Add(nameof(medicion.Int_Baja_Izq_1));

                _logger.loadWarning($"{nameof(medicion.Int_Baja_Izq_1)} Se agrega a la lista LucesConMedicionRequerida");
            }

            // Validación para Inc_Baja_Izq_1
            if (!patron.Inc_Baja_Izq_1 && medicion.Inc_Baja_Izq_1 != null)
            {
                LucesConMedicionNoRequerida.Add(nameof(medicion.Inc_Baja_Izq_1));

                _logger.loadWarning($"{nameof(medicion.Inc_Baja_Izq_1)} Se agrega a la lista LucesConMedicionNoRequerida");
            }
            else if (patron.Inc_Baja_Izq_1 && (medicion.Inc_Baja_Izq_1 == null || medicion.Inc_Baja_Izq_1 < 0))
            {
                LucesConMedicionRequerida.Add(nameof(medicion.Inc_Baja_Izq_1));

                _logger.loadWarning($"{nameof(medicion.Inc_Baja_Izq_1)} Se agrega a la lista LucesConMedicionRequerida");
            }

            // Validación para Int_Baja_Der_1
            if (!patron.Int_Baja_Der_1 && medicion.Int_Baja_Der_1 != null)
            {
                LucesConMedicionNoRequerida.Add(nameof(medicion.Int_Baja_Der_1));
                _logger.loadWarning($"{nameof(medicion.Int_Baja_Der_1)} Se agrega a la lista LucesConMedicionNoRequerida");
            }
            else if (patron.Int_Baja_Der_1 && (medicion.Int_Baja_Der_1 == null || medicion.Int_Baja_Der_1 <= 0))
            {
                LucesConMedicionRequerida.Add(nameof(medicion.Int_Baja_Der_1));

                _logger.loadWarning($"{nameof(medicion.Int_Baja_Der_1)} Se agrega a la lista LucesConMedicionRequerida");
            }

            if(LucesConMedicionRequerida.Count != 0 || LucesConMedicionNoRequerida.Count != 0) 
            {
                _logger.loadError("No Se completa ya que falta o no son requeridos alguno parametros");
                return new
                {
                    Status = "Warning",
                    Message = "Verificar lo siguiente",
                    LucesRequeridas = LucesConMedicionRequerida,
                    LucesNoRequeridas = LucesConMedicionNoRequerida

                };
            }

            var respuesta = new
            {
                Status = "OK",
                Message = "Mediciones cumplen con lo establecido en cofiguraciones",
            };
            _logger.loadInformation("Validacion de medicion Completada ");
            return respuesta;
            
        }

    }
}

using Api.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validaciones
{
    public class MedicionLuzValidation : AbstractValidator<MedicionLuz>
    {
        public MedicionLuzValidation()
        {
            RuleFor(m => m.Int_Baja_Izq_1)
                .NotEmpty().WithMessage("Int_Baja_Izq_1 Campo vacio ")
                .GreaterThanOrEqualTo(0).When(m => m.Int_Baja_Izq_1.HasValue)
                .WithMessage($"El valor Int_Baja_Izq_1 no puede ser negativo");

            RuleFor(m => m.Inc_Baja_Izq_1)
                .NotEmpty().WithMessage("Inc_Baja_Izq_1 Campo vacio ")
                .GreaterThanOrEqualTo(0).When(m => m.Inc_Baja_Izq_1.HasValue)
                .WithMessage("El valor Inc_Baja_Izq_1 no puede ser negativo");

            RuleFor(m => m.Int_Baja_Der_1)
                .NotEmpty().WithMessage("Int_Baja_Izq_1 Campo vacio ")
                .GreaterThanOrEqualTo(0).When(m => m.Int_Baja_Der_1.HasValue)
                .WithMessage("El valor Int_Baja_Der_1 no puede ser negativo");
        }
    }
}

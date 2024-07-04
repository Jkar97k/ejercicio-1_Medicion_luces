using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Interfaces;
using Api.service;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Validaciones;

namespace IoC
{
    public class Api_BusinessLogic
    {
        public static void ReglasService(IServiceCollection services)
        {
            services.AddScoped<IPatronLucesService,PatronLucesService >();
            services.AddScoped<IMedicionLucesService, MedicionLucesService>();
        }

        public static void ValidacionesService(IServiceCollection services)
        {
            //services.AddValidatorsFromAssemblyContaining<PatronLucesValidation>();
            services.AddValidatorsFromAssemblyContaining<MedicionLuzValidation>();
            services.AddFluentValidationAutoValidation();
        }
        public static void LoggerService(IServiceCollection services)
        {
            services.AddScoped(typeof(IapiLogger<>),typeof(LogginAdapter<>));
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.service;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public class Api_BusinessLogic
    {
        public static void ReglasService(IServiceCollection services)
        {
            services.AddScoped<IPatronLucesService,PatronLucesService >();
            services.AddScoped<IMedicionLucesService, MedicionLucesService>();
        }
    }
}

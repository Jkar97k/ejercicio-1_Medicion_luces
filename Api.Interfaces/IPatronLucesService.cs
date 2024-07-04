using Api.Entidades;

namespace Api.service
{
    public interface IPatronLucesService
    {
        bool ConfiguracionLuces(PatronLuces patron);
        PatronLuces ObtenerConfiguracion();
    }
}
using Api.Entidades;

namespace Api.service
{
    public interface IPatronLucesService
    {
        int ConfiguracionLuces(PatronLuces patron);
        PatronLuces ObtenerConfiguracion();
    }
}
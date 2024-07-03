using Api.Entidades;

namespace Api.service
{
    public interface IMedicionLucesService
    {
        List<string> LucesConMedicionNoRequerida { get; }
        List<string> LucesConMedicionRequerida { get; }
        object Validacion(MedicionLuz medicion);
    }
}
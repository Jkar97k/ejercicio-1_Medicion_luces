using Api.Entidades;

namespace Api.service
{
    public interface IMedicionLucesService
    {
        IList<string> LucesConMedicionNoRequerida { get; }
        IList<string> LucesConMedicionRequerida { get; }
        object Validacion(MedicionLuz medicion);
    }
}
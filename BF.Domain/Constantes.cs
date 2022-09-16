using System;
using System.Collections.Generic;

namespace BF.Domain
{
    public static class Constantes
    {


    }
    public static class CodigosRespuesta
    {
        public const string EXITOSO = "BF000";

    }
    public static class PronosticoMethod
    {
        public const string PRONOSTICO_X_CANAL = "api/pronostico/ListarPorCanal";
        public const string REGISTRAR = "Registrar";
    }
    public static class CanalMethod
    {
        public const string LISTAR= "api/canal/listar";
        public const string CANALES_X_PARTICIPANTE = "api/canal/participante";
        public const string REGISTRAR_PARTICIPANTE_EN_CANAL = "api/Canal/SuscribirParticipante";
    }

    public enum RequestType{
        POST=1,
        GET=2
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ProvaCandidato.Helper
{
    public static class EmpresaHelper
    {
        public static string GetEmpresa()
        {
            string response = ConfigurationManager.AppSettings.Get("NomeEmpresa");

            if (response == null)
                return "Erro ao capturar o nome da empresa.";

            return response;
        }
    }
}
using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Fretefy.Test.Domain.Utils
{
    public class ExcelExporter
    {
        public static byte[] ExportarRegioes(IEnumerable<RegiaoExportDTO> regioes)
        {
            using var memoryStream = new MemoryStream();

            using (var streamWriter = new StreamWriter(memoryStream))
            {
                streamWriter.WriteLine("Regiao,Status,UF,Cidade");

                foreach (var regiao in regioes)
                {
                    streamWriter.WriteLine($"{regiao.Regiao},{regiao.Ativo},{regiao.UF},{regiao.Cidade}");
                }
            }

            return memoryStream.ToArray();
        }
    }
}

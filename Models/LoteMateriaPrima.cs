using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iveco_Green_Ledger.Models
{
    internal class LoteMateriaPrima
    {
        public int Id { get; set; }
        public string TipoMaterial { get; set; }
        public DateTime? DataProducao { get; set;}
        public double QuantidadeKg { get; set; }
        public Double PegadaCarbonoPorKg { get; set; }
        public int fk_Fornecedor_Id { get; set; }
    }
}

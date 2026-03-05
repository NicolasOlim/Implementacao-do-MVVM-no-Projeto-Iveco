using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iveco_Green_Ledger.Models
{
    internal class VeiculoComponente
    {
        public int Id { get; set; }
        public string fk_Veiculo_Vin { get; set; }
        public int fk_LoteMateriaPrima_Id { get; set; }
        public string NomePeca { get; set; }
    }
}

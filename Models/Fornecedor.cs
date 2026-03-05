using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iveco_Green_Ledger.Models
{
    internal class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public string Cnpj { get; set;}
    }
}

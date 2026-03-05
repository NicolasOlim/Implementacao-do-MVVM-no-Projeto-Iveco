using Iveco_Green_Ledger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iveco_Green_Ledger.Data;
using Iveco_Green_Ledger.Commands;


namespace Iveco_Green_Ledger.Viewmodels
{
    internal class VeiculoViewModel : BaseViewModel
    {

        public ObservableCollection<Veiculo> Veiculos { get; set; }

        public VeiculoViewModel()
        {
            SalvarCommand = new RelayCommand(Salvar, PodeSalvar);
            Veiculos = new ObservableCollection<Veiculo>();
            CarregarTarefas();
        }

        private void CarregarTarefas()
        {
            var lista = new VeiculoRepository().Listar();
            Veiculos.Clear();
            foreach(var veiculo in lista)
                Veiculos.Add(veiculo);
        }

    }
}

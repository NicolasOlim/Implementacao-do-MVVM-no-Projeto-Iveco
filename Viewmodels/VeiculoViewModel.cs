using Iveco_Green_Ledger.Commands;
using Iveco_Green_Ledger.Data;
using Iveco_Green_Ledger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Iveco_Green_Ledger.Viewmodels
{
    internal class VeiculoViewModel : BaseViewModel
    {

        public ObservableCollection<Veiculo> Veiculos { get; set; }

        public VeiculoViewModel()
        {
            SalvarCommand = new RelayCommand(Salvar, PodeSalvar);
            Veiculos = new ObservableCollection<Veiculo>();
            CarregarVeiculos();
            CarregarHistorico();
        }

        private void CarregarVeiculos()
        {
            var lista = new VeiculoRepository().Listar();
            Veiculos.Clear();
            foreach(var veiculo in lista)
                Veiculos.Add(veiculo);
        }

        private string _vin;
        public string Vin 
        {
         
            get => _vin;
            set
            {
                _vin = value;
                OnPropertyChanged(nameof(Vin));
            }
        }

        private string _modelo;
        public string Modelo
        {
            get => _modelo;
            set
            {
                _modelo = value;
                OnPropertyChanged(nameof(Modelo));
            }
        }

        private DateTime? _dataMontagem;
        public DateTime? DataMontagem
        {
            get => _dataMontagem;
            set
            {
                _dataMontagem = value;
                OnPropertyChanged(nameof(DataMontagem));
            }
        }

        private DataView _historicoVeiculos;
        public DataView HistoricoVeiculos
        {
            get => _historicoVeiculos;
            set
            {
                _historicoVeiculos = value;
                OnPropertyChanged(nameof(HistoricoVeiculos));
            }
        }

        private void CarregarHistorico()
        {
            var repo = new VeiculoRepository();
            var tabela = repo.ObterHistoricoVeiculosDataTable();
            HistoricoVeiculos = tabela.DefaultView;
        }

        public ICommand SalvarCommand { get; }

        private void Salvar()
        {
            var veiculoRepo = new VeiculoRepository();
            string veiculoVin = veiculoRepo.InserirOuRetornarVin(Modelo);

            var veiculo = new Veiculo
            {
                Vin = Vin,
                Modelo = Modelo,
                DataMontagem = DataMontagem
            };

            new VeiculoRepository().Inserir(veiculo);
            CarregarVeiculos();
            CarregarHistorico();
            Limpar();

        }

        private bool PodeSalvar()
        {
            return !string.IsNullOrWhiteSpace(Modelo);
        }

        private void Limpar()
        {
            Modelo = "";
            DataMontagem = null;
        }

    }
}

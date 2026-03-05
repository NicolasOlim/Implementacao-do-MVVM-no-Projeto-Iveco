using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iveco_Green_Ledger.Models;

namespace Iveco_Green_Ledger.Data
{
    internal class VeiculoRepository
    {
        public void Inserir(Veiculo veiculo)
        {
            using var conn = DataBase.GetConnection();
            conn.Open();
            var cmd = new SqliteCommand(@"
            INSERT INTO Veiculo
            (vin, modelo, data_montagem)
            VALUES (@v, @m,@d)", conn);

            cmd.Parameters.AddWithValue("@v", veiculo.Vin);
            cmd.Parameters.AddWithValue("@m", veiculo.Modelo);
            cmd.Parameters.AddWithValue("@d", veiculo.DataMontagem?.ToString("dd-MM-yyyy"));

            cmd.ExecuteNonQuery();

        }

        public List<Veiculo> Listar()
        {
            var veiculos = new List<Veiculo>();

            using var conn = DataBase.GetConnection();
            conn.Open();

            var cmd = new SqliteCommand("SELECT * FROM Veiculo", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                veiculos.Add(new Veiculo
                {
                    Vin = reader.GetString(0),
                    Modelo = reader.GetString(1),
                    DataMontagem = reader.IsDBNull(2) ? null : DateTime.Parse(reader.GetString(2))
                });
            }

            return veiculos;
        }
    }
}

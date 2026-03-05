using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Iveco_Green_Ledger.Data
{
    internal class DataBase
    {

        private static readonly string pastaBase =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Iveco_Green_Ledger");

        private static readonly string caminhoBanco =
            Path.Combine(pastaBase, "iveco.db");

        private static readonly string connectionString =
            $"Data Source={caminhoBanco}";

        static DataBase()
        {
            if (!Directory.Exists(pastaBase))
            {
                Directory.CreateDirectory(pastaBase);
            }
            if (!File.Exists(caminhoBanco))
            {
                MessageBox.Show("Banco de dados não encontrado.");
            }
        }

        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection(connectionString);
        }

    }
}

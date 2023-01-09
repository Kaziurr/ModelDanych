using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_uczestnikow.ModelDanych
{
    public class Pobierac
    {
        public List<Osoba> listaOsob { get; set; }

        public Pobierac()
        {
                listaOsob = new List<Osoba>();  

        }
        public void PobierzDaneZBazy()
        {
            string poloczenie = @"DataSource = uczestnicy.db";
            SqliteConnection connection = new SqliteConnection(poloczenie);
            connection.Open();
            var command = connection.CreateCommand();
            string sql = "select ID, Imie, Nazwisko, Data_Urodzenia, Srednia_Ocen, Poziom_Angielski from Osoba";

            command.CommandText = sql;
            var reader = command.ExecuteReader();
            while(reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                string imie = reader.GetString(reader.GetOrdinal("Imie"));
                string nazwisko = reader.GetString(reader.GetOrdinal("Nazwisko"));
                DateTime dt_U = reader.GetDateTime(reader.GetOrdinal("Data_Urodzenia"));
                decimal sred = reader.GetDecimal(reader.GetOrdinal("Srednia_Ocen"));
                string poziom = reader.GetString(reader.GetOrdinal("Poziom_Angielski"));
                listaOsob.Add(new Osoba(id, imie, nazwisko, dt_U, sred, poziom));

            }
            connection.Close();
            connection.Dispose();
        }


    }
}

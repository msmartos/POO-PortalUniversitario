using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PortalUniversitario.Models;

namespace PortalUniversitario.Data
{
    public class UnidadeData : Data
    {
        public List<Unidade> Read()
        {
            List<Unidade> lista = new List<Unidade>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select * from v_Unidade";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Unidade u = new Unidade();

                u.IdUnidade = (int)reader["IdUnd"];
                u.Nome = (string)reader["NomeUnd"];
                u.Endereco = (string)reader["Endereco"];
                u.Telefone = (string)reader["Telefone"];
                u.CNPJ = (string)reader["CNPJ"];
                u.Site = (string)reader["Site"];
                u.IdUniv = (int)reader["idUnv"];
                u.Universidade = (string)reader["NomeUnv"];
                u.Img = (string)reader["Img"];
                lista.Add(u);
            }

            return lista;
        }


        public void Create(Unidade e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO Unidades values(@idUnv, @nome, @endereco, @telefone, @cnpj, @site)";

            cmd.Parameters.AddWithValue("@idUnv", e.IdUniv);
            cmd.Parameters.AddWithValue("@nome", e.Nome);
            cmd.Parameters.AddWithValue("@endereco", e.Endereco);
            cmd.Parameters.AddWithValue("@telefone", e.Telefone);
            cmd.Parameters.AddWithValue("@cnpj", e.CNPJ);
            cmd.Parameters.AddWithValue("@site", e.Site);

            cmd.ExecuteNonQuery();

        }
        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM Unidades WHERE IdUnidade=@id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public Unidade Read(int id)
        {
            Unidade u = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM Unidades WHERE IdUnidade = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                u = new Unidade
                {
                    IdUnidade = (int)reader["IdUnidade"],
                    Nome = (string)reader["Nome"],
                    Endereco = (string)reader["Endereco"],
                    Telefone = (string)reader["Telefone"],
                    CNPJ = (string)reader["CNPJ"],
                    Site = (string)reader["Site"]
                };
            }

            return u;
        }

        public void Update(Unidade e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Universidades
                                SET Nome = @nome, Endereco = @endereco, Telefone = @telefone, CNPJ = @cnpj, Site = @site
                                WHERE IdUnidade = @id";

            cmd.Parameters.AddWithValue("@nome", e.Nome);
            cmd.Parameters.AddWithValue("@endereco", e.Endereco);
            cmd.Parameters.AddWithValue("@telefone", e.Telefone);
            cmd.Parameters.AddWithValue("@cnpj", e.CNPJ);
            cmd.Parameters.AddWithValue("@site", e.Site);
            cmd.Parameters.AddWithValue("@id", e.IdUnidade);

            cmd.ExecuteNonQuery();
        }


    }
}

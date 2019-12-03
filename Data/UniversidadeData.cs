using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PortalUniversitario.Models;

namespace PortalUniversitario.Data
{
    public class UniversidadeData : Data
    {
        public List<Universidade> Read()
        {
            List<Universidade> lista = new List<Universidade>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM Universidades";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Universidade u = new Universidade();
                u.IdUniversidade = (int)reader["IdUniversidade"];
                u.Nome = (string)reader["Nome"];
                u.Img = (string)reader["Img"];

                lista.Add(u);
            }

            return lista;
        }

        public void Create(Universidade e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO Universidades
                                VALUES(@nome, @img)";

            cmd.Parameters.AddWithValue("@nome", e.Nome);
            cmd.Parameters.AddWithValue("@img", e.Img);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM Universidades WHERE IdUniversidade=@id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public Universidade Read(int id)
        {
            Universidade u = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM Universidades WHERE IdUniversidade = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                u = new Universidade
                {
                    IdUniversidade = (int)reader["IdUniversidade"],
                    Nome = (string)reader["Nome"],
                    Img = (string)reader["Img"]
                };
            }

            return u;
        }

        public void Update(Universidade e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Universidades
                                SET Nome = @nome, Img = @img
                                WHERE IdUniversidade = @id";

            cmd.Parameters.AddWithValue("@nome", e.Nome);
            cmd.Parameters.AddWithValue("@img", e.Img);
            cmd.Parameters.AddWithValue("@id", e.IdUniversidade);

            cmd.ExecuteNonQuery();
        }
    }
}

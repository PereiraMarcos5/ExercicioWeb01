using System;
using System.Collections.Generic;
using ExercicioWeb01.Database;
using System.Linq;
using System.Web;
using ExercicioWeb01.Models;
using System.Data.SqlClient;
using System.Data;

namespace ExercicioWeb01.Repositorio
{
    public class AlunoRepositorio
    {

        public List<Alunos> ObterTodos()
        {
        List<Alunos> alunos = new List<Alunos>();


            SqlCommand comando = new BancoDados().ObterConexao();
            comando.CommandText = "SELECT id, nome, matricula, nota1, nota2, nota3, frequencia FROM alunos";
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            foreach (DataRow linha in tabela.Rows)
            {
                Alunos aluno = new Alunos()
                {
                    Id = Convert.ToInt32(linha[0].ToString()),
                    Nome = linha[1].ToString(),
                    CodigoMatricula = Convert.ToInt32(linha[2].ToString()),
                    nota1 = Convert.ToInt32(linha[3].ToString()),
                    nota2 = Convert.ToInt32(linha[4].ToString()),
                    nota3 = Convert.ToInt32(linha[5].ToString()),
                    frequencia = Convert.ToInt32(linha[5].ToString())
                };
                alunos.Add(aluno);

            }

            return alunos;
        }

        public int Cadastrar(Alunos aluno)
        {
            SqlCommand comando = new BancoDados().ObterConexao();
            comando.CommandText = "INSERT INTO alunos (nome, matricula, nota1, nota2, nota3, frequencia)OUTPUT INSERTED.ID VALUES (@NOME, @MATRICULA, @NOTA1, @NOTA2, @NOTA3, @FREQUENCIA)";
            comando.Parameters.AddWithValue("@NOME", aluno.Nome);
            comando.Parameters.AddWithValue("@MATRICULA", aluno.CodigoMatricula);
            comando.Parameters.AddWithValue("@NOTA1", aluno.nota1);
            comando.Parameters.AddWithValue("@NOTA2", aluno.nota2);
            comando.Parameters.AddWithValue("@NOTA3", aluno.nota3);
            comando.Parameters.AddWithValue("@FREQUENCIA", aluno.frequencia);
            int id = Convert.ToInt32(comando.ExecuteScalar().ToString());
            return id;
        }

        public bool Alterar(Alunos aluno)
        {
            SqlCommand comando = new BancoDados().ObterConexao();
            comando.CommandText = "UPDATE alunos SET nome = @NOME, matricula = @MATRICULA, nota1 = @NOTA1, nota2 = @NOTA2, nota3 = @NOTA3, frequencia = @FREQUENCIA WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", aluno.Nome);
            comando.Parameters.AddWithValue("@MATRICULA", aluno.CodigoMatricula);
            comando.Parameters.AddWithValue("@NOTA1", aluno.nota1);
            comando.Parameters.AddWithValue("@NOTA2", aluno.nota2);
            comando.Parameters.AddWithValue("@NOTA3", aluno.nota3);
            comando.Parameters.AddWithValue("@FREQUENCIA", aluno.frequencia);
            comando.Parameters.AddWithValue("@ID", aluno.Id);
            return comando.ExecuteNonQuery() == 1;
        }

        public bool Excluir(int id)
        {
            SqlCommand comando = new BancoDados().ObterConexao();
            comando.CommandText = "DELETE FROM alunos WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            return comando.ExecuteNonQuery() == 1;
        }

        public Alunos ObterPeloId(int id)
        {
            Alunos alunos = null;
            SqlCommand comando = new BancoDados().ObterConexao();
            comando.CommandText = "SELECT nome, matricula, nota1, nota2, nota3, frequencia FROM alunos WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            if (tabela.Rows.Count == 1)
            {
                alunos = new Alunos();
                alunos.Id = id;
                alunos.Nome = tabela.Rows[0][0].ToString();
                alunos.CodigoMatricula = Convert.ToInt32(tabela.Rows[0][1].ToString());
                alunos.nota1 = Convert.ToDecimal(tabela.Rows[0][2].ToString());
                alunos.nota2 = Convert.ToDecimal(tabela.Rows[0][3].ToString());
                alunos.nota3 = Convert.ToDecimal(tabela.Rows[0][4].ToString());
                alunos.frequencia = Convert.ToInt32(tabela.Rows[0][5].ToString());
            }
            return alunos;
        }
    }
}
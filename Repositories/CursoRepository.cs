using EduxAPI.Contexts;
using EduxAPI.Domains;
using EduxAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Repositories
{
    public class CursoRepository : ICurso
    {
        private readonly EduxContext _ctx;

        public CursoRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Metodo para alterar
        /// </summary>
        /// <param name="id">id do curso</param>
        /// <param name="curso">nome do curso</param>
        public void Alterar(Guid id, Curso curso)
        {
            try
            {
                //Busca pelo seu Id
                Curso cursoTemp = BuscarPorID(id);


                //Altera as propriedades 
                cursoTemp.IdInstituicao = curso.IdInstituicao;
                cursoTemp.IdInstituicaoNavigation = curso.IdInstituicaoNavigation;
                cursoTemp.Titulo = curso.Titulo;
                cursoTemp.Turma = curso.Turma;

                //Altera no contexto
                _ctx.Curso.Update(cursoTemp);
                //Salva
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO: Cadastrar Tabela LogErro  mensagem de erro com Tag Geral
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para buscar pelo id
        /// </summary>
        /// <param name="id">id do curso</param>
        /// <returns>curso com determinado id</returns>
        public Curso BuscarPorID(Guid id)
        {
            try
            {
      
                return _ctx.Curso.Find(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// metodo para cadastrar
        /// </summary>
        /// <param name="curso">nome do curso</param>
        public void Cadastrar(Curso curso)
        {
            try
            {
                _ctx.Curso.Add(curso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// metodo para excluir
        /// </summary>
        /// <param name="id">id do curso</param>
        public void Excluir(Guid id)
        {
            try
            {
                Curso curso = BuscarPorID(id);

                if (curso == null)
                    throw new Exception("Produto não encontrado");

                _ctx.Curso.Remove(curso);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// metodo para listar todos
        /// </summary>
        /// <returns>lista de curso</returns>
        public List<Curso> ListarTodos()
        {
            try
            {
                return _ctx.Curso.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using EduxAPI.Contexts;
using EduxAPI.Domains;
using EduxAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Repositories
{
    public class ProfessorTurmaRepsitory : IProfessorTurma
    {
        private readonly EduxContext _ctx;
        private object professorTurma;

        public ProfessorTurmaRepsitory()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Metodo para alterar
        /// </summary>
        /// <param name="id">id do produto</param>
        /// <param name="permissao">categoria</param>
        public void Alterar(Guid id, ProfessorTurma professorTurma)
        {
            try
            {
                //Busca pelo seu Id
                ProfessorTurma professorTurmaTemp = BuscarPorID(id);

                //Altera as propriedades 
                professorTurmaTemp.Permissao = professorTurma.Permissao;

                //Altera no contexto
                _ctx.ProfessorTurma.Update(professorTurmaTemp);

                //Salva
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO: Cadastrar Tabela LogErro  mensagem de erro com Tag Geral
                throw new Exception(ex.Message);
            }
        }

        public void Alterar(Guid id, ProfessorTurma professorTurma)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para buscar uma categoria pelo Id
        /// </summary>
        /// <param tipo="id">id do professor  rma</param>
        /// <returns>tipo do idprofessorTurma</returns>
        public ProfessorTurma BuscarPorID(Guid id)
        {
            try
            {
                return _ctx.ProfessorTurma.Find(id);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para adicionar novas categorias
        /// </summary>
        /// <param tipo="categoria">nova categoria</param>
        public void Cadastrar(ProfessorTurma professorTurma)
        {
            try
            {
                _ctx.ProfessorTurma.Add(professorTurma);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// metodo para excluir
        /// </summary>
        /// <param tipo="id">id da instituição</param>
        public void Excluir(Guid id)
        {
            try
            {
                ProfessorTurma cprofessorTurma = BuscarPorID(id);

                if (professorTurma == null)
                    throw new Exception("Professor não encontrado");

                _ctx.ProfessorTurma.Remove((ProfessorTurma)professorTurma);
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
        /// <returns>Lista de categorias</returns>
        public List<ProfessorTurma> ListarTodos()
        {
            try
            {
                return _ctx.ProfessorTurma.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}


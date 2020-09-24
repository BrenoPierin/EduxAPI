using EduxAPI.Contexts;
using EduxAPI.Domains;
using EduxAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Repositories
{
    public class TurmaRepository : ITurma
    {
        private readonly EduxContext _ctx;

        public TurmaRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Metodo para alterar
        /// </summary>
        /// <param name="id">id da Turma</param>
        /// <param name="turma">nome da turma</param>
        public void Alterar(int id, Turma turma)
        {
            try
            {
                Turma TurmaTemp = BuscarPorID(id);

                TurmaTemp.AlunoTurma = turma.AlunoTurma;
                TurmaTemp.Descricao = turma.Descricao;
                TurmaTemp.IdCurso = turma.IdCurso;
                TurmaTemp.IdCursoNavigation = turma.IdCursoNavigation;
                TurmaTemp.ObjetivoAluno = turma.ObjetivoAluno;
                TurmaTemp.ProfessorTurma = turma.ProfessorTurma;


                _ctx.Turma.Update(TurmaTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para buscar pelo Id
        /// </summary>
        /// <param name="id">Id da Turma</param>
        /// <returns>Turma</returns>
        public Turma BuscarPorID(int id)
        {
             try
             {

               return _ctx.Turma.Find(id);

             }
              catch (Exception ex)
             {

                   throw new Exception(ex.Message);

             }
        }

        /// <summary>
        /// Metodo para cadastrar
        /// </summary>
        /// <param name="turma">Nome da turma</param>
        public void Cadastrar(Turma turma)
        {
            try
            {
                _ctx.Turma.Add(turma);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// metodo para excluir
        /// </summary>
        /// <param name="id">id da turma</param>
        public void Excluir(int id)
        {
            try
            {
                Turma turma = BuscarPorID(id);

                if (turma == null)
                    throw new Exception("Produto não encontrado");

                _ctx.Turma.Remove(turma);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para listar todos
        /// </summary>
        /// <returns>lista de turma</returns>
        public List<Turma> ListarTodos()
        {
            try
            {
                return _ctx.Turma.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}

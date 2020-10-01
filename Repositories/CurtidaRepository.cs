using EduxAPI.Contexts;
using EduxAPI.Domains;
using EduxAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Repositories
{
    public class CurtidaRepository : ICurtida
    {
        private readonly EduxContext _ctx;

        public CurtidaRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Metodo para alterar
        /// </summary>
        /// <param name="id">id do curso</param>
        public void Alterar(Guid id, Curtida curtida)
        {
            try
            {
                //Busca pelo seu Id
                Curtida curtidaTemp = BuscarPorID(id);


                //Altera as propriedades 
                curtidaTemp.IdUsuario = curtida.IdUsuario;
                curtidaTemp.IdUsuarioNavigation = curtida.IdUsuarioNavigation;

                curtidaTemp.IdDica = curtida.IdDica;
                curtidaTemp.IdDicaNavigation = curtida.IdDicaNavigation;

                //Altera no contexto
                _ctx.Curtida.Update(curtidaTemp);

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
        public Curtida BuscarPorID(Guid id)
        {
            try
            {

                return _ctx.Curtida.Find(id);

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
        public void Cadastrar(Curtida curtida)
        {
            try
            {
                _ctx.Curtida.Add(curtida);
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
                Curtida curtida = BuscarPorID(id);

                if (curtida == null)
                    throw new Exception("Sem Curtidas");

                _ctx.Curtida.Remove(curtida);
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
        public List<Curtida> ListarTodos()
        {
            try
            {
                return _ctx.Curtida.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

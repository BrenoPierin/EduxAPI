using EduxAPI.Contexts;
using EduxAPI.Domains;
using EduxAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Repositories
{
    public class PerfilRepository : IPerfil
    {
        private readonly EduxContext _ctx;
        private object perfil;

        public PerfilRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Metodo para alterar
        /// </summary>
        /// <param name="id">id do produto</param>
        /// <param name="permissao">categoria</param>
            public void Alterar(Guid id, Perfil perfil)
        {
            try
            {
                //Busca pelo seu Id
                Perfil perfilTemp = BuscarPorID(id);

                //Altera as propriedades 
                perfilTemp.Permissao = perfil.Permissao;

                //Altera no contexto
                _ctx.Perfil.Update(perfilTemp);

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
        /// Metodo para buscar uma categoria pelo Id
        /// </summary>
        /// <param tipo="id">id do perfil</param>
        /// <returns>tipo do id perfil</returns>
        public Perfil BuscarPorID(Guid id)
        {
            try
            {
                return _ctx.Perfil.Find(id);
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
        public void Cadastrar(Perfil perfil)
        {
            try
            {
                _ctx.Perfil.Add(perfil);
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
                Perfil cperfil = BuscarPorID(id);

                if (perfil == null)
                    throw new Exception("Perfil não encontrado");

                _ctx.Perfil.Remove((Perfil)perfil);
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
        public List<Perfil> ListarTodos()
        { 
            try
            {
                return _ctx.Perfil.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}


using EduxAPI.Contexts;
using EduxAPI.Domains;
using EduxAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Repositories
{
    public class CategoriaRepository : ICategoria
    {
        private readonly EduxContext _ctx;

        public CategoriaRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Metodo para alterar
        /// </summary>
        /// <param name="id">id do produto</param>
        /// <param name="categoria">categoria</param>
        /// <returns></returns>
        public void Alterar(Guid id, Categoria categoria)
        {
            try
            {
                //Busca pelo seu Id
                Categoria categoriaTemp = BuscarPorID(id);


                //Altera as propriedades 
                categoriaTemp.Tipo = categoria.Tipo;

                //Altera no contexto
                _ctx.Categoria.Update(categoriaTemp);
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
        /// <param tipo="id">id da instituição</param>
        /// <returns>tipo do id atribuido</returns>
        public Categoria BuscarPorID(Guid id)
        {
            try
            {

                return _ctx.Categoria.Find(id);

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
        public void Cadastrar(Categoria categoria)
        {
            try
            {
                _ctx.Categoria.Add(categoria);
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
                Categoria categoria = BuscarPorID(id);

                if (categoria == null)
                    throw new Exception("Categoria não encontrada");

                _ctx.Categoria.Remove(categoria);
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
        public List<Categoria> ListarTodos()
        {
            try
            {
                return _ctx.Categoria.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}

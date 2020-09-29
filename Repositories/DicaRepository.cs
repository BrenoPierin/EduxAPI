using EduxAPI.Contexts;
using EduxAPI.Domains;
using EduxAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Repositories
{
    public class DicaRepository : IDica
    {
        private readonly EduxContext _ctx;

        public DicaRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Altera uma dica que ja foi criada usando seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dica"></param>
        public void Alterar(Guid id, Dica dica)
        {
            try
            {
                //Busca pelo ID
                Dica dicaTemp = BuscarPeloID(id);


                //Altera as propriedades 
                dicaTemp.Curtida = dica.Curtida;
                dicaTemp.Imagem = dica.Imagem;
                dicaTemp.Texto = dica.Texto;

                //Altera no contexto
                _ctx.Dica.Update(dicaTemp);
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
        /// <param name="id">id da dica</param>
        /// <returns>dica com determinado id</returns>

        public void BuscarPorID(Guid id)
        {
            try
            {
                return _ctx.Dica.Find(id);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
       
        /// <summary>
        /// metodo para cadastrar
        /// </summary>
        /// <param name="dica"></param>
        public void Cadastrar(Dica dica)
        {
            try
            {
                _ctx.Dica.Add(dica);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// metodo para excluir
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(Guid id)
        {
            try
            {
                Dica dica = BuscarPorID(id);

                if (dica == null)
                    throw new Exception("Produto não encontrado.");

                _ctx.Dica.Remove(dica);
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
        /// <returns></returns>
        public List<Dica> ListarTodos()
        {
            try
            {
                return _ctx.Dica.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

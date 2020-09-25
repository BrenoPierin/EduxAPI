using EduxAPI.Contexts;
using EduxAPI.Domains;
using EduxAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Repositories
{
    public class InstituicaoRepository : IInstituicao
    {
        private readonly EduxContext _ctx;

        public InstituicaoRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Metodo para alterar
        /// </summary>
        /// <param name="id">id do produto</param>
        /// <param name="instituicao">nome da instituição</param>
        /// <returns></returns>
        public void Alterar(Guid id, Instituicao instituicao)
        {
            try
            {
                //Busca pelo seu Id
                Instituicao instituicaoTemp = BuscarPorID(id);


                //Altera as propriedades 
                instituicaoTemp.Nome = instituicao.Nome;
                instituicaoTemp.Logradouro = instituicao.Logradouro;
                instituicaoTemp.Numero = instituicao.Numero;
                instituicaoTemp.Complemento = instituicao.Complemento;
                instituicaoTemp.Cidade = instituicao.Cidade;
                instituicaoTemp.Uf = instituicao.Uf;
                instituicaoTemp.Cep = instituicao.Cep;

                //Altera no contexto
                _ctx.Instituicao.Update(instituicaoTemp);
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
        /// Metodo para buscar uma instituição pelo Id
        /// </summary>
        /// <param name="id">id da instituição</param>
        /// <returns>instituição do id atribuido</returns>
        public Instituicao BuscarPorID(Guid id)
        {
            try
            {

                return _ctx.Instituicao.Find(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para adicionar novas instituições
        /// </summary>
        /// <param name="instituicao">nova instituição</param>
        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                _ctx.Instituicao.Add(instituicao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// metodo para excluir
        /// </summary>
        /// <param name="id">id da instituição</param>
        public void Excluir(Guid id)
        {
            try
            {
                Instituicao instituicao = BuscarPorID(id);

                if (instituicao == null)
                    throw new Exception("Produto não encontrado");

                _ctx.Instituicao.Remove(instituicao);
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
        /// <returns>Lista de produtos</returns>
        public List<Instituicao> ListarTodos()
        {
            try
            {
                return _ctx.Instituicao.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}

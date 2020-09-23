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
        public void Alterar(int id, Instituicao instituicao)
        {
            try
            {
                //Busco um produto pelo seu Id
                Instituicao instituicaoTemp = BuscarPorID(id);

                ////Verifica se o produto existe, caso não exista gera uma exception
                //if (produtoTemp == null)
                //    throw new Exception("Produto não encontrado");

                //Altera as propriedades do produto
                instituicaoTemp.Nome = instituicao.Nome;
                instituicaoTemp.Logradouro = instituicao.Logradouro;
                instituicaoTemp.Numero = instituicao.Numero;
                instituicaoTemp.Complemento = instituicao.Complemento;
                instituicaoTemp.Cidade = instituicao.Cidade;
                instituicaoTemp.Uf = instituicao.Uf;
                instituicaoTemp.Cep = instituicao.Cep;

                //Altera o produto no contexto
                _ctx.Instituicao.Update(instituicaoTemp);
                //Salva o produto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO: Cadastrar Tabela LogErro  mensagem de erro com Tag Geral
                throw new Exception(ex.Message);
            }
        }

        public Instituicao BuscarPorID(int id)
        {
            try
            {
                //List<Produto> produto = _ctx.Produtos.Where(c => c.Nome == "produto").ToList();
                //Produto produto = _ctx.Produtos.FirstOrDefault(c => c.Id == id); top 1
                return _ctx.Instituicao.Find(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Instituicao Cadastrar(Instituicao instituicao)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<Instituicao> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}

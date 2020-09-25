using EduxAPI.Contexts;
using EduxAPI.Domains;
using EduxAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly EduxContext _ctx;

        public UsuarioRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Metodo para alterar
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <param name="usuario">nome do usuario</param>
        public void Alterar(Guid id, Usuario usuario)
        {
            try
            {
                //Busca pelo seu Id
                Usuario usuarioTemp = BuscarPorID(id);


                //Altera as propriedades 
                usuarioTemp.AlunoTurma = usuario.AlunoTurma;
                usuarioTemp.Curtida = usuario.Curtida;
                usuarioTemp.DataCadastro = usuario.DataCadastro;
                usuarioTemp.DataUltinoAcesso = usuario.DataUltinoAcesso;
                usuarioTemp.Dica = usuario.Dica;
                usuarioTemp.Email = usuario.Email;

                //Altera no contexto
                _ctx.Usuario.Update(usuarioTemp);
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
        /// Busca pelo id
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <returns>usuario buscado</returns>
        public Usuario BuscarPorID(Guid id)
        {
            try
            {

                return _ctx.Usuario.Find(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// metodo para cadastrar um novo ususario
        /// </summary>
        /// <param name="usuario">nome do ususario</param>
        public void Cadastrar(Usuario usuario)
        {
            try
            {
                _ctx.Usuario.Add(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// metodo para excluir
        /// </summary>
        /// <param name="id">id do ususario</param>
        public void Excluir(Guid id)
        {
            try
            {
                Usuario usuario = BuscarPorID(id);

                if (usuario == null)
                    throw new Exception("Produto não encontrado");

                _ctx.Usuario.Remove(usuario);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// metodo para listar
        /// </summary>
        /// <returns>lista de ususarios</returns>
        public List<Usuario> ListarTodos()
        {
            try
            {
                return _ctx.Usuario.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

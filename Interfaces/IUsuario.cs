using EduxAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Interfaces
{
    interface IUsuario
    {

        List<Usuario> ListarTodos();
        Usuario BuscarPorID(Guid id);
        void Cadastrar(Usuario usuario);
        void Alterar(Guid id, Usuario usuario);
        void Excluir(Guid id);

    }
}


using EduxAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Interfaces
{
    interface IPerfil
    {

        List<Perfil> ListarTodos();
        Perfil BuscarPorID(Guid id);
        void Cadastrar(Perfil perfil);
        void Alterar(Guid id, Perfil perfil);
        void Excluir(Guid id);
    }
}

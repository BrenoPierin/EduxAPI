
using EduxAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Interfaces
{
    interface ICategoria
    {

        List<Categoria> ListarTodos();
        Categoria BuscarPorID(Guid id);
        void Cadastrar(Categoria categoria);
        void Alterar(Guid id, Categoria categoria);
        void Excluir(Guid id);
    }
}

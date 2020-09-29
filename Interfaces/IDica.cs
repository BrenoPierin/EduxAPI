using EduxAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EduxAPI.Interfaces
{
    interface IDica
    {
        List<Dica> ListarTodos();
        Dica BuscarPorID(Guid id);
        void Cadastrar(Dica dica);
        void Alterar(Guid id, Dica dica);
        void Excluir(Guid id);
    }
}


using EduxAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Interfaces
{
    interface ICurtida
    {

        List<Curtida> ListarTodos();
        Curtida BuscarPorID(Guid id);
        void Cadastrar(Curtida curtida);
        void Alterar(Guid id, Curtida curtida);
        void Excluir(Guid id);
    }
}

using EduxAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Interfaces
{
    interface ITurma
    {

        List<Turma> ListarTodos();
        Turma BuscarPorID(Guid id);
        void Cadastrar(Turma turma);
        void Alterar(Guid id, Turma turma);
        void Excluir(Guid id);
    }
}

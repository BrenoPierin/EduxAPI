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
        Turma BuscarPorID(int id);
        Turma Cadastrar(Turma turma);
        Turma Alterar(int id, Turma turma);
        void Excluir(int id);

    }
}

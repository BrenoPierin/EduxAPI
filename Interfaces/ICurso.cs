using EduxAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Interfaces
{
    interface ICurso
    {
        List<Curso> ListarTodos();
        Curso BuscarPorID(int id);
        Curso Cadastrar(Curso curso);
        Curso Alterar(int id, Curso curso);
        void Excluir(int id);

    }
}

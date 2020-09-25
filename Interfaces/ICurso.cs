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
        Curso BuscarPorID(Guid id);
        void Cadastrar(Curso curso);
        void Alterar(Guid id, Curso curso);
        void Excluir(Guid id);

    }
}

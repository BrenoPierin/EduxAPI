using EduxAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Interfaces
{
    public interface IProfessorTurma
    {

        List<ProfessorTurma> ListarTodos();
        ProfessorTurma BuscarPorID(Guid id);
        void Cadastrar(ProfessorTurma professorTurma);
        void Alterar(Guid id, ProfessorTurma professorTurma);
        void Excluir(Guid id);
    }
}

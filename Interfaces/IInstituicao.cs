using EduxAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxAPI.Interfaces
{
    interface IInstituicao
    {

        List<Instituicao> ListarTodos();
        Instituicao BuscarPorID(Guid id);
        void Cadastrar(Instituicao instituicao);
        void Alterar(Guid id, Instituicao instituicao);
        void Excluir(Guid id);

    }
}

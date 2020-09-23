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
        Instituicao BuscarPorID(int id);
        Instituicao Cadastrar(Instituicao instituicao);
        void Alterar(int id, Instituicao instituicao);
        void Excluir(int id);

    }
}

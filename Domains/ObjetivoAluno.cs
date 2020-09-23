using System;
using System.Collections.Generic;

namespace EduxAPI.Domains
{
    public partial class ObjetivoAluno
    {
        public int IdObjetivoAluno { get; set; }
        public decimal? Nota { get; set; }
        public DateTime? DataAlcancado { get; set; }
        public int? IdAlunoTurma { get; set; }
        public int? IdTurma { get; set; }
        public int? IdObjetivo { get; set; }

        public virtual AlunoTurma IdAlunoTurmaNavigation { get; set; }
        public virtual Objetivo IdObjetivoNavigation { get; set; }
        public virtual Turma IdTurmaNavigation { get; set; }
    }
}

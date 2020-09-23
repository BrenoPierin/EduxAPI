using System;
using System.Collections.Generic;

namespace EduxAPI.Domains
{
    public partial class Turma
    {
        public Turma()
        {
            AlunoTurma = new HashSet<AlunoTurma>();
            ObjetivoAluno = new HashSet<ObjetivoAluno>();
            ProfessorTurma = new HashSet<ProfessorTurma>();
        }

        public int IdTurma { get; set; }
        public string Descricao { get; set; }
        public int? IdCurso { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual ICollection<AlunoTurma> AlunoTurma { get; set; }
        public virtual ICollection<ObjetivoAluno> ObjetivoAluno { get; set; }
        public virtual ICollection<ProfessorTurma> ProfessorTurma { get; set; }
    }
}

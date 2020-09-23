using System;
using System.Collections.Generic;

namespace EduxAPI.Domains
{
    public partial class Curtida
    {
        public int IdCurtida { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdDica { get; set; }

        public virtual Dica IdDicaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}

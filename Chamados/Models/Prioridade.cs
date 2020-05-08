using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Prioridade
    {
        public Prioridade()
        {
            Chamado = new HashSet<Chamado>();
        }

        public int PriId { get; set; }
        public string PriNome { get; set; }

        public virtual ICollection<Chamado> Chamado { get; set; }
    }
}

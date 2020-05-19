using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class StatusChamado
    {
        public StatusChamado()
        {
            Chamado = new HashSet<Chamado>();
        }

        public int SchaId { get; set; }
        public string SchaNome { get; set; }

        public virtual ICollection<Chamado> Chamado { get; set; }
    }
}

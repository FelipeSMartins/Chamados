using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Atendente = new HashSet<Atendente>();
            Cliente = new HashSet<Cliente>();
        }

        public int PesId { get; set; }
        public string PesNome { get; set; }
        public string PesEmail { get; set; }

        public virtual ICollection<Atendente> Atendente { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}

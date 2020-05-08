using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Atendente
    {
        public Atendente()
        {
            AcaoChamado = new HashSet<AcaoChamado>();
            Chamado = new HashSet<Chamado>();
            DepartamentoAtendente = new HashSet<DepartamentoAtendente>();
        }

        public int AteId { get; set; }
        public int AtePessoaid { get; set; }

        public virtual Pessoa AtePessoa { get; set; }
        public virtual ICollection<AcaoChamado> AcaoChamado { get; set; }
        public virtual ICollection<Chamado> Chamado { get; set; }
        public virtual ICollection<DepartamentoAtendente> DepartamentoAtendente { get; set; }
    }
}

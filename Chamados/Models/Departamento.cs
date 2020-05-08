using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Departamento
    {
        public Departamento()
        {
            AcaoChamado = new HashSet<AcaoChamado>();
            Chamado = new HashSet<Chamado>();
            DepartamentoAtendente = new HashSet<DepartamentoAtendente>();
            DepartamentoCategoria = new HashSet<DepartamentoCategoria>();
        }

        public int DepId { get; set; }
        public string DepNome { get; set; }
        public string DepEmail { get; set; }

        public virtual ICollection<AcaoChamado> AcaoChamado { get; set; }
        public virtual ICollection<Chamado> Chamado { get; set; }
        public virtual ICollection<DepartamentoAtendente> DepartamentoAtendente { get; set; }
        public virtual ICollection<DepartamentoCategoria> DepartamentoCategoria { get; set; }
    }
}

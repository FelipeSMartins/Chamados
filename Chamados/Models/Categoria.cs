using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Categoria
    {
        public Categoria()
        {
            AcaoChamado = new HashSet<AcaoChamado>();
            Chamado = new HashSet<Chamado>();
            DepartamentoCategoria = new HashSet<DepartamentoCategoria>();
        }

        public int CatId { get; set; }
        public string CatNome { get; set; }

        public virtual ICollection<AcaoChamado> AcaoChamado { get; set; }
        public virtual ICollection<Chamado> Chamado { get; set; }
        public virtual ICollection<DepartamentoCategoria> DepartamentoCategoria { get; set; }
    }
}

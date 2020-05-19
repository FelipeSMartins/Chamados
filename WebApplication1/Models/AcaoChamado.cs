using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class AcaoChamado
    {
        public int AcaoId { get; set; }
        public int AcaoChamadoid { get; set; }
        public string AcaoDescricao { get; set; }
        public int AcaoAtendenteid { get; set; }
        public int AcaoDepartamentoid { get; set; }
        public int AcaoCategoriaid { get; set; }

        public virtual Atendente AcaoAtendente { get; set; }
        public virtual Categoria AcaoCategoria { get; set; }
        public virtual Chamado AcaoChamadoNavigation { get; set; }
        public virtual Departamento AcaoDepartamento { get; set; }
    }
}

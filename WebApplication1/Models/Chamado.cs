using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Chamado
    {
        public Chamado()
        {
            AcaoChamado = new HashSet<AcaoChamado>();
        }

        public int ChaId { get; set; }
        public string ChaTitulo { get; set; }
        public string ChaAssunto { get; set; }
        public string ChaDescricao { get; set; }
        public int ChaClienteid { get; set; }
        public int ChaAtendenteid { get; set; }
        public int ChaDepartamentoid { get; set; }
        public int ChaCategoriaid { get; set; }
        public int ChaPrioridadeid { get; set; }
        public int ChaStatusid { get; set; }
        public DateTime ChaData { get; set; }
        public string ChaCriador { get; set; }

        public virtual Atendente ChaAtendente { get; set; }
        public virtual Categoria ChaCategoria { get; set; }
        public virtual Cliente ChaCliente { get; set; }
        public virtual Departamento ChaDepartamento { get; set; }
        public virtual Prioridade ChaPrioridade { get; set; }
        public virtual StatusChamado ChaStatus { get; set; }
        public virtual ICollection<AcaoChamado> AcaoChamado { get; set; }
    }
}

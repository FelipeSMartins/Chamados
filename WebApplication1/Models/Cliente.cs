using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Cliente
    {
        public Cliente()
        {
            Chamado = new HashSet<Chamado>();
        }

        public int CliId { get; set; }
        public int CliPessoaid { get; set; }
        public int CliOrganizacaoid { get; set; }

        public virtual Organizacao CliOrganizacao { get; set; }
        public virtual Pessoa CliPessoa { get; set; }
        public virtual ICollection<Chamado> Chamado { get; set; }
    }
}

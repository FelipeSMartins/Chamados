using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Organizacao
    {
        public Organizacao()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int OrgId { get; set; }
        public string OrgNome { get; set; }
        public string OrgCnpj { get; set; }
        public string OrgEmail { get; set; }
        public string OrgTelefone { get; set; }
        public string OrgEndereco { get; set; }
        public char? OrgSituacao { get; set; }
        public string OrgObs { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}

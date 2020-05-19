using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class DepartamentoAtendente
    {
        public int DaDepartamentoid { get; set; }
        public int DaAtendenteid { get; set; }

        public virtual Atendente DaAtendente { get; set; }
        public virtual Departamento DaDepartamento { get; set; }
    }
}

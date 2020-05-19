using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class DepartamentoCategoria
    {
        public int DcDepartamentoid { get; set; }
        public int DcCategoriaid { get; set; }

        public virtual Categoria DcCategoria { get; set; }
        public virtual Departamento DcDepartamento { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina_Empleados_Leng.Entidades
{
    public class Empleados
    {
        [Key]
        public int EmpleadoId { get; set; }
        public string NombreCompleto { get; set; }
        public long Telefono { get; set; }
        public string Departamento { get; set; }
        public string Puesto { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}

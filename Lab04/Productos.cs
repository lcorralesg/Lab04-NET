using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Lab04
{
    public class Productos
    {
        public string nombreProducto { get; set; }
        public string cantidadPorUnidad { get; set; }
        public decimal precioUnidad { get; set; }
        public string categoriaProducto { get; set; }
        public short unidadesEnExistencia { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados.DAL.Models
{
   public class Usuarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}

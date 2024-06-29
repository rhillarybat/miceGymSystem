using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiceGymSystem.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome {  get; set; }
        public double Valor {  get; set; }
        public int Quantidade {  get; set; }
        public string Descricao {  get; set; }
        public string Codigo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiceGymSystem.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public string FormaPgto {  get; set; }
        public double Valor {  get; set; }
        public DateTime? Data {  get; set; }
        public Cliente Cliente { get; set; }
    }
}

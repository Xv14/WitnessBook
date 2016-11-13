using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitnessBook.Domain.Entites
{
    public class Evenement
    {
        [Key]
        public int idEvenement { get; set; }
        public string nameEvent { get; set; }
        public string description { get; set; }
        public Adresse lieux { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime dateDebutEvent { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime dateFinEvent { get; set; }
        public string TypeEvent { get; set; }

        public int idAgent { get; set; }
        public Agent agent { get; set; }
       


        public virtual ICollection<WitnessCardTraite> witnesscards { get; set; }
        public virtual ICollection<RegistredUser> registredusers { get; set; }
    }
}

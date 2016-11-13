using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitnessBook.Domain.Entites;

namespace WitnessBook.Data.Configuration
{
    public class EvenementConfiguration : EntityTypeConfiguration<Evenement>
    {
        public EvenementConfiguration()
        {

            //HasMany(w => w.witnesscards)
            //   .WithMany(e => e.evenements)
            //   .Map(v =>
            //   {
            //       v.ToTable("witnessEvent");
            //       v.MapLeftKey("Evenement");
            //       v.MapRightKey("WitnessCard");
            //   });

            //HasRequired(e => e.agent)
            // .WithMany(c1 => c1.evenements)
            // .HasForeignKey(c => c.idAgent)
            // .WillCascadeOnDelete(false);


        }
    }
}

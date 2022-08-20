using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS_Projekat_Rampe.Models
{
    
    public class Semafor : Uredjaj
    {
        public bool DozvoljenProlazak { get; set; }
        
        public Semafor (TipUredjaja tip) :base( tip)
        {
        }
    }
    
}

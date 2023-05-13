using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlloServicePFA.ModelView;

namespace AlloServicePFA.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Libelle { get; set; }
        public Service()
        {

        }
        public Service(ServiceCreateModelView model)
        {
            this.Libelle = Libelle;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Backend.Common.Models.Entity
{
    public class Promotion
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public double DiscountPercent { get; set; }

        public Service Service { get; set; }
    }
}

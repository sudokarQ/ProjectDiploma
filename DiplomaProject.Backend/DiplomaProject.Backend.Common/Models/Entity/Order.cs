using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Backend.Common.Models.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }

        public List<Client> Clients { get; set; }
        public List<Service> Services { get; set; }
    }
}

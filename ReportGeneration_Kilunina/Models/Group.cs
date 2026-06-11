using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneration_Kilunina.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Group(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneration_Kilunina.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int IdWork { get; set; }
        public int IdStudent { get; set; }
        public string Value { get; set; }
        public string Lateness { get; set; }

        public Evaluation(int Id, int IdWork, int IdStudent, string Value, string Lateness)
        {
            this.Id = Id;
            this.IdWork = IdWork;
            this.IdStudent = IdStudent;
            this.Value = Value;
            this.Lateness = Lateness;
        }
    }
}

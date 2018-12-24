using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SuperCoolApp2.Models
{
    public class SuperCoolApp2Context : DbContext
    {
        public SuperCoolApp2Context(DbContextOptions<SuperCoolApp2Context> options)
            : base(options)
        {

        }

        public DbSet<Image> Images { get; set; }
        //public DbSet<Tax> Taxes { get; set; }
    }

    public class Image
    {
        public int ImageId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public byte[] ImageFileContent { get; set; }

        public List<Image> ImageList { get; set; }
    }

    //public class Tax
    //{
    //    public decimal Earnings { get; set; }
    //    public decimal RAContribution { get; set; }
    //    public decimal AgeInYears { get; set; }
    //    public string TimePeriod { get; set; }
    //    public int MedicalDependants { get; set; }
    //    public bool HasMedical { get; set; }
    //}
}

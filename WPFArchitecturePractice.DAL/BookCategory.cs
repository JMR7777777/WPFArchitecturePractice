using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFArchitecturePractice.DAL
{
    public class BookCategory
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }
    }
}

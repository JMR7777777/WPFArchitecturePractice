using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFArchitecturePractice.Model.Rent;

[Table("Rent.BookCategory")]
public class BookCategory
{
    [Key]
    public short CategoryId { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }

    [ForeignKey("CategoryId")]
    public virtual ICollection<Book> Books { get; set; }
}

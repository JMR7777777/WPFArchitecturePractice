using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFArchitecturePractice.Model.Rent;

[Table("Rent.Book")]
public class Book
{
    [Key]
    public long BookId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsRentingState { get; set; }
    public bool IsDeleted { get; set; }

    public short CategoryId { get; set; }
    public virtual BookCategory Category { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace WPFArchitecturePractice.DAL;

    public class Book
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public virtual BookCategory Category { get; set; }

        public virtual bool isRentingState { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }

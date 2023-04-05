using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [StringLength(30)]
        public string CategoryName { get; set; }

        [StringLength(500)]
        public String CategoryDescription { get; set; }

        public ICollection<Blog> Blogs { get; set; } // Bir kategori birden fazla bloğun içinde yer alabileceği için ilişki kuruyoruz.


    }
}

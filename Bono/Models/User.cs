using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bono.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string correo { get; set; }
        [Required]
        [MaxLength(50)]
        public string password { get; set; }

        public virtual ICollection<DatosBono> DatosBono { get; set;}
    }
}
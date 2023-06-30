using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrudApplication.Modul
{
    public class AddressDetailModal
    {
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public int? PostCode { get; set; }

        [Required]
        public string Country { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dockerize.Core
{
    public class CardType
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}

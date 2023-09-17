using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;

namespace WorkTitle.Domain.Entities
{
    public class ListVoter
    {
        public Guid ListId { get; set; }

        public Guid UserId { get; set; }

        public virtual List List { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }

}
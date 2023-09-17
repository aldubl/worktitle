using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;

namespace WorkTitle.Domain.Entities
{
    public class ListType
    {
        public Guid Id { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<List> Lists { get; set; } = new List<List>();
    }

}
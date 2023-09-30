using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;

namespace WorkTitle.Domain.Entities
{
    public sealed class ListType : BaseEntity
    {
        public string? Description { get; set; }

        public ICollection<WishList>? Lists { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;

namespace WorkTitle.Domain.Entities
{
    public sealed class ListVoter : BaseEntity
    {
        public Guid? ListId { get; set; }

        public Guid? UserId { get; set; }

        public WishList? List { get; set; }

        public User? User { get; set; }
    }
}
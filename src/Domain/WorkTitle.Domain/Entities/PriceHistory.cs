using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;

namespace WorkTitle.Domain.Entities
{

    public sealed class PriceHistory : BaseEntity
    {
        public Guid? ProductId { get; set; }

        public DateTimeOffset? Date { get; set; }

        public decimal? Price { get; set; }
    }

}
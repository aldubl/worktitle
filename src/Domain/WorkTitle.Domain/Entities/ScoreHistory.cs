using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;

namespace WorkTitle.Domain.Entities
{
    public class ScoreHistory : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public DateTimeOffset? Date { get; set; }

        public short? Score { get; set; }
    }
}
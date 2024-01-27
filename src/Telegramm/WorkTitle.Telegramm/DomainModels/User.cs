using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTitle.Telegramm.DomainModels
{
    internal class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public long ChatId { get; set; }
        public required string Email { get; set; }
        public Guid DefaultListId { get; set; }
    }
}

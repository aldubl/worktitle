using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class UserRegisterResultDTO
    {
        public bool Succeeded { get; set; }

        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
    }
}

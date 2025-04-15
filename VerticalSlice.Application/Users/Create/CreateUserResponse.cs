using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalSlice.Application.Users.Create
{
    public class CreateUserResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}

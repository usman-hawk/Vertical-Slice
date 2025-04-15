using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerticalSlice.Domain.Entities;

namespace VerticalSlice.Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}

using HHMBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Infrastructure.Interfaces
{
    public interface IWishRepository
    {
        Task<Wish> Create(Wish wish);
        Task<Wish?> Read(Guid id);
        Task<IEnumerable<Wish>> ReadAll();
        Task<Wish?> Update(Wish wish);
        Task<Wish?> Delete(Guid id);
    }
}

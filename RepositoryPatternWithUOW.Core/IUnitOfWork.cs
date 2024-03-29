using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Author> Authors { get; }
        IBooksRepository Books { get; }
        IBaseRepository<Customer> Customers { get; }
        IBaseRepository<Item> Items { get; }
        IBaseRepository<Order> Orders { get; }
        IBaseRepository<OrderDetail> OrderDetails { get; }
        IBaseRepository<UOM> UOMs { get; }
        int Complete();
    }
}
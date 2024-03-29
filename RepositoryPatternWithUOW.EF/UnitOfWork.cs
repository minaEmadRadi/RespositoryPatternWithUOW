using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepository<Author> Authors { get; private set; }
        public IBooksRepository Books { get; private set; }

        public IBaseRepository<Customer> Customers { get; private set; }

        public IBaseRepository<Item> Items { get; private set; }

        public IBaseRepository<Order> Orders { get; private set; }

        public IBaseRepository<OrderDetail> OrderDetails { get; private set; }

        public IBaseRepository<UOM> UOMs { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Authors = new BaseRepository<Author>(_context);
            Books = new BooksRepository(_context);
            Customers =new CustomerRepository(_context);
            Items = new ItemRepository(_context);
            Orders = new OrderRepository(_context);
            OrderDetails = new OrderDetailRepository(_context);
            UOMs = new UOMRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
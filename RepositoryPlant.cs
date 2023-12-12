using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Data
{

        internal class RepositoryPlant<T> where T : class
        {
            private readonly GreenThumbDbContext _context;
            private readonly DbSet<T> _dbSet;

            public RepositoryPlant(GreenThumbDbContext context)
            {
                _context = context;
                _dbSet = context.Set<T>();
            }

            public IEnumerable<T> GetAll()
            {
                return _dbSet.ToList();
            }
            public void Add(T entity) => _dbSet.Add(entity);
            public async Task RemoveAsync(T entity)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
            public void SaveChanges() => _context.SaveChanges();
        }
}

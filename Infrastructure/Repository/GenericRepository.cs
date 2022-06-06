using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> table = null;

        public GenericRepository(ApplicationDbContext context)
        {
           _context = context;
            table=_context.Set<T>();
        }
        public void Add(T entity)
        {
            table.Add(entity);
        }

        public void Delete(object id)
        {
            T existing=GetTById(id);
           table.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetTById(object id)
        {
            return table.Find(id);
        }

        public void Update(T entity)
        {
            //T existing = GetTById(entity);
            //table.Update(existing);
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;    
        }
    }
}

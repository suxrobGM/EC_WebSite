﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EC_Website.Core.Interfaces;
using EC_Website.Infrastructure.Data;

namespace EC_Website.Infrastructure.Repositories
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        // ReSharper disable once MemberCanBeProtected.Global
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<TEntity> GetByIdAsync<TEntity>(string id) where TEntity: class, IEntity<string>
        {
            return _context.Set<TEntity>().FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity: class, IEntity<string>
        {
            return _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public Task<List<TEntity>> GetListAsync<TEntity>() where TEntity: class, IEntity<string>
        {
            return _context.Set<TEntity>().ToListAsync();
        }

        public Task<List<TEntity>> GetListAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity: class, IEntity<string>
        {
            return _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public IQueryable<TEntity> GetQuery<TEntity>(Expression<Func<TEntity, bool>> predicate, 
            string includeString = null, bool disableTracking = true) where TEntity: class, IEntity<string>
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (disableTracking)
            {
                query = _context.Set<TEntity>().AsNoTracking();
            }

            if (!string.IsNullOrWhiteSpace(includeString))
            {
                query = query.Include(includeString);
            }

            return predicate == null ? query : query.Where(predicate);
        }

        public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity: class, IEntity<string>
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task UpdateAsync<TEntity>(TEntity entity) where TEntity: class, IEntity<string>
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync<TEntity>(TEntity entity) where TEntity: class, IEntity<string>
        {
            var sourceEntity = _context.Set<TEntity>().FirstOrDefault(i => i.Id == entity.Id);

            if (sourceEntity == null) 
                return Task.CompletedTask;

            _context.Remove(sourceEntity);
            return _context.SaveChangesAsync();
        }
    }
}

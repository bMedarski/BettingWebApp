﻿using System;

namespace BettingApp.Data
{
	using System.Linq;
	using System.Threading.Tasks;
	using Common;
	using Microsoft.EntityFrameworkCore;

	public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable
		where TEntity : class
	{
		private readonly BettingAppDbContext _context;
		private readonly DbSet<TEntity> _dbSet;

		public DbRepository(BettingAppDbContext context)
		{
			this._context = context;
			this._dbSet = this._context.Set<TEntity>();
		}

		public Task AddAsync(TEntity entity)
		{
			return this._dbSet.AddAsync(entity);
		}

		public IQueryable<TEntity> All()
		{
			return this._dbSet;
		}

		public void Delete(TEntity entity)
		{
			this._dbSet.Remove(entity);
		}

		public Task<int> SaveChangesAsync()
		{
			return this._context.SaveChangesAsync();
		}

		public void Dispose()
		{
			this._context.Dispose();
		}
	}
}

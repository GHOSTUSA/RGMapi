﻿using Microsoft.AspNetCore.Mvc;
using RGMapi.Models.EntityFramework;

namespace RGMapi.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync();
        Task<ActionResult<TEntity>> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entityToUpdate, TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<ActionResult<TEntity>> GetBy2CompositeKeysAsync(int id1, int id2);
        Task<ActionResult<TEntity>> GetBy3CompositeKeysAsync(int id1, int id2, int id3);
        Task<ActionResult<TEntity>> GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4);
    }
}

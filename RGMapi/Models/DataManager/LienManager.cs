using RGMapi.Models.EntityFramework;
using RGMapi.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager // Pas le bon namespace ici nom plus du coup, ça devrait etre quelque chose du genre RGMapi.Models.DataManager ou autre chose ressemblant
{
    public class LienManager : IDataRepository<Lien>
    {
        readonly RgmContext _dbContext;

        public LienManager() { }

        public LienManager(RgmContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Lien>>> GetAllAsync()
        {
            return await _dbContext.Liens.ToListAsync();
        }

        public async Task<ActionResult<Lien>> GetByIdAsync(int id)
        {
            return await _dbContext.Liens.FirstOrDefaultAsync(p => p.Lienid == id);
        }

        public async Task AddAsync(Lien entity)
        {
            await _dbContext.Liens.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Lien lien, Lien entity)
        {
            _dbContext.Entry(lien).State = EntityState.Modified;
            lien.Lienid = entity.Lienid;
            lien.Liendesc = entity.Liendesc;
            lien.Lien1 = entity.Lien1;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Lien lien)
        {
            _dbContext.Liens.Remove(lien);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<Lien>> IDataRepository<Lien>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Lien>> IDataRepository<Lien>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Lien>> IDataRepository<Lien>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }
    }
}

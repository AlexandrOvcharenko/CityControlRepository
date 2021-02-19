using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.models;
using Microsoft.EntityFrameworkCore;

namespace DataService.Repository
{
    public class SectorDAO : AbstractDAO<Sector>
    {
        private readonly ApplicationDBContext dbContext;

        public SectorDAO(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<List<Sector>> GetAll()
        {
            return await dbContext.Sectors.ToListAsync();
        }

        public async Task<Sector> GetById(Guid? id)
        {
            Sector sector = await dbContext.Sectors.FindAsync(id);

            if (sector == null)
            {
                return null;
            }

            return sector;
        }

        public async Task<Sector> Create(Sector sector)
        {
            await dbContext.Sectors.AddAsync(sector);
            await dbContext.SaveChangesAsync();
            return sector;
        }

        public Task<Sector> Update(Sector model)
        {
            throw new NotImplementedException();
        }
    }
}
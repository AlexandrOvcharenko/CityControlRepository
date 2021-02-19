using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.models;
using DataService.Models;
using Microsoft.EntityFrameworkCore;

namespace DataService.Repository
{
    public class HouseDAO : AbstractDAO<House>
    {
        private readonly ApplicationDBContext dbContext;

        public HouseDAO(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<List<House>> GetAll()
        {
            return await dbContext.Houses.ToListAsync();
        }

        public async Task<House> GetById(Guid? id)
        {
            House house = await dbContext.Houses.FindAsync(id);

            if (house == null)
            {
                return null;
            }

            return house;
        }

        public async Task<House> Create(House house)
        {
            var sector = await dbContext.Sectors.FirstOrDefaultAsync(s => s.Name == house.SectorName);
            house.SectorId = sector.Id;
            await dbContext.Houses.AddAsync(house);
            await dbContext.SaveChangesAsync();
            return house;
        }

        public Task<House> Update(House house)
        {
            throw new NotImplementedException();
        }
    }
}
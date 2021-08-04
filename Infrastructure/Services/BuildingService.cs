using Application.Buildings;
using Application.Common.Models;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly ApplicationDbContext _dbContext;
        public BuildingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> CreateBuilding(Building building)
        {
            await _dbContext.Buildings.AddAsync(building);
            var result = await _dbContext.SaveChangesAsync() > 0;
            if (result)
                return Result.Success();
            //throw new Exception();
            return Result.Failure(new List<string> { "Data insert failed" });

            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<List<Building>> GetBuildingList()
        {
            throw new NotImplementedException();
        }
        //public async Task<Result> CreateBuilding(Building building)
        //{
        //    if (basicType.Id == 0)
        //    {

        //        bool check = _dbContext.BasicTypes.Where(x => x.Id == basicType.Id).Any(c => c.KeyName.ToLower() == basicType.KeyName.ToLower());
        //        if (check)
        //        {
        //            return Result.Failure(new List<string> { "Data already exist" });
        //        }
        //        await _dbContext.BasicTypes.AddAsync(basicType);
        //    }
        //    else
        //    {
        //        _dbContext.BasicTypes.Attach(basicType);
        //        _dbContext.Entry(basicType).State = EntityState.Modified;
        //    }

        //    var result = await _dbContext.SaveChangesAsync() > 0;
        //    if (result)
        //        return Result.Success();
        //    //throw new Exception();
        //    return Result.Failure(new List<string> { "Data insert failed" });
        //}
    }
}

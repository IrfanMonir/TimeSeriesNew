﻿using Application.Common.Models;
using Application.DataFields;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DataFieldService : IDataFieldService
    {
        private readonly ApplicationDbContext _dbContext;
        public DataFieldService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result> CreateDataField(DataField dataField)
        {
            await _dbContext.DataFields.AddAsync(dataField);
            var result = await _dbContext.SaveChangesAsync() > 0;
            if (result)
                return Result.Success();
            return Result.Failure(new List<string> { "Data insert failed" });
        }


        public Task<List<DataField>> GetDataFieldList()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _dbContext.DisposeAsync();
        }
    }
}

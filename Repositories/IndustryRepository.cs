﻿using Contracts;
using Entities.Models;
using Microsoft.Extensions.Options;
using Mongo.Common.MongoDB;
using Mongo.Common.Settings;
using Repositories.Extensions;
using Shared.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories
{
    public class IndustryRepository : Repository<Industry>, IIndustryRepository
    {
        public IndustryRepository(MongoDbSettings settings) : base(settings)
        {}

        public async Task AddAsync(Industry industry) => 
            await CreateAsync(industry);

        public async Task EditAsync(Expression<Func<Industry, bool>> expression, Industry industry) => 
            await UpdateAsync(expression, industry);

        public async Task DeleteAsync(Expression<Func<Industry, bool>> expression) => 
            await RemoveAsync(expression);

        public async Task<Industry?> FindAsync(Guid id) =>
            await GetAsync(i => i.Id.Equals(id));

        public PagedList<Industry> Find(SearchParameters searchTerms)
        {
            var industries = GetAsQueryable(i => i.IsDeprecated == false)
                    .OrderBy(i => i.Name)
                    .Search(searchTerms.SearchBy);

            return PagedList<Industry>.ToPagedList(industries, searchTerms.PageNumber, searchTerms.PageSize);
        }

        public IQueryable<Industry> FindAsQueryable() =>
            GetAsQueryable(x => x.IsDeprecated == false)
                .OrderBy(i => i.Name);
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using MyRecipeBook.Domain.Repositories.User;

namespace MyRecipeBook.Infrastructure.DataAccess;

internal class UnitOfWork: IUnitOfWork
{
    private readonly MyRecipeBookDbContext _dbContext;
    public UnitOfWork(MyRecipeBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Commit() => await _dbContext.SaveChangesAsync();
}

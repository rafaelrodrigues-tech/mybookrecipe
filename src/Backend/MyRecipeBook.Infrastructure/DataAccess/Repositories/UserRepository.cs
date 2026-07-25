using Microsoft.EntityFrameworkCore;

using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Repositories.User;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories;

internal sealed class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    private readonly MyRecipeBookDbContext _dbContext;
    public UserRepository(MyRecipeBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    //Adicionar usuarios no banco de dados
    public async Task Add(User user) => await _dbContext.Users.AddAsync(user);

    // Implement the read-only interface member
    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Active && user.Email.Equals(email));
    }
}

namespace MyRecipeBook.Domain.Repositories.User;

public interface IUnitOfWork
{
    Task Commit();
}

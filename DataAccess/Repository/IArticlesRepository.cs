using BussinessObject.Models;

namespace DataAccess.Repository;
public interface IArticlesRepository : IRepositoryBase<Articles>
{
    bool FindArticleTitle(string title);
}

using BussinessObject.Data;
using BussinessObject.Models;

namespace DataAccess.Repository.Impl;
public class CategoryRepositoryImpl : RepositoryBaseImpl<Category>, ICategoryRepository
{
    private readonly ApplicationContext _context;

    public CategoryRepositoryImpl(ApplicationContext context) : base(context)
    {
        _context = context;
    }

}

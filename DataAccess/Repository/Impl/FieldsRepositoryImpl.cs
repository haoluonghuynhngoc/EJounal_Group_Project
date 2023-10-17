using BussinessObject.Data;
using BussinessObject.Models;

namespace DataAccess.Repository.Impl;
public class FieldsRepositoryImpl : RepositoryBaseImpl<Fields>, IFieldsRepository
{
    private readonly ApplicationContext _context;

    public FieldsRepositoryImpl(ApplicationContext context) : base(context)
    {
        _context = context;
    }
}

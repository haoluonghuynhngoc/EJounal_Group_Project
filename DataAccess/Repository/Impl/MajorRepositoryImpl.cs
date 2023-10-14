using BussinessObject.Data;
using BussinessObject.Models;

namespace DataAccess.Repository.Impl;
public class MajorRepositoryImpl : RepositoryBaseImpl<Majors>, IMajorRepository
{
    private readonly ApplicationContext _context;

    public MajorRepositoryImpl(ApplicationContext context) : base(context)
    {
        _context = context;
    }
}

using BussinessObject.Data;
using BussinessObject.Models;

namespace DataAccess.Repository.Impl;
public class JournalRepositoryImpl : RepositoryBaseImpl<Journals>, IJournalRepository
{
    private readonly ApplicationContext _context;

    public JournalRepositoryImpl(ApplicationContext context) : base(context)
    {
        _context = context;
    }
}

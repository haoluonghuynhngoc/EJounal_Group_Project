using BussinessObject.Models;

namespace DataAccess.Repository;
public interface IMajorRepository : IRepositoryBase<Majors>
{
    public void AddAllMajor(List<Majors> majors);
}

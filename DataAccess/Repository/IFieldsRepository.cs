using BussinessObject.Models;

namespace DataAccess.Repository;
public interface IFieldsRepository : IRepositoryBase<Fields>
{
    void AddAllFields(List<Fields> fields);
}

using BussinessObject.Models;
using DataAccess.Repository;

namespace DataAccess.Data;
public class SeedDataMajors
{
    private readonly IMajorRepository _majorRepository;

    public SeedDataMajors(IMajorRepository majorRepository)
    {
        _majorRepository = majorRepository;
    }
    public void Initialize()
    {
        if (_majorRepository.GetAll().Any())
        {
            return;
        }

        _majorRepository.AddAllMajor(new List<Majors> { new Majors{ Name ="Technique"},
                                                        new Majors{ Name ="Economy"},
                                                        new Majors{ Name ="Medicine"},
                                                        new Majors{ Name ="Cuisine"},
                                                        new Majors{ Name ="Fine Arts"}
        });
    }
}

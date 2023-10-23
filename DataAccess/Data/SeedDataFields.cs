using BussinessObject.Models;
using DataAccess.Repository;

namespace DataAccess.Data;
public class SeedDataFields
{
    private readonly IFieldsRepository _fieldsRepository;

    public SeedDataFields(IFieldsRepository fieldsRepository)
    {
        _fieldsRepository = fieldsRepository;
    }
    public void Initialize()
    {
        if (_fieldsRepository.GetAll().Any())
        {
            return;
        }
        _fieldsRepository.AddAllFields(new List<Fields> { new Fields { Name = "Natural Sciences" }
                                                 , new Fields { Name = "Engineering and Technology" }
                                                 , new Fields { Name = "Medicine and Healthcare"  }
                                                 , new Fields { Name = "Social Sciences"  }
                                                 , new Fields { Name = "Arts and Culture"  }
                                                 , new Fields { Name = "Education"  }
                                                 , new Fields { Name = "Environment and Earth Sciences"  }
                                                 , new Fields { Name = "History and Anthropology"  }
                                                 , new Fields { Name = "Finance and Business"  }
                                                 }
        );
    }
}

using BussinessObject.Models;
using BussinessObject.Models.enums;
using DataAccess.Repository;

namespace DataAccess.Data;
public class SeedDataJournals
{
    private readonly IJournalRepository _journalRepository;

    public SeedDataJournals(IJournalRepository journalRepository)
    {
        _journalRepository = journalRepository;
    }

    public void Initialize()
    {
        if (_journalRepository.GetAll().Any())
        {
            return;
        }

        _journalRepository.AddAllJournals(new List<Journals> {
                            new Journals{ CreateAt=DateTime.Now,UpdateAt=DateTime.Now,Name="Academic Journals"
                                          ,SortDescription="Evaluated in many academic fields, including natural sciences, " +
                                          "engineering, medicine, sociology, economics, and more", Status =JournalStatus.ARCHIVED },
                            new Journals{ CreateAt=DateTime.Now,UpdateAt=DateTime.Now,Name="Scientific Journals"
                                          ,SortDescription="Evaluated in scientific fields of study, including natural sciences (e.g. chemistry, physics, biology) " +
                                          ", medicine, engineering, and technology", Status =JournalStatus.ARCHIVED },
                            new Journals{ CreateAt=DateTime.Now,UpdateAt=DateTime.Now,Name="Medical Journals"
                                          ,SortDescription="Rated in the field of medicine and healthcare. Includes articles on clinical research, medical developments" +
                                          ", and disease treatment", Status =JournalStatus.ARCHIVED },
                            new Journals{ CreateAt=DateTime.Now,UpdateAt=DateTime.Now,Name="Art Journals"
                                          ,SortDescription="Judged in the field of art and culture, including painting," +
                                          " sculpture, music, theater, and many other artistic fields.", Status =JournalStatus.ARCHIVED },
                            new Journals{ CreateAt=DateTime.Now,UpdateAt=DateTime.Now,Name="Social Science Journals"
                                          ,SortDescription="Evaluated in the social sciences, including psychology, sociology," +
                                          " economics, political science, and other human studies fields", Status =JournalStatus.ARCHIVED },
        });
    }
}

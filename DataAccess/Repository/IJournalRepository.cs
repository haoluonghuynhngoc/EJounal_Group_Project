﻿using BussinessObject.Models;

namespace DataAccess.Repository;
public interface IJournalRepository : IRepositoryBase<Journals>
{
    void AddAllJournals(List<Journals> journals);
}

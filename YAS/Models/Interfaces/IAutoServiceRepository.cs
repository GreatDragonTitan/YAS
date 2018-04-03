using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YAS.Models.Records;

namespace YAS.Models.Interfaces
{
    public interface IAutoServiceRepository
    {
        IQueryable<AutoServiceRecord> GetAll();

        AutoServiceRecord Get(int id);

        Task Add(AutoServiceRecord post);

        Task Edit(AutoServiceRecord post);

        Task Delete(int id);
    }
}

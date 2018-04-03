using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YAS.Models.Interfaces;
using YAS.Models.Records;

namespace YAS.Models.Repositories
{
    public class AutoServiceRepository : IAutoServiceRepository
    {
        private ApplicationDbContext _context;

        public AutoServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<AutoServiceRecord> GetAll()
        {
            return _context.AutoServices;
        }

        public AutoServiceRecord Get(int id)
        {
            foreach(var a in _context.AutoServices)
            {
                if(a.Id == id)
                {
                    return a;
                }
            }
            return null;
        }

        public async Task Add(AutoServiceRecord autoService)
        {
            autoService.DateAdded = DateTime.Now;
            _context.Add(autoService);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(AutoServiceRecord autoService)
        {
            foreach (var p in _context.AutoServices)
            {
                if (p.Id == autoService.Id)
                {
                    p.Name = autoService.Name;
                    p.Description = autoService.Description;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var p = _context.AutoServices.Find(id);
            _context.AutoServices.Remove(p);
            await _context.SaveChangesAsync();
        }
    }
}

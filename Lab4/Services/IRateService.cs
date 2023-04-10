using MauiApp1.Lab4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Lab4.Services
{
    public interface IRateService
    {
        public Task<IEnumerable<Rate>> GetRates(DateTime date);
    }
}

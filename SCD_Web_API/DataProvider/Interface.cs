using SCD_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCD_Web_API.DataProvider
{
    public interface IUserDataProvider
    {
        Task<IEnumerable<People>> GetPeoples();

        Task<People> GetPerson(int Id);

        Task AddPerson(People product);

        Task UpdatePerson(People product);

        Task DeletePerson(int Id);
    }
}

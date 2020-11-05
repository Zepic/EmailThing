using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailThing._10_Core.Domain.Model;

namespace EmailThing._10_Core.Domain.Services
{
    public interface IEmailRepository
    {
        Task<int> Create(Email email);
        Task<IEnumerable<Email>> ReadAll();
        Task<IEnumerable<Email>> ReadOneByGuid(Guid guid);
    }
}

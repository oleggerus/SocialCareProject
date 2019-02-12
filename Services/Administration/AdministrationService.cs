using DataRepository.RepositoryPattern;
using System.Collections.Generic;
using System.Linq;

namespace Services.Administration
{
    public class AdministrationService : IAdministrationService
    {
        private readonly IRepository<DataRepository.Entities.Administration> _administrationRepository;

        public AdministrationService(IRepository<DataRepository.Entities.Administration> administrationRepository)
        {
            _administrationRepository = administrationRepository;
        }

        public IList<KeyValuePair<int, string>> GetAllAdministrationsKeyValuePairs()
        {
            return _administrationRepository.TableNoTracking.Select(x => new { x.Id, x.Name }).AsEnumerable()
                .Select(x => new KeyValuePair<int, string>(x.Id, x.Name)).ToList();
        }
    }
}

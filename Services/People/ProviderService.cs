using DataRepository.Entities.People;
using DataRepository.RepositoryPattern;
using System;

namespace Services.People
{
    public class ProviderService : IProviderService
    {
        private readonly IRepository<Provider> _providerRepository;

        public ProviderService(IRepository<Provider> providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public Provider Create(Provider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException();
            }
            _providerRepository.Insert(provider);

            return provider;
        }
    }
}

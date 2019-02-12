using System.Collections.Generic;

namespace Services.Administration
{
    public interface IAdministrationService
    {
        IList<KeyValuePair<int, string>> GetAllAdministrationsKeyValuePairs();
    }
}

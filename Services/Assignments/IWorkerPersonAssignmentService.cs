using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Entities.People;

namespace Services.Assignments
{
    public interface IWorkerPersonAssignmentService
    {
        List<Worker> GetAllowedForAssignWorkers(int administrationId);
    }
}

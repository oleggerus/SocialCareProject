using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Entities;
using DataRepository.Entities.People;

namespace Services.Assignments
{
    public interface IWorkerPersonAssignmentService
    {
        List<Worker> GetAllowedForAssignWorkers(int administrationId);
        WorkerPersonAssignment Create(WorkerPersonAssignment assignment);
        bool IsWorkerFree(int workerUserId);

        Worker GetAssignedWorkerUser(int customerId);
    }
}

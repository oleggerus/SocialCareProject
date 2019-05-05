using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Entities.People;

namespace Services.People
{
    public interface IWorkerService
    {
        Worker GetWorkerByUserId(int userId);
        Worker GetWorkerById(int workerId);
    }
}

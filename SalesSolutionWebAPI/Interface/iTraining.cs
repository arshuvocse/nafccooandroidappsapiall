using SalesSolutionWebAPI.Models;
using System.Collections.Generic;

namespace SalesSolutionWebAPI.Interface
{
    public interface iTraining
    {
        IList<TrainingDAO> GetTraining(int empId);

    }
}

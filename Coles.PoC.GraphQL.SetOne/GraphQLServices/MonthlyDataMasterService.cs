using Coles.PoC.GraphQL.SetOne.Interfaces;
using Coles.PoC.GraphQL.SetOne.Model;
using System.Linq;
using Microsoft.AspNetCore.SignalR.Protocol;
using Coles.PoC.Infra.Repositories.Contracts;
using Coles.PoC.Infra.Repositories;
using Coles.PoC.Infra.EFCore.Entities;

namespace Coles.PoC.GraphQL.SetOne.GraphQLServices
{
    public class MonthlyDataMasterService : IMonthlyDataMasterService
    {
        IRepositoryManager _repository;
        public MonthlyDataMasterService(IRepositoryManager repository)
        {
			_repository = repository;
		}

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public List<MonthlyDataMaster> GetAllMonthlyDataMasters()
        {
            return GetData();
        }


        public MonthlyDataMaster GetMonthlyDataMastersById(int id)
        {
            return GetData().FirstOrDefault(s => s.Id == id);
        }


		public async Task<IEnumerable<MonthlyDataMasters>> GetAlokMonthlyDataDatabaseAsync()
		{
			var data = _repository.MonthlyDataMasterRepository.GetAllMonthlyDataMaster();
            return data;
		}

		private static List<MonthlyDataMaster> GetData()
        {
            List<MonthlyDataMaster> data = new List<MonthlyDataMaster>();
            for (int i = 0; i < 10; i++)
            {
                string? period;
                string? createdBy;
                if (i % 2 == 0)
                {
                    period = "Pick It";
                    createdBy = "Human";
                }
                else
                {
                    period = "Do It";
                    createdBy = "Auto";
                }

                data.Add(new MonthlyDataMaster { Id = i, DenominationId = i + 9, Period = period, CreatedBy = createdBy });
            }

            return data;
        }
    }
}
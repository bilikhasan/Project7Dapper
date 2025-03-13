using Microsoft.AspNetCore.Mvc;
using Project7Dapper.Repositories.StatisticsRepositories;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;


namespace Project7Dapper.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public StatisticsController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        public async Task<IActionResult> GetAllStatistics(int page = 1)
        {
            var values = await _statisticsRepository.GettAllStatisticsAsync();
            int pageSize = 15;

            var pagedList = values.ToPagedList(page, pageSize);
            return View(pagedList);
        }

    }
}

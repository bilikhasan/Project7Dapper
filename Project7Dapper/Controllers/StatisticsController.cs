using Dapper;
using Microsoft.AspNetCore.Mvc;
using Project7Dapper.Context;
using Project7Dapper.Dtos;
using Project7Dapper.Repositories.StatisticsRepositories;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;


namespace Project7Dapper.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly DapperContext _context;


        private readonly IStatisticsRepository _statisticsRepository;
        public StatisticsController(IStatisticsRepository statisticsRepository, DapperContext context)
        {
            _statisticsRepository = statisticsRepository;
            _context = context;
        }
        //public async Task<IActionResult> GetAllStatistics(int page = 1)
        //{
        //    var values = await _statisticsRepository.GettAllStatisticsAsync();
        //    int pageSize = 15;

        //    var pagedList = values.ToPagedList(page, pageSize);
        //    return View(pagedList);
        //}
        public async Task<IActionResult> GetAllStatistics(string searchQuery = "", int page = 1)
        {
            string sqlQuery = "SELECT * FROM GlobalHealthStatistics"; // Varsayılan sorgu

            if (!string.IsNullOrEmpty(searchQuery))
            {
                sqlQuery += " WHERE Disease_Name LIKE @search OR Disease_Category LIKE @search"; // Arama için filtre ekliyoruz
            }
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultStatisticsDto>(sqlQuery, new { search = "%" + searchQuery + "%" }, commandTimeout:300);

            int pageSize = 15;
            var pagedList = values.ToPagedList(page, pageSize);

            ViewBag.SearchQuery = searchQuery; // Arama terimini View tarafına göndermek için

            return View(pagedList);
        }
    }
}

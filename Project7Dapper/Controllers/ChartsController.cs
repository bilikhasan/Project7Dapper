using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Project7Dapper.Context;
using Project7Dapper.Dtos;
using Project7Dapper.Repositories.StatisticsRepositories;
using System.Linq;

namespace Project7Dapper.Controllers
{
    public class ChartsController : Controller
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public ChartsController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<IActionResult> MostSeenDiseaseIn2020()
        {
            var values = await _statisticsRepository.MostSeenDiseasein2020Async();
            ViewBag.mostDiseaseCount = values.CaseCount;
            ViewBag.mostDiseaseName = values.Disease_Name;

            var values2 = await _statisticsRepository.TheHighestDiseaseSpreadRateAsync();
            ViewBag.TheHighestDiseaseSpreadRate = values2.Select(x => new
            {
                x.Country,
                x.Disease_Name,
                x.Max_Prevalence
            }).ToList();

            var values3 = await _statisticsRepository.DiseasesWithTheHighestMortalityRatesIn2020Async();
            ViewBag.DiseasesWithTheHighestMortalityRatesIn2020 = values3.Select(x => new
            {
                x.Disease_Name,
                x.Disease_Category,
                x.Mortality_Rate
            }).ToList();

            var values4 = await _statisticsRepository.The10MostCommonDiseasesInWomenAndMenIn2020Async();
            ViewBag.The10MostCommonDiseasesInWomenAndMenIn2020 = values4.Select(x => new
            {
                x.Disease_Name,
                x.Gender,
                x.Prevalence_Rate
            }).ToList();

            var values5 = await _statisticsRepository.DiseasesWithTheMostExpensiveTreatmentsAsync();
            ViewBag.DiseasesWithTheMostExpensiveTreatments = values5.Select(x => new
            {
                x.Disease_Name,
                x.Disease_Category,
                x.Avg_Cost
            }).ToList();

            var values6 = await _statisticsRepository.CountriesWithTheLowestHealthcareAccessAsync();
            ViewBag.CountriesWithTheLowestHealthcareAccess = values6.Select(x => new
            {
                x.Country,
                x.Avg_Healthcare_Access
            }).ToList();


            var values7 = await _statisticsRepository.CountriesWithTheMostDoctorsAsync();
            ViewBag.CountriesWithTheMostDoctors = values7.Select(x => new
            {
                x.Country,
                x.Avg_Doctors
            }).ToList();

            return View();
        }





        public async Task<IActionResult> ZGrafik1()
        {
            var MostSeenDiseaseIn2020 = await _statisticsRepository.ZGrafik1();
            return View(MostSeenDiseaseIn2020);
        }

        public async Task<IActionResult> Zgrafik2()
        {
            var TheHighestDiseaseSpreadRate = await _statisticsRepository.ZGrafik2();
            return View(TheHighestDiseaseSpreadRate);
        }

        public async Task<IActionResult> ZGrafik3()
        {
            var DiseasesWithTheMostExpensiveTreatments  = await _statisticsRepository.ZGrafik3();
            return View(DiseasesWithTheMostExpensiveTreatments);
        }

        public async Task<IActionResult> ZGrafik4()
        {
            var DiseasesWithTheHighestMortalityRatesIn2020 = await _statisticsRepository.ZGrafik4();
            return View(DiseasesWithTheHighestMortalityRatesIn2020);
        }

        public async Task<IActionResult> ZGrafik5()
        {
            var The10MostCommonDiseaseInWomenAndMenIn2020 = await _statisticsRepository.ZGrafik5();
            return View(The10MostCommonDiseaseInWomenAndMenIn2020);
        }
        public async Task<IActionResult> ZGrafik6()
        {
            var CountriesWithTheLowestHealthcareAccess = await _statisticsRepository.ZGrafik6();
            return View(CountriesWithTheLowestHealthcareAccess);
        }

        public async Task<IActionResult> ZGrafik7()
        {
            var CountriesWithTheMostDoctors = await _statisticsRepository.ZGrafik7();
            return View(CountriesWithTheMostDoctors);
        }
    }
}

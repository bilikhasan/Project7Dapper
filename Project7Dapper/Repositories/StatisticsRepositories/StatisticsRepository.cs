using Dapper;
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;
using Project7Dapper.Context;
using Project7Dapper.Dtos;
using X.PagedList;


namespace Project7Dapper.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly DapperContext _context;
        public StatisticsRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<CountriesWithTheLowestHealthcareAccessDto>> CountriesWithTheLowestHealthcareAccessAsync()
        {
            string query = "SELECT top 10 Country, AVG(Healthcare_Access) AS Avg_Healthcare_Access FROM GlobalHealthStatistics GROUP BY Country ORDER BY Avg_Healthcare_Access asc";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<CountriesWithTheLowestHealthcareAccessDto>(query, commandTimeout: 300);
            return values.ToList();
        }

        public async Task<List<CountriesWithTheMostDoctors>> CountriesWithTheMostDoctorsAsync()
        {
            string query = "SELECT top 10 Country, AVG(Doctors_per_1000) AS Avg_Doctors FROM GlobalHealthStatistics GROUP BY Country ORDER BY Avg_Doctors DESC";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<CountriesWithTheMostDoctors>(query, commandTimeout: 300);
            return values.ToList();
        }

        public async Task<List<DiseasesWithTheHighestMortalityRatesIn2020>> DiseasesWithTheHighestMortalityRatesIn2020Async()
        {
            string query = "SELECT top 10 Disease_Name, Disease_Category, AVG(Mortality_Rate) AS Avg_Mortality FROM GlobalHealthStatistics WHERE Year = 2020 GROUP BY Disease_Name, Disease_Category ORDER BY Avg_Mortality DESC";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<DiseasesWithTheHighestMortalityRatesIn2020>(query, commandTimeout: 300);
            return values.ToList();
        }

        public async Task<List<DiseasesWithTheMostExpensiveTreatmentsDto>> DiseasesWithTheMostExpensiveTreatmentsAsync()
        {
            string query = "SELECT top 10 Disease_Name, Disease_Category, AVG(Average_Treatment_Cost_USD) AS Avg_Cost FROM GlobalHealthStatistics GROUP BY Disease_Name, Disease_Category ORDER BY Avg_Cost DESC";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<DiseasesWithTheMostExpensiveTreatmentsDto>(query, commandTimeout: 300);
            return values.ToList();
        }

        public async Task<List<ResultStatisticsDto>> GettAllStatisticsAsync()
        {
            string query = "select * from GlobalHealthStatistics";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultStatisticsDto>(query, commandTimeout: 300);
            return values.ToList();
        }


        public async Task<MostSeenDiseaseIn2020Dto> MostSeenDiseasein2020Async()
        {
            string query = "SELECT TOP 1  Disease_Name, COUNT (*) AS CaseCount FROM GlobalHealthStatistics WHERE Year = 2020 GROUP BY Disease_Name ORDER BY CaseCount DESC;";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<MostSeenDiseaseIn2020Dto>(query, commandTimeout: 300);
            return values.FirstOrDefault();
        }

        public async Task<List<The10MostCommonDiseasesInWomenAndMenIn2020>> The10MostCommonDiseasesInWomenAndMenIn2020Async()
        {
            string query = "SELECT top 10 Disease_Name, Gender, AVG(Prevalence_Rate) AS Avg_Prevalence FROM GlobalHealthStatistics WHERE Year = 2020 GROUP BY Disease_Name, Gender ORDER BY Avg_Prevalence DESC";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<The10MostCommonDiseasesInWomenAndMenIn2020>(query, commandTimeout: 300);
            return values.ToList();
        }

        public async Task<List<TheHighestDiseaseSpreadRateDto>> TheHighestDiseaseSpreadRateAsync()
        {
            string query = "SELECT TOP 10 Country, Disease_Name, MAX(Prevalence_Rate) AS Max_Prevalence FROM GlobalHealthStatistics GROUP BY Country, Disease_Name ORDER BY Max_Prevalence DESC";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<TheHighestDiseaseSpreadRateDto>(query, commandTimeout: 300);
            return values.ToList();
        }

        public async Task<List<MostSeenDiseaseIn2020Dto>> ZGrafik1()
        {
            string query = "SELECT TOP 10  Disease_Name, COUNT (*) AS CaseCount FROM GlobalHealthStatistics WHERE Year = 2020 GROUP BY Disease_Name ORDER BY CaseCount DESC;";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<MostSeenDiseaseIn2020Dto>(query, commandTimeout: 300);
            return values.ToList();
        }

        public async Task<List<TheHighestDiseaseSpreadRateDto>> ZGrafik2()
        {
            string query = "SELECT TOP 10 Country, Disease_Name, MAX(Prevalence_Rate) AS Max_Prevalence FROM GlobalHealthStatistics GROUP BY Country, Disease_Name ORDER BY Max_Prevalence DESC";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<TheHighestDiseaseSpreadRateDto>(query, commandTimeout: 300);
            return values.ToList();
        }

        public async Task<List<DiseasesWithTheMostExpensiveTreatmentsDto>> ZGrafik3()
        {
            string query = "SELECT top 10 Disease_Name, Disease_Category, AVG(Average_Treatment_Cost_USD) AS Avg_Cost FROM GlobalHealthStatistics GROUP BY Disease_Name, Disease_Category ORDER BY Avg_Cost DESC";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<DiseasesWithTheMostExpensiveTreatmentsDto>(query, commandTimeout: 300);
            return values.ToList();
        }

        public async Task<List<DiseasesWithTheHighestMortalityRatesIn2020>> ZGrafik4()
        {
            string query = "SELECT top 10 Disease_Name, Disease_Category, AVG(Mortality_Rate) AS Avg_Mortality FROM GlobalHealthStatistics WHERE Year = 2020 GROUP BY Disease_Name, Disease_Category ORDER BY Avg_Mortality DESC";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<DiseasesWithTheHighestMortalityRatesIn2020>(query, commandTimeout: 300);
            return values.ToList();
        }

        public async Task<List<The10MostCommonDiseasesInWomenAndMenIn2020>> ZGrafik5()
        {
            string query = "SELECT top 10 Disease_Name, Gender, AVG(Prevalence_Rate) AS Avg_Prevalence FROM GlobalHealthStatistics WHERE Year = 2020 GROUP BY Disease_Name, Gender ORDER BY Avg_Prevalence DESC";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<The10MostCommonDiseasesInWomenAndMenIn2020>(query, commandTimeout: 300);
            return values.ToList();
        }

        public async Task<List<CountriesWithTheLowestHealthcareAccessDto>> ZGrafik6()
        {
            string query = "SELECT top 10 Country, AVG(Healthcare_Access) AS Avg_Healthcare_Access FROM GlobalHealthStatistics GROUP BY Country ORDER BY Avg_Healthcare_Access asc";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<CountriesWithTheLowestHealthcareAccessDto>(query, commandTimeout: 300);
            return values.ToList();
        }

        public async Task<List<CountriesWithTheMostDoctors>> ZGrafik7()
        {
            string query = "SELECT top 10 Country, AVG(Doctors_per_1000) AS Avg_Doctors FROM GlobalHealthStatistics GROUP BY Country ORDER BY Avg_Doctors DESC";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<CountriesWithTheMostDoctors>(query, commandTimeout: 300);
            return values.ToList();
        }
    }
}

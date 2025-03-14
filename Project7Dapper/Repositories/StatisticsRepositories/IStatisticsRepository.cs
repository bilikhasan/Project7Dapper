using Project7Dapper.Dtos;

namespace Project7Dapper.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepository
    {
        Task<List<ResultStatisticsDto>> GettAllStatisticsAsync();
        Task<MostSeenDiseaseIn2020Dto> MostSeenDiseasein2020Async();

        Task<List<TheHighestDiseaseSpreadRateDto>> TheHighestDiseaseSpreadRateAsync();
        Task<List<DiseasesWithTheHighestMortalityRatesIn2020>> DiseasesWithTheHighestMortalityRatesIn2020Async();
        Task<List<The10MostCommonDiseasesInWomenAndMenIn2020>> The10MostCommonDiseasesInWomenAndMenIn2020Async();
        Task<List<DiseasesWithTheMostExpensiveTreatmentsDto>> DiseasesWithTheMostExpensiveTreatmentsAsync();
        Task<List<CountriesWithTheLowestHealthcareAccessDto>> CountriesWithTheLowestHealthcareAccessAsync();
        Task<List<CountriesWithTheMostDoctors>> CountriesWithTheMostDoctorsAsync();







        Task<List<MostSeenDiseaseIn2020Dto>> ZGrafik1();
        Task<List<TheHighestDiseaseSpreadRateDto>> ZGrafik2();
        Task<List<DiseasesWithTheMostExpensiveTreatmentsDto>> ZGrafik3();
        Task<List<DiseasesWithTheHighestMortalityRatesIn2020>> ZGrafik4();
        Task<List<The10MostCommonDiseasesInWomenAndMenIn2020>> ZGrafik5();
        Task<List<CountriesWithTheLowestHealthcareAccessDto>> ZGrafik6();



    }
}

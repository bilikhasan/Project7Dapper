namespace Project7Dapper.Dtos
{
    public class ResultStatisticsDto
    {
        public string Country { get; set; }
        public short Year { get; set; }
        public string Disease_Name { get; set; }
        public string Disease_Category { get; set; }
        public double Prevalence_Rate { get; set; }
        public double Incidence_Rate { get; set; }
        public double Mortality_Rate { get; set; }
        public string Age_Group { get; set; }
        public string Gender { get; set; }
        public int Population_Affected { get; set; }
        public double Healthcare_Access { get; set; }
        public double Doctors_per_1000 { get; set; }
        public double Hospital_Beds_per_1000 { get; set; }
        public string Treatment_Type { get; set; }
        public int Average_Treatment_Cost_USD { get; set; }
        public bool Availability_of_Vaccines_Treatment {  get; set; }
        public double Recovery_Rate { get; set; }
        public short DALYs {  get; set; }
        public double Improvement_in_5_Years {  get; set; }
        public int Per_Capita_Income_USD { get; set; }
        public double Education_Index {  get; set; }
        public double Urbanization_Rate {  get; set; }

    }
}

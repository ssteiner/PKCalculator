using System.Collections.Generic;
using System.Linq;

namespace PKCalculator
{
    [System.ComponentModel.DataObject]
    public class Calculator
    {

        private const int topUpSalaryLowerLimit = 129060;
        private const int coordinationAmountLimit = 25095;
        private const int specialContributionLimit = 150000;

        public CalculationResult CalculatePension(int age, int salary, PensionPlan plan)
        {
            var result = new CalculationResult();
            int myAge = age;
            bool firstYear = true;

            var coordinationAmount = (decimal)salary * ((decimal)100 - plan.InsuredSalary)/(decimal)100;
            if (coordinationAmountLimit > 25095)
                coordinationAmount = coordinationAmountLimit;

            result.CoordinationDeduction = coordinationAmount;

            var insuredSalary = (decimal)salary - (decimal)coordinationAmount;
            var topUpSalary = (decimal)0;
            if (salary > topUpSalaryLowerLimit && plan.SupportsTopUpPlan)
            {
                insuredSalary = topUpSalaryLowerLimit - coordinationAmount;
                topUpSalary = (decimal)salary - topUpSalaryLowerLimit;
            }

            foreach (var ppp in plan.Percentages.Where(p => /*age >= p.StartAge &&*/ age <= p.EndAge).OrderBy(p1 => p1.StartAge))
            {
                while (myAge <= ppp.EndAge)
                {
                    if (firstYear)
                    {
                        //result.CurrentYearEmployee = result.TotalEmployee = (decimal)salary * (decimal)plan.InsuredSalary / (decimal)100 * ppp.EmployeePercentage / (decimal)100;
                        //result.CurrentYearEmployer = result.TotalEmployer = (decimal)salary * (decimal)plan.InsuredSalary / (decimal)100 * ppp.EmployerPercentage / (decimal)100;
                        //result.CurrentYearEmployeeRisk = result.TotalEmployeeRisk = (decimal)salary * (decimal)plan.InsuredSalary / (decimal)100 * ppp.EmployeeRiskPercentage / (decimal)100 ;
                        //result.CurrentYearEmployerRisk = result.TotalEmployerRisk = (decimal)salary * (decimal)plan.InsuredSalary / (decimal)100 * ppp.EmployerRiskPercentage / (decimal)100;

                        result.CurrentYearEmployee = result.TotalEmployee = (decimal)insuredSalary / (decimal)100 * ppp.EmployeePercentage;
                        result.CurrentYearEmployer = result.TotalEmployer = (decimal)insuredSalary / (decimal)100 * ppp.EmployerPercentage;
                        result.CurrentYearEmployeeRisk = result.TotalEmployeeRisk = (decimal)insuredSalary / (decimal)100 * ppp.EmployeeRiskPercentage;
                        result.CurrentYearEmployerRisk = result.TotalEmployerRisk = (decimal)insuredSalary / (decimal)100 * ppp.EmployerRiskPercentage;

                        if (topUpSalary > 0)
                        {
                            var topUpPlanEmployerContribution = (decimal)topUpSalary / (decimal)100 * ppp.TopUpPlanEmployerPercentage;
                            result.CurrentYearEmployer += (decimal)topUpPlanEmployerContribution;
                            result.TotalEmployer += (decimal)topUpPlanEmployerContribution;
                            if (salary > specialContributionLimit)
                            {
                                result.CurrentYearEmployer += plan.HighEarnerSpecialContribution;
                                result.TotalEmployer += plan.HighEarnerSpecialContribution;
                            }
                        }
                        firstYear = false;

                    }
                    else
                    {
                        //result.TotalEmployee += (decimal)salary * (decimal)plan.InsuredSalary / (decimal)100 * ppp.EmployeePercentage / (decimal)100 ;
                        //result.TotalEmployer += (decimal)salary * (decimal)plan.InsuredSalary / (decimal)100 * ppp.EmployerPercentage / (decimal)100 ;

                        //decimal tempVal = (decimal)salary * (decimal)plan.InsuredSalary / (decimal)100 * ppp.EmployeeRiskPercentage / (decimal)100;
                        //decimal tempVal2 = (decimal)salary * (decimal)plan.InsuredSalary / (decimal)100 * ppp.EmployerRiskPercentage / (decimal)100;
                        //result.TotalEmployeeRisk += (decimal)salary * (decimal)plan.InsuredSalary / (decimal)100 * ppp.EmployeeRiskPercentage / (decimal)100 ;
                        //result.TotalEmployerRisk += (decimal)salary * (decimal)plan.InsuredSalary / (decimal)100 *  ppp.EmployerRiskPercentage / (decimal)100;

                        result.TotalEmployee += (decimal)insuredSalary / (decimal)100 * ppp.EmployeePercentage;
                        result.TotalEmployer += (decimal)insuredSalary / (decimal)100 * ppp.EmployerPercentage / (decimal)100;

                        if (topUpSalary > 0)
                        {
                            var topUpPlanEmployerContribution = (decimal)topUpSalary / (decimal)100 * ppp.TopUpPlanEmployerPercentage;
                            result.TotalEmployer += (decimal)topUpPlanEmployerContribution;
                            if (salary > specialContributionLimit)
                            {
                                result.CurrentYearEmployer += plan.HighEarnerSpecialContribution;
                                result.TotalEmployer += plan.HighEarnerSpecialContribution;
                            }
                        }

                        decimal tempVal = (decimal)insuredSalary / (decimal)100 * ppp.EmployeeRiskPercentage;
                        decimal tempVal2 = (decimal)insuredSalary / (decimal)100 * ppp.EmployerRiskPercentage;
                        result.TotalEmployeeRisk += (decimal)insuredSalary / (decimal)100 * ppp.EmployeeRiskPercentage;
                        result.TotalEmployerRisk += (decimal)insuredSalary / (decimal)100 * ppp.EmployerRiskPercentage;
                    }
                    myAge++;
                }
            }
            return result;
        }
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public CalculationResult CalculatePension(string age, string salary, string plan)
        {
            var pps = new PensionPlanSource();
            var myPlan = pps.GetPensionPlan(plan);

            return CalculatePension(int.Parse(age), int.Parse(salary), myPlan);
        }

    }


    public class CalculationResult
    {
        public decimal CurrentYearSaved { get { return CurrentYearEmployee + CurrentYearEmployer; } }
        public decimal CurrentYearMonthlySalaryDeduction { get { return (CurrentYearEmployeeRisk + CurrentYearEmployee) / (decimal)12;  }}
        public decimal CurrentYearEmployee { get; set; }
        public decimal CurrentYearEmployer { get; set; }
        public decimal CurrentYearEmployeeRisk { get; set; }
        public decimal CurrentYearEmployerRisk { get; set; }
        public decimal Total { get { return TotalEmployee + TotalEmployer; } }
        public decimal TotalEmployee { get; set; }
        public decimal TotalEmployer { get; set; }
        public decimal TotalEmployeeRisk { get; set; }
        public decimal TotalEmployerRisk { get; set; }

        public decimal CoordinationDeduction { get; set; }
    }

    public class PensionPlan
    {
        public string Name { get; set; }
        public string Employer { get; set; }
        public int InsuredSalary { get; set; }

        public bool SupportsTopUpPlan { get; set; }

        public int HighEarnerSpecialContribution { get; set; }
        public List<PensionPlanPercentage> Percentages {get; set;}

        public PensionPlan()
        {
            Percentages = new List<PensionPlanPercentage>();
        }

        public string FullName { get { return $"{Employer} {Name}"; } }
        
    }

    public class PensionPlanPercentage
    {
        public int StartAge { get; set; }
        public int EndAge { get; set; }
        public decimal EmployeePercentage { get; set; }
        public decimal EmployerPercentage { get; set; }
        public decimal EmployeeRiskPercentage { get; set; }
        public decimal EmployerRiskPercentage { get; set; }

        public decimal TopUpPlanEmployerPercentage { get; set; }
    }
}
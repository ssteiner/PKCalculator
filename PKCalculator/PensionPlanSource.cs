using System.Collections.Generic;
using System.Linq;

namespace PKCalculator
{
    [System.ComponentModel.DataObject]
    public class PensionPlanSource
    {

        private static PensionPlanSource mySource;
        private readonly List<PensionPlan> myPlans;

        public PensionPlanSource()
        {
            if (mySource == null)
            {
                mySource = this;
                myPlans = GeneratePlans();
            }
        }

        #region raw data
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<PensionPlan> GeneratePensionPlans()
        {
            return mySource.myPlans;
        }
        #endregion

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public PensionPlan GetPensionPlan(string identifier)
        {
            return mySource.myPlans.FirstOrDefault((p) => p.FullName == identifier);
        }
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<PensionPlanPercentage> GetPensionPlanDetails(string identifier)
        {
            return mySource.myPlans.FirstOrDefault((p) => p.FullName == identifier).Percentages;
        }


        #region generate data

        private List<PensionPlan> GeneratePlans()
        {
            var plans = new List<PensionPlan>();
            #region NXO
            PensionPlan pp = null;
            //PensionPlan pp = new PensionPlan { Employer = "NXO", Name = "Standard", InsuredSalary = 100 };
            //pp.Percentages.Add(new PensionPlanPercentage
            //{
            //    StartAge = 18,
            //    EndAge = 24,
            //    EmployeePercentage = (decimal)0.0,
            //    EmployerPercentage = 0,
            //    EmployeeRiskPercentage = (decimal)1.2,
            //    EmployerRiskPercentage = (decimal)2.0
            //});
            //pp.Percentages.Add(new PensionPlanPercentage
            //{
            //    StartAge = 25,
            //    EndAge = 34,
            //    EmployeePercentage = (decimal)5.5,
            //    EmployerPercentage = (decimal)6.5,
            //    EmployeeRiskPercentage = (decimal)1.2,
            //    EmployerRiskPercentage = (decimal)2.0
            //});
            //pp.Percentages.Add(new PensionPlanPercentage
            //{
            //    StartAge = 35,
            //    EndAge = 44,
            //    EmployeePercentage = (decimal)6,
            //    EmployerPercentage = (decimal)8,
            //    EmployeeRiskPercentage = (decimal)1.2,
            //    EmployerRiskPercentage = (decimal)2.0
            //});
            //pp.Percentages.Add(new PensionPlanPercentage
            //{
            //    StartAge = 45,
            //    EndAge = 54,
            //    EmployeePercentage = (decimal)6.5,
            //    EmployerPercentage = (decimal)9.5,
            //    EmployeeRiskPercentage = (decimal)1.2,
            //    EmployerRiskPercentage = (decimal)2.0
            //});
            //pp.Percentages.Add(new PensionPlanPercentage
            //{
            //    StartAge = 55,
            //    EndAge = 65,
            //    EmployeePercentage = (decimal)7.15,
            //    EmployerPercentage = (decimal)11.35,
            //    EmployeeRiskPercentage = (decimal)1.2,
            //    EmployerRiskPercentage = (decimal)2.0
            //});

            //plans.Add(pp);

            //pp = new PensionPlan { Employer = "NXO", Name = "Medium", InsuredSalary = 100 };
            //pp.Percentages.Add(new PensionPlanPercentage
            //{
            //    StartAge = 18,
            //    EndAge = 24,
            //    EmployeePercentage = (decimal)0.0,
            //    EmployerPercentage = (decimal)0,
            //    EmployeeRiskPercentage = (decimal)1.3,
            //    EmployerRiskPercentage = (decimal)2.0
            //});
            //pp.Percentages.Add(new PensionPlanPercentage
            //{
            //    StartAge = 25,
            //    EndAge = 34,
            //    EmployeePercentage = (decimal)7,
            //    EmployerPercentage = (decimal)6.5,
            //    EmployeeRiskPercentage = (decimal)1.3,
            //    EmployerRiskPercentage = (decimal)2.0
            //});
            //pp.Percentages.Add(new PensionPlanPercentage
            //{
            //    StartAge = 35,
            //    EndAge = 44,
            //    EmployeePercentage = (decimal)7.5,
            //    EmployerPercentage = (decimal)8,
            //    EmployeeRiskPercentage = (decimal)1.3,
            //    EmployerRiskPercentage = (decimal)2.0
            //});
            //pp.Percentages.Add(new PensionPlanPercentage
            //{
            //    StartAge = 45,
            //    EndAge = 54,
            //    EmployeePercentage = (decimal)8.5,
            //    EmployerPercentage = (decimal)9.5,
            //    EmployeeRiskPercentage = (decimal)1.3,
            //    EmployerRiskPercentage = (decimal)2.0
            //});
            //pp.Percentages.Add(new PensionPlanPercentage
            //{
            //    StartAge = 55,
            //    EndAge = 65,
            //    EmployeePercentage = (decimal)9.65,
            //    EmployerPercentage = (decimal)11.35,
            //    EmployeeRiskPercentage = (decimal)1.3,
            //    EmployerRiskPercentage = (decimal)2.0
            //});
            //plans.Add(pp);

            //pp = new PensionPlan { Employer = "NXO", Name = "Maximum", InsuredSalary = 100 };
            //pp.Percentages.Add(new PensionPlanPercentage
            //{
            //    StartAge = 18,
            //    EndAge = 24,
            //    EmployeePercentage = (decimal)0.0,
            //    EmployerPercentage = (decimal)0,
            //    EmployeeRiskPercentage = (decimal)1.4,
            //    EmployerRiskPercentage = (decimal)2.0
            //});
            //pp.Percentages.Add(new PensionPlanPercentage
            //{
            //    StartAge = 25,
            //    EndAge = 34,
            //    EmployeePercentage = (decimal)7.5,
            //    EmployerPercentage = (decimal)6.5,
            //    EmployeeRiskPercentage = (decimal)1.4,
            //    EmployerRiskPercentage = (decimal)2.0
            //});
            //pp.Percentages.Add(new PensionPlanPercentage
            //{
            //    StartAge = 35,
            //    EndAge = 44,
            //    EmployeePercentage = (decimal)8,
            //    EmployerPercentage = (decimal)8,
            //    EmployeeRiskPercentage = (decimal)1.4,
            //    EmployerRiskPercentage = (decimal)2.0
            //});
            //pp.Percentages.Add(new PensionPlanPercentage
            //{
            //    StartAge = 45,
            //    EndAge = 54,
            //    EmployeePercentage = (decimal)9.5,
            //    EmployerPercentage = (decimal)9.5,
            //    EmployeeRiskPercentage = (decimal)1.4,
            //    EmployerRiskPercentage = (decimal)2.0
            //});
            //pp.Percentages.Add(new PensionPlanPercentage
            //{
            //    StartAge = 55,
            //    EndAge = 65,
            //    EmployeePercentage = (decimal)11.35,
            //    EmployerPercentage = (decimal)11.35,
            //    EmployeeRiskPercentage = (decimal)1.4,
            //    EmployerRiskPercentage = (decimal)2.0
            //});
            //plans.Add(pp);

            #endregion

            pp = new PensionPlan { Employer = "Sunrise", Name = "STANDARD", InsuredSalary = 90 };
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 18,
                EndAge = 24,
                EmployeePercentage = (decimal)0,
                EmployerPercentage = (decimal)0,
                EmployeeRiskPercentage = (decimal)2.1,
                EmployerRiskPercentage = (decimal)2.0
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 25,
                EndAge = 34,
                EmployeePercentage = (decimal)2.5,
                EmployerPercentage = (decimal)4.5,
                EmployeeRiskPercentage = (decimal)2.1,
                EmployerRiskPercentage = (decimal)2.0
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 35,
                EndAge = 44,
                EmployeePercentage = (decimal)3.5,
                EmployerPercentage = (decimal)6.5,
                EmployeeRiskPercentage = (decimal)2.1,
                EmployerRiskPercentage = (decimal)2.0
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 45,
                EndAge = 54,
                EmployeePercentage = (decimal)5,
                EmployerPercentage = (decimal)10,
                EmployeeRiskPercentage = (decimal)2.1,
                EmployerRiskPercentage = (decimal)2.0
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 55,
                EndAge = 65,
                EmployeePercentage = (decimal)6,
                EmployerPercentage = (decimal)12,
                EmployeeRiskPercentage = (decimal)2.1,
                EmployerRiskPercentage = (decimal)2.0
            });
            plans.Add(pp);

            pp = new PensionPlan { Employer = "Sunrise", Name = "PLUS", InsuredSalary = 90 };
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 18,
                EndAge = 24,
                EmployeePercentage = (decimal)0,
                EmployerPercentage = (decimal)0,
                EmployeeRiskPercentage = (decimal)2.1,
                EmployerRiskPercentage = (decimal)2.0
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 25,
                EndAge = 34,
                EmployeePercentage = (decimal)5.5,
                EmployerPercentage = (decimal)4.5,
                EmployeeRiskPercentage = (decimal)2.1,
                EmployerRiskPercentage = (decimal)2.0
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 35,
                EndAge = 44,
                EmployeePercentage = (decimal)6.5,
                EmployerPercentage = (decimal)6.5,
                EmployeeRiskPercentage = (decimal)2.1,
                EmployerRiskPercentage = (decimal)2.0
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 45,
                EndAge = 54,
                EmployeePercentage = (decimal)8,
                EmployerPercentage = (decimal)10,
                EmployeeRiskPercentage = (decimal)2.1,
                EmployerRiskPercentage = (decimal)2.0
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 55,
                EndAge = 65,
                EmployeePercentage = (decimal)9,
                EmployerPercentage = (decimal)12,
                EmployeeRiskPercentage = (decimal)2.1,
                EmployerRiskPercentage = (decimal)2.0
            });
            plans.Add(pp);

            pp = new PensionPlan
            {
                Employer = "Sunrise UPC",
                Name = "Core Standard",
                InsuredSalary = 80,
                SupportsTopUpPlan = true,
                HighEarnerSpecialContribution = 2500
            };
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 18,
                EndAge = 24,
                EmployeePercentage = (decimal)0,
                EmployerPercentage = (decimal)0,
                EmployeeRiskPercentage = (decimal)1.4,
                EmployerRiskPercentage = (decimal)2.1,
                TopUpPlanEmployerPercentage = (decimal)0
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 25,
                EndAge = 34,
                EmployeePercentage = (decimal)5.0,
                EmployerPercentage = (decimal)5.5,
                EmployeeRiskPercentage = (decimal)1.4,
                EmployerRiskPercentage = (decimal)2.1,
                TopUpPlanEmployerPercentage = (decimal)8
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 35,
                EndAge = 44,
                EmployeePercentage = (decimal)6.0,
                EmployerPercentage = (decimal)7.5,
                EmployeeRiskPercentage = (decimal)1.4,
                EmployerRiskPercentage = (decimal)2.1,
                TopUpPlanEmployerPercentage = (decimal)11
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 45,
                EndAge = 54,
                EmployeePercentage = (decimal)7.5,
                EmployerPercentage = (decimal)11,
                EmployeeRiskPercentage = (decimal)1.4,
                EmployerRiskPercentage = (decimal)2.1,
                TopUpPlanEmployerPercentage = (decimal)14
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 55,
                EndAge = 65,
                EmployeePercentage = (decimal)9,
                EmployerPercentage = (decimal)15,
                EmployeeRiskPercentage = (decimal)1.4,
                EmployerRiskPercentage = (decimal)2.1,
                TopUpPlanEmployerPercentage = (decimal)17
            });
            plans.Add(pp);

            pp = new PensionPlan
            {
                Employer = "Sunrise UPC",
                Name = "Core Mini",
                InsuredSalary = 80,
                SupportsTopUpPlan = true,
                HighEarnerSpecialContribution = 2500
            };
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 18,
                EndAge = 24,
                EmployeePercentage = (decimal)0,
                EmployerPercentage = (decimal)0,
                EmployeeRiskPercentage = (decimal)1.4,
                EmployerRiskPercentage = (decimal)2.1,
                TopUpPlanEmployerPercentage = (decimal)0
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 25,
                EndAge = 34,
                EmployeePercentage = (decimal)3.0,
                EmployerPercentage = (decimal)5.5,
                EmployeeRiskPercentage = (decimal)1.4,
                EmployerRiskPercentage = (decimal)2.1,
                TopUpPlanEmployerPercentage = (decimal)8
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 35,
                EndAge = 44,
                EmployeePercentage = (decimal)4.0,
                EmployerPercentage = (decimal)7.5,
                EmployeeRiskPercentage = (decimal)1.4,
                EmployerRiskPercentage = (decimal)2.1,
                TopUpPlanEmployerPercentage = (decimal)11
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 45,
                EndAge = 54,
                EmployeePercentage = (decimal)5.5,
                EmployerPercentage = (decimal)11,
                EmployeeRiskPercentage = (decimal)1.4,
                EmployerRiskPercentage = (decimal)2.1,
                TopUpPlanEmployerPercentage = (decimal)14
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 55,
                EndAge = 65,
                EmployeePercentage = (decimal)7,
                EmployerPercentage = (decimal)15,
                EmployeeRiskPercentage = (decimal)1.4,
                EmployerRiskPercentage = (decimal)2.1,
                TopUpPlanEmployerPercentage = (decimal)17
            });
            plans.Add(pp);

            pp = new PensionPlan
            {
                Employer = "Sunrise UPC",
                Name = "Core Maxi",
                InsuredSalary = 80,
                SupportsTopUpPlan = true,
                HighEarnerSpecialContribution = 2500
            };
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 18,
                EndAge = 24,
                EmployeePercentage = (decimal)4.5,
                EmployerPercentage = (decimal)0,
                EmployeeRiskPercentage = (decimal)1.4,
                EmployerRiskPercentage = (decimal)2.1,
                TopUpPlanEmployerPercentage = 0
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 25,
                EndAge = 34,
                EmployeePercentage = (decimal)7,
                EmployerPercentage = (decimal)5.5,
                EmployeeRiskPercentage = (decimal)1.4,
                EmployerRiskPercentage = (decimal)2.1,
                TopUpPlanEmployerPercentage = (decimal)8.0
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 35,
                EndAge = 44,
                EmployeePercentage = (decimal)8,
                EmployerPercentage = (decimal)7.5,
                EmployeeRiskPercentage = (decimal)1.4,
                EmployerRiskPercentage = (decimal)2.1,
                TopUpPlanEmployerPercentage = (decimal)11
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 45,
                EndAge = 54,
                EmployeePercentage = (decimal)9.5,
                EmployerPercentage = (decimal)11,
                EmployeeRiskPercentage = (decimal)1.4,
                EmployerRiskPercentage = (decimal)2.1,
                TopUpPlanEmployerPercentage = (decimal)14
            });
            pp.Percentages.Add(new PensionPlanPercentage
            {
                StartAge = 55,
                EndAge = 65,
                EmployeePercentage = (decimal)11.5,
                EmployerPercentage = (decimal)15,
                EmployeeRiskPercentage = (decimal)1.4,
                EmployerRiskPercentage = (decimal)2.1,
                TopUpPlanEmployerPercentage = (decimal)17
            });
            plans.Add(pp);

            return plans;
        }

        #endregion
    }
}
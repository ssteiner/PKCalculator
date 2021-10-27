using System;

namespace PKCalculator
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CalculateButton_Click(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";
            if (!int.TryParse(Age.Text, out int age))
            {
                ErrorLabel.Text = "Not a valid age";
                return;
            }
            if (age < 18 || age > 65)
            {
                ErrorLabel.Text = "Not a valid age";
                return;
            }
            if (!int.TryParse(Salary.Text, out int salary))
            {
                ErrorLabel.Text = "Not a valid salary";
                return;
            }
            if (salary < 20520)
            {
                ErrorLabel.Text = "You don't have to pay for pension with this salary";
                return;
            }
            var calc = new Calculator();
            var pps = new PensionPlanSource();
            PensionPlan planA = pps.GetPensionPlan(PensionPlanA.SelectedValue);
            PensionPlan planB = pps.GetPensionPlan(PensionPlanB.SelectedValue);

            CalculationResult resA = calc.CalculatePension(age, salary, planA);
            CalculationResult resB = calc.CalculatePension(age, salary, planB);
            
        }

        protected void PensionPlanA_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
        }
    }
}
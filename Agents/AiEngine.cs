using EaproERP.Models;

namespace EaproERP.Agents
{
    public static class AiEngine
    {
        // Agent dedicated to predictive inventory analysis
        public static void RunInventoryAgent(Product product)
        {
            // Simulated predictive logic: Different products have different daily burn (sales) rates
            int dailyBurnRate = product.Category switch
            {
                "Inverter" => 5,
                "Battery" => 8,
                "Solar Panel" => 12,
                _ => 3
            };

            int daysLeft = product.StockLevel / dailyBurnRate;

            if (daysLeft <= 5) 
                product.AIStockPrediction = $"⚠️ Critical: Stock out predicted in {daysLeft} days.";
            else if (daysLeft <= 15) 
                product.AIStockPrediction = $"📉 Warning: Reorder soon. {daysLeft} days of supply remaining.";
            else 
                product.AIStockPrediction = $"✅ Stable: Supply sufficient for {daysLeft} days.";
        }

        // NEW: Agent dedicated to Payroll & HR analysis
        public static void RunPayrollAgent(Employee emp)
        {
            // Simulated industry standard base salaries for solar manufacturing
            decimal industryStandard = emp.Department switch
            {
                "R&D" => 80000m,
                "Sales" => 50000m,
                "Manufacturing" => 40000m,
                "Installation" => 45000m,
                _ => 45000m
            };

            // 🛑 FIXED: Safely handling the nullable Bonus with ?? 0m and forcing decimal math 🛑
            decimal bonusPercentage = emp.BaseSalary > 0 ? ((emp.Bonus ?? 0m) / emp.BaseSalary) * 100m : 0m;

            if (emp.BaseSalary < (industryStandard * 0.9m))
            {
                emp.AIPerformanceInsight = $"⚠️ Retention Risk: Base salary is {((industryStandard - emp.BaseSalary)/industryStandard):P0} below the solar industry average. Consider a raise.";
            }
            else if (bonusPercentage > 20m)
            {
                emp.AIPerformanceInsight = $"⭐ Top Performer: High bonus ratio detected. Excellent ROI for the {emp.Department} department.";
            }
            else
            {
                emp.AIPerformanceInsight = $"✅ Compensated fairly according to EAPRO standards.";
            }
        }

        public static string RunDealerAgent(Dealer dealer)
        {
            if (dealer.AnnualTurnover > 10000000m)
                return "💎 Elite Partner: Eligible for exclusive EAPRO marketing support.";
            if (dealer.IsServiceCenter)
                return "🔧 Technical Hub: Verified Service Center for After-Sales Support.";
            return "📈 Growth Phase: Target for increased On-Grid inverter inventory.";
        }
    }
}
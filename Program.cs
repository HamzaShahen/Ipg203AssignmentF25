using Ipg203AssignmentF25.Models;
using Ipg203AssignmentF25.Services;

namespace Ipg203AssignmentF25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Refrigerator r1 = new Refrigerator("44FF",5);
            AirConditioner A1 = new AirConditioner("44gg",4);
            WashingMachine W1 = new WashingMachine("ffgg", 7, WashingMachineType.Automatic);
            r1.StartInspection();
            A1.StartInspection();
            W1.StartInspection();
            r1.SetRepairComplexity(RepairComplexity.Simple);
            A1.SetRepairComplexity(RepairComplexity.Simple);
            W1.SetRepairComplexity(RepairComplexity.Simple);
            r1.StartRepair();
            r1.CompleteRepair();
            ApplianceManagement management = new ApplianceManagement();
            management.AddAppliance(r1);
            management.AddAppliance(A1);
            management.AddAppliance(W1);
            management.DisplayRepairCostAppliances();
            management.DisplayAppliancesStatus();
        }
    }
}

using Ipg203AssignmentF25.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ipg203AssignmentF25.Services
{
    /// <summary>
    /// فئة رئيسية لإدارة الأجهزة تحتوي على قائمة من الكائنات المشنقة
    /// </summary>
    public class ApplianceManagement
    {
        /// <summary>
        /// قائمة تحتوي على الكائنات المشتقة(الأجهزة المنزلية
        /// </summary>
        private readonly List<HomeAppliance> _appliances = new List<HomeAppliance>();
        /// <summary>
        /// دالة لإضافة الكائنات المشتقة الى القائمة
        /// </summary>
        public void AddAppliance(HomeAppliance appliance)
        {
            //استثاء اذا تم ادخال قيمة null
            if(appliance == null) throw new ArgumentNullException(nameof(appliance));
            //منع تكرار الارقام التسلسلية للأجهزة عند اضافتها للقائمة
            foreach (HomeAppliance existingAppliance in _appliances)
            {
                if(existingAppliance.SerialNumber == appliance.SerialNumber)
                {
                    throw new InvalidOperationException("هذا الرقم التسلسلي مسجل لدى جهاز مسبقاً");
                }
            }
            _appliances.Add(appliance);
        }
        /// <summary>
        /// دالة لعرض تكلفة اصلاح كل جهاز
        /// </summary>
        public void DisplayRepairCostAppliances()
        {
            foreach (HomeAppliance appliance in _appliances)
            {
                Console.WriteLine("\n**The Cost to Repair the {0} is |{1} $|**\n",appliance.HomeApplianceName,appliance.CalculateRepairCost());
            }
        }
        /// <summary>
        /// دالة لعرض حالة كل جهاز
        /// </summary>
        public void DisplayAppliancesStatus()
        {
            Console.WriteLine("\n\tHOME APPLIANCE\t\t||\tSTATUS\n\t==============\t\t||\t==============");
            foreach (HomeAppliance appliance in _appliances)
            {
                Console.WriteLine("\t{0}\t=>\t{1}",appliance.HomeApplianceName,appliance.Status);
            }
        }
    }
}

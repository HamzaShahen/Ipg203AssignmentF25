using System;
using System.Collections.Generic;
using System.Text;

namespace Ipg203AssignmentF25.Models
{
    /// <summary>
    /// فئة تمثل جهاز المكيف وترث الخصائص والسلوكيات المشتركة من الفئة الأساسية المجردة
    /// </summary>
    public class AirConditioner : HomeAppliance
    {
        /// <summary>
        /// خاصية تمثل سعة تبريد المكيف مقاسة بالطن وغير قابلة للتعديل من خارج هذه الفئة
        /// </summary>
        public double CoolingCapacityInTon {  get;}
        /// <summary>
        /// باني يهيء كائن جديد من المكيف ويحدد رقمه التسلسلي واسمه وسعة تبريده
        /// </summary>
        ///
        public AirConditioner(string serialNumber, double coolingCapacityInTon) : base(serialNumber, $"Air conditioner_{serialNumber}")
        {
            //استثناء اذا كانت سعة التبريد غير صالحة
            if (coolingCapacityInTon < 0.5 || coolingCapacityInTon > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(coolingCapacityInTon), "يجب أن تكون سعة تبريد المكيف أكبر من 0،5 واقل من او تساوي 5");

            }
            CoolingCapacityInTon = coolingCapacityInTon;
        }
        public override double CalculateRepairCost()
        {
            switch (Complexity)
            {
                case RepairComplexity.Undefined:
                    throw new InvalidOperationException("لا يمكن حساب تكلفة الاصلاح قبل تحديد درجة تعقيد الاصلاح");

                case RepairComplexity.Simple:
                    return CoolingCapacityInTon * 10;

                case RepairComplexity.Medium:
                    return CoolingCapacityInTon * 12;

                case RepairComplexity.Complex:
                    return CoolingCapacityInTon * 14;

                default:
                    throw new ArgumentOutOfRangeException(nameof(Complexity),"درجة تعقيد الاصلاح غير صالحة");
            }
        }
    }
}

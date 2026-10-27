using System;
using System.Collections.Generic;
using System.Text;

namespace Ipg203AssignmentF25.Models
{
    /// <summary>
    /// فئة تمثل جهاز الغسالة وترث الخصائص والسلوكيات المشتركة من الفئة الأساسية المجردة
    /// </summary>
    public class WashingMachine : HomeAppliance
    {
        /// <summary>
        /// خاصية تمثل سعة حوض الغسالة مقاسة بالكيلوغرام
        /// </summary>
        public double DrumCapacityInKg { get;}
        /// <summary>
        /// خاصية تمثل نوع الغسالة
        /// </summary>
        public WashingMachineType Type { get;}
        /// <summary>
        /// باني يهيء كائن جديد من الغسالة ويحدد رقمها التسلسلي واسمها وسعة حوضها ونوعها
        /// </summary>
        public WashingMachine(string serialNumber, double drumCapacityInKg , WashingMachineType type): base(serialNumber, $"Washing machine_{serialNumber}")
        {
            //استثناء اذا كانت سعة الحوض قيمة غير صالحة
            if(drumCapacityInKg <= 0 ||  drumCapacityInKg > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(drumCapacityInKg), "يجب ان تكون سعة حوض الغسالة اكبر من 0 واقل من او تساوي 12كغ");
            }
            DrumCapacityInKg = drumCapacityInKg;
            Type = type;
        }
        /// <summary>
        /// تحسب تكلفة اصلاح الغسالة تبعاً لسعة حوضها وتعقيد اصلاحها
        /// </summary>
        public override double CalculateRepairCost()
        {
            switch (Complexity)
            {
                case RepairComplexity.Undefined:
                    throw new InvalidOperationException("لا يمكن حساب تكلفة الاصلاح قبل تحديد درجة تعقيد الاصلاح");

                case RepairComplexity.Simple:
                    return DrumCapacityInKg * 10;

                case RepairComplexity.Medium:
                    return DrumCapacityInKg * 12;

                case RepairComplexity.Complex:
                    return DrumCapacityInKg * 14;

                default:
                    throw new ArgumentOutOfRangeException(nameof(Complexity),"درجة نعقيد الاصلاح غير صالحة");
            }
        }
    }
}
 
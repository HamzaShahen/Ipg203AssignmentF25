using System;
using System.Collections.Generic;
using System.Text;

namespace Ipg203AssignmentF25.Models
{
    /// <summary>
    /// فئة تمثل جهاز البراد وترث الخصائص والسلوكيات المشتركة من الفئة الاساسية HomeAppliance
    /// </summary>
    public class Refrigerator : HomeAppliance
    {
        /// <summary>
        ///  خاصية تمثل ارتفاع البراد مقدرا بالقدم وهي للقراءة فقط بعد انشاء الكائن
        /// </summary>
        public double HeightInFeet { get;}
        /// <summary>
        /// باني ينشئ كائنا جديدا من البراد ويحدد رقمه التسلسلي واسمه وارتفاعه
        /// </summary>
        public Refrigerator(string serialNumber, double heightInFeet) : base(serialNumber, $"refrigerato_{serialNumber}")
        {
          //رمي استثناء اذا كان ارتفاع البراد غير صالح(اقل من 1،5 او أكبر من 7 قدم
          if(heightInFeet <= 1.5 || heightInFeet >= 7)
            {
                throw new ArgumentOutOfRangeException(nameof(heightInFeet), "يجب ان يكون ارتفاع البراد اكبر او يساوي 1،5 واقل من او يساوي 7 قدم");
            }
            HeightInFeet = heightInFeet;
        }
        /// <summary>
        ///تحسب تكلفة اصلاح البراد تبعاً لارتفاعه وتعقيد اصلاحه
        /// </summary>
        public override double CalculateRepairCost()
        {
            switch (Complexity)
            {
                case RepairComplexity.Undefined:
                    throw new InvalidOperationException("لا يمكن حساب تكلفة الاصلاح قبل تحديد درجة تعقيد الاصلاح");

                case RepairComplexity.Simple:
                    return HeightInFeet * 10;

                case RepairComplexity.Medium:
                    return HeightInFeet * 12;

                case RepairComplexity.Complex:
                    return HeightInFeet * 14;

                default:
                    throw new ArgumentOutOfRangeException(nameof(Complexity), "درجة تعقيد الاصلاح غير صالحة");
            }
        }
    }
}

using Ipg203AssignmentF25.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ipg203AssignmentF25.Models
{
    /// <summary>
    ///فئة مجردة تطبق الواجهة IRepairable و تجمع الخصائص و السلوكيات المشتركة بين الأجهزة المنزلية
    /// </summary>
    public abstract class HomeAppliance : IRepairable
    {
        //الرقم التسلسلي للجهاز و يمكن قرائته من خارج الفئة دون تعديله بشكل مباشر
        public string SerialNumber { get; }
        public string HomeApplianceName { get; }
        //الحالة الحالية للجهاز و يمكن تغييرها حصرا من داخل هذه الفئة 
        public RepairStatus Status { get; private set; }
        //درجة تعقيد الاصلاح
        public RepairComplexity Complexity { get; private set; }
        //باني يهيء الجهاز المنزلي عند انشائه باستخدام رقمه التسلسلي واسمه ويحدد حالته الأولية ودرجة تعقيد اصلاحه
        protected HomeAppliance(string serialNumber, string homeApplianceName) {
            if (string.IsNullOrEmpty(serialNumber))
            {
                throw new ArgumentNullException(nameof(serialNumber),"الرقم التسلسلي لا يمكن ان يكون فارغا");
            }
            SerialNumber = serialNumber;
            HomeApplianceName = homeApplianceName;
            Status = RepairStatus.Received;
            Complexity = RepairComplexity.Undefined;
        }
        ///<summary>
        ///يبدأ فحص الجهاز وتحدّث حالته 
        ///</summary>
       public void StartInspection()
        {
            if(Status != RepairStatus.Received)
            {
                throw new InvalidOperationException("لا يمكن بدء الفحص الا للأجهزة المستلمة");
            }
            Status = RepairStatus.UnderInspection;
            Console.WriteLine($"\n\tStarting {HomeApplianceName} Inspection");
        }
        public void SetRepairComplexity(RepairComplexity complexity)
        {
            if(Status != RepairStatus.UnderInspection)
            {
                throw new InvalidOperationException("لا يمكن تحديد درجة التعقيد الا اثناء عملية الفحص");
            }
           
            Complexity = complexity;
        }
        /// <summary>
        /// يبدأ اصلاح الجهاز وتحدّث حالته
        /// </summary>
       public void StartRepair()
        {
            if(Status != RepairStatus.UnderInspection)
            {
                throw new InvalidOperationException("لا يمكن بدء اصلاح الجهاز الا بعد فحصه");
            }
            if(Complexity == RepairComplexity.Undefined)
            {
                throw new InvalidOperationException("يجب تحديد درجة تعقيد الاصلاح قبل البدء بالاصلاح");
            }
            Status = RepairStatus.UnderRepair;
            Console.WriteLine($"\n\tStarting {HomeApplianceName} repairs");
        }
        /// <summary>
        /// اكتمال اصلاح الجهاز وتحديث حالته
        /// </summary>
        public void CompleteRepair()
        {
            if(Status != RepairStatus.UnderRepair)
            {
                throw new InvalidOperationException("لا يمكن اكمال اصلاح الجهاز قبل البدء به");
            }
            Status = RepairStatus.Completed;
            Console.WriteLine($"\n\tThe {HomeApplianceName} repair is completed");
        }
        /// <summary>
        ///دالة مجردة لحساب تكلفة اصلاح كل جهاز تبعاً لخصائصه
        /// </summary>
        public abstract double CalculateRepairCost();
    }
}

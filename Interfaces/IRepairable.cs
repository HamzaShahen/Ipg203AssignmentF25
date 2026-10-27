namespace Ipg203AssignmentF25.Interfaces
{
    /// <summary>
    ///واجهة تحدد العمليات الأساسية المتعلقة بفحص الأجهزة واصلاحها
    /// </summary>
    public interface IRepairable
    {
        //تمثل العملية المسؤولة عن بدء فحص الجهاز
        void StartInspection();
        //تمثل العملية المسؤولة عن بدء اصلاح الجهاز
        void StartRepair();
        //تعلن اكتمال اصلاح الجهاز
        void CompleteRepair();
    }
}

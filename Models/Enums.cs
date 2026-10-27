using System;
using System.Collections.Generic;
using System.Text;

namespace Ipg203AssignmentF25.Models
{
    /// <summary>
    ///يحدد الحالات المعروفة التي يمكن ان يمر بها الجهاز خلال عملية الصيانة
    /// </summary>
    public enum RepairStatus
    {
        Received,
        UnderInspection,
        UnderRepair,
        Completed
    }
    /// <summary>
    /// يحدد انواع الغسالات التي تتوفر امكانية اصلاحها في النظام
    /// </summary>
    public enum WashingMachineType
    {
        Regular,
        SemiAutomatic,
        Automatic
    }
    /// <summary>
    /// يحدد الحالات لدرجة تعقيد اصلاح الجهاز
    /// </summary>
    public enum RepairComplexity
    {
        Undefined,
        Simple,
        Medium,
        Complex
    }
}

using System;
using System.Collections.Generic;

namespace Score.Models
{
    public partial class ClClinicsDoctor
    {
        public int ClinicDoctorId { get; set; }
        public int ClinicId { get; set; }
        public int EmployeeId { get; set; }
        public byte PrecentageHospial { get; set; }
        public byte PercentageDoctor { get; set; }
        /// <summary>
        /// بياخد اجر عيادات الشركات متاخر فى الشهر اللى بعده
        /// 1- نعم بياخدها متاخر
        /// 0- لا بياخجها فى نفس الشهر
        /// </summary>
        public bool? DelayFeesComp { get; set; }
        /// <summary>
        /// فى حالة الاطباء لهم حد ادنى لليوم فى حالة عدم تحقيق العياده فى هذا اليوم
        /// </summary>
        public bool IsUseMiniCharge { get; set; }
        /// <summary>
        /// اقل قيمة للعياده بعدها ياخد الحد الادنى  للاجر الخاص به
        /// </summary>
        public float? MiniTargetClinicValue { get; set; }
        /// <summary>
        /// قسمة الاجر المستحق فى حالة عدم تحقيق تارجت العياده
        /// </summary>
        public float? ValueDoctor { get; set; }

        public virtual ClClinic Clinic { get; set; } = null!;
        public virtual HrEmployee Employee { get; set; } = null!;
    }
}

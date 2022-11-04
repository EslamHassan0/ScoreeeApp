using System;
using System.Collections.Generic;

namespace Score.Models
{
    /// <summary>
    /// العيادات
    /// </summary>
    public partial class ClClinic
    {
        public ClClinic()
        {
            ClClinicsDoctors = new HashSet<ClClinicsDoctor>();
        }

        public int ClinicId { get; set; }
        /// <summary>
        /// اسم العيادة
        /// </summary>
        public string ClinicName { get; set; } = null!;
        /// <summary>
        /// مدة الكشف بالدقيقة
        /// </summary>
        public byte DiagnosisPeriod { get; set; }
        public string? Notes { get; set; }

        public virtual ICollection<ClClinicsDoctor> ClClinicsDoctors { get; set; }
    }
}

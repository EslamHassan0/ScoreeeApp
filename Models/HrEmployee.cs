using System;
using System.Collections.Generic;

namespace Score.Models
{
    /// <summary>
    /// جدول بيانات الموظفين - بيانات أساسية
    /// </summary>
    public partial class HrEmployee
    {
        public HrEmployee()
        {
            ClClinicsDoctors = new HashSet<ClClinicsDoctor>();
            Users = new HashSet<User>();
        }

        /// <summary>
        /// رقم مسلسل للجدول
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// كود الموظف - لابد من الإدخال - لا يكرر
        /// </summary>
        public string EmployeeCode { get; set; } = null!;
        /// <summary>
        /// اسم الموظف - لابد من الإدخال - لا يكرر
        /// </summary>
        public string EmployeeName { get; set; } = null!;
        /// <summary>
        /// صورة الموظف
        /// </summary>
        public string? EmployeePhoto { get; set; }
        /// <summary>
        /// العنوان
        /// </summary>
        public string? EmployeeAddress { get; set; }
        /// <summary>
        /// التليفونات
        /// </summary>
        public string? EmployeeTelephones { get; set; }
        /// <summary>
        /// نوع الجنس : 1 - ذكر   &amp;   2 - أنثى
        /// </summary>
        public byte? EmployeeSexType { get; set; }
        /// <summary>
        /// تاريخ الميلاد
        /// </summary>
        public DateTime? EmployeeBirthDate { get; set; }
        /// <summary>
        /// رقم تحقيق الشخصية
        /// </summary>
        public string? IdentityCardNo { get; set; }
        /// <summary>
        /// رقم مسلسل نوع تحقيق الشخصية
        /// </summary>
        public int? IdentityCardTypeId { get; set; }
        /// <summary>
        /// تاريخ صدور تحقيق الشخصية
        /// </summary>
        public DateTime? IdentityCardDate { get; set; }
        /// <summary>
        /// مكان صدور تحقيق الشخصية
        /// </summary>
        public string? IdentityCardPlace { get; set; }
        /// <summary>
        /// رقم مسلسل نوع الحالة الإجتماعية
        /// </summary>
        public int? SocialStatusTypeId { get; set; }
        public int? ChildrenNo { get; set; }
        /// <summary>
        /// الموقف من الخدمة فى الشركة : 1 - داخل الخدمة   &amp;   2 - خارج الخدمة
        /// </summary>
        public byte? DutyPositionType { get; set; }
        public DateTime? OutDutyDate { get; set; }
        public string? OutDutyReason { get; set; }
        /// <summary>
        /// تاريخ التعيين
        /// </summary>
        public DateTime? AppointmentDate { get; set; }
        public byte? ContractType { get; set; }
        public string? ContractNo { get; set; }
        /// <summary>
        /// رقم مسلسل القسم
        /// </summary>
        public int? DepId { get; set; }
        /// <summary>
        /// رقم مسلسل الفئة
        /// </summary>
        public int? CategoryId { get; set; }
        /// <summary>
        /// قيد مكتب العمل
        /// </summary>
        public string? WorkOfficeRegistration { get; set; }
        public DateTime? WorkOfficeRegDate { get; set; }
        public string? SocialSecurityNo { get; set; }
        /// <summary>
        /// نوع عمل الموظف  
        /// 1- FullTime 
        /// 2- PartTime
        /// </summary>
        public byte? EmployeeHireType { get; set; }
        /// <summary>
        /// ملاحظات
        /// </summary>
        public string? EmployeeNotes { get; set; }
        public int? BankId { get; set; }
        public string? BankAccount { get; set; }
        public int? ProjectId { get; set; }
        public int? ReligionId { get; set; }
        public int? NationalityId { get; set; }
        public string? ResidenceNo { get; set; }
        public string? ResidenceIssuePlace { get; set; }
        public DateTime? ResidenceStartDate { get; set; }
        public DateTime? ResidenceEndDate { get; set; }
        public string? PassportNo { get; set; }
        public string? PassportIssuePlace { get; set; }
        public DateTime? PassportStartDate { get; set; }
        public DateTime? PassportEndDate { get; set; }
        public string? DriveLicenseNo { get; set; }
        public string? DriveLicenseIssuePlace { get; set; }
        public DateTime? DriveLicenseStartDate { get; set; }
        public DateTime? DriveLicenseEndDate { get; set; }
        /// <summary>
        /// نوع الاجر في حالة الاطباء
        /// ===============
        /// 1 اجر يومي ثابت
        /// 2 اجر شهري ثابت
        /// 3 نسبة من الايراد الشهري
        /// 4 قيمة ثابتة للحالة
        /// 5 متطوع مجاني
        /// </summary>
        public byte? DocSalaryType { get; set; }
        /// <summary>
        /// قيمة اجر الطبيب حسب نوعه
        /// =====================
        /// قيمة يوم الاجر اليومي
        /// قيمة شهر الاجر الشهري
        /// نسبة الايراد
        /// قيمة الحالة
        /// </summary>
        public float? DocSalaryValue { get; set; }
        public byte? Tax { get; set; }

        public virtual ICollection<ClClinicsDoctor> ClClinicsDoctors { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

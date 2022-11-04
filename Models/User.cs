using System;
using System.Collections.Generic;

namespace Score.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        /// <summary>
        /// الاسم بالكامل
        /// </summary>
        public string? UserFullName { get; set; }
        /// <summary>
        /// اسم الدخول
        /// </summary>
        public string UserName { get; set; } = null!;
        /// <summary>
        /// كلمة السر
        /// </summary>
        public string Password { get; set; } = null!;
        /// <summary>
        /// مجموعة الصلاحيات
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// السماح بالدخول
        /// </summary>
        public bool UserAllow { get; set; }
        /// <summary>
        /// تم حذفه
        /// و هذا لمنع حذف اي مستخدم لما له من تأثير على طابع المستخدم
        /// </summary>
        public bool Deleted { get; set; }
        /// <summary>
        /// ملاحظات
        /// </summary>
        public string? Notes { get; set; }
        public int? EmployeeId { get; set; }
        public bool? AllowDiscount { get; set; }
        public byte? MaxDiscount { get; set; }

        public virtual HrEmployee? Employee { get; set; }
    }
}

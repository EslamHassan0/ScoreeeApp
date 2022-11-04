using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Score.Models
{
    public partial class newScoreContext : DbContext
    {
        public newScoreContext()
        {
        }

        public newScoreContext(DbContextOptions<newScoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClClinic> ClClinics { get; set; } = null!;
        public virtual DbSet<ClClinicsDoctor> ClClinicsDoctors { get; set; } = null!;
        public virtual DbSet<HrEmployee> HrEmployees { get; set; } = null!;
        public virtual DbSet<Scoree> Scores { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TF0HS6G;Database=newScore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClClinic>(entity =>
            {
                entity.HasKey(e => e.ClinicId);

                entity.ToTable("clClinics");

                entity.HasComment("العيادات");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.ClinicName)
                    .HasMaxLength(250)
                    .HasComment("اسم العيادة");

                entity.Property(e => e.DiagnosisPeriod).HasComment("مدة الكشف بالدقيقة");
            });

            modelBuilder.Entity<ClClinicsDoctor>(entity =>
            {
                entity.HasKey(e => e.ClinicDoctorId);

                entity.ToTable("clClinicsDoctor");

                entity.Property(e => e.ClinicDoctorId).HasColumnName("ClinicDoctorID");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.DelayFeesComp)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("بياخد اجر عيادات الشركات متاخر فى الشهر اللى بعده\r\n1- نعم بياخدها متاخر\r\n0- لا بياخجها فى نفس الشهر");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.IsUseMiniCharge)
                    .HasColumnName("IS_UseMiniCharge")
                    .HasComment("فى حالة الاطباء لهم حد ادنى لليوم فى حالة عدم تحقيق العياده فى هذا اليوم");

                entity.Property(e => e.MiniTargetClinicValue).HasComment("اقل قيمة للعياده بعدها ياخد الحد الادنى  للاجر الخاص به");

                entity.Property(e => e.PrecentageHospial).HasColumnName("precentageHospial");

                entity.Property(e => e.ValueDoctor).HasComment("قسمة الاجر المستحق فى حالة عدم تحقيق تارجت العياده");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.ClClinicsDoctors)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_clClinicsDoctor_clClinics");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ClClinicsDoctors)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_clClinicsDoctor_hrEmployees");
            });

            modelBuilder.Entity<HrEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("hrEmployees");

                entity.HasComment("جدول بيانات الموظفين - بيانات أساسية");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasComment("رقم مسلسل للجدول");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("datetime")
                    .HasComment("تاريخ التعيين");

                entity.Property(e => e.BankAccount).HasMaxLength(200);

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasComment("رقم مسلسل الفئة");

                entity.Property(e => e.ContractNo).HasMaxLength(200);

                entity.Property(e => e.ContractType).HasDefaultValueSql("((1))");

                entity.Property(e => e.DepId)
                    .HasColumnName("DepID")
                    .HasComment("رقم مسلسل القسم");

                entity.Property(e => e.DocSalaryType).HasComment("نوع الاجر في حالة الاطباء\r\n===============\r\n1 اجر يومي ثابت\r\n2 اجر شهري ثابت\r\n3 نسبة من الايراد الشهري\r\n4 قيمة ثابتة للحالة\r\n5 متطوع مجاني");

                entity.Property(e => e.DocSalaryValue).HasComment("قيمة اجر الطبيب حسب نوعه\r\n=====================\r\nقيمة يوم الاجر اليومي\r\nقيمة شهر الاجر الشهري\r\nنسبة الايراد\r\nقيمة الحالة");

                entity.Property(e => e.DriveLicenseEndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DriveLicenseIssuePlace).HasMaxLength(50);

                entity.Property(e => e.DriveLicenseNo).HasMaxLength(50);

                entity.Property(e => e.DriveLicenseStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DutyPositionType)
                    .HasDefaultValueSql("((1))")
                    .HasComment("الموقف من الخدمة فى الشركة : 1 - داخل الخدمة   &   2 - خارج الخدمة");

                entity.Property(e => e.EmployeeAddress)
                    .HasMaxLength(250)
                    .HasComment("العنوان");

                entity.Property(e => e.EmployeeBirthDate)
                    .HasColumnType("datetime")
                    .HasComment("تاريخ الميلاد");

                entity.Property(e => e.EmployeeCode)
                    .HasMaxLength(50)
                    .HasComment("كود الموظف - لابد من الإدخال - لا يكرر");

                entity.Property(e => e.EmployeeHireType)
                    .HasDefaultValueSql("((1))")
                    .HasComment("نوع عمل الموظف  \r\n1- FullTime \r\n2- PartTime");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(100)
                    .HasComment("اسم الموظف - لابد من الإدخال - لا يكرر");

                entity.Property(e => e.EmployeeNotes)
                    .HasMaxLength(200)
                    .HasComment("ملاحظات");

                entity.Property(e => e.EmployeePhoto)
                    .HasMaxLength(100)
                    .HasComment("صورة الموظف");

                entity.Property(e => e.EmployeeSexType)
                    .HasDefaultValueSql("((1))")
                    .HasComment("نوع الجنس : 1 - ذكر   &   2 - أنثى");

                entity.Property(e => e.EmployeeTelephones)
                    .HasMaxLength(150)
                    .HasComment("التليفونات");

                entity.Property(e => e.IdentityCardDate)
                    .HasColumnType("datetime")
                    .HasComment("تاريخ صدور تحقيق الشخصية");

                entity.Property(e => e.IdentityCardNo)
                    .HasMaxLength(50)
                    .HasComment("رقم تحقيق الشخصية");

                entity.Property(e => e.IdentityCardPlace)
                    .HasMaxLength(250)
                    .HasComment("مكان صدور تحقيق الشخصية");

                entity.Property(e => e.IdentityCardTypeId)
                    .HasColumnName("IdentityCardTypeID")
                    .HasComment("رقم مسلسل نوع تحقيق الشخصية");

                entity.Property(e => e.NationalityId).HasColumnName("NationalityID");

                entity.Property(e => e.OutDutyDate).HasColumnType("smalldatetime");

                entity.Property(e => e.OutDutyReason).HasMaxLength(200);

                entity.Property(e => e.PassportEndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PassportIssuePlace).HasMaxLength(50);

                entity.Property(e => e.PassportNo).HasMaxLength(50);

                entity.Property(e => e.PassportStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ReligionId).HasColumnName("ReligionID");

                entity.Property(e => e.ResidenceEndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ResidenceIssuePlace).HasMaxLength(50);

                entity.Property(e => e.ResidenceNo).HasMaxLength(50);

                entity.Property(e => e.ResidenceStartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.SocialSecurityNo).HasMaxLength(50);

                entity.Property(e => e.SocialStatusTypeId)
                    .HasColumnName("SocialStatusTypeID")
                    .HasComment("رقم مسلسل نوع الحالة الإجتماعية");

                entity.Property(e => e.WorkOfficeRegDate).HasColumnType("smalldatetime");

                entity.Property(e => e.WorkOfficeRegistration)
                    .HasMaxLength(50)
                    .HasComment("قيد مكتب العمل");
            });

            modelBuilder.Entity<Scoree>(entity =>
            {
                entity.ToTable("Score");

                entity.Property(e => e.ScoreId)
                    .ValueGeneratedNever()
                    .HasColumnName("ScoreID");

                entity.Property(e => e.Backhand).HasColumnName("backhand");

                entity.Property(e => e.Clubname).HasMaxLength(150);

                entity.Property(e => e.Forehand).HasColumnName("forehand");

                entity.Property(e => e.Notes).HasMaxLength(50);

                entity.Property(e => e.PlanyerName).HasMaxLength(150);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AllowDiscount)
                    .HasColumnName("Allow_Discount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deleted).HasComment("تم حذفه\r\nو هذا لمنع حذف اي مستخدم لما له من تأثير على طابع المستخدم");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Notes)
                    .HasMaxLength(250)
                    .HasComment("ملاحظات");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasComment("كلمة السر");

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .HasComment("مجموعة الصلاحيات");

                entity.Property(e => e.UserAllow).HasComment("السماح بالدخول");

                entity.Property(e => e.UserFullName)
                    .HasMaxLength(200)
                    .HasComment("الاسم بالكامل");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasComment("اسم الدخول");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Users_hrEmployees");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

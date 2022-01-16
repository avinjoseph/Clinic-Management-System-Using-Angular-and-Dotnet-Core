using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Clinic_Management_System_8.Models
{
    public partial class CMSContext : DbContext
    {
        public CMSContext()
        {
        }

        public CMSContext(DbContextOptions<CMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announcement> Announcement { get; set; }
        public virtual DbSet<AppointmentTypes> AppointmentTypes { get; set; }
        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<DoctorNotes> DoctorNotes { get; set; }
        public virtual DbSet<EmployeeSpecializations> EmployeeSpecializations { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<LabHasTechnician> LabHasTechnician { get; set; }
        public virtual DbSet<LabTests> LabTests { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Prescriptions> Prescriptions { get; set; }
        public virtual DbSet<Queries> Queries { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Specializations> Specializations { get; set; }
        public virtual DbSet<TestReports> TestReports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=JITHUMOLS\\SQLEXPRESS; Initial Catalog=CMS; Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.HasKey(e => e.AnnId)
                    .HasName("PK__Announce__1C67F94B181B4D21");

                entity.Property(e => e.AnnDate).HasColumnType("date");

                entity.Property(e => e.AnnText)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Announcement)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_emp");
            });

            modelBuilder.Entity<AppointmentTypes>(entity =>
            {
                entity.HasKey(e => e.AppointmentTypeId)
                    .HasName("PK__Appointm__E258532B02E670E2");

                entity.Property(e => e.AppointmentType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.HasKey(e => e.AppointmentId)
                    .HasName("PK__Appointm__8ECDFCC28F488F64");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.HasOne(d => d.AppointmentType)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.AppointmentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPOINTMENT_APTYPE");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPOINTMENT_EMP");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPOINTMENT_PATIENT");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__Departme__B2079BEDA29E157A");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DoctorNotes>(entity =>
            {
                entity.HasKey(e => e.NoteId)
                    .HasName("PK__DoctorNo__EACE355FB5B3AE9A");

                entity.Property(e => e.Note)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NoteDate).HasColumnType("date");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DoctorNotes)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_emp_note");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.DoctorNotes)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_patient_note");
            });

            modelBuilder.Entity<EmployeeSpecializations>(entity =>
            {
                entity.HasKey(e => e.Esid)
                    .HasName("PK__Employee__2332FD9543C92B42");

                entity.Property(e => e.Esid).HasColumnName("ESId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSpecializations)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ES_Employee");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.EmployeeSpecializations)
                    .HasForeignKey(d => d.SpecializationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ES_Specialization");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__Employee__7AD04F119E2D83E9");

                entity.Property(e => e.DateOfJoining).HasColumnType("date");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_DEPT");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_ROLE");
            });

            modelBuilder.Entity<LabHasTechnician>(entity =>
            {
                entity.HasKey(e => e.Ltid)
                    .HasName("PK__LabHasTe__4D388D6D3D176D87");

                entity.Property(e => e.Ltid).HasColumnName("LTId");

                entity.HasOne(d => d.Lab)
                    .WithMany(p => p.LabHasTechnician)
                    .HasForeignKey(d => d.LabId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LT_Labs");

                entity.HasOne(d => d.LabTechnician)
                    .WithMany(p => p.LabHasTechnician)
                    .HasForeignKey(d => d.LabTechnicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LT_Employee");
            });

            modelBuilder.Entity<LabTests>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("PK__Labs__EDBD68DAB41F0F38");

                entity.Property(e => e.TestName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_LOGIN_EMPLOYEE");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROLE_LOGIN");
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__Patients__970EC366E2BDD1EF");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__Payments__9B556A38C99757AA");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAYMENTS_PATIENTS");
            });

            modelBuilder.Entity<Prescriptions>(entity =>
            {
                entity.HasKey(e => e.PrescriptionId)
                    .HasName("PK__Prescrip__401308323F818364");

                entity.Property(e => e.Prescription)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PrescriptionDate).HasColumnType("date");

                entity.Property(e => e.Tests)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRESCRIPTION_EMPLOYEE");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRESCRIPTION_PATIENT");
            });

            modelBuilder.Entity<Queries>(entity =>
            {
                entity.HasKey(e => e.QueryId)
                    .HasName("PK__Queries__5967F7DBC1EEB747");

                entity.Property(e => e.Query)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.AnsweredByNavigation)
                    .WithMany(p => p.Queries)
                    .HasForeignKey(d => d.AnsweredBy)
                    .HasConstraintName("FK_QUERIES_EMPLOYEE");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Roles__8AFACE1A211F25D3");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Specializations>(entity =>
            {
                entity.HasKey(e => e.SpecializationId)
                    .HasName("PK__Speciali__5809D86FC55BD289");

                entity.Property(e => e.SpecializationName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestReports>(entity =>
            {
                entity.HasKey(e => e.TestReportId)
                    .HasName("PK__TestRepo__07E0C2EA57579E4A");

                entity.Property(e => e.ReportGeneratedDate).HasColumnType("date");

                entity.Property(e => e.TestReport)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TestReportsDoctor)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TESTREPORTS_EMP_DOCTOR");

                entity.HasOne(d => d.LabTechnician)
                    .WithMany(p => p.TestReportsLabTechnician)
                    .HasForeignKey(d => d.LabTechnicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TESTREPORTS_EMP_TECHNICIAN");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TestReports)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TESTREPORTS_PATIENT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

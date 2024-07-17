using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context.EntityFramework
{
    public class SimpleContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.213.175;Database=PuantajAppDab;User Id=SA; Password=Password1; Integrated Security=false; Encrypt = False;"); //Yusuf'un Database
            //optionsBuilder.UseSqlServer("Server= 192.168.135.128; Database=PuantajAppDbs; User Id=SA; Password=Password1; Integrated Security=false; Encrypt = False;"); //Mustafa'nın Database
        }
        public DbSet<User> AppUser { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }  
        public DbSet<OperationCompetency> OperationCompetencies { get; set; }
        public DbSet<Competency> Competencies { get; set; }
        public DbSet<JobUnit> JobUnits { get; set; }
        public DbSet<UserJobUnit> UserJobUnits { get; set; }
        public DbSet<JobDepartment> JobDepartments { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Logging> Loggings { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tally> Tallies { get; set; }
        public DbSet<Syllabus> Syllabus { get; set; }
        public DbSet<EmailParameter> EmailParameters { get; set; }
        public DbSet<WeekTally> WeekTallies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserOperationClaim>()
                .HasOne(x => x.User)
                .WithMany(y => y.UserOperationClaims)                
                .HasForeignKey(z => z.UserGuidId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserOperationClaim>()
                .HasOne(x => x.OperationClaim)
                .WithMany(y => y.UserOperationClaims)
                .HasForeignKey(z => z.OperationClaimGuidId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OperationCompetency>()
                .HasOne(x => x.OperationClaim)
                .WithMany(y => y.OperationCompetencies)
                .HasForeignKey(z => z.OperationClaimGuidId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OperationCompetency>()
                .HasOne(x => x.Competency)
                .WithMany(y => y.OperationCompetencies)
                .HasForeignKey(z => z.CompetencyGuidId)
                .OnDelete(DeleteBehavior.NoAction);
            //user->jobunit
            //modelBuilder.Entity<User>()
            //   .HasOne(x => x.JobUnit)
            //   .WithMany(y => y.Users)
            //   .HasForeignKey(z => z.JobUnitGuidId)
            //   .OnDelete(DeleteBehavior.NoAction);
            
            // user->userjobunit
            modelBuilder.Entity<UserJobUnit>()
               .HasOne(x => x.User)
               .WithMany(y => y.UserJobUnits)
               .HasForeignKey(z => z.UserGuidId)
               .OnDelete(DeleteBehavior.NoAction);

            // jobunit -> Userjobunit
            modelBuilder.Entity<UserJobUnit>()
               .HasOne(x => x.JobUnit)
               .WithMany(y => y.UserJobUnits)
               .HasForeignKey(z => z.JobUnitGuidId)
               .OnDelete(DeleteBehavior.NoAction);

             //job department -> jobunit
            modelBuilder.Entity<JobUnit>()
               .HasOne(x => x.JobDepartment)
               .WithMany(y => y.JobUnits)
               .HasForeignKey(z => z.JobDepartmentGuidId)
               .OnDelete(DeleteBehavior.NoAction);

            // student ->jobunit
            //modelBuilder.Entity<Student>()
            //    .HasOne(x => x.JobUnit)
            //    .WithMany(y => y.Students)
            //    .HasForeignKey(z => z.JobUnitGuidId)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Student>()
               .HasOne(x => x.JobUnit)
               .WithMany(y => y.Students)
               .HasForeignKey(z => z.JobUnitGuidId)
               .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Student>()
            //    .HasOne(x => x.JobDepartment)
            //    .WithMany(y => y.Students)
            //    .HasForeignKey(z => z.JobDepartmentGuidId)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Tally>()
                .HasOne(x => x.Student)
                .WithMany(y => y.Tallies)
                .HasForeignKey(z => z.StudentGuidId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<WeekTally>()
                .HasOne(x => x.Student)
                .WithMany(y => y.WeekTallies)
                .HasForeignKey(z => z.StudentGuidId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Syllabus>()
                .HasOne(x => x.Student)
                .WithMany(y => y.Syllabi)
                .HasForeignKey(z => z.StudentGuidId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>(x =>
            {
                x.Property(y => y.NameSurname)
                .HasMaxLength(50);

                x.Property(y => y.Email)
                .HasMaxLength(50);

                x.Property(y => y.ImageUrl)
                .HasMaxLength(100);
               
                x.Property(y => y.ImageByte)
                .IsRequired(true);

                x.Property(y => y.PasswordHash)
                .IsRequired(true);

                x.Property(y => y.PasswordSalt)
                .IsRequired(true);

                x.Property(y => y.ConfirmValue)
                .HasMaxLength(100);

                x.Property(y => y.IsConfirm)
                .IsRequired(true);

                x.Property(y => y.ForgotPasswordValue)
                .HasMaxLength(100);

                x.Property(y => y.ForgotPasswordRequestDate)
                .HasColumnType("datetime"); 

                x.Property(y => y.IsForgotPasswordComplete)
                .IsRequired(true);



            });
            // userjobunit
            modelBuilder.Entity<UserJobUnit>(x =>
            {
                x.Property(y => y.UserJobUnitGuidId)
                .HasMaxLength(100);
            });
            // Tally
            //modelBuilder.Entity<Tally>(x =>
            //{
            //    x.Property(y => y.CountHour)
            //        .IsRequired(false);
            //});
            //
            modelBuilder.Entity<OperationClaim>(x =>
            {
                x.Property(y => y.OperationClaimName)
                .HasMaxLength(100);
            });

            modelBuilder.Entity<Competency>(x =>
            {
                x.Property(y => y.Name)
                .HasMaxLength(100);
            });

            modelBuilder.Entity<JobUnit>(x =>
            {
                x.Property(y => y.JobUnitName)
                .HasMaxLength(100);
            });

            modelBuilder.Entity<JobDepartment>(x =>
            {
                x.Property(y => y.Name)
                .HasMaxLength(100);
            });

            modelBuilder.Entity<Holiday>(x =>
            {
                x.Property(y => y.HolidayFirstDate)
                .HasColumnType("datetime")
                .IsRequired();

                x.Property(y => y.HolidayFinishDate)
                .HasColumnType("datetime")
                .IsRequired();


                x.Property(y => y.HolidayName)
                .IsRequired();
            });

            modelBuilder.Entity<Settings>(x =>
            {
                //x.Property(y => y.MontHour)
                //.HasColumnType("datetime");

                //x.Property(y => y.WeekHour)
                //.HasColumnType("datetime");

                //x.Property(y => y.DayHour)
                //.HasColumnType("datetime");

            });

            modelBuilder.Entity<Student>(x =>
            {
                x.Property(y => y.NameSurname)
                .HasMaxLength(50);

                x.Property(y => y.Email)
                .HasMaxLength(50);

                x.Property(y => y.StudentNo)
                .IsRequired(true);

                x.Property(y => y.Faculty)
                .IsRequired(true)
                .HasMaxLength (100);

                x.Property(y => y.ImageByte)
                .IsRequired(true);

                x.Property(y => y.FacultyDepartment)
                .IsRequired(true)
                .HasMaxLength (100);

                x.Property(y => y.StudentClass)
                .IsRequired(true);

            });

            //modelBuilder.Entity<Tally>(x =>
            //{
            //    x.Property(y => y.JobDate)
            //    .HasColumnType("datetime");

            //    x.Property(y => y.FirstDate)
            //    .HasColumnType("datetime");

            //    x.Property(y => y.FinishDate)
            //    .HasColumnType("datetime");

            //});

            modelBuilder.Entity<WeekTally>(x =>
            {

                x.Property(y => y.FirstDate)
                .HasColumnType("datetime");

                x.Property(y => y.FinishDate)
                .HasColumnType("datetime");

            });

        }
    }
}

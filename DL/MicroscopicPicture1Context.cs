using System;
using System;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DL
{
    public partial class MicroscopicPicture1Context : DbContext
    {
        public MicroscopicPicture1Context()
        {
        }

        public MicroscopicPicture1Context(DbContextOptions<MicroscopicPicture1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Bacterium> Bacteriums { get; set; }
        public virtual DbSet<DiscussionGroup> DiscussionGroups { get; set; }
        public virtual DbSet<DoctorsInDiscussionGroup> DoctorsInDiscussionGroups { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<Hmo> Hmos { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PicturesCollection> PicturesCollections { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserKind> UserKinds { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\PUPILS;Database=MicroscopicPicture1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("RATING");

                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasMaxLength(50);

                entity.Property(e => e.Method)
                    .HasColumnName("METHOD")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Path)
                    .HasColumnName("PATH")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordDate)
                 .HasColumnName("Record_Date")
                 .HasColumnType("datetime");

                entity.Property(e => e.Referer)
                    .HasColumnName("REFERER")
                    .HasMaxLength(100);

                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
            });


            modelBuilder.Entity<Bacterium>(entity =>
            {
                entity.ToTable("bacteriums");

                entity.HasIndex(e => e.BacteriumName, "UQ__bacteriu__D916BCF126D87F10")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BacteriumName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("bacterium_name")
                    .IsFixedLength(true);

                entity.Property(e => e.InformationOfBacterium)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("information_of_bacterium");

                entity.Property(e => e.Medicine)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("medicine")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<DiscussionGroup>(entity =>
            {
                entity.ToTable("discussion_group");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Diagnosis).HasColumnName("diagnosis");

                entity.Property(e => e.ExaminationId).HasColumnName("examination_id");

                entity.HasOne(d => d.DiagnosisNavigation)
                    .WithMany(p => p.DiscussionGroupDiagnosisNavigations)
                    .HasForeignKey(d => d.Diagnosis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__discussio__diagn__37A5467C");

                entity.HasOne(d => d.Examination)
                    .WithMany(p => p.DiscussionGroupExaminations)
                    .HasForeignKey(d => d.ExaminationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__discussio__exami__38996AB5");
            });

            modelBuilder.Entity<DoctorsInDiscussionGroup>(entity =>
            {
                entity.ToTable("doctors_in_discussion_group");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasColumnType("ntext")
                    .HasColumnName("comment");

                entity.Property(e => e.DiscussionGroupId).HasColumnName("discussion_group_id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.DoctorsOpinion)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("doctors_opinion");

                entity.Property(e => e.LinkToImage)
                    .HasColumnType("image")
                    .HasColumnName("link_to_image");

                entity.HasOne(d => d.DiscussionGroup)
                    .WithMany(p => p.DoctorsInDiscussionGroups)
                    .HasForeignKey(d => d.DiscussionGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__doctors_i__discu__398D8EEE");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DoctorsInDiscussionGroups)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__doctors_i__docto__3A81B327");
            });

            modelBuilder.Entity<Examination>(entity =>
            {
                entity.ToTable("examinations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comments)
                    .HasColumnType("ntext")
                    .HasColumnName("comments");

                entity.Property(e => e.ComputerDiagnosis)
                    .HasColumnType("ntext")
                    .HasColumnName("computer_diagnosis");

                entity.Property(e => e.DoctorDiagnosis)
                    .HasColumnType("ntext")
                    .HasColumnName("doctor_diagnosis");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.ExaminationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("examination_date");

                entity.Property(e => e.LinkToFile)
                    .HasColumnType("ntext")
                    .HasColumnName("link_to_file");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.PrescriptionName)
                    .HasColumnType("ntext")
                    .HasColumnName("prescription_name");

                entity.Property(e => e.TissueCultureResult)
                    .HasColumnType("ntext")
                    .HasColumnName("tissue_culture_result");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Examinations)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__examinati__docto__3B75D760");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Examinations)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__examinati__patie__3C69FB99");
            });

            modelBuilder.Entity<Hmo>(entity =>
            {
                entity.ToTable("HMO");

                entity.HasIndex(e => e.NameOfHmo, "UQ__HMO__5DDB05EA5570EFCC")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NameOfHmo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("name_of_HMO");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("birthDate");

                entity.Property(e => e.HmoId).HasColumnName("HMO_id");

                entity.Property(e => e.MedicalInformation)
                    .HasColumnType("ntext")
                    .HasColumnName("medical_information");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Hmo)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.HmoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__patients__HMO_id__3D5E1FD2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__patients__user_i__3E52440B");
            });

            modelBuilder.Entity<PicturesCollection>(entity =>
            {
                entity.ToTable("pictures_collection");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BacteriumId).HasColumnName("bacteriumId");

                entity.Property(e => e.LinkToImage)
                    .HasColumnType("image")
                    .HasColumnName("link_to_image");

                entity.HasOne(d => d.Bacterium)
                    .WithMany(p => p.PicturesCollections)
                    .HasForeignKey(d => d.BacteriumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pictures___bacte__3F466844");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.IdNumber, "UQ__users__D58CDE111573D34B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email")
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("id_number")
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.Property(e => e.UserKindId).HasColumnName("user_kind_id");

                entity.HasOne(d => d.UserKind)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserKindId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__users__user_kind__403A8C7D");
            });

            modelBuilder.Entity<UserKind>(entity =>
            {
                entity.ToTable("user_kind");

                entity.HasIndex(e => e.UserKind1, "UQ__user_kin__3CBE27CC97269827")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserKind1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("user_kind")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

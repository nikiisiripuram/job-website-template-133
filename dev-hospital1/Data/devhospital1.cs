using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using dev_hospital1.Models;

namespace dev_hospital1.Data;

public partial class devhospital1 : DbContext
{
    public devhospital1()
    {
    }

    public devhospital1(DbContextOptions<devhospital1> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Register> Registers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ICS-LT-H7L96V3\\SQLEXPRESS;Initial Catalog=dev-hos;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC2FBE01A52");

            entity.Property(e => e.AppointmentId).ValueGeneratedNever();
            entity.Property(e => e.AppointmentTime).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Depar__3F466844");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Patie__403A8C7D");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED090E1B15");

            entity.Property(e => e.DepartmentId).ValueGeneratedNever();
            entity.Property(e => e.DepartmentName).HasMaxLength(100);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__2DC00EBF3F380E44");

            entity.Property(e => e.DoctorId).ValueGeneratedNever();
            entity.Property(e => e.DoctorName).HasMaxLength(100);
            entity.Property(e => e.Qualification).HasMaxLength(100);
            entity.Property(e => e.Specialization).HasMaxLength(100);

            entity.HasOne(d => d.Department).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Doctors__Departm__398D8EEE");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC3667468D435");

            entity.Property(e => e.PatientId).ValueGeneratedNever();
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.PatientName).HasMaxLength(100);
            entity.Property(e => e.Phoneno).HasMaxLength(20);

            entity.HasOne(d => d.Doctor).WithMany(p => p.Patients)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Patients__Doctor__3C69FB99");
        });

        modelBuilder.Entity<Register>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Register__3214EC07CBCBA862");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

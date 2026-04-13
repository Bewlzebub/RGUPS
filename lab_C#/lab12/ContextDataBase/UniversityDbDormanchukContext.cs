using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using lab10_ASP.Tables;

namespace lab10_ASP.ContextDataBase;

public partial class UniversityDbDormanchukContext : DbContext
{
    public UniversityDbDormanchukContext()
    {
    }

    public UniversityDbDormanchukContext(DbContextOptions<UniversityDbDormanchukContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ведомости> Ведомостиs { get; set; }

    public virtual DbSet<Дисциплины> Дисциплиныs { get; set; }

    public virtual DbSet<Кафедры> Кафедрыs { get; set; }

    public virtual DbSet<Преподаватели> Преподавателиs { get; set; }

    public virtual DbSet<Студенты> Студентыs { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_CI_AS");

        modelBuilder.Entity<Ведомости>(entity =>
        {
            entity.HasKey(e => e.КодЗаписи);

            entity.ToTable("Ведомости");

            entity.Property(e => e.КодЗаписи).HasColumnName("код_записи");
            entity.Property(e => e.ДатаСдачи)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("дата_сдачи");
            entity.Property(e => e.Дисциплина).HasColumnName("дисциплина");
            entity.Property(e => e.Оценка).HasColumnName("оценка");
            entity.Property(e => e.Преподаватель).HasColumnName("преподаватель");
            entity.Property(e => e.Студент).HasColumnName("студент");

            entity.HasOne(d => d.ДисциплинаNavigation).WithMany(p => p.Ведомостиs)
                .HasForeignKey(d => d.Дисциплина)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ведомости_Дисциплины");

            entity.HasOne(d => d.ПреподавательNavigation).WithMany(p => p.Ведомостиs)
                .HasForeignKey(d => d.Преподаватель)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ведомости_Преподаватели");

            entity.HasOne(d => d.СтудентNavigation).WithMany(p => p.Ведомостиs)
                .HasForeignKey(d => d.Студент)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ведомости_Студенты");
        });

        modelBuilder.Entity<Дисциплины>(entity =>
        {
            entity.HasKey(e => e.КодДисциплины);

            entity.ToTable("Дисциплины");

            entity.Property(e => e.КодДисциплины).HasColumnName("код_дисциплины");
            entity.Property(e => e.ВидКонтроля)
                .HasMaxLength(50)
                .HasColumnName("вид_контроля");
            entity.Property(e => e.Кафедра).HasColumnName("кафедра");
            entity.Property(e => e.КолВоЧасов).HasColumnName("кол_во_часов");
            entity.Property(e => e.Название)
                .HasMaxLength(100)
                .HasColumnName("название");
            entity.Property(e => e.Преподаватель).HasColumnName("преподаватель");

            entity.HasOne(d => d.КафедраNavigation).WithMany(p => p.Дисциплиныs)
                .HasForeignKey(d => d.Кафедра)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Дисциплины_Кафедры");

            entity.HasOne(d => d.ПреподавательNavigation).WithMany(p => p.Дисциплиныs)
                .HasForeignKey(d => d.Преподаватель)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Дисциплины_Преподаватели");
        });

        modelBuilder.Entity<Кафедры>(entity =>
        {
            entity.HasKey(e => e.КодКафедры);

            entity.ToTable("Кафедры");

            entity.Property(e => e.КодКафедры).HasColumnName("код_кафедры");
            entity.Property(e => e.КолВоПреподавателей).HasColumnName("кол_во_преподавателей");
            entity.Property(e => e.Название)
                .HasMaxLength(100)
                .HasColumnName("название");
            entity.Property(e => e.НомерКомнаты).HasColumnName("номер_комнаты");
            entity.Property(e => e.НомерКорпуса).HasColumnName("номер_корпуса");
            entity.Property(e => e.Телефон)
                .HasMaxLength(20)
                .HasColumnName("телефон");
            entity.Property(e => e.Факультет)
                .HasMaxLength(100)
                .HasColumnName("факультет");
            entity.Property(e => e.ФиоЗаведующего)
                .HasMaxLength(150)
                .HasColumnName("фио_заведующего");
        });

        modelBuilder.Entity<Преподаватели>(entity =>
        {
            entity.HasKey(e => e.КодПреподавателя);

            entity.ToTable("Преподаватели");

            entity.Property(e => e.КодПреподавателя).HasColumnName("код_преподавателя");
            entity.Property(e => e.Адрес)
                .HasMaxLength(200)
                .HasColumnName("адрес");
            entity.Property(e => e.ГодПоступления).HasColumnName("год_поступления");
            entity.Property(e => e.ГодРождения).HasColumnName("год_рождения");
            entity.Property(e => e.Город)
                .HasMaxLength(50)
                .HasColumnName("город");
            entity.Property(e => e.Должность)
                .HasMaxLength(100)
                .HasColumnName("должность");
            entity.Property(e => e.Имя)
                .HasMaxLength(50)
                .HasColumnName("имя");
            entity.Property(e => e.Кафедра).HasColumnName("кафедра");
            entity.Property(e => e.Отчество)
                .HasMaxLength(50)
                .HasColumnName("отчество");
            entity.Property(e => e.Пол)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("пол");
            entity.Property(e => e.Стаж).HasColumnName("стаж");
            entity.Property(e => e.Телефон)
                .HasMaxLength(20)
                .HasColumnName("телефон");
            entity.Property(e => e.Фамилия)
                .HasMaxLength(50)
                .HasColumnName("фамилия");

            entity.HasOne(d => d.КафедраNavigation).WithMany(p => p.Преподавателиs)
                .HasForeignKey(d => d.Кафедра)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Преподаватели_Кафедры");
        });

        modelBuilder.Entity<Студенты>(entity =>
        {
            entity.HasKey(e => e.КодСтудента);

            entity.ToTable("Студенты");

            entity.Property(e => e.КодСтудента).HasColumnName("код_студента");
            entity.Property(e => e.Адрес)
                .HasMaxLength(200)
                .HasColumnName("адрес");
            entity.Property(e => e.ГодРождения).HasColumnName("год_рождения");
            entity.Property(e => e.Город)
                .HasMaxLength(50)
                .HasColumnName("город");
            entity.Property(e => e.Имя)
                .HasMaxLength(50)
                .HasColumnName("имя");
            entity.Property(e => e.Кафедра).HasColumnName("кафедра");
            entity.Property(e => e.Отчество)
                .HasMaxLength(50)
                .HasColumnName("отчество");
            entity.Property(e => e.Пол)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("пол");
            entity.Property(e => e.Телефон)
                .HasMaxLength(20)
                .HasColumnName("телефон");
            entity.Property(e => e.Фамилия)
                .HasMaxLength(50)
                .HasColumnName("фамилия");

            entity.HasOne(d => d.КафедраNavigation).WithMany(p => p.Студентыs)
                .HasForeignKey(d => d.Кафедра)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Студенты_Кафедры");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

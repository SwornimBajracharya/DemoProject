using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CRUDOperationAPI.Contexts;

namespace CRUDOperationAPI.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20191203091148_Updated projects table")]
    partial class Updatedprojectstable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRUDOperationAPI.Models.ClientProject", b =>
                {
                    b.Property<int>("ClientProjectID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientID");

                    b.Property<int>("ProjectID");

                    b.HasKey("ClientProjectID");

                    b.HasIndex("ClientID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ClientProject");
                });

            modelBuilder.Entity("CRUDOperationAPI.Models.Clients", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientContactNumber");

                    b.Property<string>("ClientFirstName");

                    b.Property<string>("ClientLastName");

                    b.Property<string>("ClientOffice");

                    b.Property<string>("OfficeAddress");

                    b.HasKey("ClientID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("CRUDOperationAPI.Models.Contacts", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("ContactNumber")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("EmergencyContactNumber")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CRUDOperationAPI.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContactId");

                    b.Property<string>("Department");

                    b.Property<string>("Designation");

                    b.Property<bool>("IsFullTimer");

                    b.Property<decimal>("Salary");

                    b.Property<float>("WorkingHrPerDay");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ContactId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CRUDOperationAPI.Models.EmployeeProject", b =>
                {
                    b.Property<int>("EmployeeProjectID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeID");

                    b.Property<int>("ProjectID");

                    b.HasKey("EmployeeProjectID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ProjectID");

                    b.ToTable("EmployeeProject");
                });

            modelBuilder.Entity("CRUDOperationAPI.Models.EmployeeSchedule", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeID");

                    b.Property<DateTime?>("InTime");

                    b.Property<DateTime?>("OutTime");

                    b.Property<decimal?>("TotalHourWorkPerday");

                    b.HasKey("ScheduleID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("EmployeeSchedule");
                });

            modelBuilder.Entity("CRUDOperationAPI.Models.Projects", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ProjectEndDate");

                    b.Property<string>("ProjectName");

                    b.Property<DateTime>("ProjectStartDate");

                    b.HasKey("ProjectID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("CRUDOperationAPI.Models.ClientProject", b =>
                {
                    b.HasOne("CRUDOperationAPI.Models.Clients", "Clients")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRUDOperationAPI.Models.Projects", "Projects")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRUDOperationAPI.Models.Employee", b =>
                {
                    b.HasOne("CRUDOperationAPI.Models.Contacts", "Contacts")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("CRUDOperationAPI.Models.EmployeeProject", b =>
                {
                    b.HasOne("CRUDOperationAPI.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRUDOperationAPI.Models.Projects", "Projects")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRUDOperationAPI.Models.EmployeeSchedule", b =>
                {
                    b.HasOne("CRUDOperationAPI.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

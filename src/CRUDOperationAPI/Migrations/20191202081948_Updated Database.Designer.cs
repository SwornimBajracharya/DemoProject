using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CRUDOperationAPI.Contexts;

namespace CRUDOperationAPI.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20191202081948_Updated Database")]
    partial class UpdatedDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("CRUDOperationAPI.Models.Employee", b =>
                {
                    b.HasOne("CRUDOperationAPI.Models.Contacts", "Contacts")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });
        }
    }
}

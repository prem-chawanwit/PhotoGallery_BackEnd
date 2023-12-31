﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhotoGallery_BackeEnd.Context;

#nullable disable

namespace PhotoGallery_BackEnd.Migrations
{
    [DbContext(typeof(APIDbContext))]
    [Migration("20231104135557_addLoginTimesIsLoggedIn")]
    partial class addLoginTimesIsLoggedIn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PhotoGallery_BackEnd.Models.Tasks.SectionUploadPathData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("basePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dataSource")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("timeUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("API_SectionUploadPathData");
                });

            modelBuilder.Entity("PhotoGallery_BackEnd.Models.Tasks.TaskModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("taskid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("uploadPathDataid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("uploadPathDataid");

                    b.ToTable("API_TaskModel");
                });

            modelBuilder.Entity("PhotoGallery_BackEnd.Models.Tasks.TaskOrderData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("sectionUploadPathDataid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("sectionUploadPathDataid");

                    b.ToTable("API_TaskOrderData");
                });

            modelBuilder.Entity("PhotoGallery_BackEnd.Models.Tasks.TaskReviewData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("extractData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("extractEndTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("extractSta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("extractStartTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isRunning")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("task_id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("API_TaskReviewData");
                });

            modelBuilder.Entity("PhotoGallery_BackEnd.Models.Users.LoginTimming", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("expireToken")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isLoggedIn")
                        .HasColumnType("bit");

                    b.Property<DateTime>("lastLoggedIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("API_LoginTimming");
                });

            modelBuilder.Entity("PhotoGallery_BackEnd.Models.Users.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<byte[]>("passwordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("userAccessLevelid")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("userAccessLevelid");

                    b.ToTable("API_Users");

                    b.HasData(
                        new
                        {
                            id = 1,
                            passwordHash = new byte[] { 238, 53, 17, 173, 232, 175, 182, 3, 170, 124, 37, 143, 19, 30, 66, 145, 213, 32, 131, 13, 23, 162, 171, 84, 143, 184, 20, 136, 18, 30, 235, 7, 76, 253, 21, 108, 81, 29, 39, 127, 172, 195, 7, 132, 83, 211, 67, 197, 132, 103, 168, 64, 80, 187, 90, 215, 85, 129, 236, 200, 150, 11, 199, 66 },
                            passwordSalt = new byte[] { 205, 251, 72, 167, 4, 123, 33, 226, 38, 67, 235, 131, 215, 129, 177, 106, 240, 244, 192, 189, 75, 221, 79, 176, 191, 113, 1, 59, 183, 96, 103, 236, 171, 229, 95, 169, 202, 152, 25, 69, 97, 205, 86, 254, 96, 197, 199, 136, 235, 176, 26, 251, 107, 107, 214, 26, 106, 224, 152, 241, 193, 68, 32, 1, 139, 63, 140, 164, 175, 92, 177, 115, 85, 94, 59, 14, 202, 94, 195, 67, 55, 80, 233, 122, 220, 11, 7, 229, 189, 69, 218, 13, 63, 11, 163, 177, 17, 140, 32, 10, 61, 11, 16, 4, 1, 6, 121, 186, 6, 127, 149, 92, 170, 228, 182, 147, 124, 68, 112, 84, 78, 203, 193, 110, 197, 199, 100, 129 },
                            userAccessLevelid = 1,
                            username = "prem"
                        },
                        new
                        {
                            id = 2,
                            passwordHash = new byte[] { 8, 206, 191, 0, 172, 183, 253, 251, 153, 116, 47, 116, 44, 243, 243, 121, 154, 49, 220, 183, 145, 47, 96, 18, 27, 203, 230, 66, 52, 208, 239, 51, 167, 97, 18, 237, 30, 236, 220, 152, 120, 126, 227, 13, 173, 80, 154, 18, 32, 182, 21, 111, 223, 3, 60, 90, 209, 24, 210, 188, 29, 143, 243, 25 },
                            passwordSalt = new byte[] { 23, 130, 60, 2, 12, 106, 14, 185, 81, 34, 17, 231, 116, 192, 241, 236, 126, 82, 214, 160, 41, 168, 164, 106, 238, 251, 2, 234, 175, 109, 164, 225, 57, 136, 9, 117, 52, 32, 37, 198, 43, 170, 203, 9, 240, 156, 156, 23, 6, 83, 77, 173, 83, 160, 193, 60, 228, 107, 249, 194, 199, 142, 121, 90, 175, 70, 180, 21, 119, 32, 159, 69, 49, 177, 8, 240, 159, 23, 115, 77, 194, 242, 168, 1, 213, 152, 118, 97, 99, 174, 140, 142, 11, 1, 86, 200, 77, 109, 192, 177, 32, 41, 54, 253, 234, 238, 213, 207, 115, 216, 116, 158, 143, 53, 120, 212, 9, 0, 129, 38, 82, 193, 32, 124, 229, 49, 82, 244 },
                            userAccessLevelid = 1,
                            username = "superadmin"
                        },
                        new
                        {
                            id = 3,
                            passwordHash = new byte[] { 155, 28, 173, 77, 77, 65, 100, 96, 50, 159, 69, 228, 239, 95, 5, 58, 59, 58, 86, 206, 10, 213, 125, 132, 106, 150, 38, 102, 145, 116, 31, 245, 183, 57, 216, 70, 32, 63, 209, 36, 45, 34, 55, 26, 123, 15, 151, 158, 131, 7, 98, 117, 191, 39, 204, 153, 109, 131, 107, 71, 169, 220, 138, 195 },
                            passwordSalt = new byte[] { 111, 114, 14, 188, 56, 8, 231, 81, 155, 43, 216, 51, 246, 116, 39, 125, 125, 20, 79, 108, 44, 173, 212, 130, 61, 204, 2, 223, 167, 87, 140, 162, 79, 60, 18, 244, 86, 41, 172, 82, 134, 80, 213, 230, 100, 252, 233, 32, 181, 34, 42, 202, 181, 100, 3, 108, 75, 90, 109, 199, 43, 110, 219, 70, 227, 48, 21, 174, 172, 5, 187, 138, 167, 103, 224, 63, 53, 189, 155, 169, 211, 197, 24, 124, 156, 8, 151, 176, 29, 80, 52, 249, 205, 207, 118, 156, 195, 173, 101, 134, 33, 127, 148, 159, 83, 2, 252, 186, 250, 203, 184, 162, 32, 208, 255, 174, 139, 203, 92, 149, 147, 110, 82, 45, 194, 231, 216, 104 },
                            userAccessLevelid = 2,
                            username = "admin"
                        },
                        new
                        {
                            id = 4,
                            passwordHash = new byte[] { 168, 238, 78, 130, 31, 147, 208, 61, 239, 158, 178, 246, 14, 41, 26, 109, 246, 254, 76, 70, 33, 125, 208, 245, 169, 169, 11, 220, 100, 134, 211, 224, 220, 27, 92, 91, 185, 108, 53, 63, 198, 203, 63, 94, 131, 148, 32, 147, 135, 201, 148, 129, 197, 1, 46, 196, 196, 213, 13, 149, 191, 108, 126, 106 },
                            passwordSalt = new byte[] { 132, 192, 184, 23, 237, 116, 122, 252, 53, 194, 254, 225, 81, 209, 220, 195, 196, 15, 111, 89, 247, 195, 21, 234, 137, 3, 230, 150, 167, 110, 203, 80, 70, 199, 64, 96, 239, 255, 170, 154, 102, 116, 208, 195, 204, 186, 212, 68, 141, 249, 185, 31, 94, 2, 78, 33, 63, 138, 214, 98, 114, 127, 73, 95, 198, 215, 82, 171, 234, 174, 95, 69, 7, 218, 50, 169, 152, 200, 213, 161, 51, 153, 98, 73, 39, 28, 68, 222, 43, 241, 94, 18, 35, 55, 158, 187, 28, 4, 233, 215, 2, 116, 255, 111, 70, 68, 234, 154, 128, 57, 81, 199, 242, 24, 104, 194, 11, 213, 55, 29, 173, 184, 4, 37, 153, 207, 96, 108 },
                            userAccessLevelid = 3,
                            username = "user"
                        },
                        new
                        {
                            id = 5,
                            passwordHash = new byte[] { 5, 39, 157, 206, 68, 179, 128, 110, 241, 185, 175, 231, 153, 219, 123, 139, 173, 64, 189, 216, 149, 150, 185, 39, 139, 221, 101, 88, 220, 49, 176, 118, 119, 235, 213, 166, 162, 239, 246, 12, 4, 226, 211, 109, 212, 161, 86, 120, 105, 40, 84, 207, 172, 207, 23, 228, 147, 99, 158, 126, 240, 7, 202, 157 },
                            passwordSalt = new byte[] { 83, 118, 164, 181, 182, 126, 46, 23, 185, 79, 96, 73, 201, 238, 147, 64, 149, 253, 216, 221, 226, 208, 58, 3, 151, 212, 15, 177, 106, 193, 241, 248, 85, 141, 57, 226, 15, 89, 221, 154, 59, 169, 45, 237, 214, 200, 110, 121, 230, 160, 222, 61, 47, 129, 72, 35, 34, 172, 235, 32, 138, 186, 123, 206, 55, 113, 82, 62, 58, 217, 219, 110, 164, 253, 3, 110, 223, 179, 75, 234, 61, 163, 58, 215, 25, 92, 173, 177, 172, 34, 165, 173, 97, 48, 102, 32, 217, 133, 111, 203, 211, 162, 224, 140, 60, 228, 204, 216, 153, 229, 137, 173, 219, 58, 210, 10, 144, 131, 230, 132, 1, 154, 84, 32, 44, 75, 90, 12 },
                            userAccessLevelid = 4,
                            username = "guest"
                        },
                        new
                        {
                            id = 6,
                            passwordHash = new byte[] { 55, 47, 189, 75, 76, 104, 69, 240, 217, 116, 121, 211, 226, 32, 148, 239, 2, 111, 205, 66, 104, 143, 250, 235, 224, 174, 123, 189, 37, 202, 214, 23, 203, 212, 181, 91, 207, 103, 151, 99, 64, 183, 47, 58, 38, 167, 130, 104, 96, 209, 20, 110, 189, 119, 146, 9, 108, 82, 133, 219, 81, 207, 4, 204 },
                            passwordSalt = new byte[] { 106, 25, 113, 28, 229, 81, 96, 107, 76, 78, 164, 90, 91, 156, 74, 64, 111, 254, 205, 170, 209, 189, 48, 175, 158, 156, 71, 12, 129, 75, 195, 63, 242, 82, 94, 170, 118, 145, 36, 140, 111, 226, 65, 208, 51, 17, 167, 206, 79, 226, 252, 112, 45, 62, 116, 2, 86, 1, 252, 145, 62, 96, 149, 46, 48, 113, 14, 79, 75, 172, 152, 212, 108, 149, 227, 135, 51, 237, 61, 66, 218, 70, 11, 57, 6, 178, 102, 143, 24, 9, 82, 198, 138, 246, 62, 66, 47, 113, 15, 104, 220, 241, 35, 253, 75, 188, 248, 119, 174, 231, 243, 90, 210, 41, 41, 231, 183, 1, 176, 185, 66, 101, 195, 105, 207, 212, 4, 128 },
                            userAccessLevelid = 99,
                            username = "unknow"
                        });
                });

            modelBuilder.Entity("PhotoGallery_BackEnd.Models.Users.UserAccessLevel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("accessLevel")
                        .HasColumnType("int");

                    b.Property<string>("accessLevelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("API_UserAccessLevel");

                    b.HasData(
                        new
                        {
                            id = 1,
                            accessLevel = 1,
                            accessLevelName = "SuperAdmin"
                        },
                        new
                        {
                            id = 2,
                            accessLevel = 2,
                            accessLevelName = "Admin"
                        },
                        new
                        {
                            id = 3,
                            accessLevel = 3,
                            accessLevelName = "User"
                        },
                        new
                        {
                            id = 4,
                            accessLevel = 4,
                            accessLevelName = "Guest"
                        },
                        new
                        {
                            id = 99,
                            accessLevel = 99,
                            accessLevelName = "Unknown"
                        });
                });

            modelBuilder.Entity("PhotoGallery_BackEnd.Models.Tasks.TaskModel", b =>
                {
                    b.HasOne("PhotoGallery_BackEnd.Models.Tasks.SectionUploadPathData", "uploadPathData")
                        .WithMany()
                        .HasForeignKey("uploadPathDataid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("uploadPathData");
                });

            modelBuilder.Entity("PhotoGallery_BackEnd.Models.Tasks.TaskOrderData", b =>
                {
                    b.HasOne("PhotoGallery_BackEnd.Models.Tasks.SectionUploadPathData", "sectionUploadPathData")
                        .WithMany()
                        .HasForeignKey("sectionUploadPathDataid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sectionUploadPathData");
                });

            modelBuilder.Entity("PhotoGallery_BackEnd.Models.Users.User", b =>
                {
                    b.HasOne("PhotoGallery_BackEnd.Models.Users.UserAccessLevel", "userAccessLevels")
                        .WithMany()
                        .HasForeignKey("userAccessLevelid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("userAccessLevels");
                });
#pragma warning restore 612, 618
        }
    }
}

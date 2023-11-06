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
    [Migration("20231106063824_addColumnSectionuploadData")]
    partial class addColumnSectionuploadData
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

                    b.Property<string>("fileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameFileSystem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sizeFile")
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
                            passwordHash = new byte[] { 67, 136, 17, 149, 28, 8, 66, 227, 77, 218, 147, 92, 66, 49, 116, 103, 70, 195, 59, 26, 18, 235, 96, 150, 102, 172, 143, 220, 252, 189, 254, 60, 19, 44, 234, 183, 20, 109, 189, 209, 102, 28, 242, 176, 7, 153, 199, 126, 97, 33, 89, 102, 190, 52, 168, 19, 252, 216, 30, 93, 209, 173, 132, 168 },
                            passwordSalt = new byte[] { 19, 38, 244, 74, 230, 123, 249, 108, 211, 33, 182, 212, 129, 94, 65, 197, 7, 51, 220, 36, 218, 200, 155, 25, 93, 246, 219, 14, 140, 112, 192, 174, 151, 179, 176, 244, 95, 255, 29, 240, 98, 195, 229, 48, 48, 207, 150, 4, 239, 61, 129, 147, 206, 242, 222, 61, 157, 14, 157, 146, 146, 122, 33, 190, 105, 170, 193, 244, 15, 225, 101, 0, 146, 89, 31, 96, 37, 127, 180, 213, 243, 4, 14, 59, 196, 205, 10, 100, 3, 38, 245, 222, 206, 108, 140, 171, 76, 29, 170, 96, 105, 141, 172, 196, 46, 132, 174, 219, 79, 117, 183, 220, 123, 69, 222, 78, 246, 147, 160, 137, 189, 98, 185, 133, 89, 9, 121, 62 },
                            userAccessLevelid = 1,
                            username = "prem"
                        },
                        new
                        {
                            id = 2,
                            passwordHash = new byte[] { 2, 23, 80, 9, 44, 27, 93, 227, 188, 177, 94, 247, 113, 177, 177, 136, 147, 52, 82, 39, 195, 66, 120, 86, 30, 227, 179, 244, 90, 122, 157, 210, 5, 143, 178, 87, 179, 191, 134, 85, 250, 119, 142, 185, 186, 88, 125, 130, 22, 86, 191, 144, 121, 149, 11, 180, 128, 102, 162, 143, 28, 93, 169, 72 },
                            passwordSalt = new byte[] { 142, 207, 69, 225, 178, 245, 95, 3, 147, 46, 64, 64, 121, 98, 157, 59, 242, 18, 164, 110, 155, 146, 205, 74, 132, 138, 165, 95, 210, 191, 151, 218, 150, 241, 78, 18, 22, 72, 190, 21, 160, 201, 33, 141, 141, 40, 197, 211, 0, 192, 121, 3, 85, 37, 10, 164, 250, 223, 125, 155, 133, 176, 95, 146, 135, 116, 146, 198, 60, 102, 49, 126, 98, 247, 243, 41, 250, 156, 177, 52, 229, 79, 196, 119, 187, 250, 9, 106, 69, 92, 5, 107, 226, 120, 130, 46, 66, 2, 72, 91, 81, 237, 101, 158, 134, 172, 49, 122, 127, 220, 155, 11, 187, 133, 63, 27, 48, 175, 69, 47, 106, 137, 24, 150, 103, 42, 54, 10 },
                            userAccessLevelid = 1,
                            username = "superadmin"
                        },
                        new
                        {
                            id = 3,
                            passwordHash = new byte[] { 229, 239, 184, 188, 94, 90, 235, 146, 132, 157, 157, 142, 128, 171, 145, 238, 187, 90, 165, 132, 206, 183, 68, 43, 192, 240, 62, 251, 117, 193, 43, 189, 68, 6, 208, 77, 223, 30, 239, 135, 104, 105, 225, 124, 163, 79, 1, 2, 160, 99, 56, 138, 151, 9, 203, 26, 201, 15, 1, 96, 188, 221, 131, 129 },
                            passwordSalt = new byte[] { 47, 178, 93, 221, 207, 195, 2, 92, 178, 213, 93, 30, 122, 85, 117, 238, 220, 130, 203, 26, 73, 165, 71, 243, 18, 232, 205, 179, 50, 158, 168, 55, 179, 162, 59, 111, 220, 210, 46, 233, 31, 124, 100, 110, 54, 223, 240, 159, 33, 141, 221, 50, 205, 61, 230, 242, 145, 23, 152, 119, 200, 24, 10, 50, 247, 113, 183, 174, 230, 212, 155, 214, 148, 254, 90, 112, 70, 194, 53, 176, 118, 41, 75, 180, 202, 105, 44, 123, 87, 17, 182, 111, 254, 249, 213, 128, 135, 234, 35, 245, 205, 71, 36, 177, 78, 17, 169, 105, 64, 153, 63, 252, 207, 114, 120, 10, 139, 140, 199, 115, 76, 206, 239, 253, 81, 27, 146, 233 },
                            userAccessLevelid = 2,
                            username = "admin"
                        },
                        new
                        {
                            id = 4,
                            passwordHash = new byte[] { 58, 183, 62, 108, 57, 125, 129, 146, 87, 233, 213, 255, 103, 236, 165, 157, 134, 58, 23, 113, 169, 151, 230, 63, 230, 9, 174, 101, 140, 166, 204, 223, 186, 240, 63, 74, 190, 162, 202, 206, 210, 148, 192, 107, 236, 230, 11, 97, 79, 162, 34, 230, 191, 26, 175, 84, 251, 38, 12, 234, 143, 206, 26, 98 },
                            passwordSalt = new byte[] { 63, 164, 112, 149, 71, 138, 55, 22, 101, 8, 88, 210, 19, 227, 205, 202, 99, 215, 32, 162, 20, 181, 51, 146, 78, 221, 186, 149, 223, 242, 219, 2, 82, 130, 8, 176, 24, 128, 157, 55, 123, 83, 102, 98, 234, 215, 74, 167, 147, 29, 201, 114, 153, 146, 182, 220, 251, 18, 94, 90, 58, 2, 108, 213, 46, 221, 204, 115, 175, 73, 163, 214, 28, 2, 113, 138, 140, 14, 193, 158, 103, 130, 134, 228, 205, 108, 73, 17, 28, 198, 120, 94, 132, 127, 210, 167, 8, 16, 127, 83, 162, 207, 230, 125, 47, 15, 203, 5, 51, 243, 100, 91, 120, 251, 224, 85, 25, 24, 31, 118, 201, 89, 120, 218, 152, 206, 220, 84 },
                            userAccessLevelid = 3,
                            username = "user"
                        },
                        new
                        {
                            id = 5,
                            passwordHash = new byte[] { 91, 115, 124, 28, 82, 33, 221, 37, 217, 57, 45, 105, 197, 37, 251, 37, 121, 27, 77, 56, 118, 215, 53, 191, 240, 67, 100, 248, 242, 110, 150, 199, 24, 1, 103, 136, 227, 58, 236, 35, 22, 216, 49, 21, 171, 135, 156, 98, 122, 1, 54, 96, 205, 28, 158, 89, 203, 140, 101, 144, 1, 143, 196, 2 },
                            passwordSalt = new byte[] { 84, 150, 123, 126, 78, 112, 37, 4, 219, 233, 229, 85, 41, 32, 31, 35, 4, 5, 111, 201, 105, 198, 114, 150, 133, 175, 142, 194, 190, 233, 77, 158, 41, 122, 214, 59, 75, 159, 114, 2, 145, 14, 246, 131, 107, 244, 26, 146, 238, 203, 1, 56, 161, 94, 203, 94, 131, 47, 132, 81, 0, 52, 159, 83, 208, 166, 16, 66, 15, 88, 166, 197, 10, 157, 151, 78, 11, 54, 82, 91, 111, 151, 117, 35, 243, 0, 216, 246, 144, 26, 26, 7, 120, 202, 103, 95, 183, 0, 38, 94, 26, 116, 99, 58, 187, 183, 195, 37, 215, 14, 238, 35, 144, 74, 219, 24, 142, 128, 115, 75, 115, 228, 249, 238, 86, 225, 8, 147 },
                            userAccessLevelid = 4,
                            username = "guest"
                        },
                        new
                        {
                            id = 6,
                            passwordHash = new byte[] { 171, 2, 96, 249, 19, 14, 65, 179, 150, 57, 203, 235, 5, 77, 200, 231, 121, 227, 196, 99, 179, 129, 6, 6, 193, 188, 107, 133, 202, 187, 108, 31, 244, 186, 94, 206, 171, 65, 95, 184, 56, 69, 33, 7, 73, 243, 163, 135, 206, 226, 165, 252, 211, 243, 71, 142, 27, 165, 186, 158, 186, 93, 227, 186 },
                            passwordSalt = new byte[] { 251, 9, 38, 95, 107, 244, 144, 31, 250, 152, 96, 151, 167, 159, 205, 183, 14, 197, 123, 90, 178, 130, 64, 140, 103, 86, 124, 197, 9, 176, 140, 149, 244, 185, 246, 75, 143, 229, 84, 195, 71, 17, 48, 166, 31, 121, 234, 187, 106, 254, 101, 42, 57, 201, 20, 253, 6, 30, 233, 208, 97, 215, 102, 51, 65, 12, 30, 117, 218, 88, 14, 92, 139, 248, 224, 96, 251, 73, 98, 14, 246, 32, 122, 212, 199, 150, 11, 158, 152, 210, 47, 9, 74, 156, 17, 51, 194, 199, 230, 80, 152, 217, 82, 139, 29, 13, 236, 105, 18, 173, 253, 6, 75, 93, 234, 232, 196, 193, 180, 222, 135, 100, 158, 104, 40, 134, 249, 28 },
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
﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoGallery_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class changeColumnSectionUploadData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dataSource",
                table: "API_SectionUploadPathData",
                newName: "sizeFile");

            migrationBuilder.AddColumn<string>(
                name: "fileExtension",
                table: "API_SectionUploadPathData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 151, 143, 86, 3, 162, 80, 251, 177, 169, 204, 174, 215, 206, 105, 155, 218, 209, 147, 19, 208, 126, 93, 191, 52, 163, 191, 62, 216, 18, 43, 111, 68, 224, 204, 111, 44, 234, 228, 4, 16, 37, 80, 151, 98, 92, 114, 157, 115, 52, 186, 86, 136, 15, 82, 110, 251, 12, 192, 145, 174, 71, 6, 152, 69 }, new byte[] { 99, 147, 113, 183, 132, 61, 30, 199, 66, 24, 111, 247, 32, 79, 24, 166, 208, 243, 22, 178, 124, 229, 166, 20, 103, 47, 15, 186, 72, 30, 201, 124, 121, 104, 232, 234, 239, 123, 89, 191, 155, 50, 233, 252, 109, 102, 121, 193, 139, 43, 227, 237, 77, 189, 162, 145, 247, 233, 94, 198, 18, 93, 45, 86, 95, 246, 235, 36, 124, 73, 231, 112, 160, 251, 81, 254, 129, 24, 15, 28, 251, 201, 169, 23, 120, 43, 113, 242, 175, 55, 106, 195, 176, 104, 254, 161, 229, 31, 182, 23, 98, 216, 98, 111, 88, 110, 91, 209, 128, 52, 114, 166, 26, 13, 111, 54, 252, 248, 251, 151, 101, 57, 127, 88, 153, 198, 9, 85 } });

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 236, 156, 215, 53, 163, 139, 3, 50, 244, 127, 217, 219, 54, 230, 91, 252, 238, 239, 15, 164, 106, 140, 246, 129, 126, 5, 116, 238, 186, 10, 216, 211, 156, 195, 172, 183, 190, 76, 170, 164, 173, 0, 164, 76, 239, 183, 178, 144, 154, 57, 194, 247, 32, 136, 251, 124, 2, 59, 8, 28, 21, 67, 156, 120 }, new byte[] { 49, 92, 245, 8, 178, 178, 243, 222, 168, 95, 185, 209, 179, 161, 16, 190, 50, 201, 230, 174, 157, 105, 241, 131, 231, 139, 206, 207, 153, 140, 73, 61, 183, 101, 94, 73, 128, 64, 215, 5, 162, 183, 213, 89, 160, 205, 92, 14, 52, 56, 35, 126, 105, 168, 34, 90, 229, 31, 161, 155, 110, 162, 107, 43, 61, 17, 101, 122, 227, 3, 164, 7, 13, 179, 139, 241, 125, 174, 122, 136, 20, 67, 23, 146, 56, 248, 70, 14, 110, 236, 57, 104, 152, 42, 210, 214, 133, 110, 69, 9, 48, 34, 65, 83, 250, 15, 162, 28, 242, 215, 141, 221, 74, 158, 50, 75, 68, 120, 80, 228, 66, 84, 244, 168, 31, 236, 24, 2 } });

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 254, 161, 133, 219, 87, 120, 183, 111, 1, 100, 219, 231, 247, 152, 67, 67, 135, 95, 160, 186, 45, 198, 47, 42, 23, 98, 146, 135, 112, 222, 92, 151, 180, 202, 187, 90, 6, 183, 186, 192, 52, 189, 106, 56, 192, 88, 19, 91, 145, 128, 228, 142, 56, 131, 185, 189, 190, 102, 46, 199, 0, 176, 224, 238 }, new byte[] { 223, 224, 130, 9, 85, 226, 132, 25, 54, 105, 232, 15, 97, 62, 116, 159, 122, 191, 176, 167, 1, 124, 243, 185, 190, 227, 103, 134, 211, 230, 254, 3, 255, 137, 89, 224, 57, 162, 93, 37, 209, 142, 179, 68, 241, 72, 122, 43, 26, 142, 88, 38, 36, 244, 155, 254, 60, 148, 91, 6, 239, 94, 236, 225, 216, 46, 47, 248, 169, 223, 153, 50, 226, 61, 215, 135, 101, 215, 99, 165, 179, 61, 98, 10, 158, 227, 112, 166, 167, 102, 44, 50, 34, 197, 27, 114, 144, 37, 248, 2, 243, 111, 16, 165, 39, 195, 98, 77, 90, 97, 217, 125, 132, 152, 92, 80, 12, 156, 189, 235, 108, 195, 79, 113, 225, 88, 19, 29 } });

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 200, 243, 170, 49, 51, 246, 113, 214, 111, 6, 36, 53, 88, 129, 219, 4, 77, 43, 15, 64, 205, 125, 215, 151, 201, 164, 31, 206, 227, 231, 218, 164, 130, 255, 6, 80, 136, 19, 75, 82, 153, 65, 67, 208, 49, 1, 159, 55, 193, 232, 74, 7, 228, 66, 236, 106, 160, 39, 36, 139, 180, 150, 120, 53 }, new byte[] { 77, 8, 88, 212, 56, 157, 51, 61, 82, 1, 81, 5, 72, 158, 76, 202, 16, 33, 46, 15, 39, 21, 252, 211, 14, 155, 159, 169, 194, 241, 194, 55, 115, 21, 188, 49, 107, 71, 53, 31, 179, 49, 75, 122, 164, 167, 200, 170, 145, 126, 181, 34, 109, 153, 25, 203, 160, 118, 150, 186, 51, 221, 82, 155, 43, 112, 112, 8, 242, 103, 104, 203, 150, 127, 249, 127, 31, 145, 244, 185, 12, 85, 239, 71, 117, 201, 228, 1, 29, 0, 23, 174, 74, 142, 69, 67, 164, 236, 62, 72, 244, 218, 240, 86, 253, 25, 219, 255, 0, 60, 116, 89, 131, 4, 34, 108, 194, 49, 155, 131, 244, 86, 17, 153, 184, 125, 116, 208 } });

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 166, 76, 22, 162, 176, 199, 180, 230, 115, 86, 157, 133, 22, 91, 61, 215, 124, 38, 250, 62, 66, 82, 4, 210, 158, 252, 29, 153, 32, 40, 3, 88, 71, 114, 27, 81, 31, 255, 226, 147, 177, 206, 229, 108, 182, 4, 1, 96, 242, 2, 77, 129, 48, 243, 42, 97, 4, 38, 157, 92, 48, 89, 145, 212 }, new byte[] { 175, 223, 125, 250, 117, 229, 162, 144, 221, 240, 10, 62, 67, 12, 6, 32, 85, 227, 177, 134, 105, 249, 106, 162, 77, 87, 103, 133, 139, 230, 62, 231, 84, 82, 29, 184, 59, 56, 94, 206, 167, 135, 116, 61, 43, 224, 170, 113, 75, 88, 122, 48, 250, 132, 227, 204, 220, 113, 26, 128, 168, 225, 157, 61, 182, 5, 251, 219, 17, 236, 96, 139, 32, 247, 187, 7, 221, 175, 25, 32, 72, 196, 166, 16, 29, 84, 70, 114, 76, 217, 164, 132, 156, 16, 182, 192, 117, 41, 16, 164, 48, 212, 112, 114, 69, 121, 110, 206, 8, 211, 157, 155, 224, 224, 103, 142, 78, 125, 199, 227, 129, 144, 122, 140, 30, 250, 230, 241 } });

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 9, 139, 54, 53, 179, 160, 42, 176, 121, 79, 157, 126, 138, 43, 112, 169, 212, 40, 66, 41, 106, 52, 33, 34, 122, 5, 20, 50, 157, 228, 151, 218, 102, 170, 59, 108, 74, 224, 129, 96, 134, 157, 96, 213, 148, 109, 7, 76, 58, 39, 138, 247, 190, 76, 78, 63, 145, 203, 131, 27, 116, 217, 87, 142 }, new byte[] { 238, 237, 164, 124, 57, 46, 144, 160, 22, 162, 134, 38, 8, 57, 191, 142, 36, 13, 19, 2, 21, 10, 145, 125, 37, 47, 17, 188, 26, 62, 78, 76, 19, 188, 118, 81, 211, 48, 139, 159, 220, 61, 75, 194, 65, 60, 183, 142, 94, 103, 118, 136, 212, 104, 180, 94, 94, 123, 193, 241, 64, 210, 36, 22, 245, 158, 106, 234, 141, 223, 176, 223, 140, 199, 197, 38, 241, 42, 28, 123, 4, 211, 197, 46, 232, 19, 203, 56, 113, 84, 14, 183, 141, 121, 75, 7, 248, 143, 220, 116, 52, 105, 43, 194, 136, 56, 203, 227, 245, 134, 233, 76, 219, 51, 204, 95, 206, 153, 250, 163, 128, 72, 20, 178, 108, 77, 245, 66 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fileExtension",
                table: "API_SectionUploadPathData");

            migrationBuilder.RenameColumn(
                name: "sizeFile",
                table: "API_SectionUploadPathData",
                newName: "dataSource");

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 238, 53, 17, 173, 232, 175, 182, 3, 170, 124, 37, 143, 19, 30, 66, 145, 213, 32, 131, 13, 23, 162, 171, 84, 143, 184, 20, 136, 18, 30, 235, 7, 76, 253, 21, 108, 81, 29, 39, 127, 172, 195, 7, 132, 83, 211, 67, 197, 132, 103, 168, 64, 80, 187, 90, 215, 85, 129, 236, 200, 150, 11, 199, 66 }, new byte[] { 205, 251, 72, 167, 4, 123, 33, 226, 38, 67, 235, 131, 215, 129, 177, 106, 240, 244, 192, 189, 75, 221, 79, 176, 191, 113, 1, 59, 183, 96, 103, 236, 171, 229, 95, 169, 202, 152, 25, 69, 97, 205, 86, 254, 96, 197, 199, 136, 235, 176, 26, 251, 107, 107, 214, 26, 106, 224, 152, 241, 193, 68, 32, 1, 139, 63, 140, 164, 175, 92, 177, 115, 85, 94, 59, 14, 202, 94, 195, 67, 55, 80, 233, 122, 220, 11, 7, 229, 189, 69, 218, 13, 63, 11, 163, 177, 17, 140, 32, 10, 61, 11, 16, 4, 1, 6, 121, 186, 6, 127, 149, 92, 170, 228, 182, 147, 124, 68, 112, 84, 78, 203, 193, 110, 197, 199, 100, 129 } });

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 8, 206, 191, 0, 172, 183, 253, 251, 153, 116, 47, 116, 44, 243, 243, 121, 154, 49, 220, 183, 145, 47, 96, 18, 27, 203, 230, 66, 52, 208, 239, 51, 167, 97, 18, 237, 30, 236, 220, 152, 120, 126, 227, 13, 173, 80, 154, 18, 32, 182, 21, 111, 223, 3, 60, 90, 209, 24, 210, 188, 29, 143, 243, 25 }, new byte[] { 23, 130, 60, 2, 12, 106, 14, 185, 81, 34, 17, 231, 116, 192, 241, 236, 126, 82, 214, 160, 41, 168, 164, 106, 238, 251, 2, 234, 175, 109, 164, 225, 57, 136, 9, 117, 52, 32, 37, 198, 43, 170, 203, 9, 240, 156, 156, 23, 6, 83, 77, 173, 83, 160, 193, 60, 228, 107, 249, 194, 199, 142, 121, 90, 175, 70, 180, 21, 119, 32, 159, 69, 49, 177, 8, 240, 159, 23, 115, 77, 194, 242, 168, 1, 213, 152, 118, 97, 99, 174, 140, 142, 11, 1, 86, 200, 77, 109, 192, 177, 32, 41, 54, 253, 234, 238, 213, 207, 115, 216, 116, 158, 143, 53, 120, 212, 9, 0, 129, 38, 82, 193, 32, 124, 229, 49, 82, 244 } });

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 155, 28, 173, 77, 77, 65, 100, 96, 50, 159, 69, 228, 239, 95, 5, 58, 59, 58, 86, 206, 10, 213, 125, 132, 106, 150, 38, 102, 145, 116, 31, 245, 183, 57, 216, 70, 32, 63, 209, 36, 45, 34, 55, 26, 123, 15, 151, 158, 131, 7, 98, 117, 191, 39, 204, 153, 109, 131, 107, 71, 169, 220, 138, 195 }, new byte[] { 111, 114, 14, 188, 56, 8, 231, 81, 155, 43, 216, 51, 246, 116, 39, 125, 125, 20, 79, 108, 44, 173, 212, 130, 61, 204, 2, 223, 167, 87, 140, 162, 79, 60, 18, 244, 86, 41, 172, 82, 134, 80, 213, 230, 100, 252, 233, 32, 181, 34, 42, 202, 181, 100, 3, 108, 75, 90, 109, 199, 43, 110, 219, 70, 227, 48, 21, 174, 172, 5, 187, 138, 167, 103, 224, 63, 53, 189, 155, 169, 211, 197, 24, 124, 156, 8, 151, 176, 29, 80, 52, 249, 205, 207, 118, 156, 195, 173, 101, 134, 33, 127, 148, 159, 83, 2, 252, 186, 250, 203, 184, 162, 32, 208, 255, 174, 139, 203, 92, 149, 147, 110, 82, 45, 194, 231, 216, 104 } });

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 168, 238, 78, 130, 31, 147, 208, 61, 239, 158, 178, 246, 14, 41, 26, 109, 246, 254, 76, 70, 33, 125, 208, 245, 169, 169, 11, 220, 100, 134, 211, 224, 220, 27, 92, 91, 185, 108, 53, 63, 198, 203, 63, 94, 131, 148, 32, 147, 135, 201, 148, 129, 197, 1, 46, 196, 196, 213, 13, 149, 191, 108, 126, 106 }, new byte[] { 132, 192, 184, 23, 237, 116, 122, 252, 53, 194, 254, 225, 81, 209, 220, 195, 196, 15, 111, 89, 247, 195, 21, 234, 137, 3, 230, 150, 167, 110, 203, 80, 70, 199, 64, 96, 239, 255, 170, 154, 102, 116, 208, 195, 204, 186, 212, 68, 141, 249, 185, 31, 94, 2, 78, 33, 63, 138, 214, 98, 114, 127, 73, 95, 198, 215, 82, 171, 234, 174, 95, 69, 7, 218, 50, 169, 152, 200, 213, 161, 51, 153, 98, 73, 39, 28, 68, 222, 43, 241, 94, 18, 35, 55, 158, 187, 28, 4, 233, 215, 2, 116, 255, 111, 70, 68, 234, 154, 128, 57, 81, 199, 242, 24, 104, 194, 11, 213, 55, 29, 173, 184, 4, 37, 153, 207, 96, 108 } });

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 5, 39, 157, 206, 68, 179, 128, 110, 241, 185, 175, 231, 153, 219, 123, 139, 173, 64, 189, 216, 149, 150, 185, 39, 139, 221, 101, 88, 220, 49, 176, 118, 119, 235, 213, 166, 162, 239, 246, 12, 4, 226, 211, 109, 212, 161, 86, 120, 105, 40, 84, 207, 172, 207, 23, 228, 147, 99, 158, 126, 240, 7, 202, 157 }, new byte[] { 83, 118, 164, 181, 182, 126, 46, 23, 185, 79, 96, 73, 201, 238, 147, 64, 149, 253, 216, 221, 226, 208, 58, 3, 151, 212, 15, 177, 106, 193, 241, 248, 85, 141, 57, 226, 15, 89, 221, 154, 59, 169, 45, 237, 214, 200, 110, 121, 230, 160, 222, 61, 47, 129, 72, 35, 34, 172, 235, 32, 138, 186, 123, 206, 55, 113, 82, 62, 58, 217, 219, 110, 164, 253, 3, 110, 223, 179, 75, 234, 61, 163, 58, 215, 25, 92, 173, 177, 172, 34, 165, 173, 97, 48, 102, 32, 217, 133, 111, 203, 211, 162, 224, 140, 60, 228, 204, 216, 153, 229, 137, 173, 219, 58, 210, 10, 144, 131, 230, 132, 1, 154, 84, 32, 44, 75, 90, 12 } });

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 55, 47, 189, 75, 76, 104, 69, 240, 217, 116, 121, 211, 226, 32, 148, 239, 2, 111, 205, 66, 104, 143, 250, 235, 224, 174, 123, 189, 37, 202, 214, 23, 203, 212, 181, 91, 207, 103, 151, 99, 64, 183, 47, 58, 38, 167, 130, 104, 96, 209, 20, 110, 189, 119, 146, 9, 108, 82, 133, 219, 81, 207, 4, 204 }, new byte[] { 106, 25, 113, 28, 229, 81, 96, 107, 76, 78, 164, 90, 91, 156, 74, 64, 111, 254, 205, 170, 209, 189, 48, 175, 158, 156, 71, 12, 129, 75, 195, 63, 242, 82, 94, 170, 118, 145, 36, 140, 111, 226, 65, 208, 51, 17, 167, 206, 79, 226, 252, 112, 45, 62, 116, 2, 86, 1, 252, 145, 62, 96, 149, 46, 48, 113, 14, 79, 75, 172, 152, 212, 108, 149, 227, 135, 51, 237, 61, 66, 218, 70, 11, 57, 6, 178, 102, 143, 24, 9, 82, 198, 138, 246, 62, 66, 47, 113, 15, 104, 220, 241, 35, 253, 75, 188, 248, 119, 174, 231, 243, 90, 210, 41, 41, 231, 183, 1, 176, 185, 66, 101, 195, 105, 207, 212, 4, 128 } });
        }
    }
}
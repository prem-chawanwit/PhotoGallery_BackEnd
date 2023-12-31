﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoGallery_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class addLoginTimesIsLoggedIn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isLoggedIn",
                table: "API_LoginTimming",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isLoggedIn",
                table: "API_LoginTimming");

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 110, 168, 30, 28, 251, 168, 150, 188, 132, 27, 141, 111, 220, 214, 168, 189, 212, 100, 104, 105, 249, 244, 233, 36, 170, 137, 77, 182, 28, 159, 83, 88, 107, 229, 110, 188, 193, 48, 161, 45, 239, 195, 238, 18, 190, 204, 17, 105, 67, 149, 239, 66, 191, 76, 46, 129, 135, 93, 177, 139, 59, 18, 28, 19 }, new byte[] { 146, 225, 32, 237, 255, 12, 9, 78, 75, 232, 181, 124, 241, 233, 27, 121, 168, 185, 144, 36, 132, 147, 255, 13, 189, 23, 30, 181, 107, 25, 251, 34, 205, 84, 172, 184, 37, 146, 144, 99, 184, 208, 58, 214, 44, 178, 250, 60, 8, 241, 163, 176, 142, 27, 240, 138, 222, 223, 115, 6, 52, 28, 221, 197, 111, 240, 209, 0, 150, 255, 80, 241, 99, 30, 154, 21, 22, 178, 228, 26, 128, 212, 86, 96, 87, 23, 63, 121, 200, 222, 199, 164, 176, 184, 208, 15, 160, 55, 153, 136, 100, 83, 103, 182, 200, 155, 249, 53, 249, 208, 113, 163, 104, 154, 10, 177, 191, 119, 189, 184, 207, 216, 87, 233, 252, 217, 145, 150 } });

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 16, 167, 91, 255, 252, 22, 226, 102, 132, 29, 178, 10, 131, 120, 36, 171, 52, 138, 123, 4, 129, 155, 231, 167, 30, 176, 61, 230, 40, 111, 183, 196, 153, 112, 223, 194, 73, 19, 198, 45, 4, 216, 109, 75, 163, 44, 95, 116, 121, 75, 90, 115, 189, 30, 58, 137, 125, 138, 201, 197, 156, 241, 178, 71 }, new byte[] { 78, 206, 111, 238, 114, 221, 146, 4, 151, 42, 216, 148, 197, 201, 183, 186, 154, 190, 180, 62, 194, 37, 84, 220, 222, 210, 249, 161, 139, 15, 251, 23, 150, 151, 193, 242, 180, 20, 167, 113, 189, 191, 15, 167, 39, 253, 205, 247, 22, 11, 73, 92, 30, 220, 241, 214, 24, 55, 118, 252, 218, 163, 64, 123, 108, 73, 155, 86, 25, 87, 207, 183, 125, 242, 194, 59, 177, 38, 116, 168, 254, 225, 27, 61, 232, 2, 62, 253, 33, 101, 131, 108, 241, 49, 188, 196, 83, 91, 138, 146, 197, 7, 107, 138, 107, 50, 39, 5, 248, 50, 249, 82, 153, 49, 154, 158, 195, 46, 225, 71, 79, 196, 4, 170, 6, 64, 1, 81 } });

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 100, 42, 94, 129, 19, 219, 88, 122, 199, 107, 170, 145, 78, 237, 226, 126, 210, 194, 186, 152, 228, 229, 199, 51, 145, 165, 121, 172, 128, 11, 57, 235, 69, 94, 159, 155, 249, 180, 102, 88, 111, 193, 115, 7, 52, 211, 82, 85, 86, 223, 17, 45, 150, 38, 58, 119, 113, 106, 100, 181, 149, 141, 242, 112 }, new byte[] { 236, 22, 21, 49, 216, 77, 29, 187, 229, 48, 110, 80, 98, 32, 34, 138, 248, 230, 141, 55, 96, 46, 32, 108, 84, 174, 230, 243, 238, 242, 59, 42, 109, 116, 152, 227, 123, 116, 136, 187, 14, 108, 92, 109, 56, 215, 154, 31, 231, 105, 45, 195, 114, 203, 120, 98, 199, 14, 202, 55, 107, 190, 157, 75, 83, 196, 170, 128, 208, 87, 250, 124, 155, 40, 44, 1, 219, 131, 87, 78, 178, 233, 132, 43, 196, 129, 102, 170, 17, 108, 199, 251, 54, 20, 229, 31, 174, 139, 237, 170, 107, 6, 228, 31, 27, 216, 184, 3, 249, 128, 99, 14, 217, 15, 18, 253, 236, 76, 255, 129, 17, 30, 2, 19, 67, 47, 1, 137 } });

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 54, 30, 142, 192, 155, 185, 160, 168, 179, 23, 139, 77, 215, 226, 204, 182, 156, 137, 188, 45, 18, 10, 239, 208, 1, 207, 219, 58, 147, 153, 197, 143, 119, 196, 107, 115, 148, 249, 224, 216, 241, 55, 234, 243, 96, 243, 35, 38, 190, 82, 202, 52, 16, 52, 175, 108, 223, 197, 215, 93, 220, 65, 148, 98 }, new byte[] { 227, 131, 118, 82, 83, 40, 72, 10, 82, 254, 117, 25, 192, 97, 165, 219, 44, 128, 157, 65, 236, 44, 74, 53, 252, 162, 95, 1, 19, 90, 97, 59, 212, 166, 105, 24, 228, 29, 177, 81, 223, 226, 153, 66, 244, 232, 165, 110, 119, 72, 121, 93, 142, 26, 196, 40, 101, 246, 153, 191, 151, 21, 58, 64, 238, 237, 97, 21, 248, 169, 45, 57, 104, 49, 204, 102, 6, 162, 203, 131, 240, 16, 175, 71, 172, 129, 41, 8, 142, 58, 42, 86, 253, 40, 100, 84, 17, 183, 125, 37, 172, 168, 174, 146, 98, 237, 43, 194, 57, 242, 4, 106, 8, 241, 42, 249, 108, 87, 12, 246, 78, 227, 219, 251, 134, 226, 145, 79 } });

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 41, 8, 230, 179, 74, 82, 166, 144, 8, 69, 115, 217, 161, 100, 246, 73, 221, 249, 85, 129, 249, 17, 151, 116, 43, 49, 92, 183, 175, 4, 5, 31, 125, 108, 112, 142, 89, 77, 243, 94, 191, 81, 91, 208, 203, 87, 13, 12, 173, 220, 10, 106, 65, 92, 28, 253, 73, 2, 195, 236, 21, 183, 45, 38 }, new byte[] { 39, 112, 189, 219, 106, 96, 219, 60, 179, 222, 213, 132, 190, 254, 53, 139, 211, 142, 179, 31, 83, 20, 49, 113, 160, 26, 135, 24, 55, 18, 118, 191, 184, 90, 26, 250, 38, 190, 36, 28, 22, 248, 10, 173, 68, 52, 119, 49, 72, 189, 172, 112, 229, 203, 242, 95, 63, 127, 243, 239, 109, 242, 103, 236, 248, 42, 172, 85, 59, 15, 223, 62, 204, 82, 88, 70, 190, 127, 138, 167, 115, 236, 118, 164, 248, 160, 96, 203, 69, 168, 73, 142, 120, 86, 26, 251, 8, 55, 229, 43, 17, 6, 37, 147, 76, 156, 189, 148, 219, 169, 30, 142, 242, 22, 162, 207, 51, 243, 213, 210, 194, 52, 226, 46, 234, 104, 149, 74 } });

            migrationBuilder.UpdateData(
                table: "API_Users",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "passwordHash", "passwordSalt" },
                values: new object[] { new byte[] { 170, 254, 168, 193, 33, 31, 204, 54, 85, 191, 159, 69, 235, 51, 217, 44, 98, 4, 53, 73, 13, 203, 100, 122, 125, 126, 185, 17, 229, 236, 92, 194, 212, 9, 209, 121, 0, 229, 30, 213, 195, 126, 14, 188, 88, 25, 99, 136, 151, 46, 178, 143, 68, 16, 65, 246, 124, 248, 150, 219, 88, 150, 44, 243 }, new byte[] { 94, 89, 45, 51, 87, 14, 102, 248, 170, 135, 176, 113, 85, 103, 170, 151, 36, 46, 80, 41, 220, 209, 246, 168, 36, 142, 209, 169, 253, 71, 95, 72, 208, 204, 36, 207, 49, 244, 187, 207, 19, 196, 243, 71, 180, 24, 98, 245, 72, 208, 80, 153, 186, 179, 91, 188, 37, 49, 101, 213, 189, 126, 22, 209, 127, 252, 28, 185, 52, 174, 194, 46, 39, 32, 56, 177, 14, 64, 2, 235, 104, 48, 9, 236, 83, 76, 238, 243, 138, 206, 198, 53, 43, 35, 107, 20, 76, 72, 139, 123, 65, 144, 214, 206, 243, 43, 170, 217, 33, 251, 157, 208, 81, 33, 43, 99, 0, 139, 151, 220, 4, 122, 94, 154, 177, 94, 0, 163 } });
        }
    }
}

namespace PhotoGallery_BackEnd.Models.Users
{
    public enum AccessLevelRoles
    {
        [EnumMember(Value = "SuperAdmin")]
        SuperAdmin,
        [EnumMember(Value = "Admin")]
        Admin,
        [EnumMember(Value = "User")]
        User,
        [EnumMember(Value = "Guest")]
        Guest,
        [EnumMember(Value = "Unknown")]
        Unknown,
    }
}

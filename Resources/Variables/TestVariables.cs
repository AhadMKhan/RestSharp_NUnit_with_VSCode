public static class TestVariables
{
    public static string DynamicAuthToken { get; set; } = "";
    public static int DynamicResponseCode { get; set; }
    public static int DynamicBookingId { get; set; }
    public static string? DynamicFirstName { get; set; }
    public static string? DynamicLastName { get; set; }
    public static string? DynamicAdditionalNeeds { get; set; }

    public static string DefaultFirstname { get; } = "Automation";
    public static string DefaultLastname { get; } = "Test";
    public static string DefaultAdditionalneeds { get; } = "Breakfast";
    public static string UpdateFirstname { get; } = "Ahad";
    public static string UpdateLastname { get; } = "Khan";
    public static string UpdateAdditionalneeds { get; } = "Dinner";
}

namespace Constants
{
    public static class Failed
    {
        public static string ToFindUser(Guid key) => $"User with primary key '{key}' is not found";
    }
}

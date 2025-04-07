namespace FamilyTree.Api;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class Family
    {
        private const string Base = $"{ApiBase}/family";

        public const string GetAll = Base;
        public const string GetMembers = $"{Base}/members";
    }

    public static class Health
    {
        private const string Base = $"{ApiBase}/health";
        public const string Get = Base;
    }
}

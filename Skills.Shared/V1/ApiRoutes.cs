namespace Skills.Shared.V1;

public static class ApiRoutes
{
    private const string Root = "api";
    private const string Version = "v1";

    private const string Base = Root + "/" + Version;

    public static class CharacterRoute
    {
        private const string baseRoute = "/character";

        public const string Get = Base + baseRoute;

        public const string GetList = Base + baseRoute + "s";

        public const string Create = Base + baseRoute;

        public const string Update = Base + baseRoute + "/{characterId}";

        public const string Delete = Base + baseRoute + "/{characterId}";
    }

    public static class FileRoute
    {
        private const string baseRoute = "/file";

        public const string Get = Base + baseRoute;

        public const string Create = Base + baseRoute;

        public const string Delete = Base + baseRoute + "/{fileId}";
    }

    public static class FileMessageRoute
    {
        private const string baseRoute = "/fileMessage";

        public const string Get = Base + baseRoute;

        public const string Create = Base + baseRoute;

        public const string Delete = Base + baseRoute + "/{fileId}";
    }

    public static class StartingPageRoute
    {
        public const string Get = Base + "/startingPage";
    }
}

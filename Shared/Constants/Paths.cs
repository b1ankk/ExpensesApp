namespace ExpensesApp.Shared.Constants
{
    public static class Paths
    {
        public static class Api
        {
            public const string Root = "api";

            public const string Operations = Root + "/operations";
            public const string VerboseOperations = Operations + "/verbose";
            public const string OperationTypes = Root + "/operation_types";
            public const string OperationOwners = Root + "/operation_owners";

            public static string Operation(int id) {
                return $"{Operations}/{id}";
            }
        }

        public static class Page
        {
            public const string Root = "";
            public const string Home = Root;
            public const string Operations = Root + "/operations";
            public const string EditOperation = Operations + "/edit";
        }
    }
}

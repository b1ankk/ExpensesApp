namespace ExpensesApp.Shared.Constants
{
    public static class Paths
    {
        public static class Api
        {
            public const string Root = "api";

            public const string Operations = Root + "/operations";
            public const string VerboseOperations = Operations + "/verbose";
            public const string OperationTypes = Root + "/operation-types";
            public const string OperationOwners = Root + "/operation-owners";

            public const string AccountingPeriods = Root + "/accounting-periods";

            public static string Operation(int id) {
                return $"{Operations}/{id}";
            }

            public static string AccountingPeriodSummary(int idPeriod) {
                return $"{AccountingPeriods}/{idPeriod}/summary";
            }
        }

        public static class Page
        {
            public const string Root = "";
            public const string Home = Root;
            public const string Operations = Root + "/operations";
            public const string EditOperation = Operations + "/edit";
            public const string AccountingPeriods = Root + "accounting-periods";
            
            public static string AccountingPeriodSummary(int idPeriod) {
                return $"{AccountingPeriods}/{idPeriod}/summary";
            }
        }
    }
}

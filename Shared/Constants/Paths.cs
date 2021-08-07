namespace ExpensesApp.Shared.Constants
{
    public static class Paths
    {
        public static class Api
        {
            public const string ApiRoot = "api";
            
            public const string Operations = ApiRoot + "/operations";
            public const string VerboseOperations = Operations + "/verbose";
            public const string OperationTypes =  ApiRoot + "/operation_types";
            
            public static string Operation(int id) {
                return $"{Operations}/{id}";
            }
        }
        
        public static class Page
        {
            public const string Operations = "operations";
            public const string EditOperation = Operations + "/edit";
        }
        
    }
}

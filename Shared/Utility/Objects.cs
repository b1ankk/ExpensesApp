namespace ExpensesApp.Shared.Utility
{
    public static class Objects
    {
        public static void SetProperties(this object destination, object source) {
            CopyProperties(source, destination);
        }
        
        public static void CopyProperties(object source, object destination) {
            var destProperties = destination.GetType().GetProperties();
            
            foreach (var destProperty in destProperties) {
                var sourceProperty = source.GetType().GetProperty(destProperty.Name);
                if (sourceProperty != null)
                    destProperty.SetValue(destination, sourceProperty.GetValue(source));
            }
        }
    }
}

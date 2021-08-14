using System.Reflection;

namespace ExpensesApp.Shared.Utility
{
    public static class Objects
    {
        public static void SetProperties(this object destination, object source) {
            CopyProperties(source, destination);
        }

        public static void CopyProperties(object source, object destination) {
            PropertyInfo[] destProperties = destination.GetType().GetProperties();

            foreach (PropertyInfo destProperty in destProperties) {
                PropertyInfo sourceProperty = source.GetType().GetProperty(destProperty.Name);
                if (sourceProperty != null)
                    destProperty.SetValue(destination, sourceProperty.GetValue(source));
            }
        }
    }
}

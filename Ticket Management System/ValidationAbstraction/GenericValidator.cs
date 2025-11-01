using System.Reflection;

namespace Ticket_Management_System.ValidationAbstraction
{
    public static class GenericValidator
    {
        public static ValidationResult Validate<T>(T obj)
        {
            if (obj == null)
                return ValidationResult.Fail($"{typeof(T).Name} cannot be null.");

            var type = typeof(T);

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var attr = prop.GetCustomAttribute<RequiredFieldAttribute>();
                if (attr == null)
                    continue;

                var value = prop.GetValue(obj);
                bool isInvalid =
                    value == null ||
                    (value is string str && string.IsNullOrWhiteSpace(str)) ||
                    (value is int i && i == 0);

                if (isInvalid)
                {
                    var message = attr.ErrorMessage ??
                                  $"{prop.Name} is required in {typeof(T).Name}.";
                    return ValidationResult.Fail(message);
                }
            }

            return ValidationResult.Success();
        }
    }
}

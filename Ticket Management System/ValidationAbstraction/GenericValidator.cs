using System;
using System.Reflection;

namespace Ticket_Management_System.ValidationAbstraction
{
    /// <summary>
    /// Provides generic validation helpers that inspect objects via reflection
    /// to enforce required fields and common identity checks.
    /// </summary>
    /// <remarks>
    /// - <see cref="Validate{T}(T)"/> scans all public instance properties of <typeparamref name="T"/>
    ///   for <see cref="RequiredFieldAttribute"/> and validates their values.
    /// - <see cref="ValidateWithId(object, int)"/> validates both an identifier and the supplied object,
    ///   appending the identifier to any error message for easier troubleshooting.
    /// - <see cref="ValidateWithIdOnly(int)"/> validates only the identifier and attempts a generic validation
    ///   invocation for consistency with other flows.
    /// </remarks>
    public static class GenericValidator
    {
        /// <summary>
        /// Validates an instance of <typeparamref name="T"/> by inspecting all public instance properties
        /// decorated with <see cref="RequiredFieldAttribute"/> and ensuring they are not default/empty.
        /// </summary>
        /// <typeparam name="T">The type of the object being validated.</typeparam>
        /// <param name="obj">The object instance to validate.</param>
        /// <returns>
        /// A <see cref="ValidationResult"/> indicating success when all required fields are valid;
        /// otherwise a failure result with the corresponding error message.
        /// </returns>
        /// <remarks>
        /// The following value kinds are considered invalid:
        /// - <c>null</c>
        /// - <see cref="string"/>: null, empty, or whitespace
        /// - <see cref="int"/>: <c>0</c>
        /// - <see cref="DateTime"/>: <see cref="DateTime.MinValue"/> (i.e., default)
        /// - <see cref="DateTimeOffset"/>: <see cref="DateTimeOffset.MinValue"/> (i.e., default)
        /// </remarks>
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
                    (value is int i && i == 0) ||
                    (value is DateTime dt && dt == default) ||
                    (value is DateTimeOffset dto && dto == default);

                if (isInvalid)
                {
                    var message = attr.ErrorMessage ??
                                  $"{prop.Name} is required in {typeof(T).Name}.";
                    return ValidationResult.Fail(message);
                }
            }

            return ValidationResult.Success();
        }

        /// <summary>
        /// Validates the specified <paramref name="id"/> and then validates the provided <paramref name="obj"/>
        /// using <see cref="Validate{T}(T)"/>. If validation fails, the error message is suffixed with the Id.
        /// </summary>
        /// <param name="obj">The object instance to validate.</param>
        /// <param name="id">The identifier to validate; must be greater than zero.</param>
        /// <returns>
        /// A <see cref="ValidationResult"/> indicating success when the Id is valid and the object passes validation;
        /// otherwise a failure result with an error message that includes the Id.
        /// </returns>
        /// <remarks>
        /// Uses reflection to construct and invoke the generic <see cref="Validate{T}(T)"/> method
        /// for the runtime type of <paramref name="obj"/>.
        /// </remarks>
        public static ValidationResult ValidateWithId(this object obj, int id)
        {
            if (id <= 0)
                return ValidationResult.Fail("Id must be greater than zero.");

            if (obj == null)
                return ValidationResult.Fail($"Object cannot be null. (Id: {id})");

            var method = typeof(GenericValidator).GetMethod(nameof(Validate), BindingFlags.Public | BindingFlags.Static);
            if (method == null)
                return ValidationResult.Fail("Validation method not found.");

            var generic = method.MakeGenericMethod(obj.GetType());
            var result = (ValidationResult)generic.Invoke(null, new[] { obj })!;

            if (!result.IsValid && !string.IsNullOrWhiteSpace(result.ErrorMessage))
                return ValidationResult.Fail($"{result.ErrorMessage} (Id: {id})");

            return result;
        }

        /// <summary>
        /// Validates that the provided <paramref name="id"/> is greater than zero.
        /// Additionally attempts to invoke the generic <see cref="Validate{T}(T)"/> using the Id's type
        /// to maintain a consistent validation pipeline.
        /// </summary>
        /// <param name="id">The identifier to validate; must be greater than zero.</param>
        /// <returns>
        /// A <see cref="ValidationResult"/> indicating success when the Id is valid; otherwise a failure result
        /// with an error message. If the generic validation flow provides an error message, the Id is appended.
        /// </returns>
        public static ValidationResult ValidateWithIdOnly(this int id)
        {
            if (id <= 0)
                return ValidationResult.Fail("Id must be greater than zero.");

            var method = typeof(GenericValidator).GetMethod(nameof(Validate), BindingFlags.Public | BindingFlags.Static);
            if (method == null)
                return ValidationResult.Fail("Validation method not found.");

            var generic = method.MakeGenericMethod(id.GetType());
            var result = (ValidationResult)generic.Invoke(null, new object?[] { id })!;

            if (!result.IsValid && !string.IsNullOrWhiteSpace(result.ErrorMessage))
                return ValidationResult.Fail($"{result.ErrorMessage} (Id: {id})");

            return result;
        }
    }
}
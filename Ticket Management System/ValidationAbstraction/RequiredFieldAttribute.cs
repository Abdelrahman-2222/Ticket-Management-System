namespace Ticket_Management_System.ValidationAbstraction
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredFieldAttribute : Attribute
    {
        public string? ErrorMessage { get; }

        public RequiredFieldAttribute(string? errorMessage = null)
        {
            ErrorMessage = errorMessage;
        }
    }
}

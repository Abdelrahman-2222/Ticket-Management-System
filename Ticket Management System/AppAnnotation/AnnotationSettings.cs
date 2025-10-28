namespace Ticket_Management_System.AppConfiguration
{
    public static class AnnotationSettings
    {
        public const int NameMaxLength = 30;
        public const int ContentMaxLength = 300;
        public const int NameMinLength = 3;
        public const string EmailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
    }
}

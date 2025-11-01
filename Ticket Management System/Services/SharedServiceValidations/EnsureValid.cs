using Ticket_Management_System.ValidationAbstraction;

namespace Ticket_Management_System.Services.SharedServiceValidations
{
    public class EnsureValid
    {
        public void EnsureValidDTOOnly<T>(T dto)
        {
            var result = GenericValidator.Validate(dto);
            if (!result.IsValid)
                throw new ArgumentException(result.ErrorMessage);
        }

        public void EnsureValidDTOWithID<T>(T dto, int id)
        {
            var result = GenericValidator.ValidateWithId(dto, id);
            if (!result.IsValid)
                throw new ArgumentException(result.ErrorMessage);
        }

        public void EnsureValidIDOnly(int id)
        {
            var result = GenericValidator.ValidateWithIdOnly(id);
            if (!result.IsValid)
                throw new ArgumentException(result.ErrorMessage);
        }

    }
}

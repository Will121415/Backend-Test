using System.ComponentModel.DataAnnotations;
using Entity;

namespace back_end.models
{
    public class ClientInputModel
    {
        [Required]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [MinLength(10,ErrorMessage="El campo debe tener MINIMO 10 caracteres")]
        [StringLength(10,ErrorMessage="El campo debe tener MAXIMO 10 caracteres")]
        public string Indentification { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Solo se permiten letras")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Solo se permiten letras")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Formato del telefono es invalido")]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Neighborhood { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Solo se permiten letras")]
        public string City { get; set; }
    }

    public class ClientViewModel: ClientInputModel
    {
        public ClientViewModel()
        {
            
        }

        public ClientViewModel(Client client)
        {
            Indentification = client.Indentification;
            Name = client.Name;
            LastName = client.LastName;
            Phone = client.Phone;
            Address = client.Address;
            Neighborhood = client.Neighborhood;
            City = client.City;
        }
    }
}
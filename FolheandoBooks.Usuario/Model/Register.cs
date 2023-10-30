using FolheandoBooks.Usuario.Model.Base;

namespace FolheandoBooks.Usuario.Model
{
    public class Register : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

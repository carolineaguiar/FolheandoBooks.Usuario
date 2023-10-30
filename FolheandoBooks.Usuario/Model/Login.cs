using FolheandoBooks.Usuario.Model.Base;

namespace FolheandoBooks.Usuario.Model
{
    public class Login : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

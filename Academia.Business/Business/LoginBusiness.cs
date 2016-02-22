using Academia.Entity;
using Academia.EntityFramework.Repository;
using System;
using System.Linq;

namespace Academia.Business
{
    public class LoginBusiness
    {
        #region Propriedades Protegidas

        protected UsuarioRepository _usuarioRepository { get; set; }

        #endregion

        #region Construtores

        public LoginBusiness()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        #endregion

        #region Métodos Públicos

        public Usuario ValidarLogin(Login login)
        {
            if (login == null)
            {
                throw new ArgumentException("O parâmetro login é obrigatório.");
            }

            if (string.IsNullOrEmpty(login.User))
            {
                throw new ArgumentException("O Usuario é obrigatório.");
            }

            if (string.IsNullOrEmpty(login.Password))
            {
                throw new ArgumentException("A Senha é obrigatória.");
            }

            var usuario = _usuarioRepository.ListarComFiltro(new UsuarioFilter { Login = login.User, Senha = login.Password }).SingleOrDefault();

            if (usuario == null)
            {
                throw new Exception("Login e/ou senha inválidos");
            }

            return usuario;
        }

        #endregion
    }
}

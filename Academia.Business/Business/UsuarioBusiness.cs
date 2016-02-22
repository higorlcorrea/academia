using Academia.Entity;
using Academia.EntityFramework.Repository;

namespace Academia.Business
{
    public class UsuarioBusiness
    {

        #region Propriedades Protegidas

        protected UsuarioRepository _usuarioRepository { get; set; }

        #endregion

        #region Construtores

        public UsuarioBusiness()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        #endregion

        #region Métodos Públicos

        public Usuario Obter(int idUsuario)
        {
            return _usuarioRepository.Obter(idUsuario);
        }

        #endregion

    }
}

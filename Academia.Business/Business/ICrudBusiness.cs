using Academia.Entity.Interfaces;
using System.Collections.Generic;

namespace Academia.Business.Business
{
    public interface ICrudBusiness<T>
        where T : class
    {
        #region Assinatura de Métodos

        void Inserir(T entidade);

        void Editar(T entidade);

        T Obter(int id);

        void Excluir(int id);

        List<T> Listar();

        #endregion
    }
}

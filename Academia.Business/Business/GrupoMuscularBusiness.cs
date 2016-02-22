using Academia.Entity;
using Academia.EntityFramework.Repository;
using System;
using System.Linq;
using System.Collections.Generic;
using Academia.Entity.Constantes;

namespace Academia.Business.Business
{
    public class GrupoMuscularBusiness : ICrudBusiness<GrupoMuscular>
    {
        #region Propriedades Protegidas

        public GrupoMuscularRepository _grupoMuscularRepository { get; set; }

        #endregion

        #region Construtores

        public GrupoMuscularBusiness()
        {
            _grupoMuscularRepository = new GrupoMuscularRepository();
        }

        #endregion

        #region Métodos Públicos

        public void Inserir(GrupoMuscular grupoMuscular)
        {
            if (grupoMuscular == null)
            {
                throw new Exception("O parâmetro estava vazio.");
            }

            var grupos = _grupoMuscularRepository.ListarComFiltro(new GrupoMuscularFilter { Nome = grupoMuscular.Nome });

            if (grupos.Count == 1)
            {
                throw new Exception("Já existe um Grupo Muscular com este Nome.");
            }

            _grupoMuscularRepository.Inserir(grupoMuscular);
        }

        public void Editar(GrupoMuscular grupoMuscular)
        {
            if (grupoMuscular == null)
            {
                throw new Exception("O parâmetro estava vazio.");
            }

            if (grupoMuscular.Id <= 0)
            {
                throw new Exception("O campo Id deve ser maior do que zero.");
            }

            var grupos = _grupoMuscularRepository.ListarComFiltro(new GrupoMuscularFilter { Nome = grupoMuscular.Nome });

            if (grupos.Count == 1 && grupos.First().Id != grupoMuscular.Id)
            {
                throw new Exception("Já existe um Grupo Muscular com este Nome.");
            }

            _grupoMuscularRepository.Editar(grupoMuscular);
        }

        public GrupoMuscular Obter(int id)
        {
            var grupo =  _grupoMuscularRepository.Obter(id);

            if (grupo == null)
            {
                throw new Exception(Mensagens.BUSCA_ERRO);
            }
            return grupo;
        }

        public void Excluir(int id)
        {
            _grupoMuscularRepository.Excluir(id);
        }

        public List<GrupoMuscular> Listar()
        {
            return _grupoMuscularRepository.ListarComFiltro(new GrupoMuscularFilter());
        }

        public List<GrupoMuscular> ListarComFiltro(GrupoMuscularFilter filtro)
        {
            return _grupoMuscularRepository.ListarComFiltro(filtro);
        }

        #endregion
        
    }
}

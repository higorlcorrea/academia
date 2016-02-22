using Academia.Entity;
using Academia.Entity.Constantes;
using Academia.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academia.Business.Business
{
    public class CargoBusiness : ICrudBusiness<Cargo>
    {
        #region Propriedades Protegidas

        public CargoRepository _cargoRepository { get; set; }

        #endregion

        #region Construtores

        public CargoBusiness()
        {
            _cargoRepository = new CargoRepository();
        }

        #endregion

        #region Métodos Públicos

        public void Inserir(Cargo cargo)
        {
            if(cargo == null)
            {
                throw new Exception("O parâmetro estava vazio.");
            }

            var cargos = _cargoRepository.ListarComFiltro(new CargoFilter { Nome = cargo.Nome });

            if (cargos.Count > 0)
            {
                throw new Exception("Já existe um Cargo com este Nome.");
            }

            _cargoRepository.Inserir(cargo);
        }

        public void Editar(Cargo cargo)
        {
            if (cargo == null)
            {
                throw new Exception("O parâmetro estava vazio.");
            }

            if (cargo.Id <= 0)
            {
                throw new Exception("O campo Id deve ser maior do que zero.");
            }

            var cargos = _cargoRepository.ListarComFiltro(new CargoFilter { Nome = cargo.Nome });

            if (cargos.Count == 1 && cargos.First().Id != cargo.Id)
            {
                throw new Exception("Já existe um Cargo com este Nome.");
            }

            _cargoRepository.Editar(cargo);
        }

        public Cargo Obter(int id)
        {
            var cargo = _cargoRepository.Obter(id);

            if (cargo == null)
            {
                throw new Exception(Mensagens.BUSCA_ERRO);
            }

            return cargo;
        }

        public void Excluir(int id)
        {
            _cargoRepository.Excluir(id);
        }

        public List<Cargo> Listar()
        {
            return _cargoRepository.ListarComFiltro(new CargoFilter());
        }

        public List<Cargo> ListarComFiltro(CargoFilter filter)
        {
            return _cargoRepository.ListarComFiltro(filter);
        }

        #endregion

    }
}

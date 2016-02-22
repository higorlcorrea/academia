using Academia.Entity;
using Academia.Entity.Constantes;
using Academia.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academia.Business.Business
{
    public class MaquinaBusiness : ICrudBusiness<Maquina>
    {
        #region Propriedades Protegidas

        public MaquinaRepository _maquinaRepository { get; set; }

        #endregion

        #region Construtores

        public MaquinaBusiness()
        {
            _maquinaRepository = new MaquinaRepository();
        }

        #endregion

        #region Métodos Públicos

        public void Inserir(Maquina maquina)
        {
            if (maquina == null)
            {
                throw new Exception("O parâmetro estava vazio.");
            }

            var Maquinas = _maquinaRepository.ListarComFiltro(new MaquinaFilter { Nome = maquina.Nome });

            if (Maquinas.Count > 0)
            {
                throw new Exception("Já existe um Máquina com este Nome.");
            }

            _maquinaRepository.Inserir(maquina);
        }

        public void Editar(Maquina maquina)
        {
            if (maquina == null)
            {
                throw new Exception("O parâmetro estava vazio.");
            }

            if (maquina.Id <= 0)
            {
                throw new Exception("O campo Id deve ser maior do que zero.");
            }

            var Maquinas = _maquinaRepository.ListarComFiltro(new MaquinaFilter { Nome = maquina.Nome, OrImagem = maquina.Imagem });

            if (Maquinas.Count == 1 && Maquinas.First().Id != maquina.Id)
            {
                throw new Exception("Já existe uma Máquina com este Nome.");
            }

            _maquinaRepository.Editar(maquina);
        }

        public Maquina Obter(int id)
        {
            var Maquina = _maquinaRepository.Obter(id);

            if (Maquina == null)
            {
                throw new Exception(Mensagens.BUSCA_ERRO);
            }

            return Maquina;
        }

        public void Excluir(int id)
        {
            _maquinaRepository.Excluir(id);
        }

        public List<Maquina> Listar()
        {
            return _maquinaRepository.ListarComFiltro(new MaquinaFilter());
        }

        public List<Maquina> ListarComFiltro(MaquinaFilter filter)
        {
            return _maquinaRepository.ListarComFiltro(filter);
        }

        #endregion
    }
}

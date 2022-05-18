using CRUDCaminhoes.Data;
using CRUDCaminhoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDCaminhoes.Repositorio
{
    public class CaminhaoRepositorio : ICaminhaoRepositorio
    {
        private readonly BancoContext _bancoContext;


        public CaminhaoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public CaminhaoModel Adicionar(CaminhaoModel caminhao)
        {         
            _bancoContext.Caminhao.Add(caminhao);
            _bancoContext.SaveChanges();

            return caminhao;

        }

        public bool Apagar(int id)
        {
            CaminhaoModel caminhaoDb = ListarPorId(id);

            if (caminhaoDb == null) throw new System.Exception("Erro na exclusão do registro.");

            _bancoContext.Caminhao.Remove(caminhaoDb);
            _bancoContext.SaveChanges();

            return true;
        }

        public CaminhaoModel Atualizar(CaminhaoModel caminhao)
        {
            CaminhaoModel caminhaoDb = ListarPorId(caminhao.Id);

            if (caminhaoDb == null) throw new System.Exception("Erro na atualização.");

            caminhaoDb.Nome = caminhao.Nome;
            caminhaoDb.Descricao = caminhao.Descricao;
            caminhaoDb.DataDeCriacao = caminhao.DataDeCriacao;

            _bancoContext.Caminhao.Update(caminhaoDb);
            _bancoContext.SaveChanges();
            return caminhaoDb;
        }

        public List<CaminhaoModel> BuscarTodos()
        {
            return _bancoContext.Caminhao.ToList();
        }

        public CaminhaoModel ListarPorId(int id)
        {
            return _bancoContext.Caminhao.FirstOrDefault(x => x.Id == id);
        }
    }
}

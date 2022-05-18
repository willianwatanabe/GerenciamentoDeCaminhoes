using CRUDCaminhoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDCaminhoes.Repositorio
{
    public interface ICaminhaoRepositorio
    {
        bool Apagar(int id);

        CaminhaoModel Atualizar(CaminhaoModel caminhao);

        CaminhaoModel ListarPorId(int id);

        List<CaminhaoModel> BuscarTodos();

        CaminhaoModel Adicionar(CaminhaoModel caminhao);



    }
}

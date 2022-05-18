using CRUDCaminhoes.Models;
using CRUDCaminhoes.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDCaminhoes.Controllers
{
    public class CaminhaoController : Controller
    {

        private readonly ICaminhaoRepositorio _caminhaoRepositorio;       

        public CaminhaoController(ICaminhaoRepositorio caminhaoRepositorio)
        {
            _caminhaoRepositorio = caminhaoRepositorio;
        }

        public IActionResult Index()
        {
            List<CaminhaoModel> caminhoes = _caminhaoRepositorio.BuscarTodos();
            return View(caminhoes);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(CaminhaoModel caminhao)
        {
            if (ModelState.IsValid)
            {
                _caminhaoRepositorio.Adicionar(caminhao);
                return RedirectToAction("Index");
            }
            return View(caminhao);
        }

        public IActionResult Editar(int id)
        {
            if (ModelState.IsValid)
            {
                CaminhaoModel caminhao = _caminhaoRepositorio.ListarPorId(id);
                return View(caminhao);
            }

            return View("Editar", id);
        }

        [HttpPost]
        public IActionResult Alterar(CaminhaoModel caminhao)
        {
            _caminhaoRepositorio.Atualizar(caminhao);
            return RedirectToAction("Index");
        }

        public IActionResult Detalhes(int id)
        {
            CaminhaoModel caminhao = _caminhaoRepositorio.ListarPorId(id);
            return View(caminhao);
        }

        public IActionResult DeletarConfirmar(int id)
        {
            CaminhaoModel caminhao = _caminhaoRepositorio.ListarPorId(id);
            return View(caminhao);
        }

        public IActionResult Deletar(int id)
        {
            _caminhaoRepositorio.Apagar(id);
            return RedirectToAction("Index");

        }

    }
}

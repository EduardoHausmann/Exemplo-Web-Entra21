using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class EstoqueController : Controller
    {
        EstoqueRepositorio reposirotio = new EstoqueRepositorio();

        // GET: Estoque
        public ActionResult Index()
        {
            List<Estoque> estoques = reposirotio.ObterTodos("");

            ViewBag.Estoques = estoques;

            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Store(string nome, int quantidade, decimal valor)
        {
            Estoque estoque = new Estoque();
            estoque.Nome = nome;
            estoque.Quantidade = quantidade;
            estoque.Valor = valor;
            int id = reposirotio.Inserir(estoque);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            reposirotio.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Estoque estoque = reposirotio.ObterPeloId(id);
            ViewBag.Estoque = estoque;

            return View();
        }

        public ActionResult Update(int id, string nome, int quantidade, decimal valor)
        {
            Estoque estoque = new Estoque();
            estoque.Id = id;
            estoque.Nome = nome;
            estoque.Quantidade = quantidade;
            estoque.Valor = valor;

            bool alterou = reposirotio.Atualizar(estoque);
            return RedirectToAction("Index");
        }
    }
}
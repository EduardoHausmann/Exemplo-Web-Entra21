using System.Web.Mvc;

namespace View.Controllers
{
    public class ColaboradorController : Controller
    {
        // GET: Colaborador
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro(string nome,
            string sobrenome)
        {
            string nomeCompleto = $"{nome} {sobrenome}";
            ViewBag.NomeCompleto = nomeCompleto;

            return View();
        }
    }
}
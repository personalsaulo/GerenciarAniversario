using Agenda.Models;
using System.Web.Mvc;
using System.Linq;

namespace Agenda.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        private static RepositorioDePessoas _pessoas = new RepositorioDePessoas();
        public ActionResult Index()
        {
            //var pessoa = new Pessoa();
            return View( _pessoas.listaPessoas);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
 

        // POST: Pessoa/Create
        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            _pessoas.CriaPessoa(pessoa);
            return View();
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(string nome)
        {
            var pessoa = _pessoas.listaPessoas.Where(s => s.Nome == nome).FirstOrDefault();
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(Pessoa pessoa)
        {
            var nome = pessoa.Nome;
            var sobrenome = pessoa.Sobrenome;

            return RedirectToAction("Index");
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

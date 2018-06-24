using Agenda.Models;
using System.Web.Mvc;
using System.Linq;

namespace Agenda.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        private static RepositorioDePessoas _pessoas = new RepositorioDePessoas();

        public ActionResult Index(string palavraDeBusca)
        {
            var pessoas = from p in _pessoas.listaPessoas
                          select p;
            if (!string.IsNullOrEmpty(palavraDeBusca))
                pessoas = pessoas.Where(b => b.Nome.Contains(palavraDeBusca));

            //var pessoa = new Pessoa();
            //return View( _pessoas.listaPessoas);
            return View(pessoas);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
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

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            var pessoa = _pessoas.listaPessoas.Where(s => s.id == id).FirstOrDefault();
            return View(pessoa);
        }
 
        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            var pessoa = _pessoas.listaPessoas.Where(s => s.id == id).FirstOrDefault();
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(Pessoa pessoa)
        {
            if (!ModelState.IsValid) return View();

            //var original = (from item in _pessoas.listaPessoas where item.id == pessoa.id select item).First();

            var itemIndex = _pessoas.listaPessoas.FindIndex(x => x.id == pessoa.id);
            var item = _pessoas.listaPessoas.ElementAt(itemIndex);
            _pessoas.listaPessoas.RemoveAt(itemIndex);
            item.id = pessoa.id;
            item.Nome = pessoa.Nome;
            item.Sobrenome = pessoa.Sobrenome;
            item.DataDeAniversario = pessoa.DataDeAniversario;
            _pessoas.listaPessoas.Insert(itemIndex, item);


            //var nome = pessoa.nome

            return RedirectToAction("Index");
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            var pessoa = _pessoas.listaPessoas.Where(s => s.id == id).FirstOrDefault();
            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        public ActionResult Delete(Pessoa pessoa)
        {
            try
            {
                var itemIndex = _pessoas.listaPessoas.FindIndex(x => x.id == pessoa.id);
                var item = _pessoas.listaPessoas.ElementAt(itemIndex);
                _pessoas.listaPessoas.RemoveAt(itemIndex);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

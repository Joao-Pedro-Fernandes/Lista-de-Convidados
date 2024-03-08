using Atividade_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_1.Controllers
{
    public class ConvidadosController : Controller
    {

        public static List<Convidado> convidados = new List<Convidado>()
        {
            new Convidado
            {
                Id = 1,
                Nome = "João",
                Email = "joaofernandes@aluno.unifenas.br",
                Comparecimento = true
            },
            new Convidado
            {
                Id = 2,
                Nome = "João Marcelo",
                Email = "joaomarcelo@aluno.unifenas.br",
                Comparecimento = true
            },
            new Convidado
            {
                Id = 3,
                Nome = "Felipe",
                Email = "felipe@aluno.unifenas.br",
                Comparecimento = false
            }
        };

        public ActionResult Index()
        {
            return View(convidados);
        }

        public ActionResult Details(int id)
        {
            return View(convidados.FirstOrDefault(convidado => convidado.Id == id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Convidado convidado)
        {
            convidado.Id = convidados.Select(x => x.Id).Max() + 1;
            convidados.Add(convidado);
            return RedirectToAction("Index");
        }

        // GET: ConvidadosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Convidado convidado)
        {
            convidados.Remove(convidados.FirstOrDefault(x => x.Id == convidado.Id));
            convidados.Add(convidado);
            return RedirectToAction("Index");
        }
     
        public ActionResult Delete(Convidado convidado)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            convidados.Remove(convidados.FirstOrDefault(x => x.Id == id));
            return RedirectToAction("Index");
        }

        public ActionResult ListaConfirmados()
        {
            return View(convidados);
        }
    }
}

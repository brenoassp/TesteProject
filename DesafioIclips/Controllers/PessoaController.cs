using DesafioIclips.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DesafioIclips.Controllers
{
    public class PessoaController : Controller
    {
        private IEnumerable<Pessoa> pessoas = new List<Pessoa>()
        {
            new Pessoa {Nome = "David Koch", Email = "david@gmail.com", Situacao = "atrasado"},
            new Pessoa {Nome = "Charles Koch", Email = "koch@gmail.com", Situacao = "atrasado"},
            new Pessoa {Nome = "Michael Bloomberg", Email = "bloomberg@gmail.com", Situacao = "atrasado"},
            new Pessoa {Nome = "Larry Ellison", Email = "larry@gmail.com", Situacao = "atrasado"},
            new Pessoa {Nome = "Mark Zuckerberg", Email = "mark@gmail.com", Situacao = "em andamento"},
            new Pessoa {Nome = "Jeff Bezos", Email = "jeff@gmail.com", Situacao = "em andamento"},
            new Pessoa {Nome = "Carlos Slim", Email = "carlos@gmail.com", Situacao = "atrasado"},
            new Pessoa {Nome = "Warren Buffett", Email = "warren@gmail.com", Situacao = "em andamento"},
            new Pessoa {Nome = "Amâncio Ortega", Email = "ortega@gmail.com", Situacao = "em andamento"},
            new Pessoa {Nome = "Bill Gates", Email = "gates@gmail.com", Situacao = "em andamento"},
        };

        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            PessoasListViewModel model = new PessoasListViewModel
            {
                Pessoas = pessoas
            };
            ViewBag.Title = "Todas as pessoas";
            return View(model);
        }

        [Route("Pessoa/Situacao/{situacao?}")]
        public ActionResult Situacao(string situacao)
        {
            PessoasListViewModel model;

            model = new PessoasListViewModel
            {
                Pessoas = pessoas
            };

            if (situacao == "atrasadas")
            {
                model = new PessoasListViewModel
                {
                    Pessoas = pessoas
                    .Select(item => new Pessoa { Nome = item.Nome, Email = item.Email, Situacao = item.Situacao })
                    .Where(item => item.Situacao == "atrasado")
                    .ToList()
                };
                ViewBag.Title = "Atrasadas";
            }
            else if (situacao == "emAndamento")
            {
                model = new PessoasListViewModel
                {
                    Pessoas = pessoas
                    .Select(item => new Pessoa { Nome = item.Nome, Email = item.Email, Situacao = item.Situacao })
                    .Where(item => item.Situacao == "em andamento")
                    .ToList()
                };
                ViewBag.Title = "Em Andamento";
            }
            return View("List", model);
        }

        [HttpPost]
        public PartialViewResult Ajax_OrdenaPessoas(string pessoasJSON)
        {
            List<Pessoa> list = JsonConvert.DeserializeObject<List<Pessoa>>(pessoasJSON);
            list = list.OrderBy(x => x.Nome).ToList();
            var model = new PessoasListViewModel
            {
                Pessoas = list
            };
            return PartialView("_Pessoas", model);
        }
    }
}
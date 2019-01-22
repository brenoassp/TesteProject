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
    public class HomeController : Controller
    {
        private List<Pessoa> pessoas = new List<Pessoa>()
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

        public ActionResult Index()
        {
            ViewBag.Pessoas = this.pessoas;
            ViewBag.Title = "Todas as pessoas";
            return View();
        }


        [Route("Situacao/{situacao?}")]
        public ActionResult Situacao(string situacao)
        {
            if (String.IsNullOrEmpty(situacao))
            {
                ViewBag.Pessoas = this.pessoas;
            }
            else if (situacao == "atrasadas")
            {
                var pessoas_atrasadas = pessoas
                .Select(item => new Pessoa { Nome = item.Nome, Email = item.Email, Situacao = item.Situacao })
                .Where(item => item.Situacao == "atrasado");
                ViewBag.Pessoas = pessoas_atrasadas;
                ViewBag.Title = "Atrasadas";
            }
            else if (situacao == "emAndamento")
            {
                var pessoas_andamento = pessoas
                .Select(item => new Pessoa { Nome = item.Nome, Email = item.Email, Situacao = item.Situacao })
                .Where(item => item.Situacao == "em andamento");
                ViewBag.Pessoas = pessoas_andamento;
                ViewBag.Title = "Em Andamento";
            }
            else
            {
                throw new HttpException(404, "Not found");
            }
            return View("Index");
        }

        [HttpPost]
        public string Ajax_OrdenaPessoas(string pessoasJSON)
        {
            List<Pessoa> list = JsonConvert.DeserializeObject<List<Pessoa>>(pessoasJSON);
            list = list.OrderBy(x => x.Nome).ToList();
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(list);
        }
    }
}
using ExercicioWeb01.Models;
using ExercicioWeb01.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExercicioWeb01.Controllers
{
    public class AlunosController : Controller
    {
        // GET: Alunos
        public ActionResult Index()
        {
            List<Alunos> alunos = new AlunoRepositorio().ObterTodos();
            ViewBag.Alunos = alunos;
            ViewBag.TituloPagina = "Alunos";
            return View();
        }


    }
}
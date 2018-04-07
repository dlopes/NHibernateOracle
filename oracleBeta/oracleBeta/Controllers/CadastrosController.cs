using oracleBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oracleBeta.Controllers
{
    public class CadastrosController : Controller
    {
        // GET: Cadastros
        public ActionResult Index()
        {
            CadastroRepository cadastroRepository = new CadastroRepository();
            var cadastros = cadastroRepository.GetAll();
            ViewBag.qtd = cadastros.Count;
            return View(cadastros);
  
        }

        // GET: Cadastros/Details/5
        public ActionResult Details(String CPF_CGC, String COD_PESSOA)
        {
            CadastroRepository cadastroRepository = new CadastroRepository();
            var cadastro = cadastroRepository.Get(CPF_CGC, COD_PESSOA);
            return View(cadastro);
        }

        // GET: Cadastros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cadastros/Create
        [HttpPost]
        public ActionResult Create(Cadastro cadastro)
        {
            try
            {
                CadastroRepository cadastroRepository = new CadastroRepository();
                cadastroRepository.Save(cadastro);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Cadastros/Edit/5
        public ActionResult Edit(String CPF_CGC, String COD_PESSOA)
        {
            CadastroRepository cadastroRepository = new CadastroRepository();
            var cadastro = cadastroRepository.Get(CPF_CGC, COD_PESSOA);
            return View(cadastro);

        }

        // POST: Cadastros/Edit/5
        [HttpPost]
        public ActionResult Edit(String CPF_CGC, Cadastro cadastro, String COD_PESSOA)
        {
            try
            {
                CadastroRepository cadastroRepository = new CadastroRepository();
                var cadastroAlterado = cadastroRepository.Get(CPF_CGC, COD_PESSOA);

                cadastroAlterado.COD_PESSOA  = cadastro.COD_PESSOA;
                cadastroAlterado.CPF_CGC = cadastro.CPF_CGC;
                cadastroAlterado.DATA_INCLUSAO = cadastro.DATA_INCLUSAO;
                cadastroAlterado.NOME_PESSOA = cadastro.NOME_PESSOA;

                cadastroRepository.Save(cadastroAlterado);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cadastros/Delete/5
        public ActionResult Delete(String CPF_CGC, String COD_PESSOA)
        {
            CadastroRepository cadastroRepository = new CadastroRepository();
            var cadastro = cadastroRepository.Get(CPF_CGC, COD_PESSOA);
            return View(cadastro);
        }

        // POST: Cadastros/Delete/5
        [HttpPost]
        public ActionResult Delete(String CPF_CGC, Cadastro cadastro)
        {
            try
            {
                CadastroRepository cadastroRepository = new CadastroRepository();
                cadastroRepository.Delete(cadastro);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

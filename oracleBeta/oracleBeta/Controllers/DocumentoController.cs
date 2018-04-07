using oracleBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oracleBeta.Controllers
{
    public class DocumentoController : Controller
    {
        // GET: Biometria
        public ActionResult Index()
        {
            DocumentoRepository documentoRepository = new DocumentoRepository();
            var biometrias = documentoRepository.GetAll();
            ViewBag.qtd = biometrias.Count;
            return View(biometrias);

        }

        // GET: Biometria/Details/5
        public ActionResult Details(String CPF_CGC, String REF_CLIENTE, String SEQUENCIA, String NOME_ARQUIVO)
        {
            DocumentoRepository documentoRepository = new DocumentoRepository();
            var biometria = documentoRepository.Get(CPF_CGC, REF_CLIENTE, SEQUENCIA, NOME_ARQUIVO);
            return View(biometria);
        }

        // GET: Biometria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Biometria/Create
        [HttpPost]
        public ActionResult Create(Documento documento)
        {
            try
            {
                DocumentoRepository documentoRepository = new DocumentoRepository();
                documentoRepository.Save(documento);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Biometria/Edit/5
        public ActionResult Edit(String CPF_CGC, String REF_CLIENTE, String SEQUENCIA, String NOME_ARQUIVO)
        {
            DocumentoRepository documentoRepository = new DocumentoRepository();
            var biometria = documentoRepository.Get(CPF_CGC, REF_CLIENTE, SEQUENCIA, NOME_ARQUIVO);
            return View(biometria);

        }

        // POST: Biometria/Edit/5
        [HttpPost]
        public ActionResult Edit(String CPF_CGC, Documento documento, String REF_CLIENTE, String SEQUENCIA, String NOME_ARQUIVO)
        {
            try
            {
                DocumentoRepository documentoRepository = new DocumentoRepository();
                var biometriaAlterada = documentoRepository.Get(CPF_CGC, REF_CLIENTE, SEQUENCIA, NOME_ARQUIVO);

                biometriaAlterada.COD_CLIENTE = documento.COD_CLIENTE;
                biometriaAlterada.COD_TIPO = documento.COD_TIPO;
                biometriaAlterada.CPF_CGC = documento.CPF_CGC;
                biometriaAlterada.DATA_EXCLUSAO = documento.DATA_EXCLUSAO;
                biometriaAlterada.DATA_INCLUSAO = documento.DATA_INCLUSAO;
                biometriaAlterada.NOME_ARQUIVO = documento.NOME_ARQUIVO;
                biometriaAlterada.REFERENCIA = documento.REFERENCIA;
                biometriaAlterada.REF_CLIENTE = documento.REF_CLIENTE;
                biometriaAlterada.SEQUENCIA = documento.SEQUENCIA;

                documentoRepository.Save(biometriaAlterada);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Biometria/Delete/5
        public ActionResult Delete(String CPF_CGC, String REF_CLIENTE, String SEQUENCIA, String NOME_ARQUIVO)
        {
            DocumentoRepository documentoRepository = new DocumentoRepository();
            var biometria = documentoRepository.Get(CPF_CGC, REF_CLIENTE, SEQUENCIA, NOME_ARQUIVO);
            return View(biometria);
        }

        // POST: Biometria/Delete/5
        [HttpPost]
        public ActionResult Delete(String CPF_CGC, Documento documento)
        {
            try
            {
                DocumentoRepository documentoRepository = new DocumentoRepository();
                documentoRepository.Delete(documento);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

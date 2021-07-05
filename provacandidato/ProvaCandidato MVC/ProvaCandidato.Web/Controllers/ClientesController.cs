using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProvaCandidato.Data;
using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Helper;

namespace ProvaCandidato.Controllers
{
    public class ClientesController : BaseController<Cliente>
    {
        // GET: Clientes
        public override ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Cidade).Where(x => x.Ativo);
            return View(clientes.ToList());
        }

        public JsonResult GetCidadesJson(int? cidadeId)
        {
            if (cidadeId != null)
                return Json(new SelectList(db.Cidades, "Codigo", "Nome", cidadeId), JsonRequestBehavior.AllowGet);

            return Json(new SelectList(db.Cidades, "Codigo", "Nome"), JsonRequestBehavior.AllowGet);

        }

        public override ActionResult Create([Bind(Include = "Codigo,Nome,DataNascimento,CidadeId,Ativo")] Cliente cliente)
        {
            if (cliente.DataNascimento < DateTime.Now)
                return base.Create(cliente);

            return View(cliente);
        }

        public override ActionResult Edit([Bind(Include = "Codigo,Nome,DataNascimento,CidadeId,Ativo")] Cliente cliente)
        {
            if (cliente.DataNascimento < DateTime.Now)
                return base.Edit(cliente);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult RenderObs(List<ClienteObservacao> observacoes)
        {
            return PartialView("_ClienteObservacoes", observacoes);
        }

        [HttpPost]
        public ActionResult CreateObs([Bind(Include = "Cliente,Observacao")] ClienteObservacao obs)
        {
            if (ModelState.IsValid)
            {
                MessageHelper.DisplaySuccessMessage(this, $"Objeto criado com sucesso.");
                obs.ClienteId = obs.Cliente.Codigo;
                obs.Cliente = null;
                db.ClienteObservacoes.Add(obs);
                db.SaveChanges();
                return RedirectToAction($"Clientes/Edit/{obs.ClienteId}");
            }

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

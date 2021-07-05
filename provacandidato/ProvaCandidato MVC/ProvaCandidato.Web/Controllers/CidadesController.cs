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

namespace ProvaCandidato.Controllers
{
    public class CidadesController : BaseController<Cidade>
    {
        public override ActionResult Create([Bind(Include = "Codigo,Nome")] Cidade cidade)
        {
            return base.Create(cidade);
        }

        public override ActionResult Edit([Bind(Include = "Codigo,Nome")] Cidade cidade)
        {
            return base.Edit(cidade);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ehaiker.Models;
using EntityState = System.Data.Entity.EntityState;

namespace ehaiker.Controllers
{
    public class GameWebApiController : ApiController
    {
        private EhaikerContext db = new EhaikerContext();

        // GET api/GameWebApi
        public IEnumerable<GameModel> GetGameItemModels()
        {
            return db.GameLists.AsEnumerable();
        }

        // GET api/GameWebApi/5
        public GameModel GetGameItemModel(int id)
        {
            GameModel gameitemmodel = db.GameLists.Find(id);
            if (gameitemmodel == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return gameitemmodel;
        }

        // PUT api/GameWebApi/5
        public HttpResponseMessage PutGameItemModel(int id, GameModel gameitemmodel)
        {
            if (ModelState.IsValid && id == gameitemmodel.ItemID)
            {
                db.Entry(gameitemmodel).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/GameWebApi
        public HttpResponseMessage PostGameItemModel(GameModel gameitemmodel)
        {
            if (ModelState.IsValid)
            {
                db.GameLists.Add(gameitemmodel);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, gameitemmodel);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = gameitemmodel.ItemID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/GameWebApi/5
        public HttpResponseMessage DeleteGameItemModel(int id)
        {
            GameModel gameitemmodel = db.GameLists.Find(id);
            if (gameitemmodel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.GameLists.Remove(gameitemmodel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, gameitemmodel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TweetSharp;
using WitnessBook.Data;
using WitnessBook.Domain.Entites;
using WitnessBook.GUI.Models;
using WitnessBook.Services;
using System.Net.Http;
using System.Web.Helpers;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace WitnessBook.GUI.Controllers
{
    public class EventController : Controller
    {
        // private WitnessBookContext db = new WitnessBookContext();
        IEventService service = null;
        public EventController()
        {
            service = new EventService();
        }




        public ActionResult GetEventsNoFinished()
        {
            List<EventModel> EM = new List<EventModel>();
            foreach (var item in service.GetEventsNoFinished())
            {
                EM.Add(
                    new EventModel
                    {
                        idEvenement = item.idEvenement,
                        nameEvent = item.nameEvent,
                        description = item.description,
                        lieux = item.lieux,
                        dateDebutEvent = item.dateDebutEvent,
                        dateFinEvent = item.dateFinEvent,
                        TypeEvent = item.TypeEvent





                    });
            }
            //ViewBag.model = "1";
            return View(EM);

        }
        public ActionResult GetEventsFinished()
        {
            List<EventModel> EM = new List<EventModel>();
            foreach (var item in service.GetEventsFinished())
            {
                EM.Add(
                    new EventModel
                    {
                        idEvenement = item.idEvenement,
                        nameEvent = item.nameEvent,
                        description = item.description,
                        lieux = item.lieux,
                        dateDebutEvent = item.dateDebutEvent,
                        dateFinEvent = item.dateFinEvent,
                        TypeEvent = item.TypeEvent





                    });
            }
            //ViewBag.model = "1";
            return View(EM);

        }
        public ActionResult MapEventByRegion()
        {
            List<MapRegionEventModels> mp = new List<MapRegionEventModels>();
            List<String> listAd = service.GetListAddresseEvent();
            foreach (var item in listAd)
            {
                int c = service.GetCountAddresseEvent(item);
                String code = "";
                String color = "";
                if (item == "Afghanistan") { code = "AF"; color = "#eea638"; }
                else if (item == "Albania") { code = "AL"; color = "#d8854f"; }
                else if (item == "Algeria") { code = "DZ"; color = "#de4c4f"; }
                else if (item == "Angola") { code = "AO"; color = "#de4c4f"; }
                else if (item == "Argentina") { code = "AR"; color = "#86a965"; }
                else if (item == "Armenia") { code = "AM"; color = "#d8854f"; }
                else if (item == "Australia") { code = "AU"; color = "#8aabb0"; }
                else if (item == "Austria") { code = "AT"; color = "#d8854f"; }
                else if (item == "Azerbaijan") { code = "AZ"; color = "#d8854f"; }
                else if (item == "Bahrain") { code = "BH"; color = "#eea638"; }
                else if (item == "Bangladesh") { code = "BD"; color = "#eea638"; }
                else if (item == "Belarus") { code = "BY"; color = "#d8854f"; }
                else if (item == "Belgium") { code = "BE"; color = "#d8854f"; }
                else if (item == "Benin") { code = "BJ"; color = "#de4c4f"; }
                else if (item == "Brazil") { code = "BR"; color = "#86a965"; }
                else if (item == "Canada") { code = "CA"; color = "#a7a737"; }
                else if (item == "Cameroon") { code = "ARCM"; color = "#de4c4f"; }
                else if (item == "Chile") { code = "CL"; color = "#Argentina"; }
                else if (item == "China") { code = "CN"; color = "#eea638"; }
                else if (item == "Egypt") { code = "EG"; color = "#de4c4f"; }
                else if (item == "India") { code = "IN"; color = "#eea638"; }
                else if (item == "Italy") { code = "JM"; color = "#a7a737"; }
                else if (item == "Japan") { code = "JP"; color = "#eea638"; }
                else if (item == "United States") { code = "US"; color = "#a7a737"; }
                else if (item == "Tunisia") { code = "TN"; color = "#de4c4f"; }
                else if (item == "Morocco") { code = "MA"; color = "#de4c4f"; }
                else if (item == "France") { code = "FR"; color = "#d8854f"; }
                else if (item == "Spain") { code = "ES"; color = "#d8854f"; }
                else if (item == "Qatar") { code = "QA"; color = "#eea638"; }
                mp.Add(
                    new MapRegionEventModels
                    {
                        name = item + " " + c,
                        value = c,
                        code = code,
                        color = color
                    }
                );

            }
            ViewBag.List = mp;
            return View();
        }

        public ActionResult GoogleMap()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                service.Dispose();
            }
            base.Dispose(disposing);

        }


        public ActionResult GetEventsByDate()
        {


            return View();
        }

        [HttpPost]
        public ActionResult GetEventsByDate(DateTime datedebut, DateTime datefin)
        {
            DateTime dd = datedebut;
            DateTime df = datefin;
            // ViewBag.text = "hello from post" + dd;

            List<EventModel> EM = new List<EventModel>();
            foreach (var item in service.GetEventsByDate(dd, df))
            {
                EM.Add(
                    new EventModel
                    {
                        idEvenement = item.idEvenement,
                        nameEvent = item.nameEvent,
                        description = item.description,
                        lieux = item.lieux,
                        dateDebutEvent = item.dateDebutEvent,
                        dateFinEvent = item.dateFinEvent,
                        TypeEvent = item.TypeEvent





                    });
            }
            //ViewBag.model = "1";
            return View(EM);
        }


        // GET: Event

        public ActionResult Index()

        {


            //var event = service.GetAllEvent();

            List<EventModel> EM = new List<EventModel>();
            foreach (var item in service.GetAllEvent())
            {
                EM.Add(
                    new EventModel
                    {
                        idEvenement = item.idEvenement,
                        nameEvent = item.nameEvent,
                        description = item.description,
                        lieux = item.lieux,
                        dateDebutEvent = item.dateDebutEvent,
                        dateFinEvent = item.dateFinEvent,
                        TypeEvent = item.TypeEvent




                    });
            }
            return View(EM);

        }
        public ActionResult TweetView()
        {
            return View();
        }

       

        [HttpPost]
        public ActionResult TweetView(int id)

        {
            
            Evenement e = service.GetById(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            EventModel em = new EventModel
            {


                nameEvent = e.nameEvent,
                description = e.description,
                lieux = e.lieux,
                dateDebutEvent = e.dateDebutEvent,
                dateFinEvent = e.dateFinEvent,
                TypeEvent = e.TypeEvent

            };
            ViewBag.nameEvent = em.nameEvent;
            return View();
        }


        public ActionResult Events([DataSourceRequest]DataSourceRequest request)
        {
            return Json(service.GetAllEvent().ToDataSourceResult(request));
        }






        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            Evenement e = service.GetById(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            EventModel em = new EventModel
            {

                
                nameEvent = e.nameEvent,
                description = e.description,
                lieux = e.lieux,
                dateDebutEvent = e.dateDebutEvent,
                dateFinEvent = e.dateFinEvent,
                TypeEvent = e.TypeEvent

            };

            return View(em);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            var eventmodel = new EventModel();
           

            return View(eventmodel);
            
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventModel em)
        {
            
            Evenement e = new Evenement
            {
                idEvenement = em.idEvenement,
                nameEvent = em.nameEvent,
                description = em.description,
                lieux = em.lieux,
                dateDebutEvent = em.dateDebutEvent,
                dateFinEvent = em.dateFinEvent,
                TypeEvent = em.TypeEvent

            };
            service.AddEvent(e);
            service.SaveChange();
            return RedirectToAction("Index");


        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            Evenement e = service.GetById(id);
            EventModel em = new EventModel
            {
                idEvenement = e.idEvenement,
                nameEvent = e.nameEvent,
                description = e.description,
                lieux = e.lieux,
                dateDebutEvent = e.dateDebutEvent,
                dateFinEvent = e.dateFinEvent,
                TypeEvent = e.TypeEvent

            };
            return View(em);
            
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Evenement e = service.GetById(id);
           

            try
            {
                service.Update(e);
                UpdateModel(e);

                service.SaveChange();
                return RedirectToAction("Index");

                // return RedirectToAction("Details", new { id = EventModel. });
            }
            catch
            {
                //ModelState.AddRuleViolations(dinner.GetRuleViolations());

                return View(e);
            }

        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            
            Evenement e = service.GetById(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            EventModel em = new EventModel
            {
                idEvenement = e.idEvenement,
                nameEvent = e.nameEvent,
                description = e.description,
                lieux = e.lieux,
                dateDebutEvent = e.dateDebutEvent,
                dateFinEvent = e.dateFinEvent,
                TypeEvent = e.TypeEvent

            };

            return View(em);
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EventModel em)
        {

            Evenement e = service.GetById(id);
            
            
            service.DeleteEvent(e);
            service.SaveChange();
            return RedirectToAction("Index");

        }
    }
}

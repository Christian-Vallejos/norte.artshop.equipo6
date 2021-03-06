﻿using Microsoft.AspNet.Identity;
using norte.ArtshopEquipo6.Data.Model;
using norte.ArtshopEquipo6.Data.Services;
using norteArtshopEquipo6.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace norteArtshopEquipo6.WebSite.Controllers
{
    [Authorize]
    public class ArtistaController : BaseController
    {
        private BaseDataService<Artist> db = new BaseDataService<Artist>();


        public ArtistaController() {

        }
        public ActionResult Index()
        {
            var list = db.Get();
            return View(list);
        }
        public ActionResult Create()
        {
            if (User.IsInRole("admin"))
            {
                var model = new Artist();
                return View(model);
            }
            else {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            this.CheckAuditPattern(artist, true);
            var listModel = db.ValidateModel(artist);
            if (ModelIsValid(listModel))
                return View(artist);
            try
            {
                db.Create(artist);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(artist);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = db.GetById(id.Value);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(Artist artist)
        {
            CheckAuditPattern(artist);
            var listModel = db.ValidateModel(artist);
            if (ModelIsValid(listModel))
                return View(artist);
            try
            {
                db.Update(artist);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(artist);
            }
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = db.GetById(id.Value);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [HttpPost]
        public ActionResult Delete(Artist artist)
        {
            try
            {
                db.Delete(artist.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(artist);
            }
        }
    }
}
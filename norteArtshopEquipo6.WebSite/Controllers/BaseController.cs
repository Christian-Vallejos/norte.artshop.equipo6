using norteArtshopEquipo6.WebSite.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace norte.ArtshopEquipo6.Data.Services
{
    public class BaseController : Controller
    {
        protected CartController cartController = new CartController();

        protected bool ModelIsValid(List<ValidationResult> listModel)
        {
            var message = string.Empty;
            var result = listModel != null && listModel.Count > 0;
            if (result)
            {
                foreach (var item in listModel)
                    message += string.Format("{0}\r\n", item.ErrorMessage);
                ViewBag.MessageDanger = message;
            }

            return result;
        }

        protected void CheckAuditPattern(dynamic model, bool created = false)
        {
            string userId = TryGetUserId();
            if (created)
            {
                model.CreatedOn = DateTime.Now;
                model.CreatedBy = userId;
            }
            if (model.CreatedOn == new DateTime(0001,01,01))
            {
                model.CreatedOn = DateTime.Now;
                model.CreatedBy = userId;
            }
            model.ChangedOn = DateTime.Now;

            if(userId!=null)
                model.ChangedBy = userId;
        }

        protected virtual string TryGetUserId()
        {

            string userId = null;
            try
            {
                if (!User.Identity.IsAuthenticated)
                    return null;

                userId = User.Identity.Name;
                if (userId != null)
                    return userId;
            }
            catch
            {
                return null;
            }

            return userId;
        }
    }
}

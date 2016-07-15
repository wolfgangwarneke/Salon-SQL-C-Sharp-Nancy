using System.Collections.Generic;
using System;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace Salon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/admin"] = _ => {
        return View["admin.cshtml"];
      };
      Get["/employee/add"] = _ => {
        return View["new_employee_form.cshtml"];
      };
      Post["/employee/add"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["name"]);
        newStylist.Save();
        return View["index.cshtml"];
      };
    }
  }
}

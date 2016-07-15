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
        List<Stylist> allStylists = Stylist.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        return View["index.cshtml", model];
      };
      Get["/admin"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        return View["admin.cshtml", model];
      };
      Get["/employee/add"] = _ => {
        return View["new_employee_form.cshtml"];
      };
      Post["/employee/add"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["name"]);
        newStylist.Save();
        return View["index.cshtml"];
      };
      Get["employee/update/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        return View["update_employee_form.cshtml", SelectedStylist];
      };
      Patch["employee/update/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        SelectedStylist.Update(Request.Form["newname"]);
        List<Stylist> allStylists = Stylist.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        return View["admin.cshtml", model];
      };
    }
  }
}

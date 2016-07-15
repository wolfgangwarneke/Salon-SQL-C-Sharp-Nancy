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
        List<Client> allClients = Client.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        model.Add("clients", allClients);
        return View["index.cshtml", model];
      };
      Get["/admin"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        List<Client> allClients = Client.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        model.Add("clients", allClients);
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
      Get["/employee/update/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        return View["update_employee_form.cshtml", SelectedStylist];
      };
      Patch["/employee/update/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        SelectedStylist.Update(Request.Form["newname"]);
        List<Stylist> allStylists = Stylist.GetAll();
        List<Client> allClients = Client.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        model.Add("clients", allClients);
        return View["admin.cshtml", model];
      };
      Get["/employee/remove/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        return View["remove_employee_confirmation.cshtml", SelectedStylist];
      };
      Delete["/employee/remove/{id}"] = parameters => {
        if (Request.Form["confirm"] == "yes")
        {
          Stylist SelectedStylist = Stylist.Find(parameters.id);
          SelectedStylist.Delete();
        }
        List<Stylist> allStylists = Stylist.GetAll();
        List<Client> allClients = Client.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        model.Add("clients", allClients);
        return View["admin.cshtml", model];
      };
      Get["/customer/add"] = _ => {
        return View["new_customer_form.cshtml"];
      };
      Post["/customer/add"] = _ => {
        Client newClient = new Client(Request.Form["name"], 0);
        newClient.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        List<Client> allClients = Client.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        model.Add("clients", allClients);
        return View["admin.cshtml", model];
      };
    }
  }
}

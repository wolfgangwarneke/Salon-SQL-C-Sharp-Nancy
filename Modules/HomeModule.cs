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
        List<Stylist> allStylists = Stylist.GetAll();
        List<Client> allClients = Client.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        model.Add("clients", allClients);
        return View["admin.cshtml", model];
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
        List<Stylist> allStylists = Stylist.GetAll();
        return View["new_customer_form.cshtml", allStylists];
      };
      Post["/customer/add"] = _ => {
        Client newClient = new Client(Request.Form["name"], Request.Form["stylist-id"]);
        newClient.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        List<Client> allClients = Client.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        model.Add("clients", allClients);
        return View["admin.cshtml", model];
      };
      Get["/customer/update/name/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        return View["update_customer_form.cshtml", SelectedClient];
      };
      Patch["/customer/update/name/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        SelectedClient.UpdateName(Request.Form["newname"]);
        List<Stylist> allStylists = Stylist.GetAll();
        List<Client> allClients = Client.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        model.Add("clients", allClients);
        return View["admin.cshtml", model];
      };
      Get["/customer/update/stylist/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        List<Stylist> allStylists = Stylist.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        model.Add("selectedClient", SelectedClient);
        return View["update_customer_stylist_form.cshtml", model];
      };
      Patch["/customer/update/stylist/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        SelectedClient.UpdateStylistId(Request.Form["stylist-id"]);
        List<Stylist> allStylists = Stylist.GetAll();
        List<Client> allClients = Client.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        model.Add("clients", allClients);
        return View["admin.cshtml", model];
      };
      Get["/customer/remove/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        return View["remove_customer_confirmation.cshtml", SelectedClient];
      };
      Delete["/customer/remove/{id}"] = parameters => {
        if (Request.Form["confirm"] == "yes")
        {
          Client SelectedClient = Client.Find(parameters.id);
          SelectedClient.Delete();
        }
        List<Stylist> allStylists = Stylist.GetAll();
        List<Client> allClients = Client.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        model.Add("clients", allClients);
        return View["admin.cshtml", model];
      };
      Get["/employee/showclients"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        List<Client> allClients = Client.GetAll();
        List<Client> stylistClients = new List<Client> {};
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("stylists", allStylists);
        model.Add("clients", allClients);
        model.Add("showcustomers", stylistClients);
        return View["admin.cshtml", model];
      };
      Get["/all/delete"] = _ => {
        Stylist.DeleteAll();
        Client.DeleteAll();
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

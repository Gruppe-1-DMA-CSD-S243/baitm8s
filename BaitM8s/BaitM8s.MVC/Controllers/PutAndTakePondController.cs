using BaitM8s.APIClient;
using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace BaitM8s.MVC.Controllers
{
    public class PutAndTakePondController : Controller
    {
        IPutAndTakePondDAO _putAndTakePondAPIClient = new PutAndTakePondAPIClient("https://localhost:7182");
        public IActionResult Overview(int id)
        {
            //return View(_putAndTakePondAPIClient.GetByPondOwner(id));
            return View(_putAndTakePondAPIClient.GetAll());
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(PutAndTakePond putAndTakePond)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        //TODO: try catch
        //        var newId = _blogPostApiClient.Create(blogpost);

        //        return RedirectToAction("Details", "BlogPost", new { Id = newId });
        //    }
        //    //TODO: giv fejlbesked og  vis formular igen
        //    return View();
        //}


        //[HttpGet]
        //public IActionResult Manage(string phoneNumber)
        //{
        //    //TODO: try catch
        //    Console.WriteLine(phoneNumber + "number?");
        //    return View(_putAndTakePondAPIClient.GetOne(phoneNumber));
        //}

        //[HttpPost]
        //public IActionResult Manage(PutAndTakePond putAndTakePond)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //TODO: try catch
        //        _putAndTakePondAPIClient.Update(putAndTakePond);
        //        return RedirectToAction("Manage", "PutAndTakePond", new { putAndTakePond.PondNumber });
        //    }
        //    //TODO: giv fejlbesked
        //    return View(putAndTakePond);
        //}

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    //TODO: try catch
        //    return View(_blogPostApiClient.GetOne(id));
        //}

        //[HttpPost]
        //public IActionResult Delete(int id, BlogPost blogpost)
        //{
        //    //TODO: try catch
        //    _blogPostApiClient.Delete(id);
        //    return RedirectToAction("Index", "Home");
        //}
    }
}

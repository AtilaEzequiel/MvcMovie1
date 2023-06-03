using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class PagosController : Controller
    {
        // GET: PagosController


        public static List<Pago> pagoList = new List<Pago>();
        public IActionResult Index()
        {
            /*var listMovies = new List<Pago>();

            var movie1 = new Pago
            {
                CondIva = "Terror",
                Cuit = 1,
                RazonSocial = "nose",
                Domicilio = "hola",
                Email = "La noche del terror",
                CondVenta="hola"
            };
            listMovies.Add(movie1);
            //pagoList.Add(movie1);
            */
            return View(pagoList);
        }

        // GET: PagosController/Details/5
        public ActionResult Details(Double? id)
        {
            try
            {
               // var pago = pagoList.FindIndex(a => a.Cuit == 12321312312);
               var pago= pagoList.SingleOrDefault(a => a.Cuit == id);
               return View(pago);
            }
            catch (Exception)
            {

                throw;
            }
            ;
        }

        // GET: PagosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PagosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pago collection)
        {
            try
            {
                pagoList.Add(collection);
                return RedirectToAction("Index");
               // return View(Index);
            }
            catch
            {
                return View();
            }
        }

        // GET: PagosController/Edit/5
        public ActionResult Edit(double id)
        {
            var pago = pagoList.SingleOrDefault(a => a.Cuit == id);
            return View(pago);
        }

        // POST: PagosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(double id, Pago pag)
        {
            try
            {
                // pagoList.SaveChangesAsync(pag);
                var pago = pagoList.SingleOrDefault(a => a.Cuit == id);

                pagoList.Append(pag);
                pago.RazonSocial = pag.RazonSocial;
                pago.CondVenta = pag.CondVenta;
                pago.Email = pag.Email;
                pago.CondIva = pag.CondIva;
                pago.Domicilio = pag.Domicilio;
                
                pagoList.ForEach(a => a.Cuit = id);
                
                //pagoList.(pag);
                //pagoList.Sort(pag);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PagosController/Delete/5
        public ActionResult Delete(double id)
        {
            var pago = pagoList.SingleOrDefault(a => a.Cuit == id);
            return View(pago);
        }

        // POST: PagosController/Delete/5
        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(double id, Pago pag)
        {
            try
            {
                var pago =  pagoList.SingleOrDefault(a => a.Cuit == id);
                pagoList.Remove(pago);
                //pagoList.Prepend
              //  var value = await pagoList.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

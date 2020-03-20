using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using ONK1.Models;

namespace Frontend.Controllers
{
    public class HaandvaerkersController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public HaandvaerkersController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET: Haandvaerkers
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("api");
            var request = new HttpRequestMessage(HttpMethod.Get, "Haandvaerker");
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            var listOfHaandvaerkers = await response.Content.ReadAsAsync<IEnumerable<Haandvaerker>>();

            return View(listOfHaandvaerkers);
        }

        // GET: Haandvaerkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var client = _clientFactory.CreateClient("api");
            var request = new HttpRequestMessage(HttpMethod.Get, $"Haandvaerker/{id}");
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            var haandvaerker = await response.Content.ReadAsAsync<Haandvaerker>();

            return View(haandvaerker);
        }

        // GET: Haandvaerkers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Haandvaerkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HVAnsaettelsesdato,HVEfternavn,HVFagomraade,HVFornavn,HaandvaerkerId")] Haandvaerker haandvaerker)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var client = _clientFactory.CreateClient("api");
                    var response = await client.PostAsJsonAsync("Haandvaerker", haandvaerker);
                    response.EnsureSuccessStatusCode();

                    var test = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(test);

                    //var response = await client.SendAsync(request);

                    //Console.WriteLine(newCraftsman.Id + " " + newCraftsman.EmploymentDate);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(haandvaerker);
        }

        //// GET: Haandvaerkers/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var haandvaerker = await _context.Haandvaerker.FindAsync(id);
        //    if (haandvaerker == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(haandvaerker);
        //}

        // POST: Haandvaerkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("HVAnsaettelsesdato,HVEfternavn,HVFagomraade,HVFornavn,HaandvaerkerId")] Haandvaerker haandvaerker)
        //{
        //    if (id != haandvaerker.HaandvaerkerId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(haandvaerker);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!HaandvaerkerExists(haandvaerker.HaandvaerkerId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(haandvaerker);
        //}

        // GET: Haandvaerkers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    try
        //    {
        //        var client = _clientFactory.CreateClient("api");
        //        var request = new HttpRequestMessage(HttpMethod.Delete, $"Haandvaerker/{id}");
        //        var response = await client.SendAsync(request);

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError, response);
        //        }

        //        var test = await response.Content.ReadAsStringAsync();
        //        Console.WriteLine(test);

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

    }
}

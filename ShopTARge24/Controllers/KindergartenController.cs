using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;

namespace ShopTARge24.Controllers
{
    public class KindergartenController : Controller
    {
        private readonly IKindergartenServices _service;
        public KindergartenController(IKindergartenServices service) => _service = service;

        // GET: /Kindergarten
        public async Task<IActionResult> Index()
            => View(await _service.IndexAsync());

        // GET: /Kindergarten/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var dto = await _service.DetailsAsync(id);
            if (dto == null) return NotFound();
            return View(dto);
        }

        // GET: /Kindergarten/Create
        public IActionResult Create() => View();

        // POST: /Kindergarten/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KindergartenDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            await _service.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Kindergarten/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _service.DetailsAsync(id);
            if (dto == null) return NotFound();
            return View(dto);
        }

        // POST: /Kindergarten/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KindergartenDto dto)
        {
            if (id != dto.Id) return BadRequest();
            if (!ModelState.IsValid) return View(dto);

            var updated = await _service.UpdateAsync(dto);
            if (updated == null) return NotFound();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Kindergarten/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _service.DetailsAsync(id);
            if (dto == null) return NotFound();
            return View(dto);
        }

        // POST: /Kindergarten/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

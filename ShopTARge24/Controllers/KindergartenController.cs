using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Models.Kindergartens;

namespace ShopTARge24.Controllers
{
    public class KindergartenController : Controller
    {
        private readonly IKindergartenServices _service;
        public KindergartenController(IKindergartenServices service) => _service = service;

        // GET: /Kindergarten
        public async Task<IActionResult> Index()
        {
            var dtos = await _service.IndexAsync();

            var vm = dtos.Select(x => new KindergartenIndexViewModel
            {
                Id = x.Id,
                GroupName = x.GroupName,
                ChildrenCount = x.ChildrenCount,
                KindergartenName = x.KindergartenName,
                TeacherName = x.TeacherName,
                CreatedAt = x.CreatedAt
            });

            return View(vm);
        }

        // GET: /Kindergarten/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var dto = await _service.DetailsAsync(id);
            if (dto == null) return NotFound();

            var vm = new KindergartenDetailsViewModel
            {
                Id = dto.Id,
                GroupName = dto.GroupName,
                ChildrenCount = dto.ChildrenCount,
                KindergartenName = dto.KindergartenName,
                TeacherName = dto.TeacherName,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };

            return View(vm);
        }

        // GET: /Kindergarten/Create
        public IActionResult Create()
        {
            var vm = new KindergartenCreateUpdateViewModel();
            return View("CreateUpdate", vm);
        }

        // POST: /Kindergarten/Create
        [HttpPost]
        public async Task<IActionResult> Create(KindergartenCreateUpdateViewModel vm)
        {
            if (!ModelState.IsValid) return View("CreateUpdate", vm);

            var dto = new KindergartenDto
            {
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                TeacherName = vm.TeacherName
            };

            await _service.CreateAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Kindergarten/Update/5
        public async Task<IActionResult> Update(int id)
        {
            var dto = await _service.DetailsAsync(id);
            if (dto == null) return NotFound();

            var vm = new KindergartenCreateUpdateViewModel
            {
                Id = dto.Id,
                GroupName = dto.GroupName,
                ChildrenCount = dto.ChildrenCount,
                KindergartenName = dto.KindergartenName,
                TeacherName = dto.TeacherName,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };

            return View("CreateUpdate", vm);
        }

        // POST: /Kindergarten/Update/5
        [HttpPost]
        public async Task<IActionResult> Update(int id, KindergartenCreateUpdateViewModel vm)
        {
            if (id != vm.Id) return BadRequest();
            if (!ModelState.IsValid) return View("CreateUpdate", vm);

            var dto = new KindergartenDto
            {
                Id = vm.Id!.Value,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                TeacherName = vm.TeacherName,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt
            };

            var updated = await _service.UpdateAsync(dto);
            if (updated == null) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Kindergarten/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _service.DetailsAsync(id);
            if (dto == null) return NotFound();

            var vm = new KindergartenDeleteViewModel
            {
                Id = dto.Id,
                GroupName = dto.GroupName,
                ChildrenCount = dto.ChildrenCount,
                KindergartenName = dto.KindergartenName,
                TeacherName = dto.TeacherName,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };

            return View(vm);
        }

        // POST: /Kindergarten/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id, KindergartenDeleteViewModel _)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

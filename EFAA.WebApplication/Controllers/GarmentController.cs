using EFAA.BusinessLogic.DTOs;
using EFAA.BusinessLogic.UseCases.Designers.Queries.GetDesingners;
using EFAA.BusinessLogic.UseCases.Garments.Commands.CreateGarment; 
using EFAA.BusinessLogic.UseCases.Garments.Commands.UpdateGarment;
using EFAA.BusinessLogic.UseCases.Garments.Queries.GetGarment;
using EFAA.BusinessLogic.UseCases.Garments.Queries.GetGarments;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFAA.WebApplication.Controllers
{
    [Authorize]
    public class GarmentController : Controller
    {
        private readonly IMediator _mediator;

        public GarmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: GarmentController
        public async Task<IActionResult> Index()
        {
            var garments = await _mediator.Send(new GetGarmentsQuery());
            return View(garments);
        }

        // GET: GarmentController/Create
        public async Task<IActionResult> Create()
        {
            var designers = await _mediator.Send(new GetDesignersQuery());
            ViewData["DesignerId"] = new SelectList(designers, "DesignerId", "DesignerName");
            return View();
        }

        // POST: GarmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGarmentRequest createGarmentRequest)
        {
            try
            {
                var result = await _mediator.Send(new CreateGarmentCommand(createGarmentRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedió un error al intentar guardar la nueva prenda");
            }
            catch (Exception ex)
            {
                var designers = await _mediator.Send(new GetDesignersQuery());
                ViewData["DesignerId"] = new SelectList(designers, "DesignerId", "DesignerName");
                ModelState.AddModelError("", ex.Message);
                return View(createGarmentRequest);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var garment = await _mediator.Send(new GetGarmentQuery(id));
            var designers = await _mediator.Send(new GetDesignersQuery());
            ViewData["DesignerId"] = new SelectList(designers, "DesignerId", "DesignerName", garment.DesignerId);
            return View(garment.Adapt(new UpdateGarmentRequest()));
        }

        // POST: GarmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateGarmentRequest updateGarmentRequest)
        {
            try
            {
                var result = await _mediator.Send(new UpdateGarmentCommand(updateGarmentRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedió un error al intentar editar la prenda");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var designers = await _mediator.Send(new GetDesignersQuery());
                ViewData["DesignerId"] = new SelectList(designers, "DesignerId", "DesignerName", updateGarmentRequest.DesignerId);
                return View(updateGarmentRequest);
            }
        }
    }
}
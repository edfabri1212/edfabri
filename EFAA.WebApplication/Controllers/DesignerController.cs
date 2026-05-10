using EFAA.BusinessLogic.DTOs;
using EFAA.BusinessLogic.UseCases.Designers.Commands.CreateDesigner;
using EFAA.BusinessLogic.UseCases.Designers.Commands.DeleteDesingner;
using EFAA.BusinessLogic.UseCases.Designers.Commands.UpdateDesingner;
using EFAA.BusinessLogic.UseCases.Designers.Queries.GetDesigner;
using EFAA.BusinessLogic.UseCases.Designers.Queries.GetDesingners;
using EFAA.Entities;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace EFAA.WebApplication.Controllers
{
    // --- CONTROLADOR DE DISEÑADOR ---
    public class DesignerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    // --- CONTROLADOR DE MARCAS (BRANDS) ---
    [Authorize]
    public class DesingnerController : Controller
    {
        private readonly IMediator _mediator;

        public DesingnerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _mediator.Send(new GetDesignersQuery());
            return View(Designer);
        }

        private IActionResult View(IDesigner desingner)
        {
            throw new NotImplementedException();
        }

        // GET: DesingnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DesingnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDesignerRequest createDesingnerRequest)
        {
            try
            {
                var result = await _mediator.Send(new CreateDesignerCommand(createDesingnerRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error la intentar guardar la nueva marca");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(createDesingnerRequest);
            }
        }

        // GET: DesingnerController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Desingner = await _mediator.Send(new GetDesignerQuery(id));
            return View(Desingner.Adapt(new UpdateDesignerRequest()));
        }

        // POST: DesingnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateDesignerRequest updateDesingnerRequest)
        {
            try
            {
                var result = await _mediator.Send(new UpdateDesignerCommand(updateDesingnerRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error la intentar editar marca");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(updateDesingnerRequest);
            }
        }

        // GET: DesingnerController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Desingner = await _mediator.Send(new GetDesignerQuery(id));
            return View(Desingner);
        }

        // POST: DesingnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, DesignerResponse DesingnerResponse)
        {
            try
            {
                var result = await _mediator.Send(new DeleteDesignerCommand(id));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error la intentar editar marca");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(DesingnerResponse);
            }
        }
    }
}
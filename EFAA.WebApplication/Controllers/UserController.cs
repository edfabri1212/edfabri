using EFAA.BusinessLogic.DTOs;
using EFAA.BusinessLogic.UseCases.Designers.Commands.CreateDesigner;
using EFAA.BusinessLogic.UseCases.Designers.Commands.DeleteDesingner;
using EFAA.BusinessLogic.UseCases.Designers.Commands.UpdateDesigner;
using EFAA.BusinessLogic.UseCases.Designers.Queries.GetDesigner;
using EFAA.BusinessLogic.UseCases.Designers.Queries.GetDesingners;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EFAA.WebApplication.Controllers
{
    [Authorize]
    public class DesignersController : Controller
    {
        private readonly IMediator _mediator;

        public DesignersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var designers = await _mediator.Send(new GetDesignersQuery());
            return View(designers);
        }

        // GET: DesignerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DesignerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDesignerRequest createDesignerRequest)
        {
            try
            {
                var result = await _mediator.Send(new CreateDesignerCommand(createDesignerRequest));

                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar guardar el nuevo diseñador");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(createDesignerRequest);
            }
        }

        // GET: DesignerController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var designer = await _mediator.Send(new GetDesignerQuery(id));
            return View(designer.Adapt(new UpdateDesignerRequest()));
        }

        // POST: DesignerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateDesignerRequest updateDesignerRequest)
        {
            try
            {
                var result = await _mediator.Send(new UpdateDesignerCommand(updateDesignerRequest));

                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar editar diseñador");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(updateDesignerRequest);
            }
        }

        // GET: DesignerController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var designer = await _mediator.Send(new GetDesignerQuery(id));
            return View(designer);
        }

        // POST: DesignerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, DesignerResponse designerResponse)
        {
            try
            {
                var result = await _mediator.Send(new DeleteDesignerCommand(id));

                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar eliminar diseñador");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(designerResponse);
            }
        }
    }
}
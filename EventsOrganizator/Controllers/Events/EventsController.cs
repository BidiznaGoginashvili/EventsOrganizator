using System;
using MediatR;
using Kendo.Mvc.UI;
using System.Text.Json;
using Kendo.Mvc.Extensions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OA.CQRS.Query.Events.Read;
using OA.CQRS.Query.Events.ReadById;
using OA.CQRS.Command.Events.InsertEvent;
using OA.CQRS.Command.Events.DeleteEvent;

namespace EventsOrganizator.Controllers.Events
{
    public class EventsController : Controller
    {
        #region Fields

        private readonly IMediator _mediator;

        #endregion

        #region Ctor

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region ActionResults

        public ActionResult List()
        {
            ReadEventQuery model = new ReadEventQuery();

            return View(model);
        }

        [AcceptVerbs("Post")]
        public async Task<IActionResult> EventsListing(ReadEventQuery model, [DataSourceRequest]DataSourceRequest request)
        {
            var eventHandler = await _mediator.Send(model);
            var events = eventHandler.ToDataSourceResult(request);

            var gridModel = new DataSourceResult()
            {
                Data = events.Data,
                Total = events.Total
            };

            return Json(data: gridModel, new JsonSerializerOptions() { PropertyNameCaseInsensitive = false });
        }

        public ActionResult Create()
        {
            InsertEventCommand command = new InsertEventCommand();

            return View(command);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ReadByIdQuery query = new ReadByIdQuery(id);
            var eventHandler = _mediator.Send(query);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            DeleteEventCommand command = new DeleteEventCommand(id);

            await _mediator.Send(command);

            return RedirectToAction("List");
        }
    }

    #endregion
}
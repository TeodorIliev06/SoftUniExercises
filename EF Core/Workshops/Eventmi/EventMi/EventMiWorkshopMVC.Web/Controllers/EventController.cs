namespace EventMiWorkshopMVC.Web.Controllers
{
    using System.Globalization;

    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Contracts;
    using ViewModels.Event;

    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); //Reload the page with the error messages
            }

            bool isStartDateValid = DateTime.TryParse(model.Start, CultureInfo.InvariantCulture, DateTimeStyles.None, out var startDate);
            if (!isStartDateValid)
            {
                ModelState.AddModelError(nameof(model.Start), "Start date is in incorrect format!");
                return View(model);
            }

            bool isEndDateValid = DateTime.TryParse(model.End, CultureInfo.InvariantCulture, DateTimeStyles.None, out var endDate);
            if (!isEndDateValid)
            {
                ModelState.AddModelError(nameof(model.End), "End date is in incorrect format!");
                return View(model);
            }

            await eventService.AddEvent(model, startDate, endDate);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                EditEventFormModel eventModel = await this.eventService.GetEventById(id.Value);

                return View(eventModel);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, EditEventFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            bool isStartDateValid = DateTime.TryParse(model.Start, CultureInfo.InvariantCulture, DateTimeStyles.None, out var startDate);
            if (!isStartDateValid)
            {
                ModelState.AddModelError(nameof(model.Start), "Start date is in incorrect format!");
                return View(model);
            }

            bool isEndDateValid = DateTime.TryParse(model.End, CultureInfo.InvariantCulture, DateTimeStyles.None, out var endDate);
            if (!isEndDateValid)
            {
                ModelState.AddModelError(nameof(model.End), "End date is in incorrect format!");
                return View(model);
            }

            try
            {
                await this.eventService.EditEventById(id.Value, model, startDate, endDate);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                EditEventFormModel eventModel = await this.eventService.GetEventById(id.Value);

                return View(eventModel);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, EditEventFormModel model)
		{
			if (!id.HasValue)
			{
				return RedirectToAction("Index", "Home");
			}

			try
			{
				await this.eventService.DeleteEventById(id.Value);

                //TODO: Implement All Events View 
				return RedirectToAction("Index", "Home");
			}
			catch (Exception e)
			{
				return RedirectToAction("Index", "Home");
			}
		}
    }
}

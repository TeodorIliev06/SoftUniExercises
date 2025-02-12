namespace EventMiWorkshopMVC.Services.Data
{
	using Contracts;
	using EventMiWorkshopMVC.Data;
	using EventMiWorkshopMVC.Data.Models;
	using Web.ViewModels.Event;

	public class EventService : IEventService
	{
		private readonly EventMiDbContext dbContext;

		public EventService(EventMiDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task AddEvent(AddEventFormModel eventFormModel, DateTime start, DateTime end)
		{
			Event newEvent = new Event
			{
				Name = eventFormModel.Name,
				StartDate = start,
				EndDate = end,
				Place = eventFormModel.Place
			};

			await dbContext.Events.AddAsync(newEvent);
			await dbContext.SaveChangesAsync();
		}

		public async Task<EditEventFormModel> GetEventById(int id)
		{
			Event eventDb = await this.dbContext.Events.
				FindAsync(id);

			if (eventDb == null)
			{
				throw new ArgumentException($"Event with id {id} does not exist!");
			}

			if (eventDb.IsActive!.Value == false)
			{
				throw new InvalidOperationException($"Event with id {id} is not active!");
			}

			EditEventFormModel eventFound = new EditEventFormModel()
			{
				Name = eventDb.Name,
				Start = eventDb.StartDate.ToString("d"),
				End = eventDb.EndDate.ToString("d"),
				Place = eventDb.Place
			};

			return eventFound;
		}

		public async Task EditEventById(int id, EditEventFormModel eventFormModel, DateTime start, DateTime end)
		{
			Event eventToEdit = await dbContext.Events
			.FindAsync(id);

			if (eventToEdit.IsActive!.Value == false)
			{
				throw new InvalidOperationException($"Event with id {id} is not active!");
			}

			eventToEdit.Name = eventFormModel.Name;
			eventToEdit.StartDate = start;
			eventToEdit.EndDate = end;
			eventToEdit.Place = eventFormModel.Place;

			await dbContext.SaveChangesAsync();
		}

		public async Task DeleteEventById(int id)
		{
			Event eventToDelete = await dbContext.Events
				.FindAsync(id);

			if (eventToDelete == null)
			{
				throw new ArgumentException($"Event with id {id} does not exist!");
			}

			if(eventToDelete.IsActive!.Value == false)
			{
				throw new InvalidOperationException($"Event with id {id} is not active!");
			}

			this.dbContext.Events.Remove(eventToDelete);
			await this.dbContext.SaveChangesAsync();
		}
	}
}
}

namespace EventMiWorkshopMVC.Services.Data.Contracts
{
	using Web.ViewModels.Event;

	public interface IEventService
	{
		Task AddEvent(AddEventFormModel eventFormModel, DateTime start, DateTime end);
		Task<EditEventFormModel> GetEventById(int id);
		Task EditEventById(int id, EditEventFormModel eventFormModel, DateTime start, DateTime end);
		Task DeleteEventById(int id);
	}
}

using Fideo.DTO;
using Fideo.Models;
using Fideo.Repositories;

namespace Fideo.Services
{
    public class AvailableSlotService
    {
        private AvailableSlotRepository repository;

        public AvailableSlotService(AvailableSlotRepository repository)
        {
            this.repository = repository;
        }

        public void CreateAvailableSlot(AvailabelSlotCreateDTO available_slot)
        {
            repository.Create(new AvailableSlot
            {
                StartDateTime = available_slot.StartDateTime,
				EndDateTime = available_slot.EndDateTime,
				BusinessId = available_slot.BusinessId,
				OfferId = available_slot.OfferId,
            });
        }

        public AvailableSlot FindAvailableSlot(int available_slot_id)
        {
            return repository.getContext().AvailableSlots.Find(available_slot_id);
        }

        public List<AvailableSlot> GetAvailableSlots()
        {
            return repository.GetAll();
        }
    }
}

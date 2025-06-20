using Fideo.DTO;
using Fideo.Models;
using Fideo.Repositories;

namespace Fideo.Services
{
    public class AppointmentStatusService
    {
        private AppointmentStatusRepository repository;

        public AppointmentStatusService(AppointmentStatusRepository repository)
        {
            this.repository = repository;
        }

        public void CreateAppointmentStatus(AppointmentStatusCreateDTO appointment_status)
        {
            repository.Create(new AppointmentStatus
            {
                Status = appointment_status.Status
            });
        }

        public AppointmentStatus GetAppointmentStatus(int appointment_status_id)
        {
            return repository.getContext().AppointmentStatus.Find(appointment_status_id);
        }

        public List<AppointmentStatus> getAppointmentStatus()
        {
            return repository.GetAll();
        }
    }
}

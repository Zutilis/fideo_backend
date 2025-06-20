﻿using Fideo.DTO;
using Fideo.Models;
using Fideo.Repositories;

namespace Fideo.Services
{
    public class AppointmentService
    {
        private AppointmentRepository repository;

        public AppointmentService(AppointmentRepository repository)
        {
            this.repository = repository;
        }

        public void CreateAppointment(AppointmentCreateDTO appointment)
        {
            repository.Create(new Appointment
            {
                UserId = appointment.UserId,
                AvailableSlotId = appointment.AvailableSlotId,
                AppointmentStatusId = appointment.AppointmentStatusId
            });
        }

        public Appointment GetAppointment(int appointment_id)
        {
            return repository.getContext().Appointments.Find(appointment_id);
        }

        public List<Appointment> getAppointments()
        {
            return repository.GetAll();
        }
    }
}

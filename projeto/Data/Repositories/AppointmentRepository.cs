using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projeto.Domain;
using Microsoft.EntityFrameworkCore;
using projeto.Data.Repositories;


namespace projeto.Domain.Interfaces
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DataContext context;

        public AppointmentRepository(DataContext context){
            this.context = context;
        }

        public void Delete(int entityId){
            var ap = GetById(entityId);
            context.Appointments.Remove(ap);
            context.SaveChanges();
        }

        public IList<Appointment> GetAll(){
            return context.Appointments.Include(x => x.doctor).Include(x => x.patient).ToList();            
        }

        public Appointment GetById(int entityId){
            return context.Appointments.Include(x=>x.doctor).Include(x => x.patient).SingleOrDefault(x=>x.Id == entityId);
        }

        public void Save(Appointment entity){
            entity.doctor = context.Doctors.Find(entity.doctor.Id);
            entity.patient = context.Patients.Find(entity.patient.Id);
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(Appointment entity){
            entity.doctor = context.Doctors.SingleOrDefault(x=>x.Id == entity.doctor.Id);
            entity.patient = context.Patients.SingleOrDefault(x=>x.Id == entity.patient.Id);

            context.Appointments.Update(entity);
            context.SaveChanges();  
        }
    }
}
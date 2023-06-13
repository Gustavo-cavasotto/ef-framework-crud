using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projeto.Domain.Interfaces;
using projeto.Domain;

namespace projeto.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DataContext context;

        public DoctorRepository(){
            this.context = new DataContext();
        }


        public void Delete(int entityId){
            var doctor = GetById(entityId);
            context.Doctors.Remove(doctor);
            context.SaveChanges();
        }

        public IList<Doctor> GetAll(){
            return context.Doctors.ToList();
        }

        public Doctor GetById(int entityId)
        {
            return context.Doctors.SingleOrDefault(x => x.Id == entityId);
        }
        
        public void Save(Doctor entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(Doctor entity)
        {
            context.Doctors.Update(entity);
            context.SaveChanges();
        }


    }
}
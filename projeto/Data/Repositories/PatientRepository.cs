using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projeto.Data.Repositories;
using projeto.Data;
using projeto.Domain.Interfaces;
using projeto.Domain;

namespace projeto.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DataContext context;

        public PatientRepository(DataContext context){
            this.context = context;
        }

        public void Delete(int entityId){
            var patient = GetById(entityId);
            context.Patients.Remove(patient);
            context.SaveChanges();
        }

        public IList<Patient> GetAll (){
            return context.Patients.ToList();
        }

        public Patient GetById(int entityId){
            return context.Patients.SingleOrDefault(x => x.Id == entityId);
        }

        public void Save(Patient entity){
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(Patient entity)
        {
            context.Patients.Update(entity);
            context.SaveChanges();
        }
    }
}
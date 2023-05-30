using projeto.Data.Repositories;
using projeto.Domain.Interfaces;
using projeto.Domain;
using projeto.Data;

var db = new DataContext();

IDoctorRepository _doctorRepository = new DoctorRepository(db);
// var doctor = new Doctor(){
//     Id = 1,
//     name = "Agostinho Potrich",
//     specialty = "Cardiologist"
// };


// _doctorRepository.Save(doctor);
// _doctorRepository.Delete(3);

var newDoctor = _doctorRepository.GetById(2);
newDoctor.specialty = "Ginecologist";
_doctorRepository.Update(newDoctor);

var doctorsList = _doctorRepository.GetAll();
foreach (var item in doctorsList){
    Console.WriteLine($"Id: {item.Id} | Name: {item.name} | Specialty: {item.specialty}");
}

// IPatientRepository _patientRepository = new PatientRepository(db);
// var patient = new Patient(){
//     Id = 1,
//     name = "João Vitor",
// };

// _patientRepository.Save(patient);

IAppointmentRepository _appointmentRepository = new AppointmentRepository(db);
// var appointment = new Appointment(){
//     Id = 1,
//     date = new DateTime(2023, 5, 28),
//     doctor = doctor,
//     patient = patient
// };

// _appointmentRepository.Save(appointment);


var appointmentChange = _appointmentRepository.GetById(1);
appointmentChange.date = new DateTime(2023, 5, 28).AddHours(18);
_appointmentRepository.Update(appointmentChange);

var appointmentsList = _appointmentRepository.GetAll();
foreach (var item in appointmentsList){
    Console.WriteLine($"Id: {item.Id} | Date: {item.date} | Doctor: {item.doctor.name} | Patient: {item.patient.name}");
}

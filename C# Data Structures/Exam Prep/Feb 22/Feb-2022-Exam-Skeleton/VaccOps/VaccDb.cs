using System.Linq;

namespace VaccOps
{
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;

    public class VaccDb : IVaccOps
    {
        private Dictionary<string, Doctor> doctorsByName = new Dictionary<string, Doctor>();
        private Dictionary<string, Patient> patientsByName = new Dictionary<string, Patient>();
        public void AddDoctor(Doctor doctor)
        {
            if (this.doctorsByName.ContainsKey(doctor.Name))
            {
                throw new ArgumentException();
            }

            this.doctorsByName.Add(doctor.Name, doctor);
        }

        public void AddPatient(Doctor doctor, Patient patient)
        {
            if (!this.doctorsByName.ContainsKey(doctor.Name))
            {
                throw new ArgumentException();
            }

            this.patientsByName.Add(patient.Name, patient);
            this.doctorsByName[doctor.Name].Patients.Add(patient);
            patient.Doctor = doctor;
        }

        public void ChangeDoctor(Doctor oldDoctor, Doctor newDoctor, Patient patient)
        {
            if (!this.doctorsByName.ContainsKey(oldDoctor.Name) ||
                !this.doctorsByName.ContainsKey(newDoctor.Name) ||
                !this.patientsByName.ContainsKey(patient.Name))
            {
                throw new ArgumentException();
            }

            this.doctorsByName[oldDoctor.Name].Patients.Remove(patient);
            this.doctorsByName[newDoctor.Name].Patients.Add(patient);
            patient.Doctor = newDoctor;
        }

        public bool Exist(Doctor doctor) => this.doctorsByName.ContainsKey(doctor.Name);

        public bool Exist(Patient patient) => this.patientsByName.ContainsKey(patient.Name);

        public IEnumerable<Doctor> GetDoctors() => this.doctorsByName.Values;

        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry)
            => this.GetDoctors().Where(d => d.Popularity == populariry);

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc()
            => this.GetDoctors().OrderByDescending(d => d.Patients.Count)
                .ThenBy(d => d.Name);

        public IEnumerable<Patient> GetPatients() => this.patientsByName.Values;

        public IEnumerable<Patient> GetPatientsByTown(string town)
            => this.GetPatients().Where(p => p.Town == town);

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi)
            => this.patientsByName.Values.Where(p => p.Age >= lo && p.Age <= hi);

        public IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge()
            => this.GetPatients().OrderBy(p => p.Doctor.Popularity)
                .ThenByDescending(p => p.Height)
                .ThenBy(p => p.Age);

        public Doctor RemoveDoctor(string name)
        {
            if (!this.doctorsByName.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            var doctor = this.doctorsByName[name];
            this.doctorsByName.Remove(name);
            doctor.Patients.ForEach(p => this.patientsByName.Remove(p.Name));

            return doctor;
        }
    }
}

using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ImportDtos;
using Medicines.Utilities;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";
        private static XmlHelper? xmlHelper;
        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            var sb = new StringBuilder();
            ICollection<Patient> patients = new List<Patient>();
            //int counter = 0;

            PatientImportDto[] patientDtos = JsonConvert.DeserializeObject<PatientImportDto[]>(jsonString);

            foreach (var pDto in patientDtos)
            {
                if (!IsValid(pDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var patient = new Patient()
                {
                    FullName = pDto.FullName,
                    AgeGroup = (AgeGroup)pDto.AgeGroup,
                    Gender = (Gender)pDto.Gender,
                };

                foreach (int medId in pDto.Medicines)
                {
                    if (patient.PatientsMedicines.Any(x => x.MedicineId == medId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var medicine = new PatientMedicine()
                    {
                        Patient = patient,
                        MedicineId = medId,
                    };

                    patient.PatientsMedicines.Add(medicine);
                }

                //counter += patient.PatientsMedicines.Count;
                patients.Add(patient);
                sb.AppendLine(String.Format(SuccessfullyImportedPatient,patient.FullName,patient.PatientsMedicines.Count));
            }

            context.Patients.AddRange(patients);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            var sb = new StringBuilder();
            xmlHelper = new XmlHelper();

            //int medCounter = 0;
            ICollection<Pharmacy> validPharmacies = new List<Pharmacy>();

            PharmacyImportDto[] pharmacyDtos = xmlHelper.Deserialize<PharmacyImportDto[]>(xmlString, "Pharmacies");

            foreach (var phDto in pharmacyDtos)
            {
                if (!IsValid(phDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var pharmacy = new Pharmacy()
                {
                    Name = phDto.Name,
                    PhoneNumber = phDto.PhoneNumber,
                    IsNonStop = bool.Parse(phDto.IsNonStop),
                };

                foreach (var medDto in phDto.Medicines)
                {
                    if (!IsValid(medDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime medicineProductionDate;
                    bool isProductionDateValid = DateTime
                        .TryParseExact(medDto.ProductionDate, "yyyy-MM-dd", CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out medicineProductionDate);

                    if (!isProductionDateValid)
                    {
                        sb.Append(ErrorMessage);
                        continue;
                    }

                    DateTime medicineExpityDate;
                    bool isExpityDateValid = DateTime
                        .TryParseExact(medDto.ExpiryDate, "yyyy-MM-dd", CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out medicineExpityDate);

                    if (!isExpityDateValid)
                    {
                        sb.Append(ErrorMessage);
                        continue;
                    }

                    if (medicineProductionDate >= medicineExpityDate ||
                        pharmacy.Medicines.Any(x => x.Name == medDto.Name && x.Producer == medDto.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var medicine = new Medicine()
                    {
                        Name = medDto.Name,
                        Price = (decimal)medDto.Price,
                        Category = (Category)medDto.Category,
                        ProductionDate = medicineProductionDate,
                        ExpiryDate = medicineExpityDate,
                        Producer = medDto.Producer,
                    };

                    //medCounter++;
                    pharmacy.Medicines.Add(medicine);
                }

                validPharmacies.Add(pharmacy);
                sb.AppendLine(String.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(validPharmacies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}

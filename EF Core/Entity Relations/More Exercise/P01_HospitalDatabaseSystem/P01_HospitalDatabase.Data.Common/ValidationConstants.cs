namespace P01_HospitalDatabase.Data.Common
{
    public class ValidationConstants
    {
        // Patient
        public const int PatientFirstNameLength = 50;
        public const int PatientLastNameLength = 50;
        public const int PatientAddressLength = 250;

        // Visitation
        public const int VisitationCommentsLength = 250;

        // Diagnose
        public const int DiagnoseNameLength = 50;
        public const int DiagnoseCommentsLength = 250;

        // Medicament
        public const int MedicamentNameLength = 50;

        // Doctor
        public const int DoctorNameLength = 100;
        public const int DoctorSpecialityLength = 100;
    }
}
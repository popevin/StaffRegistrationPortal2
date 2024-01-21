namespace StaffApplication2.DTOs
{
    public class Employee
    {


        public int Id { get; set; }

        public int UserId { get; set; }

        public string DobUploadPath { get; set; }

        public string CertificateUploadPath { get; set; }

        public string PassportUploadPath { get; set; }

        public string EmploymentStatus { get; set; }

        public string MaritalStatus { get; set; }

        public int WorkingExperience { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string Disability { get; set; }

        public string MedicalRecordUploadPath { get; set; }

        public string NationalIDcode { get; set; }

        public string Nationality { get; set; }

        public string IdUploadPath { get; set; }
        public string CreatedBy { get; set; }


        public string UpdatedBy { get; set; }

        public bool IsUpdated { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }



    }

    public class CreateEmployee
    {

        public int UserId { get; set; }

        public string DobUploadPath { get; set; }

        public string CertificateUploadPath { get; set; }

        public string PassportUploadPath { get; set; }

        public string EmploymentStatus { get; set; }

        public string MaritalStatus { get; set; }

        public int WorkingExperience { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string Disability { get; set; }

        public string MedicalRecordUploadPath { get; set; }

        public string NationalIDcode { get; set; }

        public string Nationality { get; set; }

        public string IdUploadPath { get; set; }
        public string CreatedBy { get; set; }

    }

    public class UpdateEmployee
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string DobUploadPath { get; set; }

        public string CertificateUploadPath { get; set; }

        public string PassportUploadPath { get; set; }

        public string EmploymentStatus { get; set; }

        public string MaritalStatus { get; set; }

        public int WorkingExperience { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string Disability { get; set; }

        public string MedicalRecordUploadPath { get; set; }

        public string NationalIDcode { get; set; }

        public string Nationality { get; set; }

        public string IdUploadPath { get; set; }

        public string UpdatedBy { get; set; }



    }

    public class DeleteEmployee
    {
        public int Id { get; set; }

        public string DeletedBy { get; set; }




    }
}

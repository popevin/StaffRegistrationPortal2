namespace StaffApplication2.DTOs
{
    public class User
    {

        public int UserId { get; set; }
        public int RoleId { get; set; }

        public int GenderId { get; set; }

        public int DepartmentId { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? OtherName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public bool IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool IsUpdated { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool IsDeactivated { get; set; }

        public string? DeactivatedBy { get; set; }

        public DateTime DeactivatedDate { get; set; }

        public bool IsReactivated { get; set; }

        public string? ReactivatedBy { get; set; }

        public DateTime ReactivatedDate { get; set; }
    }

    public class CreateUser
    {

        public int RoleId { get; set; }

        public int GenderId { get; set; }

        public int DepartmentId { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? OtherName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }



    }
    public class EmailandPassword
    {
        public string? Email { get; set; }

        public string? Password { get; set; }
    }

    public class ReactivateUser
    {
        public int Id { get; set; }

        public string? ReactivateEmail { get; set; }

        public string? ReactivatedBy { get; set; }
    }

    public class DeactivateUser
    {
        public int Id { get; set; }

        public string? DeactivateEmail { get; set; }


        public string? DeactivatedBy { get; set; }

    }

    public class UpdateUser
    {

        public int UserId { get; set; }
        public int RoleId { get; set; }

        public int GenderId { get; set; }

        public int DepartmentId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public bool IsActive { get; set; }

        public bool IsUpdated { get; set; }

        public string UpdatedBy { get; set; }

     }

  



}

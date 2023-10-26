namespace RESTful.API.Infrastructure.Models
{
    public class UserDTO : BaseModelDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public DateTime? DateOfBirth { get; set; }

        #region Relationships
        
        public int  TypeId { get; set; }

        #endregion
    }
}

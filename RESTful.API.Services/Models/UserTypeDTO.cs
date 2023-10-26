namespace RESTful.API.Infrastructure.Models
{
    public class UserTypeDTO : BaseModelDTO
    {
        public string Name { get; set; }

        #region Relationships
        public IEnumerable<UserDTO> Users { get; set; } 
        #endregion
    }
}

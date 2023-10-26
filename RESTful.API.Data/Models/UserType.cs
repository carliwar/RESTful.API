using System.ComponentModel.DataAnnotations.Schema;

namespace RESTful.API.Data.Models
{
    [Table("UserType")]
    public class UserType : BaseModel
    {
        public string Name { get; set; }

        #region Relationships
        public ICollection<User> Users { get; set; } 
        #endregion
    }
}

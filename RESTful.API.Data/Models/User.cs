using System.ComponentModel.DataAnnotations.Schema;

namespace RESTful.API.Data.Models
{
    [Table("User")]
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public DateTime? DateOfBirth { get; set; }

        #region Relationships

        public UserType Type { get; set; }
        public int  TypeId { get; set; }

        #endregion
    }
}

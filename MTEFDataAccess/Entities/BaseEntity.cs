using System.ComponentModel.DataAnnotations.Schema;

namespace MTEFDataAccess.Entities
{
    public class BaseEntity
    {
        [Column("dateCreation")]
        public DateTime DateCreation { get; set; }
    }
}

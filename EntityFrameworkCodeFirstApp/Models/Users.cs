using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCodeFirstApp.Models
{
    public class Users
    {
        //key is used for auto increment primary key

        [Key]
        public int ID { get; set; }
        public string Name  { get; set; }

        public string ContactNo { get; set; }
    }
}

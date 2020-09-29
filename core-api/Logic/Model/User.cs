using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Logic.Model
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public string Gender { get; set; }
    }
}

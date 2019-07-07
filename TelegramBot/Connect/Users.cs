namespace TelegramBot.Connect
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [Key]
        public int idUser { get; set; }

        [Required]
        [StringLength(60)]
        public string Uname { get; set; }

        [Required]
        [StringLength(50)]
        public string Upassword { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public int? telegramId { get; set; }
    }
}

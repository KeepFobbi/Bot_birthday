namespace TelegramBot.Connect
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Birthday")]
    public partial class Birthday
    {
        [Key]
        public int idBirthday { get; set; }

        public int idUser { get; set; }

        [Required]
        [StringLength(60)]
        public string Uname { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(255)]
        public string Note { get; set; }
    }
}

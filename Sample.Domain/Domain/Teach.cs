using Sample.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sample.Domain.Domain
{
    [Table("T_teach")]
    public class Teach : BaseEntity
    {
        [Column("Varchar(255)"), Description("姓名")]
        public string Name { get; set; }

        [Column("DateTime"), Description("创建时间")]
        public DateTime Creattime { get; set; }

        [DefaultValue(false), Description("创建时间")]
        public bool Curricula { get; set; }

    }
}

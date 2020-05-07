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
        [Column(TypeName = "Varchar(255)"), Description("姓名")]
        public string Name { get; set; }

        [Column(TypeName = "DateTime"), Description("创建时间")]
        public DateTime Creattime { get; set; }

        [DefaultValue(false), Description("课程")]
        public bool Curricula { get; set; }

    }
}

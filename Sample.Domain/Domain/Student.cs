using Sample.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sample.Domain.Domain
{
    [Table("T_student")]
   public class Student:BaseEntity
    {
        [Column(TypeName = "Varchar(20)"),Description("学生姓名")]
        public string  StudentName { get; set; }

        [Column(TypeName = "DateTime"), Description("创建时间")]
        public DateTime Creattime { get; set; }

        [Column(TypeName = "varchar(255)"),Description("家庭地址")]
        public string  Address { get; set; }
    }
}

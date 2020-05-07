using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sample.Infrastructure.Interfaces
{
  public  class BaseEntity
    {
        [Key, Column(TypeName ="VarChar(40)")]
        public Guid Id { get; set; }
    }
}

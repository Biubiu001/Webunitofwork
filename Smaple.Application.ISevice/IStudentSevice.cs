using Sample.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Smaple.Application.ISevice
{
    public interface IStudentSevice
    {
         Task<int>  Add();
        Task<Student> Get(string id); 
    }
}

using Sample.Domain.Domain;
using Sample.Infrastructure.Interfaces.Abstractions;
using Smaple.Application.ISevice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Service
{
    public class StudentService : IStudentSevice
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<Student> _Stduentrepository;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _Stduentrepository = unitOfWork.CreateRepository<Student>();
        }
        public async Task<int> Add()
        {
            var st = new Student
            {
                Address = "111",
                Creattime = DateTime.Now,
                Id = Guid.NewGuid(),
                StudentName = "text"

            };
            _Stduentrepository.InsertRange(st);
            return await _unitOfWork.SaveChangesAsync()==true?1:0;

        }

        public Task<Student> Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}

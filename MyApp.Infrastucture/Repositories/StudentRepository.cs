using Microsoft.EntityFrameworkCore;
using MyApp.Application.Interfaces;
using MyApp.Core.Enteties;
using MyApp.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infrastucture.Repositories
{
    public  class StudentRepository(ApplicationDbContext context) : IStudentRepository
    {

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await context.Students.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task <Student> AddStudentAsync(Student student)
        {
            context.Students.Add(student);
            await context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            var existingStudent = await context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (existingStudent != null)
            {
                // 1. Map the new values to the existing tracked entity
                existingStudent.Name = student.Name;
                existingStudent.Class = student.Class;
                existingStudent.FatherName = student.FatherName;
                existingStudent.MotherName = student.MotherName;

                // 2. Save the changes to the database!
                await context.SaveChangesAsync();

                return existingStudent;
            }

            return null; // Or handle as not found
        }

        public async Task<string> DeleteStudentAsync(int id)
        {
            var Data = await context.Students.FirstOrDefaultAsync(x => x.Id == id);
          
            
                context.Students.Remove(Data);
                context.SaveChanges();
            return "Student is detelted successufully ";
            }
            
        }
}

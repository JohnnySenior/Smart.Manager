﻿using Microsoft.AspNetCore.Mvc;
using SmartManager.Models.Groups;
using SmartManager.Models.Students;
using SmartManager.Services.Processings.GroupStatistics;
using SmartManager.Services.Processings.Students;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartManager.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentProcessingService studentProcessingService;
        private readonly IGroupStatisticProccessingService groupStatisticProccessingService;

        public StudentController(
            IStudentProcessingService studentProcessingService,
            IGroupStatisticProccessingService groupStatisticProccessingService)
        {
            this.studentProcessingService = studentProcessingService;
            this.groupStatisticProccessingService = groupStatisticProccessingService;
        }

        public IActionResult PostStudent()
        {
            return View();
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostStudent(Student student)
        {

            await this.studentProcessingService.AddStudentAsync(student);

            await this.groupStatisticProccessingService
                .UpdateStatisticsByStudentAsync(student);

            return RedirectToAction("GetStudents");
        }

        public IActionResult GetStudents()
        {
            IQueryable<Student> students = this.studentProcessingService.RetrieveAllStudents();

            return View(students);
        }

        public IActionResult GetStudentsWithGroup(Guid groupId)
        {
            IQueryable<Student> applicants =
                this.studentProcessingService.RetrieveAllStudents().Where(a => a.GroupId == groupId);

            return View(applicants);
        }

        public IActionResult GetStudentsWithAttendances()
        {
            IQueryable<Student> students = this.studentProcessingService.RetrieveAllStudents();

            return View(students);
        }

        public IActionResult GetStudentsWithPayments(Guid groupId)
        {
            IQueryable<Student> students =
                this.studentProcessingService.RetrieveAllStudents().Where(s => s.GroupId == groupId);

            return View(students);
        }

        public async ValueTask<ActionResult> GetStudentAsync(Guid Id)
        {
            var student =
                await this.studentProcessingService.RetrieveStudentByIdAsync(Id);

            return Ok(student);
        }

        [HttpGet]
        public async ValueTask<IActionResult> DeleteStudent(Guid studentId)
        {
            IQueryable<Student> students = this.studentProcessingService.RetrieveAllStudents();

            Student student = students.SingleOrDefault(a => a.Id == studentId);

            await this.studentProcessingService.RemoveStudentAsync(student.Id);

            return RedirectToAction("GetStudents");
        }

        [HttpGet]
        public async ValueTask<IActionResult> DeleteStudentInGroup(Guid studentId)
        {
            IQueryable<Student> students = this.studentProcessingService.RetrieveAllStudents();

            Student student = students.SingleOrDefault(a => a.Id == studentId);

            await this.studentProcessingService.RemoveStudentAsync(student.Id);

            return RedirectToAction("GetStudentsWithGroup");
        }
    }
}

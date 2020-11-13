using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Module1.Data;
using Module1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Module1
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = GetAllEmployees();
            var assignment = new Assignment()
            {
                Name = "Test 2",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                EmployeeId = employees[0].Id
            };

            //Editing Assignment
            CreateAssignment(assignment);
            assignment.Name = "Test 1";
            assignment.Employee = employees[1];

            EditAssignment(assignment);

                       

            //Creating Assignments
            Console.WriteLine("Heres a list of all Assignments");


            //Query

            //Lazy Loading
            Console.WriteLine("\nLAZY LOADING");
           // var assignments = GetAllAssignments();
            using (var db = new ApplicationDbContext())
            {
                var assignments = db.Assignments.ToList();
                foreach (var a in assignments)
                {
                    Console.WriteLine($"{a.Employee.FirstName} {a.Employee.LastName} has to do {a.Name}");
                }

            }



            ////Eager Loading
            using (var context = new ApplicationDbContext())
            {
                var employeesAssigned = context.Assignments.Include(x => x.Employee).ToList();

                Console.WriteLine("\nEAGER LOADING");
                foreach (var employeeAssignment in employeesAssigned)
                {
                    Console.WriteLine($"{employeeAssignment.Employee.FirstName} {employeeAssignment.Employee.LastName} has to do {employeeAssignment.Name}");
                }
            }
            ////Explicit Loading
            Console.WriteLine("\nEXPLICIT LOADING");

            using (var context = new ApplicationDbContext())
            {
                var assignments = GetAllAssignments();
                var assignment1 = context.Assignments.Single(x => x.Id == assignments[0].Id);

                context.Entry(assignment1).Reference(x=> x.Employee).Load();

                Console.WriteLine($"{assignment1.Employee.FirstName} {assignment1.Employee.LastName} has to do {assignment1.Name}");
            }
            var newAssignment = GetAssignment("Test 1");
            DeleteAssignment(newAssignment);
            
        }

        public static List<Employee> GetAllEmployees()
        {
            using var context = new ApplicationDbContext();
            var employees = context.Employees.ToList();
            context.Dispose();
            return employees;
        }
        public static List<Assignment> GetAllAssignments()
        {
            using var context = new ApplicationDbContext();
            var assignments = context.Assignments.ToList();
            context.Dispose();
            return assignments;
            
        }
        public static Assignment GetAssignment(string assignmentName)
        {
            using var context = new ApplicationDbContext();
            var assignment = context.Assignments.FirstOrDefault(x => x.Name == assignmentName);
            context.Dispose();
            return assignment;
        }
        public static void EditAssignment(Assignment assignment)
        {
            using (var context = new ApplicationDbContext()) 
            { 
                context.Assignments.Update(assignment);
                context.SaveChanges();
            }
        }
        public static void CreateAssignment(Assignment assignment)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Assignments.Add(assignment);
                context.SaveChanges();
            }
        }
        public static void DeleteAssignment(Assignment assignment)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    context.Assignments.Remove(assignment);
                    context.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("Delete Error, Assignment not found!");
                }
                
            }       
        }
    }
}

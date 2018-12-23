using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExistingDbAndCoreLib.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectCore.Entities;

namespace ExistingDbAndCoreLib.Pages
{
    public class IndexModel : PageModel
    {
        dbSchoolContext _context;

        public IndexModel(dbSchoolContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            try
            {
                School school = _context.Students.Include()
                // .Where(s => s.Id == 1).include.FirstOrDefault();
                //School school = _context.Schools.Where(s => s.Id == 1).FirstOrDefault();
                //var students = _context.Students.Where(s => s.School.Id == 1).ToList();
                var studentsInSchool = school.Students;
            } catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}

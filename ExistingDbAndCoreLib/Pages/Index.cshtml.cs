using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExistingDbAndCoreLib.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            var students = _context.Students.Where(s => s.School.Id == 1).ToList();
            var apa = students[0].FirstName;
            var katt = 2;
        }
    }
}

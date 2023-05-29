using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DeploymentAppWithDb.Data;
using DeploymentAppWithDb.Models;

namespace DeploymentAppWithDb.Pages.Expenses
{
    public class CreateModel : PageModel
    {
        private readonly DeploymentAppWithDb.Data.ProjectContext _context;

        public CreateModel(DeploymentAppWithDb.Data.ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ExpenseTypeID"] = new SelectList(_context.ExpenseTypes, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Expense Expense { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Expenses.Add(Expense);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

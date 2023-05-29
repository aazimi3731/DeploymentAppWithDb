using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DeploymentAppWithDb.Data;
using DeploymentAppWithDb.Models;

namespace DeploymentAppWithDb.Pages.Expenses
{
    public class DetailsModel : PageModel
    {
        private readonly DeploymentAppWithDb.Data.ProjectContext _context;

        public DetailsModel(DeploymentAppWithDb.Data.ProjectContext context)
        {
            _context = context;
        }

      public Expense Expense { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Expenses == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses.FirstOrDefaultAsync(m => m.ID == id);
            if (expense == null)
            {
                return NotFound();
            }
            else 
            {
                var expenseType = _context.ExpenseTypes.FirstOrDefaultAsync(type => type.ID == expense.ExpenseTypeID).Result;
                expense.ExpenseType = expenseType != null ? expenseType : new ExpenseType();

                Expense = expense;
            }
            return Page();
        }
    }
}

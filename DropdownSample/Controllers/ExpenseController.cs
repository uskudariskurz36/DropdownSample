using DropdownSample.Helpers;
using DropdownSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DropdownSample.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CreateExpenseModel model = new CreateExpenseModel();

            LoadModel(model);

            return View(model);
        }

        private static void LoadModel(CreateExpenseModel model)
        {
            List<string> categories = new List<string>();
            categories.Add("Akaryakıt");
            categories.Add("Gıda");
            categories.Add("Giyim");
            categories.Add("Ofis");

            // Dropdown ların items ları SelectList türünde verilir.
            // SelectList bir veri kaynağı(list türünde) alır.
            model.Categories = new SelectList(categories);

            DatabaseContext db = new DatabaseContext();
            List<User> users = db.Users.ToList();

            // lstUsers.DataSource = users;
            // lstUsers.DisplayMember = "Username";
            // lstUsers.ValueMember = "Id";

            // Dropdown ların items ları SelectList türünde verilir.
            // SelectList bir veri kaynağı(list türünde) alır.
            model.Users = new SelectList(users, "Id", "Username");
        }

        [HttpPost]
        public IActionResult Create(CreateExpenseModel model)
        {
            if (ModelState.IsValid)
            {
                Expense expense = new Expense
                {
                    Title = model.Title,
                    Description = model.Description,
                    Date = model.Date,
                    Amount = model.Amount,
                    Category = model.Category,
                    UserId = model.UserId
                };

                DatabaseContext db = new DatabaseContext();
                db.Expenses.Add(expense);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            LoadModel(model);

            // Model valid değilse;
            return View(model);
        }
    }
}

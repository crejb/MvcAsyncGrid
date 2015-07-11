using AsyncGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsyncGrid.Controllers
{
    public class HomeController : Controller
    {
        public static IEnumerable<Person> _people = new List<Person>
        {
            new Person{FirstName = "Andrew", LastName = "Smith", Age=25},
            new Person{FirstName = "Barry", LastName = "Taylor", Age=35},
            new Person{FirstName = "Chris", LastName = "Wales", Age=30},
        };

        public ActionResult Index(string sortBy = "FirstName", bool sortAsc = true)
        {
            var getSortVal = GetSortValueFunction(sortBy);

            var sortedPeople = sortAsc
                ? _people.OrderBy(getSortVal)
                : _people.OrderByDescending(getSortVal);

            ViewBag.SortDirections = GetNextSortDirections(sortBy, sortAsc);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_People", sortedPeople);
            }

            return View(sortedPeople);
        }

        private Func<Person, object> GetSortValueFunction(string sortBy)
        {
            switch (sortBy)
            {
                case "FirstName":
                    return p => p.FirstName;
                case "LastName":
                    return p => p.LastName;
                case "Age":
                    return p => p.Age;
                default:
                    return p => p.FirstName;
            }
        }

        private Dictionary<string, bool> GetNextSortDirections(string sortBy, bool sortAsc)
        {
            // By default, next timewe sort by a column it should be sorted ascending
            var sortDirections = new Dictionary<string, bool>{
                {"FirstName", true},
                {"LastName", true},
                {"Age", true}
            };

            // The next time we sort by the current column, toggle the current direction
            sortDirections[sortBy] = !sortAsc;

            return sortDirections;
        }
    }
}
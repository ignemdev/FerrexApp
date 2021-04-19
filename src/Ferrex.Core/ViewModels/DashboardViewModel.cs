using Ferrex.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferrex.Core.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<Product> TodayProducts { get; set; }
        public IEnumerable<Category> TodayCategories { get; set; }
        public int RegisteredProducts { get; set; }
        public int RegisteredCategories { get; set; }
        public int WithoutStockProducts { get; set; }
        public int AcumulatedStock { get; set; }
    }
}

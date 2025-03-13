using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Shared.Models
{
    public class SelectedModelChecked
    {
        public object Value { set; get; }
        public object Text { set; get; }
        public bool IsChecked { set; get; } = false;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRMS.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }

        public virtual Job Job { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dashboard.Web.Models
{
    public class DashboardData
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public string Data { get; set; }
        public ApplicationUser User { get; set; }
    }
}
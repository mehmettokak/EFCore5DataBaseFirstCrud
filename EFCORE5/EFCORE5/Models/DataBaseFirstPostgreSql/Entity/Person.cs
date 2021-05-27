using System;
using System.Collections.Generic;

#nullable disable

namespace EFCORE5.Models.DataBaseFirstPostgreSql.Entity
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
    }
}

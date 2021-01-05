using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyToDo.Models
{
    public class Todo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }

    }
}

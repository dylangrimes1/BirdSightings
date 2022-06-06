using System;
using SQLite;

namespace Notes.Models
{
    public class Bird
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Species { get; set; }

        public string Location { get; set; }

        public string DateOfViewing { get; set; }
        public DateTime Date { get; set; }
    }
}
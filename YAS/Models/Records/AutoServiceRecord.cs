using System;

namespace YAS.Models.Records
{
    public class AutoServiceRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string Photo { get; set; }
    }
}
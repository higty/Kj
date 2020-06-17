using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace DbAccessConsoleApp
{
    public class TaskRecord
    {
        public Guid TaskCD { get; set; }
        public String Title { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreateTime { get; set; }
        public String UserName { get; set; }
        public String Description { get; set; }
    }
}

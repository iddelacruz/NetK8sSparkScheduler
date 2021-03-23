using System;
using System.Collections.Generic;
using System.Text;

namespace NetSparkScheduler.Services.Models
{
    //TODO: Terminar este struct de string
    public sealed class Status
    {
        public static Status Pending = new Status("Pending");
        public static Status Running = new Status("Status");
        public static Status Completed = new Status("Completed");

        string value;
        public string Title
        {
            get { return this.value; }
            private set { this.value = value; }
        }

        Status(string value)
        {
            this.value = value;
        }
    }
}

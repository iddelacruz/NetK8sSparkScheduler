namespace NetSparkScheduler.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class Pod
    {
        public string Identifier { get; private set; }
        public string Name { get; private set; }
        public Status Status { get; private set; }

        public Pod(string identifier, string name, Status status)
        {
            this.Identifier = identifier;
            this.Name = name;
            this.Status = status;
        }
    }
}

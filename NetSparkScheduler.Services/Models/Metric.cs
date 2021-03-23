namespace NetSparkScheduler.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class Metric
    {
        public string Name { get; private set; }
        public uint Memory { get; private set; }
        public uint CPU { get; private set; }

        public Metric(string namespaceName, uint memory, uint cpu)
        {
            this.Name = namespaceName;
            this.Memory = memory;
            this.CPU = cpu;
        }
    }
}

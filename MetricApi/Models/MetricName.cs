using System;
using System.Collections.Generic;

namespace MetricApi.Models
{
    public partial class MetricName
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long GroupId { get; set; }

        public MetricGroup Group { get; set; }
    }
}

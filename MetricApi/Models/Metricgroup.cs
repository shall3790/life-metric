using System;
using System.Collections.Generic;

namespace MetricApi.Models
{
    public partial class MetricGroup
    {
        public MetricGroup()
        {
            MetricName = new HashSet<MetricName>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<MetricName> MetricName { get; set; }
    }
}

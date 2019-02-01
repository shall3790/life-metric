using System.Collections.Generic;
using MetricApi.Models;

namespace MetricApi.Services
{
    public interface IMetricService
    {
        string Get();
        List<Metricgroup> GetGroups();
    }
}

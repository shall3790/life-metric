# life-metric

## Generate db Model
`dotnet ef dbcontext scaffold "Host=localhost;Database=metricdb;Username=admin;Password=password" Npgsql.EntityFrameworkCore.PostgreSQL -c MetricDbContext -o Models`
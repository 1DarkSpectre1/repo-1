using Dapper;
using MetricsAgent.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public interface IDotNetMetricsRepository : IRepository<DotNetMetric>
    {

    }
    public class DotNetMetricsRepository : IDotNetMetricsRepository
    {

        private string ConnectionString = SettingsDB.GetConnectionDB();
        // инжектируем соединение с базой данных в наш репозиторий через конструктор
        public IList<DotNetMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<DotNetMetric>("SELECT Id, Time, Value FROM dotnetmetrics").ToList();
            }
        }
        public IList<DotNetMetric> GetByTimeSpan(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<DotNetMetric>("SELECT * FROM dotnetmetrics WHERE Time>=@fromTime AND Time<=@toTime",
                     new
                     {
                         fromTime = fromTime.Second,
                         toTime = toTime.Second

                     }).ToList();

            }
        }
        public void Create(DotNetMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO dotnetmetrics(value, time) VALUES(@value, @time)",
                    new
                    {
                        value = item.Value,
                        time = item.Time
                    });

            }
        }
        public DotNetMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<DotNetMetric>("SELECT Id, Time, Value FROM dotnetmetrics WHERE id=@id",
                    new { id = id });
            }
        }
    }
}

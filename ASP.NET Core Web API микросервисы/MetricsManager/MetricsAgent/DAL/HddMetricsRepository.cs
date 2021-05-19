using Dapper;
using MetricsAgent.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public interface IHddMetricsRepository : IRepository<HddMetric>
    {

    }

    public class HddMetricsRepository : IHddMetricsRepository
    {
        private string ConnectionString = SettingsDB.GetConnectionDB();
        // инжектируем соединение с базой данных в наш репозиторий через конструктор
        public IList<HddMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<HddMetric>("SELECT Id, Time, Value FROM hddmetrics").ToList();
            }

        }
        public HddMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<HddMetric>("SELECT Id, Time, Value FROM hddmetrics WHERE id=@id",
                    new { id = id });
            }

        }

        public IList<HddMetric> GetByTimeSpan(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<HddMetric>("SELECT * FROM hddmetrics WHERE Time>=@fromTime AND Time<=@toTime",
                     new
                     {
                         fromTime = fromTime.Second,
                         toTime = toTime.Second

                     }).ToList();

            }
        }

        public void Create(HddMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO hddmetrics(value, time) VALUES(@value, @time)",
                    new
                    {
                        value = item.Value,
                        time = item.Time.ToUnixTimeSeconds()
                    });

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EmailThing._10_Core.Domain.Model;

namespace EmailThing._10_Core.Domain.Repository
{
    public class Repository<T>
    {
        private readonly SqlConnection _connection;
        public Repository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Create(T obj)
        {
            
            var type = typeof(T);
            var props = type.GetProperties();
            var sql = $"INSERT INTO {type} ({GetParams(props)}) VALUES ({GetParams(props, true)})";
            return await _connection.ExecuteAsync(sql, obj);
        }

        public async Task<IEnumerable<T>> ReadAll()
        {
            var type = typeof(T);
            var props = type.GetProperties();
            var sql = $"SELECT {GetParams(props)} FROM {type.Name}";
            return await _connection.QueryAsync<T>(sql);
        }
        public async Task<IEnumerable<T>> ReadOneByGuid(Guid guid)
        {
            var type = typeof(T);
            var props = type.GetProperties();
            var sql = $"SELECT {GetParams(props)} FROM {type.Name} WHERE GuidID = @GuidID";
            return await _connection.QueryAsync<T>(sql, new {GuidID = guid});
        }

        private static string GetParams(PropertyInfo[] props, bool includeAt = false)
        {
            return string.Join(',', props.Select(p => (includeAt ? "@" : "") + p.Name));
        }


        //string readAll = @"SELECT Id, Date, DoneToday, DoingTomorrow

        //                    FROM LogDatabase";
        //private static StringBuilder GetParams(PropertyInfo[] props)
        //{
        //    StringBuilder propBuilder = new StringBuilder();
        //    return propBuilder
        //}
    }
}

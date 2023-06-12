using Core.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public static class EntityHelper
    {
        public static string GetTableName<TEntity>()
        {
            Type type = typeof(TEntity);
            dynamic? tableattr = type.GetCustomAttributes(false).FirstOrDefault(attr => attr.GetType().Name == "TableAttribute");
            var name = type.Name;

            if (tableattr != null)
            {
                name = tableattr.Name;
            }

            return name;
        }
        public static List<string> GetColumns<TEntity>()
        {
            Type type = typeof(TEntity);
            return type.GetProperties().Select(prop => prop.Name).ToList();
        }
        public static List<string> GetValue<TEntity>(TEntity entity)
        {
            Type type = typeof(TEntity);
            return type.GetProperties().Select(prop =>
            {
                string value = string.Empty;
                object valueObject = entity?.GetType()?.GetProperties()?.FirstOrDefault(entityProp => entityProp.Name == prop.Name)?.GetValue(entity);
                if (prop is int || prop.PropertyType.BaseType == typeof(int) || prop.PropertyType.BaseType == typeof(Enum) || prop.PropertyType.Name == nameof(Decimal) || prop.PropertyType.Name == nameof(Double))
                {
                    value = valueObject?.ToString() ?? string.Empty;
                }
                else if (prop is bool)
                {
                    if ((bool)valueObject)
                    {
                        value = "1";
                    }
                    else
                    {
                        value = "0";
                    }
                }
                else if (prop is Guid)
                {
                    value = $"'{valueObject?.ToString() ?? Guid.Empty.ToString()}'";

                }
                else if (prop.PropertyType.Name == nameof(DateTime))
                {
                    DateTime date = (DateTime)valueObject;
                    value = $"cast('{date.ToString("yyyyMMdd hh:mm:ss")}' as datetime)";
                    //value = $"cast('{date.ToString("G")}' as datetime)  convert(datetime,'{date.ToString("G")}',20)";
                }
                else
                {
                    value = $"'{valueObject?.ToString() ?? string.Empty}'";
                }
                return value;
            }).ToList();
        }
        public static Dictionary<string, string> GetColumnsValue<TEntity>(TEntity entity)
        {
            Dictionary<string, string> columnsValue = new();
            var columns = GetColumns<TEntity>();
            var value = GetValue(entity);
            if (columns.Count == value.Count)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    columnsValue.Add(columns[i], value[i]);
                }
            }
            return columnsValue;
        }
        public static List<TEntity> MapEntity<TEntity>(SqlDataReader sqlDataReader)
        {
            Type listType = typeof(List<TEntity>);
            var entities = (List<TEntity>)Activator.CreateInstance(listType);
            Type type = typeof(TEntity);
            while (sqlDataReader.Read())
            {
                var entity = (TEntity)Activator.CreateInstance(type);
                var props = entity?.GetType()?.GetProperties();
                foreach (var prop in props)
                {
                    prop.SetValue(entity, sqlDataReader[prop.Name]);
                }
                entities.Add(entity);
            }
            return entities;
        }
    }
}

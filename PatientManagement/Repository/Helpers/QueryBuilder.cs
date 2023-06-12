using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class QueryBuilder
    {
        public QueryBuilder(string query = "")
        {
            QueryString = new StringBuilder(query);
        }
        public StringBuilder QueryString { get; set; }
        public string Build()
        {
            return QueryString.ToString().Trim();
        }

        public void AddStatement(QueryBuilder query, string statement)
        {
            query.QueryString.Append(statement);
        }
        public QueryBuilder Update(string tableName)
        {
            AddStatement(this, $" update {tableName}");
            return this;
        }
        public QueryBuilder Set(Dictionary<string, string> columnsValue)
        {
            List<string> values = new();
            foreach (var columnValue in columnsValue)
            {
                if (columnValue.Key.ToLower() == "id")
                {
                    continue;
                }
                values.Add($" {columnValue.Key} = {columnValue.Value}");
            }
            AddStatement(this, $" set {string.Join(", ", values)}");
            return this;
        }
        public QueryBuilder InsertInto(string tableName, List<string> columns, List<List<string>> values)
        {
            AddStatement(this, $" insert into {tableName} ({string.Join(", ", columns)})");
            List<string> valueQueries = new();
            foreach (var value in values)
            {
                if (value.Count == columns.Count)
                {
                    valueQueries.Add($" values ({string.Join(", ", value)})");
                }
            }
            AddStatement(this, string.Join(", ", valueQueries));
            return this;
        }
        public QueryBuilder From(string tableName)
        {
            AddStatement(this, $" from {tableName}");
            return this;
        }
        public QueryBuilder Where(string column, string value)
        {
            AddStatement(this, $" where {column} = '{value}'");
            return this;
        }
        public QueryBuilder Where(string column, int value)
        {
            AddStatement(this, $" where {column} = {value}");
            return this;
        }
        public QueryBuilder Join(string tableName)
        {
            AddStatement(this, $" join {tableName}");
            return this;
        }
        public QueryBuilder On(string condition)
        {
            AddStatement(this, $" on {condition}");
            return this;
        }
        public string Between(string column, DateTime startDate, DateTime endDate)
        {
            return $" {column} between '{startDate:yyyy-MM-dd}' and '{endDate:yyyy-MM-dd}'";
        }
        public QueryBuilder And(string condition)
        {
            AddStatement(this, $" and {condition}");
            return this;
        }
        public QueryBuilder Or(string condition)
        {
            AddStatement(this, $" or {condition}");
            return this;
        }
    }
}

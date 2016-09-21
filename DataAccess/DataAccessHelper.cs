using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessHelper
    {
        private ConnectionManager _conMan;
        private SqlDataReader _reader;

        public DataAccessHelper(ConnectionManager conMan)
        {
            this._conMan = conMan;
        }

        private SqlCommand CreateCommand(string procedure, SqlParameter[] parameters = null)
        {
            SqlCommand command = new SqlCommand
            {
                Connection = this._conMan.GetConnection(),
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = procedure
            };
            if (parameters != null)
                command.Parameters.AddRange(parameters);
            return command;
        }

        public List<T> GetDataList<T>(string procedure, SqlParameter[] parameters = null, bool keepOpen = false)
        {
            List<T> result = null;
            try
            {
                var command = this.CreateCommand(procedure, parameters);
                this._reader = command.ExecuteReader();

                result = ConvertReaderToList<T>(this._reader);
                if (!keepOpen)
                    this._reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public List<T> GetNextDataList<T>(bool keepOpen = false)
        {
            List<T> result = null;
            try
            {
                result = ConvertReaderToList<T>(this._reader);
                if (!keepOpen)
                    this._reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public T GetScalar<T>(string procedure, SqlParameter[] parameters = null, bool keepOpen = false)
        {
            var result = default(T);
            try
            {
                var command = this.CreateCommand(procedure, parameters);
                this._reader = command.ExecuteReader();

                result = ConvertReaderToScalar<T>(this._reader);
                if (!keepOpen)
                    this._reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public T GetNextScalar<T>(bool keepOpen = false)
        {
            var result = default(T);
            try
            {
                result = ConvertReaderToScalar<T>(this._reader);
                if (!keepOpen)
                    this._reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        private static T ConvertReaderToScalar<T>(SqlDataReader reader)
        {
            DataTable table = new DataTable();
            table.Load(reader);
            if (table.Rows.Count == 0)
            {
                return default(T);
            }

            return (T)Convert.ChangeType(table.Rows[0][0], typeof(T));
        }

        private static List<T> ConvertReaderToList<T>(SqlDataReader reader)
        {
            DataTable table = new DataTable();
            table.Load(reader);
            if (table.Rows.Count == 0)
            {
                return null;
            }

            var rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertRowsToList<T>(rows);
        }

        private static List<T> ConvertRowsToList<T>(IList<DataRow> rows)
        {
            List<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (var row in rows)
                {
                    T item = GetObjectFromRow<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }

        private static T GetObjectFromRow<T>(DataRow row)
        {
            T item = default(T);
            if (row != null)
            {
                item = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    var prop = item.GetType().GetProperty(column.ColumnName);
                    if (prop != null)
                    {
                        try
                        {
                            var value = row[column.ColumnName];
                            if (!string.IsNullOrEmpty(value.ToString()))
                            {
                                SetPropertyValue(item, prop, value);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }
            }

            return item;
        }

        public void PutData(string procedure, SqlParameter[] parameters = null, bool keepOpen = false)
        {
            try
            {
                var command = this.CreateCommand(procedure, parameters);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void SetPropertyValue(object model, PropertyInfo property, object value)
        {
            if (property.PropertyType == typeof(DateTimeOffset?))
            {
                var actualValue = (value as DateTimeOffset?).Value.Date;
                property.SetValue(model, actualValue.Date, null);
            }
            else if (property.PropertyType == typeof(TimeSpan))
            {
                var actualValue = (TimeSpan)value;
                property.SetValue(model, actualValue, null);
            }
            else
            {
                var actualValue = Convert.ChangeType(value, property.PropertyType);
                property.SetValue(model, actualValue, null);
            }
        }
    }
}

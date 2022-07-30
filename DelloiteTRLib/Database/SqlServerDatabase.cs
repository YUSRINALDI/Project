using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;

namespace DelloiteTRLib.Database
{
    public class SqlServerDatabase
    {
        private string _connectionString;
        private SqlConnection _connection;      
        private SqlTransaction _transaction;
        private bool _useTransaction;

        public SqlServerDatabase(string connectionString)
        {
            _connectionString = connectionString;
            this.openConnection();
            
        }

        public SqlDataReader ExecuteReader(string commandText)
        {
            return this.ExecuteReader(commandText, null);
        }


        public SqlDataReader ExecuteReader(string commandText, Hashtable parameters)
        {   
            SqlCommand command = null;                       
            SqlDataReader dataReader = null;
            try
            {
                command = new SqlCommand(commandText, _connection);               
                this.AddParameters(parameters, ref command); 
                dataReader = command.ExecuteReader();                
            }
            catch (Exception ex)
            {   
                throw ex;
            }

            return dataReader;
        }


        public void AddParameters(Hashtable parameters, ref SqlCommand command)
        {
            if (parameters != null)
            {
                if (parameters.Count > 0)
                {
                    foreach (DictionaryEntry  de in parameters)
                    {
                        SqlParameter parameter = new SqlParameter(de.Key.ToString(), de.Value);
                        command.Parameters.Add(parameter);
                    }
                }
            }
        }




        public int ExecuteNonQuery(string commandText, Hashtable  parameters)
        {   
            SqlCommand command = null;   
            int affectedRows = 0;
            try
            {  
                command = new SqlCommand(commandText, _connection);
                if ( _useTransaction )
                {
                    command.Transaction = _transaction;
                }
                this.AddParameters(parameters, ref command);
                affectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {  
                throw ex;
            }      
            return affectedRows;
        }


        public object ExecuteScalar(string commandText, Hashtable parameters)
        {   
            SqlCommand command = null;
            object scalarValue = null;

            try
            {
              
                command = new SqlCommand(commandText, _connection);
                this.AddParameters(parameters, ref command);

                scalarValue =command.ExecuteScalar();

            }
            catch (Exception ex)
            {               
                throw ex;
            }

            return scalarValue;

        }


        public void SetTransaction()
        {
            if (_connection != null)
            {
                _useTransaction = true;
                _transaction = _connection.BeginTransaction();
            }
        }


        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
            }
        }


        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
        }


        private void openConnection()
        {
            try
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();

            }catch(Exception ex)
            {
                throw ex;
            }
           
        }


        private void closeConnection()
        {
            if (_connection != null)
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
                _connection = null;
            }
        }


        public void CloseReader(ref SqlDataReader dataReader)
        {
            if (dataReader != null)
            {
                if (dataReader.IsClosed == false)
                {
                    dataReader.Close();
                }
                dataReader = null;
            }
        }

        public void Dispose()
        {
            this.closeConnection();
        }

    }
}

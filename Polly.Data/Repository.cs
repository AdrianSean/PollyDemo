using Dapper;
using Polly;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Data
{
    public class Repository
    {
        static Policy retryPolicy = Policy.Handle<SqlException>().Retry(1);

        readonly string _databaseConnection;


        public Repository()
        {
            _databaseConnection = ConfigurationManager.ConnectionStrings["DapperConnection"].ConnectionString;
        }

        public Response GetById(Guid guid)
        {
            var response = new Response();
            try {
                response.Person = retryPolicy.Execute(() => PerformDatabaseReadById(guid));
                response.Sucess = true;
            }
            catch (SqlException ex) {
                response.Error = ex;
            }
            
            return response;
        }


        public Response GetAll()
        {
            var response = new Response();
            try {
                response.People = retryPolicy.Execute(() => PerformDatabaseRead());
                response.Sucess = true;
            }
            catch (SqlException ex) {
                response.Error = ex;
            }

            return response;
        }


        Person PerformDatabaseReadById(Guid guid) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Calling PerformDatabaseReadById");
            Console.ForegroundColor = ConsoleColor.White;

            Person person = null;
            const string sqlQuery = "SELECT Id, FirstName, LastName, Age FROM Person WHERE Id = @Guid";
            using (IDbConnection db = new SqlConnection(_databaseConnection)) {

                person = db.Query<Person>(sqlQuery, new { Guid = guid }).FirstOrDefault();
            }

            return person;
        }

        IReadOnlyList<Person> PerformDatabaseRead() {

            IReadOnlyList<Person> persons = null;
            const string sqlQuery = "SELECT Id, FirstName, LastName, Age FROM Person";
            using (IDbConnection db = new SqlConnection(_databaseConnection)) {

                persons = db.Query<Person>(sqlQuery).OrderBy(p => p.LastName).ToList();
            }

            return persons;
        }          
    }
}

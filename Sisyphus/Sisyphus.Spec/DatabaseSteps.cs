namespace Sisyphus.Spec
{
    using System.Configuration;
    using System.Data.SqlClient;

    using TechTalk.SpecFlow;

    [Binding]
    public class DatabaseSteps
    {
        public const string DatabaseName = "database";

        [Given(@"I have created a test database called ""(.*)""")]
        public void GivenIHaveCreatedATestDatabaseCalled(string databaseName)
        {
            string serverAddress = ConfigurationManager.AppSettings[TestConfigSource.SqlInstance];
            string testDbPath = ConfigurationManager.AppSettings["testDbPath"];

            string createDb = @"CREATE DATABASE [" + databaseName + "] ON  PRIMARY "
                              + @"( NAME = N'Sisyphus-test', FILENAME = N'" + testDbPath + databaseName
                              + ".mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )";

            string dropDb = "DROP DATABASE " + databaseName + ";";

            const string Database = "Master";
            string connectionString = CreateConnectionString(serverAddress, Database);

            using (var con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = dropDb;
                    con.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                        // ReSharper disable once EmptyGeneralCatchClause
                    catch
                    {
                        // dont care if this fails
                    }

                    con.Close();
                }
            }

            //    using (var command = con.CreateCommand())
            //    {
            //        command.CommandText = createDb;
            //        con.Open();
            //        command.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}

            StageDatabase.Stage();

            ScenarioContext.Current.Add(DatabaseName, databaseName);
        }

        public static string CreateConnectionString(string serverAddress, string database)
        {
            return string.Format("Server = {0}; Database = {1}; Trusted_Connection = True;", serverAddress, database);
        }
    }
}
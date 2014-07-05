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

            string dropDb = "IF EXISTS(SELECT name FROM sys.databases WHERE name = '" + databaseName
                            + "') ALTER DATABASE " + databaseName + " SET RESTRICTED_USER WITH ROLLBACK IMMEDIATE; IF EXISTS(SELECT name FROM sys.databases WHERE name = '" + databaseName
                            + "') DROP DATABASE " + databaseName + ";";

            const string Database = "Master";
            string connectionString = CreateConnectionString(serverAddress, Database);

            using (var con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = dropDb;
                    con.Open();

                    command.ExecuteNonQuery();


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
            return string.Format("Server = {0}; Database = {1};User=testRunner;Password=testtest;Trusted_Connection = True;", serverAddress, database);
        }
    }
}
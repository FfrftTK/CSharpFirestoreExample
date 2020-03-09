using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using Google.Cloud.Firestore;

namespace CSharpFirebaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Env.Load();
            var ProjectId = Env.PROJECT_ID;
            Environment.SetEnvironmentVariable(
                "GOOGLE_APPLICATION_CREDENTIALS",
                Path.Combine(AppContext.BaseDirectory, Env.SERVICE_ACCOUNT_JSON_PATH));
            AddDataExample(ProjectId).Wait();
        }

        /// Add data to DB
        private static async Task AddDataExample(string project)
        {
            FirestoreDb db = FirestoreDb.Create(project);
            // [START fs_add_data_1]
            DocumentReference docRef = db.Collection("users").Document("test");
            Dictionary<string, object> user = new Dictionary<string, object>
            {
                { "First", "Ada" },
                { "Last", "Lovelace" },
                { "Born", 1815 }
            };
            await docRef.SetAsync(user);
            // [END fs_add_data_1]
            Console.WriteLine("Added data to the alovelace document in the users collection.");
        }
    }
}

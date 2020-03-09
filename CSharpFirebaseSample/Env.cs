using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace CSharpFirebaseSample
{
    public static class Env
    {
        /// <summary>
        /// Name of the file to manage environment variables.
        /// Change if needed.
        /// </summary>
        public const string ENV_FILE_NAME = ".env";
        static readonly string workingDirectory = Environment.CurrentDirectory;
        static readonly string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        public static void Load()
        {
            DotNetEnv.Env.Load(Path.Combine(projectDirectory, ENV_FILE_NAME));
        }

        public static string GetString([CallerMemberName] string key = "") => DotNetEnv.Env.GetString(key);
        public static int GetInt([CallerMemberName] string key = "") => DotNetEnv.Env.GetInt(key);
        public static bool GetBool([CallerMemberName] string key = "") => DotNetEnv.Env.GetBool(key);
        public static double GetDouble([CallerMemberName] string key = "") => DotNetEnv.Env.GetDouble(key);

        public static string SERVICE_ACCOUNT_JSON_PATH => GetString();
        public static string PROJECT_ID => GetString();
    }
}

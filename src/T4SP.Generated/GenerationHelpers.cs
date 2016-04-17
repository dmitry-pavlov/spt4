using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T4SP.Generated
{
    public static class GenerationHelpers
    {
        public static List<string> GetTableNames()
        {
            return new List<string> {"Pr_GetOneTable", "Custom_get_second_table", "getThirdSet_of_data"};

          //  var connectionString =
          //      @"Data Source=.;Initial Catalog=movies;Integrated Security=True";
          //
          //  var commandText = "select table_name as TableName from INFORMATION_SCHEMA.Tables "; 
          //
          //  using (var connection = new SqlConnection(connectionString))
          //  {
          //      connection.Open();
          //      using (var command = new SqlCommand(commandText, connection))
          //      using (var reader = command.ExecuteReader())
          //      {
          //          while (reader.Read())
          //          {
          //              yield return reader["TableName"] as string;
          //          }
          //      }
          //  }
        }

        public static string RefineProcedureName(string procedureName)
        {
            if(procedureName == null) throw new ArgumentNullException(nameof(procedureName));

            // Remove accent (replace symbols like "éåäöíØ" with standard ones "eaaoiO")
            var str = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(procedureName));

            // Remove non alpha-numeric symbols
            str = Regex.Replace(str, @"[^a-z0-9\s-]", " ", RegexOptions.IgnoreCase).Trim();

            // Replace spaces if any for some reasons
            str = Regex.Replace(str, @"\s+", "-").Trim();

            var refined = "";
            foreach (var symbol in str.ToCharArray())
            {
                if (char.IsUpper(symbol)) refined += "-" + symbol;
                else refined += symbol;
            }

            var words = refined.Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries).Select(word =>
            {
                if (word.Length == 0)
                    return word;
                if (word.Length == 1)
                    return word.ToUpper();
                return char.ToUpper(word[0]) + word.Remove(0, 1).ToLower();
            });

            return string.Join("", words);
        }

        private static void Select(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}

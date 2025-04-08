using CSVDataEmployee.Models;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
namespace CSVDataEmployee.CSVHelper
{
    public class Helper
    {

        public static readonly string filePath = "EmployeesData.csv";
        // Change path if needed

        // Read Employee Data from CSV
        public static List<Employee> ReadEmployees()
        {
            if (!File.Exists(filePath))
                return new List<Employee>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                TrimOptions = TrimOptions.Trim, // Trim extra spaces in headers
                HeaderValidated = null, // Ignore missing headers
                MissingFieldFound = null // Ignore missing fields
            }))
            {
                return new List<Employee>(csv.GetRecords<Employee>());
            }
        }

        // Write Employee Data to CSV
        public static void WriteEmployees(List<Employee> employees)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(employees);
            }
        }
    }
}

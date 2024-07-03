#nullable disable
namespace TransferObjectPatternApp
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
    }

    public static class EmployeeMapper
    {
        public static EmployeeDTO MapToDTO(Employee employee)
        {
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FullName = $"{employee.FirstName} {employee.LastName}",
                Department = employee.Department
            };
        }
    }

    public class EmployeeService
    {
        private List<Employee> _employees = new List<Employee>
    {
        new Employee { EmployeeId = 1, FirstName = "Amit", LastName = "Mohanty", Department = "IT" },
        new Employee { EmployeeId = 2, FirstName = "Ranjit", LastName = "Reddy", Department = "BA" },
        new Employee { EmployeeId = 3, FirstName = "Anamika", LastName = "Rout", Department = "HR" },
        new Employee { EmployeeId = 4, FirstName = "Swarup", LastName = "Pradhan", Department = "Finance" }
    };

        public EmployeeDTO GetEmployeeById(int employeeId)
        {
            var employee = _employees.FirstOrDefault(e => e.EmployeeId == employeeId);

            if (employee == null)
            {
                return null;
            }

            return EmployeeMapper.MapToDTO(employee);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var employeeService = new EmployeeService();
            int employeeIdToRetrieve = 2;

            var employeeDTO = employeeService.GetEmployeeById(employeeIdToRetrieve);

            if (employeeDTO != null)
            {
                Console.WriteLine($"Employee ID: {employeeDTO.EmployeeId}");
                Console.WriteLine($"Full Name: {employeeDTO.FullName}");
                Console.WriteLine($"Department: {employeeDTO.Department}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }
}
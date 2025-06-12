using PageForMe.Models;
using PageForMe.Data;
using Microsoft.EntityFrameworkCore;

namespace PageForMe.Services
{
    public class DataGeneratorService
    {
        private readonly ApplicationDbContext _context;
        private readonly Random _random;

        // Sample data arrays
        private readonly string[] _firstNames = {
            "John", "Jane", "Michael", "Sarah", "David", "Emma", "Chris", "Lisa",
            "Robert", "Maria", "James", "Jennifer", "William", "Amanda", "Daniel",
            "Jessica", "Matthew", "Ashley", "Anthony", "Melissa", "Mark", "Deborah",
            "Donald", "Dorothy", "Steven", "Carol", "Paul", "Ruth", "Andrew", "Sharon"
        };

        private readonly string[] _lastNames = {
            "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller",
            "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez",
            "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin",
            "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Lewis"
        };

        private readonly string[] _departments = {
            "Engineering", "Marketing", "Sales", "Human Resources", "Finance",
            "Operations", "Customer Service", "IT", "Research & Development", "Legal"
        };

        private readonly string[] _jobTitles = {
            "Software Engineer", "Senior Developer", "Project Manager", "Data Analyst",
            "Marketing Specialist", "Sales Representative", "HR Coordinator", "Accountant",
            "Operations Manager", "Customer Success Manager", "DevOps Engineer", "QA Engineer"
        };

        private readonly string[] _cities = {
            "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia",
            "San Antonio", "San Diego", "Dallas", "San Jose", "Austin", "Jacksonville",
            "San Francisco", "Columbus", "Charlotte", "Indianapolis", "Seattle", "Denver"
        };

        private readonly string[] _countries = {
            "USA", "Canada", "UK", "Germany", "France", "Spain", "Italy", "Netherlands",
            "Sweden", "Norway", "Denmark", "Australia", "New Zealand", "Japan"
        };

        private readonly string[] _projectNames = {
            "Phoenix Migration", "Digital Transformation", "Cloud Infrastructure", "Mobile App Redesign",
            "Data Analytics Platform", "Customer Portal", "AI Integration", "Security Upgrade",
            "Performance Optimization", "Legacy System Modernization", "API Gateway", "Microservices Architecture"
        };

        private readonly string[] _projectStatuses = { "Active", "Completed", "On Hold", "Cancelled" };
        private readonly string[] _priorities = { "Low", "Medium", "High", "Critical" };

        private readonly string[] _productNames = {
            "Laptop Pro", "Wireless Headphones", "Smart Watch", "Tablet", "Gaming Mouse",
            "Mechanical Keyboard", "Monitor 4K", "Webcam HD", "Smartphone", "Bluetooth Speaker",
            "External Hard Drive", "Graphics Card", "RAM Module", "SSD Drive", "Power Bank"
        };

        private readonly string[] _categories = {
            "Electronics", "Computers", "Accessories", "Mobile", "Audio", "Gaming", "Storage"
        };

        private readonly string[] _regions = {
            "North America", "Europe", "Asia Pacific", "Latin America", "Middle East", "Africa"
        };

        public DataGeneratorService(ApplicationDbContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task GenerateEmployeesAsync(int count = 100)
        {
            var employees = new List<Employee>();

            for (int i = 0; i < count; i++)
            {
                var firstName = _firstNames[_random.Next(_firstNames.Length)];
                var lastName = _lastNames[_random.Next(_lastNames.Length)];
                int ranNum = _random.Next(1, 4000);
                
                var employee = new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = $"{firstName.ToLower()}.{lastName.ToLower()}.{ranNum}@company.com",
                    Department = _departments[_random.Next(_departments.Length)],
                    JobTitle = _jobTitles[_random.Next(_jobTitles.Length)],
                    Salary = _random.Next(40000, 150000),
                    HireDate = DateTime.UtcNow.AddDays(-_random.Next(30, 2000)),
                    Age = _random.Next(22, 65),
                    City = _cities[_random.Next(_cities.Length)],
                    Country = _countries[_random.Next(_countries.Length)],
                    IsActive = _random.Next(100) > 10, // 90% active
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                employees.Add(employee);
            }

            await _context.Employees.AddRangeAsync(employees);
            await _context.SaveChangesAsync();
        }

        public async Task GenerateProjectsAsync(int count = 50)
        {
            var employeeIds = await _context.Employees.Select(e => e.Id).ToListAsync();
            if (!employeeIds.Any())
            {
                throw new InvalidOperationException("No employees found. Generate employees first.");
            }

            var projects = new List<Project>();

            for (int i = 0; i < count; i++)
            {
                var startDate = DateTime.UtcNow.AddDays(-_random.Next(30, 365));
                var status = _projectStatuses[_random.Next(_projectStatuses.Length)];
                DateTime? endDate = null;

                if (status == "Completed")
                {
                    endDate = startDate.AddDays(_random.Next(30, 200));
                }

                var project = new Project
                {
                    Name = $"{_projectNames[_random.Next(_projectNames.Length)]} {_random.Next(1, 100)}",
                    Description = $"Project description for {_projectNames[_random.Next(_projectNames.Length)]}",
                    Budget = _random.Next(10000, 500000),
                    StartDate = startDate,
                    EndDate = endDate,
                    Status = status,
                    Priority = _priorities[_random.Next(_priorities.Length)],
                    EmployeeId = employeeIds[_random.Next(employeeIds.Count)],
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                projects.Add(project);
            }

            await _context.Projects.AddRangeAsync(projects);
            await _context.SaveChangesAsync();
        }

        public async Task GenerateSalesAsync(int count = 200)
        {
            var sales = new List<Sale>();

            for (int i = 0; i < count; i++)
            {
                var price = _random.Next(10, 2000);
                var quantity = _random.Next(1, 10);
                
                var sale = new Sale
                {
                    ProductName = _productNames[_random.Next(_productNames.Length)],
                    Category = _categories[_random.Next(_categories.Length)],
                    Price = price,
                    Quantity = quantity,
                    TotalAmount = price * quantity,
                    SaleDate = DateTime.UtcNow.AddDays(-_random.Next(1, 365)),
                    CustomerName = $"{_firstNames[_random.Next(_firstNames.Length)]} {_lastNames[_random.Next(_lastNames.Length)]}",
                    Region = _regions[_random.Next(_regions.Length)],
                    SalesRep = $"{_firstNames[_random.Next(_firstNames.Length)]} {_lastNames[_random.Next(_lastNames.Length)]}",
                    CreatedAt = DateTime.UtcNow
                };

                sales.Add(sale);
            }

            await _context.Sales.AddRangeAsync(sales);
            await _context.SaveChangesAsync();
        }

        public async Task GenerateAllDataAsync()
        {
            await GenerateEmployeesAsync(100);
            await GenerateProjectsAsync(50);
            await GenerateSalesAsync(200);
        }

        public async Task ClearAllDataAsync()
        {
            _context.Projects.RemoveRange(_context.Projects);
            _context.Sales.RemoveRange(_context.Sales);
            _context.Employees.RemoveRange(_context.Employees);
            await _context.SaveChangesAsync();
        }
    }
}
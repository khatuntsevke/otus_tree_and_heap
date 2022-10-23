namespace ConsoleApp
{
    public class Company
    {
        private readonly OtusBinarySearchTree<int, string> _employeesDB;
        private readonly string _title;

        public Company(string? title)
        {
            if (title == null)
            {
                _title = "Otus corparation";
            }
            else
            {
                _title = title;
            }
            _employeesDB = new OtusBinarySearchTree<int, string>();
        }

        public void AddEmployee(string name, int salary)
        {
            _employeesDB.AddNode(salary, name);
        }

        public string LookForEployee(int salary)
        {
            string? name = _employeesDB.LookingFor(salary);
            return (name == default)? "такой сотрудник не найден": name;
        }

        public void PrintEmployees()
        {
            Console.WriteLine(_title+" employees:");
            foreach (Tuple<int, string> employeeInfo in _employeesDB.InOrderTraversal())
            {                
                Console.WriteLine($"    {employeeInfo.Item2} - {employeeInfo.Item1}руб");
            }
        }
    }
}

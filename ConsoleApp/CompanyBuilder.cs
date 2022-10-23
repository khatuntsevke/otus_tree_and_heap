namespace ConsoleApp
{
    public class CompanyBuilder
    {
        public void AllValuesAreFixed()
        {
            var otusCorporation = new Company("Otus corporation");

            var rng = new Random();
            otusCorporation.AddEmployee(name: "Алексей Ягур", salary: rng.Next(70, 250) * 1000);
            otusCorporation.AddEmployee(name: "Антон Герасименко", salary: rng.Next(70, 250) * 1000);
            otusCorporation.AddEmployee(name: "Роман Приходько", salary: rng.Next(70, 250) * 1000);
            otusCorporation.AddEmployee(name: "Эдгар Пилипсон", salary: rng.Next(70, 250) * 1000);
            otusCorporation.AddEmployee(name: "Евгений Тюменцев", salary: rng.Next(70, 250) * 1000);
            otusCorporation.AddEmployee(name: "Вадим Литвинов", salary: rng.Next(70, 250) * 1000);
            otusCorporation.AddEmployee(name: "Виктор Дзицкий", salary: rng.Next(70, 250) * 1000);
            otusCorporation.AddEmployee(name: "Руслан Щербаков", salary: rng.Next(70, 250) * 1000);
            otusCorporation.AddEmployee(name: "Александр Новиков", salary: rng.Next(70, 250) * 1000);
            otusCorporation.AddEmployee(name: "Артур Хисматуллин", salary: 777777);
            otusCorporation.AddEmployee(name: "Павел Жувагин", salary: rng.Next(70, 250) * 1000);
            
            otusCorporation.PrintEmployees();

            Console.WriteLine("\nПоиск сотрудника, размер зарплаты котрого 777777руб");
            string nameEmployee = otusCorporation.LookForEployee(777777);
            Console.WriteLine($"    {nameEmployee}");

            Console.WriteLine("\nПоиск сотрудника, размер зарплаты котрого 251000руб");
            nameEmployee = otusCorporation.LookForEployee(251000);
            Console.WriteLine($"    {nameEmployee}");
        }

        Company InteractiveBuildingCompany()
        {
            Console.Write("\nВведите наименование корпорации: ");
            string? companyName = Console.ReadLine();
            var company = new Company(companyName);
            while (true)
            {
                Console.Write("\nВведите имя сотрудника: ");
                string? name = Console.ReadLine();
                if (name == "" || name == null) break;

                int salary = ReadSalary();                
                
                company.AddEmployee(name, salary);
            }
            Console.WriteLine("\n");
            company.PrintEmployees();
            
            return company;
        }

        public void BuildAndCheck()
        {
            while(true)
            {
                var company = InteractiveBuildingCompany();

                while (true)
                {
                    Console.WriteLine("\nПоиск сотрудника по размеру его зарплаты.");
                    int salary = ReadSalary();
                    string nameEmployee = company.LookForEployee(salary);
                    Console.WriteLine($"    {nameEmployee}");

                    Console.WriteLine("Введите 0(создать новую корпорацию) или 1(снова поиск зарплаты): ");
                    string? decision = Console.ReadLine();
                    if (decision == "0") break;                        
                }
            }
        }
        
        public int ReadSalary()
        {
            int salary;
            while (true)
            {
                try
                {
                    Console.Write($"Введите размер зарплаты сотрудника: ");
                    salary = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("размер зарплаты указывайте цифрами");
                }
            }
            return salary;
        }
    }
}

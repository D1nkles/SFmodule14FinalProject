namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            var sortedPhoneBook = phoneBook.OrderBy(s => s.Name).ThenBy(s => s.LastName);

            int contactsLenght = phoneBook.Count();
            int pages = contactsLenght / 2;
            int pageCount = 1;
            int skipContacts = 0;

            while (true)
            {
                Console.WriteLine("Для навигации между страницами вводите на клавиатуре цифры от 1 до 3.");
                char userInput = Console.ReadKey().KeyChar;

                switch (userInput)
                {
                    case '1':
                        Console.Clear();
                        skipContacts = 0;
                        pageCount = 1;
                        foreach (var info in from contact in sortedPhoneBook.Skip(skipContacts).Take(2) select contact)
                        {
                            Console.WriteLine(info.Name + "\t" + info.LastName + "\t" + info.PhoneNumber);
                        }
                        Console.WriteLine($"Страница номер {pageCount}");
                        break;

                    case '2':
                        Console.Clear();
                        skipContacts = 2;
                        pageCount = 2;
                        foreach (var info in from contact in sortedPhoneBook.Skip(skipContacts).Take(2) select contact)
                        {
                            Console.WriteLine(info.Name + "\t" + info.LastName + "\t" + info.PhoneNumber);
                        }
                        Console.WriteLine($"Страница номер {pageCount}");
                        break;

                    case '3':
                        Console.Clear();
                        skipContacts = 4;
                        pageCount = 1;
                        foreach (var info in from contact in sortedPhoneBook.Skip(skipContacts).Take(2) select contact)
                        {
                            Console.WriteLine(info.Name + "\t" + info.LastName + "\t" + info.PhoneNumber);
                        }
                        Console.WriteLine($"Страница номер {pageCount}");
                        break;

                    default:
                        Console.WriteLine("Вы нажали неверную клавишу!");
                        break;
                }
            }
        }
    }
    public class Contact // модель класса
    {
        public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
}
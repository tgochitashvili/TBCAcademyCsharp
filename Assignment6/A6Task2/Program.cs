using LibrarySystem;
using System.Text;
using static A6Task2.Program;

namespace A6Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person0 = new Person("Person0");
            person0.AddContact(new Person("Person1"));
            person0.AddContact(new Person("Person2"));
            person0.AddContact(new Person("Person3"));

            Console.WriteLine($"{person0}'s contacts:  \n{person0.Contacts}");

            person0.AddTask(new Task("Task 0", new DateTime(2023, 10, 10)));
            person0.AddTask(new Task("Task 1", new DateTime(2024, 6, 4)));
            person0.AddTask(new Task("Task 2", new DateTime(2024, 12, 9)));

            Console.WriteLine($"{person0}'s tasks:  \n{person0.Tasks}");

        }

        public class Person
        {
            private string _name;
            private CustomList<Person> _contacts;
            private CustomList<Task> _tasks;

            public Person(string name)
            {
                this.Name = name;
                _contacts = new CustomList<Person>();
                _tasks = new CustomList<Task>();
            }

            public string Name
            {
                get
                {
                    return this._name;
                }
                set
                {
                    this._name = value;
                }
            }

            public CustomList<Person> Contacts
            {
                get
                {
                    return _contacts;
                }
            }

            public CustomList <Task> Tasks
            {
                get
                {
                    return _tasks;
                }
            }



            public void AddContact(Person person)
            {
                _contacts.AddElement(person);
            }

            public void AddTask(Task task)
            {
                _tasks.AddElement(task);
            }


            public override string ToString()
            {
                return this.Name;
            }
        }

        public class Task
        {
            private string _name;
            private DateTime _dueDate;

            public string Name
            {
                get
                {
                    return this._name;
                }
                set
                {
                    this._name = value;
                }
            }

            public DateTime DueDate
            {
                get
                {
                    return this._dueDate;
                }
                set
                {
                    this._dueDate = value;
                }
            }


            public Task(string name, DateTime dueDate)
            {
                this.Name = name;
                this.DueDate = dueDate;
            }

            public override string ToString()
            {
                return $"Task: {Name} is due at {DueDate}";
            }
        }
    }
}
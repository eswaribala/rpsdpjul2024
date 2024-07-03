#nullable disable
namespace InterceptingFilterPatternApp
{
    public class Person
    {

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
    }
    public interface ICriteria
    {
        List<Person> MeetCriteria(List<Person> persons);
    }
    public class CriteriaFirstName : ICriteria
    {
        private string searchCriteria;
        public CriteriaFirstName(string searchCriteria)
        {
            this.searchCriteria = searchCriteria;
        }
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> personsData = new List<Person>();
            foreach (var item in persons)
            {
                if (item.FirstName.ToUpper().Equals(searchCriteria.ToUpper()))
                {
                    personsData.Add(item);
                }
            }

            return personsData;
        }
    }
    public class CriteriaLastName : ICriteria
    {
        private string searchCriteria;
        public CriteriaLastName(string searchCriteria)
        {
            this.searchCriteria = searchCriteria;
        }

        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> personsData = new List<Person>();
            foreach (var item in persons)
            {
                if (item.LastName.ToUpper().Equals(searchCriteria.ToUpper()))
                {
                    personsData.Add(item);
                }
            }

            return personsData;
        }
    }
    public class CriteriaPhone : ICriteria
    {
        private string searchCriteria;
        public CriteriaPhone(string searchCriteria)
        {
            this.searchCriteria = searchCriteria;
        }

        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> personsData = new List<Person>();
            foreach (var item in persons)
            {
                if (item.Phone.ToUpper().Equals(searchCriteria.ToUpper()))
                {
                    personsData.Add(item);
                }
            }

            return personsData;
        }
    }
    public class CriteriaEmail : ICriteria
    {
        private string searchCriteria;
        public CriteriaEmail(string searchCriteria)
        {
            this.searchCriteria = searchCriteria;
        }
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> personsData = new List<Person>();
            foreach (var item in persons)
            {
                if (item.Email.ToUpper().Equals(searchCriteria.ToUpper()))
                {
                    personsData.Add(item);
                }
            }

            return personsData;
        }
    }
    public class AndCriteria : ICriteria
    {
        private ICriteria criteria;
        private ICriteria otherCriteria;

        public AndCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaPersons = criteria.MeetCriteria(persons);
            return otherCriteria.MeetCriteria(firstCriteriaPersons);
        }
    }
    public class OrCriteria : ICriteria
    {
        private ICriteria criteria;
        private ICriteria otherCriteria;

        public OrCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaItems = criteria.MeetCriteria(persons);
            List<Person> otherCriteriaItems = otherCriteria.MeetCriteria(persons);

            foreach (var otherItems in otherCriteriaItems)
            {
                if (!firstCriteriaItems.Contains(otherItems))
                {
                    firstCriteriaItems.Add(otherItems);
                }
            }

            return firstCriteriaItems;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            persons.Add(new Person { FirstName = "Robert", LastName = "kerry", Phone = "1234", Email = "cddd@xyz.com" });
            persons.Add(new Person { FirstName = "Robert", LastName = "Sam", Phone = "1234", Email = "sam@xyz.com" });
            persons.Add(new Person { FirstName = "Jon", LastName = "Kam", Phone = "1234", Email = "john@xyz.com" });

            Console.WriteLine("---Search by First and Last Name----");
            ICriteria firstName = new CriteriaFirstName("Robert");
            ICriteria lastName = new CriteriaLastName("Kerry");
            ICriteria fullName = new AndCriteria(firstName, lastName);
            var searchedData = fullName.MeetCriteria(persons);

            //Search by First and last name (And criteria)  
            foreach (var person in searchedData)
            {
                Console.WriteLine(person.FirstName);
                Console.WriteLine(person.LastName);
                Console.WriteLine(person.Phone);
            }

            //Search by first name and email. (And Criteria)  
            firstName = new CriteriaFirstName("Robert");
            var email = new CriteriaEmail("sam@xyz.com");
            fullName = new AndCriteria(firstName, email);
            searchedData = fullName.MeetCriteria(persons);
            foreach (var person in searchedData)
            {
                Console.WriteLine(person.FirstName);
                Console.WriteLine(person.LastName);
                Console.WriteLine(person.Phone);
            }

            Console.WriteLine("---Search by First Name Only----");
            firstName = new CriteriaFirstName("Robert");
            searchedData = firstName.MeetCriteria(persons);
            foreach (var person in searchedData)
            {
                Console.WriteLine(person.FirstName);
                Console.WriteLine(person.LastName);
                Console.WriteLine(person.Phone);
            }

            Console.WriteLine("---Search by First Name or email ----");
            //Search by first name . (or Criteria)  
            firstName = new CriteriaFirstName("Robert");
            email = new CriteriaEmail("john@xyz.com");
            fullName = new OrCriteria(firstName, email);
            searchedData = fullName.MeetCriteria(persons);
            foreach (var person in searchedData)
            {
                Console.WriteLine(person.FirstName);
                Console.WriteLine(person.LastName);
                Console.WriteLine(person.Phone);
            }

            Console.ReadKey();
        }
    }
}
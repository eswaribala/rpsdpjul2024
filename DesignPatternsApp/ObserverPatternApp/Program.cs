namespace ObserverPatternApp
{
    public class Program
    {
        public static void Main()
        {
            JobPostings jobPostings = new JobPostings();
            JobSeeker Pranaya = new JobSeeker("Pranaya");
            JobSeeker Anurag = new JobSeeker("Anurag");
            JobSeeker Kumar = new JobSeeker("Kumar");
            JobSeeker Rout = new JobSeeker("Rout");
            //Attach
            jobPostings.Attach(Pranaya);
            jobPostings.Attach(Anurag);
            jobPostings.Attach(Kumar);
            jobPostings.Attach(Rout);
            //Detach
            jobPostings.Detach(Anurag);
            jobPostings.AddJob(new Job("Software Developer at Microsoft"));
            Console.ReadKey();
        }
    }
    // Observer Interface
    public interface IJobSeeker
    {
        void Notify(Job job);
    }
    // Concrete Observer
    public class JobSeeker : IJobSeeker
    {
        public string Name { get; set; }
        public JobSeeker(string name)
        {
            Name = name;
        }
        public void Notify(Job job)
        {
            Console.WriteLine($"Hi {Name}, new job posted: {job.Description}");
        }
    }
    // Subject Interface
    public interface IJobPostings
    {
        void Attach(IJobSeeker jobSeeker);
        void Detach(IJobSeeker jobSeeker);
        void Notify(Job job);
    }
    // Concrete Subject
    public class JobPostings : IJobPostings
    {
        private List<IJobSeeker> _jobSeekers = new List<IJobSeeker>();
        public void Attach(IJobSeeker jobSeeker)
        {
            _jobSeekers.Add(jobSeeker);
        }
        public void Detach(IJobSeeker jobSeeker)
        {
            _jobSeekers.Remove(jobSeeker);
        }
        public void Notify(Job job)
        {
            foreach (var jobSeeker in _jobSeekers)
            {
                jobSeeker.Notify(job);
            }
        }
        public void AddJob(Job job)
        {
            Notify(job);
        }
    }
    public class Job
    {
        public string Description { get; set; }
        public Job(string description)
        {
            Description = description;
        }
    }
}
namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        public Book(string Name) : base(Name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }
}
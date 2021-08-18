

namespace c2.Exceptions
{
    public class DuplicatedRow : System.Exception
    {
        public DuplicatedRow(string message)
            : base($"{message} już istnieje w bazie")
        {

        }

    }
}

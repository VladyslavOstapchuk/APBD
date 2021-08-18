
namespace c2
{
    public class Studies
    {
        public string Name { get; set; }
        public string Mode { get; set; }

        public override string ToString()
        {
            return $"{Name} {Mode}";
        }
    }

    
}

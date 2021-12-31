namespace Task_2.data
{
    public class ServiceResponse <Tempelet>
    {
        public Tempelet data { get; set; }
        public bool  success { get; set; } = true;
        public string message {get; set;} =null;
    }
}
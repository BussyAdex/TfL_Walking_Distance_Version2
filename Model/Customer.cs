namespace TfL_Walking_Distance_Version2.Model
{
    class Customer : User
    {
        public Customer()
        {
            base.UserType = "Customer";
        }
        public override void Display()
        {
            Console.WriteLine($"Name {base.UserName} Type {base.UserType}");
        }
    }
}

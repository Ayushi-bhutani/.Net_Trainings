namespace OopsSessions
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual string GetDetails()
        {
            return $"Id={Id}, Name={Name}, Age={Age}";
        }
    }

    public class Man : Person
    {
        public string Playing { get; set; }

        public override string GetDetails()
        {
            return base.GetDetails() + $", Playing={Playing}";
        }
    }

    public class Woman : Person
    {
        public string PlayManage { get; set; }

        public override string GetDetails()
        {
            return base.GetDetails() + $", Managing={PlayManage}";
        }
    }

    public class Child : Person
    {
        public string WatchingCartoon { get; set; }

        public override string GetDetails()
        {
            return base.GetDetails() + $", Cartoon={WatchingCartoon}";
        }
    }
}

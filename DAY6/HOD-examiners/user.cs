namespace Management
{
    public class User
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string RoleID { get; set; }

        public User(string name, string role, string roleID)
        {
            this.Name = name;
            this.Role = role;
            this.RoleID = roleID;
        }
    }
}

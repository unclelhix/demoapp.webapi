namespace DemoApplication.WebAPI.Shared.Attributes
{
    public class DbColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public DbColumnAttribute(string name)
        {
            this.Name = name;
        }
    }
}

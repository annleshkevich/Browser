namespace SearchEngine.Model.DatabaseModels
{
    public class Browser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
    }
}

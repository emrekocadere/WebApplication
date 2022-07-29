namespace WebApplication.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public byte[] HashPassword { get; set; }
        public byte[] Salt { get; set; }
     //   public int InfoId { get; set; }
      //  public Info Info { get; set; }
    }
}

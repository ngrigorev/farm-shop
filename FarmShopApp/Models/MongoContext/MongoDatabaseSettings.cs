namespace FarmShopApp.Models.MongoContext
{
  public class MongoDatabaseSettings : IMongoDatabaseSettings
  {
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }
}
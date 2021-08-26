namespace Play.Common.Settings
{
    public class MongoDBSettings
    {

        #region Properties

        public string Host { get; set; }

        public int Port { get; set; }
        public string ConnectionString =>  $"mongodb://{Host}:{Port}";

            
        #endregion
        
    }
    
}
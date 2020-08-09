namespace Backend.Core.Settings
{
    /// <summary>
    /// Defines settings applicable to the used database.
    /// </summary>
    public class DatabaseSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseSettings"/> class.
        /// [Usage of binding settings file]
        /// </summary>
        public DatabaseSettings()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseSettings"/> class.
        /// </summary>
        /// <param name="name">The name of the database.</param>
        /// <param name="connectionString">The connectionstring for the database.</param>
        public DatabaseSettings(string name, string connectionString)
        {
            Name = name;
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Gets the name of the database.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the connection string for the database.
        /// </summary>
        public string ConnectionString { get; private set; }
    }
}

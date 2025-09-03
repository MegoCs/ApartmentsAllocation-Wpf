using System;
using System.Linq;
using ApartmentsAllocationHelper.Models.EntityModels;

namespace ApartmentsAllocationHelper.Models
{
    /// <summary>
    /// Utility class for database initialization operations
    /// </summary>
    public static class DatabaseInitializer
    {
        private static bool _isInitialized = false;

        /// <summary>
        /// Initializes the database and ensures all tables are created based on the model configurations.
        /// This method will only execute the initialization once per application lifecycle.
        /// </summary>
        /// <returns>True if database was created for the first time, false if it already existed or was already initialized</returns>
        public static bool InitializeDatabase()
        {
            // Return immediately if already initialized
            if (_isInitialized)
            {
                return false;
            }

            try
            {
                using (var context = new ApartmentDeliveryDbContext())
                {
                    bool wasCreated = context.Database.EnsureCreated();
                    
                    if (wasCreated)
                    {
                        Logger.WriteLog("Database was created for the first time", "DatabaseInitializer");
                        SeedInitialData(context);
                    }
                    else
                    {
                        Logger.WriteLog("Database already exists", "DatabaseInitializer");
                    }
                    
                    // Mark as initialized regardless of whether it was created or already existed
                    _isInitialized = true;
                    Logger.WriteLog("Database initialization completed", "DatabaseInitializer");
                    
                    return wasCreated;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Database initialization failed. Exception: {ex.Message} InnerException: {ex.InnerException}", "DatabaseInitializer");
                throw;
            }
        }

        /// <summary>
        /// Gets whether the database has been initialized during this application session
        /// </summary>
        public static bool IsInitialized => _isInitialized;

        /// <summary>
        /// Seeds initial data into a newly created database
        /// </summary>
        /// <param name="context">The database context to use for seeding</param>
        private static void SeedInitialData(ApartmentDeliveryDbContext context)
        {
            try
            {
                // Add default login details if none exist
                if (!context.LoginDetails.Any())
                {
                    context.LoginDetails.Add(new LoginDetails
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = "admin",
                        UserPassword = "admin123"
                    });
                    
                    Logger.WriteLog("Default admin login added", "DatabaseInitializer");
                }

                context.SaveChanges();
                Logger.WriteLog("Initial seed data completed", "DatabaseInitializer");
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Seed data failed. Exception: {ex.Message} InnerException: {ex.InnerException}", "DatabaseInitializer");
                throw;
            }
        }
    }
}
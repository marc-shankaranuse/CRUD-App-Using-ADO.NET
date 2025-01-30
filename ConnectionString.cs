namespace CRUDAppUsingADO
{
    public static class ConnectionString
    {
        private static string cs = "Server=MARCUS-LAPTOP\\SQLEXPRESS; Database=CrudADOdb; Trusted_Connection=True; TrustServerCertificate=True;";

        public static string dbcs { get => cs; }

    }
}

using System;

namespace PizzaBoxData
{
    public sealed class DBSingle
    {
        private static DBSingle instance;
        private PizzaBoxContext dbinstance;

        private DBSingle()
        {
            dbinstance = new PizzaBoxContext();
        }

        ~DBSingle()
        {
            dbinstance.Dispose();
        }

        public PizzaBoxContext dbInstance
        {
            get
            {
                return dbinstance;
            }
        }

        public static DBSingle Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DBSingle();
                }

                return instance;
            }
        }
    }
}

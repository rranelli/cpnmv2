using CPNMv2.Domain;
using NHibernate;
using NHibernate.Cfg;

namespace CPNMv2.Repositories
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly(typeof(ItemTypeGroup).Assembly); // aqui eu preciso adicionar cada objeto que sera persistido.
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
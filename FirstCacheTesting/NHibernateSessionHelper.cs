using FirstCacheTesting.Tables;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Caches.Couchbase;
using NHibernate.Cfg;

namespace FirstCacheTesting
{
    public static class NHibernateSessionHelper
    {
        private static readonly ISessionFactory SessionFactory;

        static NHibernateSessionHelper()
        {
            Configuration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                    builder => builder
                                   .Database("NHibDBTest")
                                   .Username("sa")
                                   .Password("123456")
                                   .Server(@"KEA-MANBAUL\SQLSERVER2014"))
                    .ShowSql())
                    .CurrentSessionContext("thread_static")
                    .Cache(c => c.UseQueryCache().ProviderClass<CouchbaseCacheProvider>())
                    .ExposeConfiguration(e => {
                        e.SetProperty("hibernate.cache.use_second_level_cache", "true");
                        e.SetProperty("current_session_context_class", "web");
                    })
                    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Employee>())
                    .BuildConfiguration();
            SessionFactory = configuration.BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}

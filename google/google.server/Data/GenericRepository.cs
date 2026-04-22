using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using google.server.Business.Contracts;
using google.server.Entity;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;

namespace google.server.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : IEntity
    {
        private ISessionFactory SessionCore { get; set; }
        public ISession Session { get; set; }
        private ITransaction transaction { get; set; }
        public GenericRepository()
        {
            LoadSession();
        }
        public void LoadSession()
        {

            //var connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            var configuration = Fluently.Configure()
                .Database(PostgreSQLConfiguration.Standard
                    //.ConnectionString(connectionString)
                    .ConnectionString(cs => cs
                        .Host("127.0.0.1")
                        .Port(5222)
                        .Database("impocruz-db")
                        .Username("postgres")
                        .Password("1844")
                    )
                    //.DefaultSchema("dbo")
                    .DefaultSchema("public")
                    //.AdoNetBatchSize(50)
                    .ShowSql()
                    //.FormatSql()
                    )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<IEntity>())
                .ExposeConfiguration(cfg =>
                {
                    //cfg.SetProperty("current_session_context_class", "thread_static");
                    // Automatically create/update schema
                    new SchemaUpdate(cfg).Execute(false, true);
                })
                .BuildConfiguration();

            SessionCore = configuration.BuildSessionFactory();
            Session = SessionCore.OpenSession();
            transaction = Session.BeginTransaction();
        }

        public T GetById(int Id)
        {
            using (ISession nhSession = SessionCore.OpenSession())
            {
                nhSession.Get<T>(Id);
                return nhSession.Get<T>(Id);
            }
        }

        public T Save(T entity)
        {
            using (ISession nhSession = SessionCore.OpenSession())
            {
                nhSession.Save(entity);
                return entity;
            }
        }

        public T Update(T t)
        {
            using (ISession nhSession = SessionCore.OpenSession())
            {
                using (ITransaction transaction = nhSession.BeginTransaction())
                {
                    nhSession.Update(t);
                    transaction.Commit();
                    return t;
                }
            }
        }

        public void Delete(T t)
        {
            using (ISession nhSession = SessionCore.OpenSession())
            {
                nhSession.Delete(t);
            }
        }
    }
}

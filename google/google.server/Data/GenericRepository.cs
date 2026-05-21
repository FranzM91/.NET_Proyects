using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using google.server.Business.Contracts;
using google.server.Entity;
using google.server.Mappings;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace google.server.Data
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : IEntity
    {
        private static ISessionFactory? _sessionFactory;
        private static readonly object _lock = new object();

        public ISession Session { get; private set; }

        public GenericRepository()
        {
            if (_sessionFactory == null)
            {
                lock (_lock)
                {
                    if (_sessionFactory == null)
                    {
                        _sessionFactory = CreateSessionFactory();
                    }
                }
            }
            Session = _sessionFactory.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(PostgreSQLConfiguration.Standard
                    .ConnectionString(cs => cs
                        .Host("127.0.0.1")
                        .Port(5221)
                        .Database("control-uab-db")
                        .Username("sa")
                        .Password("1844")
                    )
                    .DefaultSchema("public")
                    .ShowSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<IEntity>())
                .ExposeConfiguration(cfg =>
                {
                    // Automatically create/update schema
                    new SchemaUpdate(cfg).Execute(true, true);
                })
                .BuildSessionFactory();
        }

        public T GetById(int Id)
        {
            return Session.Get<T>(Id);
        }

        public T Save(T entity)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Session.Save(entity);
                transaction.Commit();
                return entity;
            }
        }

        public T Update(T t)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Session.Update(t);
                transaction.Commit();
                return t;
            }
        }

        public void Delete(T t)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Session.Delete(t);
                transaction.Commit();
            }
        }

        public void Dispose()
        {
            if (Session != null && Session.IsOpen)
            {
                Session.Dispose();
            }
        }
    }
}

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAPI2.Models;

namespace TestAPI2
{
    public class FluentNHibernatehelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    InitializeSessionFactory();
                }
                return _sessionFactory;
            }
        }
        private static void InitializeSessionFactory()
        {

            _sessionFactory = Fluently.Configure()

                .Database(MsSqlConfiguration.MsSql2012.AdoNetBatchSize(5000)

                  .ConnectionString(@"Data Source=DESKTOP-15V18E8;Initial Catalog=FirstProject;Integrated Security=True").ShowSql()

                )

                .Mappings(m =>

                          m.FluentMappings

                              .AddFromAssemblyOf<Product>())

                .ExposeConfiguration(cfg => new SchemaExport(cfg)

                 .Create(false, false))
                .BuildSessionFactory();
        }
        public static ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }
        public static IStatelessSession GetStatelessSession()
        {
            return SessionFactory.OpenStatelessSession();
        }
    }
}
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using ThucHanh.Domain;
using ISession = NHibernate.ISession;

namespace ThucHanh
{
    public class FLuentNHibernateHelper
    {
        public static ISession OpenSession()
        {
            string connectionString = @"Server=DESKTOP-15V18E8;Database=SecondProject;Trusted_Connection=True";

            ISessionFactory sessionFactory = Fluently.Configure()

                .Database(MsSqlConfiguration.MsSql2005

                  .ConnectionString(connectionString).ShowSql()

                )

                .Mappings(m =>

                          m.FluentMappings

                              .AddFromAssemblyOf<Program>())

                .ExposeConfiguration(cfg => new SchemaExport(cfg)

                 .Create(false, false))

                .BuildSessionFactory();

            return sessionFactory.OpenSession();

        }
    }
}

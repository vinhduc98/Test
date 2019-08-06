﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Test5.Domain;
using ISession = NHibernate.ISession;

namespace Test5
{
    public class FluentNHibernateHleper
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

                .Database(MsSqlConfiguration.MsSql2008

                  .ConnectionString(@"Data Source=DESKTOP-15V18E8;Initial Catalog=SecondProject;Integrated Security=True").AdoNetBatchSize(100).ShowSql()

                )

                .Mappings(m =>

                          m.FluentMappings

                              .AddFromAssemblyOf<Sales>())

                .ExposeConfiguration(cfg => new SchemaExport(cfg)

                 .Create(true, true))

                .BuildSessionFactory();
        }
        public static IStatelessSession GetSession()
        {
            return SessionFactory.OpenStatelessSession();
        }
        //session.OpenStateLessSession

    }
}

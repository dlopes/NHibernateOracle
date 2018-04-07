using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using oracleBeta.Models;
//https://desenvolvimentoaberto.org/2014/05/08/instalando-o-odac-oracle-data-access-components-e-oracle-visual-studio-tools/
//https://desenvolvimentoaberto.org/2014/05/08/conexao-oracle-database-xe-odac-12c-net-visual-studio-2013-c/
//https://rafaelomarques.wordpress.com/2013/06/08/tutorial-asp-net-mvc-com-nhibernate-e-mysql-parte-1/
//https://imasters.com.br/framework/dotnet/asp-net-mvc-crud-com-fluent-nhibernate-parte-01/?trace=1519021197&source=single
//https://desenvolvimentoaberto.org/2015/02/12/asp-net-persistencia-nhibernate-oracle-c/
//http://nhbwithoracle.blogspot.com.br 
//http://www.oracle.com/webfolder/technetwork/tutorials/obe/db/dotnet/NuGet/index.html
//https://devio.wordpress.com/2010/04/13/first-steps-with-nhibernate-fluent-oracle-c-and-visual-studio-2010-rc/
//https://desenvolvimentoaberto.org/2015/02/12/asp-net-persistencia-nhibernate-oracle-c/
//Driver para intalar do oracle
//https://stackoverflow.com/questions/32229132/c-sharp-nhibernate-oracle-managed-client

namespace oracleBeta.Dao
{
    public class NHibernateHelper
    {
        private static ISessionFactory sessionFactory;
        private static Configuration configuration;
        private static HbmMapping mapping;

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                    sessionFactory = Configuration.BuildSessionFactory();

                return sessionFactory;
            }
        }

        public static Configuration Configuration
        {
            get
            {
                if (configuration == null)
                    configuration = CreateConfiguration();

                return configuration;
            }
        }

        public static HbmMapping Mapping
        {
            get
            {
                if (mapping == null)
                    mapping = CreateMapping();

                return mapping;
            }
        }

        private static Configuration CreateConfiguration()
        {
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddDeserializedMapping(Mapping, null);

            return configuration;
        }

        private static HbmMapping CreateMapping()
        {
            var mapper = new ModelMapper();
            //Carrega os mapeamentos
            mapper.AddMappings(new List<System.Type> { typeof(CadastroMap) });

            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }
}
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using oracleBeta.Dao;
using System;
using System.Collections.Generic;

namespace oracleBeta.Models
{
    public class CadastroRepository
    {
        public Cadastro Get(/*Guid id*/ String CPF_CGC, String COD_PESSOA) 
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {

                var cadastro = session.CreateCriteria<Cadastro>()
                .Add(Restrictions.Eq("CPF_CGC", CPF_CGC))
                .Add(Restrictions.Eq("COD_PESSOA", COD_PESSOA))
                .List<Cadastro>();

                return cadastro[0];

            }
        }

        public void Save(Cadastro cadastro)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(cadastro);
                transaction.Commit();
            }
        }

        public void Update(Cadastro cadastro)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {

                session.Update(cadastro);
                transaction.Commit();
                
            }


        }

        public IList<Cadastro> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var testes = session.CreateCriteria<Cadastro>().List<Cadastro>();
                
                return testes;
            }
        }

        public void Delete(Cadastro cadastro)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.CreateQuery("delete from db.cadastro u where u.CPF_CGC = (:cpf) and u.COD_PESSOA = (:codPessoa)")
                    .SetParameter("cpf", cadastro.CPF_CGC)
                    .SetParameter("codPessoa", cadastro.COD_PESSOA)
                    .UniqueResult();
                    /*.ExecuteUpdate()*/;
                transaction.Commit();
            }
        }

    }
}
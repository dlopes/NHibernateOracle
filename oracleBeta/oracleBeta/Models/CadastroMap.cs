using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace oracleBeta.Models
{
    public class CadastroMap : NHibernate.Mapping.ByCode.Conformist.ClassMapping<Cadastro>
    {
        public CadastroMap()
        {
            Table("db.cadastro");
            //Id(x => x.Id);
            //Id(x => x.CPF_CGC);
            //Chave primária COD_PESSOA, CPF_CGC
            ComposedId(p =>
            {
                p.Property(p1 => p1.CPF_CGC, a => a.Column("CPF_CGC"));
                p.Property(p1 => p1.COD_PESSOA , a => a.Column("COD_PESSOA"));
            });

            Property(x => x.BLOB_IMAGEM);
            Property(x => x.DATA_INCLUSAO);
            Property(x => x.NOME_PESSOA);

        }

       
    }
}

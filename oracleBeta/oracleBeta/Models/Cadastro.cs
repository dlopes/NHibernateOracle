using System;
//https://stackoverflow.com/questions/32229132/c-sharp-nhibernate-oracle-managed-client
//https://www.nuget.org/packages/Oracle.ManagedDataAccess/
namespace oracleBeta.Models
{
    public class Cadastro
    {
        public virtual int COD_PESSOA { get; set; }
        public virtual string CPF_CGC { get; set; }
        public virtual string NOME_PESSOA { get; set; }
        public virtual DateTime DATA_INCLUSAO { get; set; }
        public virtual Byte[] BLOB_IMAGEM { get; set; }


        //Rescrever no casa de chave composta
        //http://www.macoratti.net/09/04/net_nhb2.htm
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Cadastro other = obj as Cadastro;
            if (other == null)
                return false;
            if (CPF_CGC == other.CPF_CGC && COD_PESSOA  == other.COD_PESSOA)
                return true;
            return base.Equals(obj);
        }
        
        //Rescrever no casa de chave composta
        public override int GetHashCode()
        {
            return (CPF_CGC + "|" + COD_PESSOA).GetHashCode();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Crud3CamadasMota
{
    public class BairroBll
    {
        private BairroDal bairroDal = null;

        public DataTable ListaBairroDal()
        {
            DataTable dtBairro = new DataTable();
            try
            {
                bairroDal = new BairroDal();
                dtBairro = bairroDal.ListaBairro();
            }
            catch (Exception erro)
            {
                
                throw erro;
            }
            return dtBairro;
        }

        public void GravaBairroDal(BairroModel bairroModel)
        {
            try
            {
                bairroDal = new BairroDal();
                bairroDal.GravaBairroDal(bairroModel);
            }
            catch (Exception erro)
            {
                
                throw erro;
            }
        }
        public void AlteraBairroDal(BairroModel bairroModel)
        {
            try
            {
                bairroDal = new BairroDal();
                bairroDal.AlteraBairroDal(bairroModel);
            }
            catch (Exception erro)
            {
                
                throw erro;
            }
        }
        public void ExcluirBairroDal(BairroModel bairroModel)
        {
            try
            {
                bairroDal = new BairroDal();
                bairroDal.ExcluirBairroDal(bairroModel);
            }
            catch (Exception erro)
            {
                
                throw erro;
            }
        }

        public BairroModel PesuisarDal(string pesquisar)
        {
            try
            {
                BairroModel obj_bairro = new BairroModel();
                bairroDal = new BairroDal();
                obj_bairro = bairroDal.Pesquisar(pesquisar);
                //return bairroDal.Pesquisar(pesquisar);
                return obj_bairro;
            }
            catch (Exception erro)
            {
                
                throw erro;
            }
        }
    }
}

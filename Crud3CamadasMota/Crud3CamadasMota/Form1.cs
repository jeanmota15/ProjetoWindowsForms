using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud3CamadasMota
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PovoaGrade();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void PovoaGrade()
        {
            try
            {
                //DataTable dtBairro = new DataTable();
                BairroBll bairroBll = new BairroBll();
                grade_bairro.DataSource = bairroBll.ListaBairroDal();
            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao listar");
            }
        }

        private void bt_gravar_Click(object sender, EventArgs e)
        {
            BairroModel obj_bairro = new BairroModel();
            obj_bairro.Nome = tb_nome.Text;

            try
            {
                BairroBll bairroBll = new BairroBll();
                bairroBll.GravaBairroDal(obj_bairro);
                MessageBox.Show("Gravado com Sucesso!");
                PovoaGrade();
            }
            catch (Exception)
            {

                MessageBox.Show("Erro na Gravação!");
            }
        }

        private void bt_alterar_Click(object sender, EventArgs e)
        {
            BairroModel obj_bairro = new BairroModel();
            obj_bairro.Id = int.Parse(tb_codigo.Text.ToString());
            obj_bairro.Nome = tb_nome.Text;
            try
            {
                BairroBll bairroBll = new BairroBll();
                bairroBll.AlteraBairroDal(obj_bairro);
                MessageBox.Show("Alterado com sucesso!");
                PovoaGrade();
            }
            catch (Exception)
            {

                MessageBox.Show("Erro na alteração!");
            }
        }

        private void bt_excluir_Click(object sender, EventArgs e)
        {
            BairroModel obj_bairro = new BairroModel();
            obj_bairro.Id = int.Parse(tb_codigo.Text.ToString());
            try
            {
                BairroBll bairroBll = new BairroBll();
                bairroBll.ExcluirBairroDal(obj_bairro);
                MessageBox.Show("Excluiu com sucesso!");
                PovoaGrade();
            }
            catch (Exception)
            {
                
                MessageBox.Show("Erro na exclusão!");
            }
        }

        private void bt_pesquisar_Click(object sender, EventArgs e)
        {
            string pesquisar = tb_pesquisar.Text;//rece 
            BairroModel obj_bairro = new BairroModel();
            try
            {
                BairroBll bairroBll = new BairroBll();
                obj_bairro = bairroBll.PesuisarDal(pesquisar);
                tb_codigo.Text = obj_bairro.Id.ToString();
                tb_nome.Text = obj_bairro.Nome;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro na pesquisa: " + erro);
            }
        }
    }
}

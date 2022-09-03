using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CrudXML
{

    public partial class Cadastro : Form
    {

        string connectionString = @"Server=localhost.\sqlexpress;Database=bdcadastro;Trusted_Connection=True;";
        bool novo;

        /* ("persist security info = false;" +
                                           "server=localhost;" +
                                           "database=BDCADASTRO" +
                                           "uid=root;pwd=;SslMode=none"); */

      
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {
            btnCadastrar.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnExcluir.Enabled = false;
            txtBairro.Enabled = false;
            txtBuscar.Enabled = false;
            txtCEP.Enabled = false;
            txtCidade.Enabled = false;
            txtEndereco.Enabled = false;
            txtID.Enabled = true;
            txtTelefone.Enabled = false;
            txtUF.Enabled = false;
            txtBuscar.Enabled = false;
            btnBuscar.Enabled = true;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            btnCadastrar.Enabled = false;
            btnCancelar.Enabled = true;
            btnBuscar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            txtCEP.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtUF.Enabled = true;
            txtTelefone.Enabled = true;
            txtTelefone.Focus();
            novo = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (novo)
            {
                string sql = "insert into CLIENTE(NOME,ENDERECO,CEP,BAIRRO,CIDADE,UF,TELEFONE)"
                    + "values ('" + txtNome.Text + "','" + txtEndereco.Text + "', '" + txtCEP.Text + "', '" + txtBairro.Text + "', '" + txtCidade.Text + "','" + txtUF.Text + "', '" + txtTelefone.Text + "')";

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try{
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Cadastro realizado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                string sql = "insert into cliente(nome,endereco,cep,bairro,cidade,uf,telefone)"
                    + "values ('" + txtNome.Text + "','" + txtEndereco.Text + "', '" + txtCEP.Text + "', '" + txtBairro.Text + "', '" + txtCidade.Text + "','" + txtUF.Text + "', '" + txtTelefone.Text + "' WHERE ID=" + txtID.Text;

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Cadastro Atualizado com sucesso!");
                }catch(Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
            btnCadastrar.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnExcluir.Enabled = false;
            txtNome.Enabled = false;
            btnBuscar.Enabled = true;
            txtEndereco.Enabled = false;
            txtCEP.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            txtTelefone.Enabled = false;
            txtID.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCEP.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
            txtTelefone.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCadastrar.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnExcluir.Enabled = false;
            txtID.Enabled = true;
            txtBuscar.Enabled = true;
            txtNome.Enabled = true;
            txtEndereco.Enabled = false;
            txtCEP.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            txtTelefone.Enabled = false;
            txtID.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCEP.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
            txtTelefone.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM CLIENTE WHERE ID=" + txtID.Text;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Registro excluido com sucesso!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string sql = "Select * from CLIENTE WHERE ID=" + txtID.Text;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    btnCadastrar.Enabled = false;
                    btnSalvar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnExcluir.Enabled = true;
                    txtID.Enabled = false;
                    btnBuscar.Enabled = false;
                    txtNome.Enabled = true;
                    txtEndereco.Enabled = true;
                    txtCEP.Enabled = true;
                    txtBairro.Enabled = true;
                    txtCidade.Enabled = true;
                    txtUF.Enabled = true;
                    txtTelefone.Enabled = true;
                    txtNome.Focus();
                    txtID.Text = reader[0].ToString();
                    txtNome.Text = reader[1].ToString();
                    txtEndereco.Text = reader[2].ToString();
                    txtCEP.Text = reader[3].ToString();
                    txtBairro.Text = reader[4].ToString();
                    txtCidade.Text = reader[5].ToString();
                    txtUF.Text = reader[6].ToString();
                    txtTelefone.Text = reader[7].ToString();
                    novo = false;
                }
                else

                    MessageBox.Show("Nenhum registro encontrado com o ID informado!");
                }
                    catch(Exception ex){
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            txtID.Text = "";
        }
    }
}
    

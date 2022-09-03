using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudXML
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Clientes clientes;

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente()
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text
            };
            clientes.Adicionar(cli);
            clientes.Salvar();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes.ListarTodos();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            clientes = new Clientes();
            clientes.Carregar();
            dataGridView1.DataSource = clientes.ListarTodos();
        }
    }
}

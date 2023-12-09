using Projeto_Controle_de_Vendas.br.com.projeto.dao;
using Projeto_Controle_de_Vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_de_Vendas.br.com.projeto.view
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();

            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;
            txtCodigo.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            Cliente obj = new Cliente();

           
            obj.nome = txtNome.Text;
            obj.rg = txtRG.Text;
            obj.cpf = txtCPF.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCEP.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComplemento.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbxUF.Text;

            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(obj);

            txtNome.Text = "";
            txtRG.Text = "";
            txtCPF.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
            txtCelular.Text = "";
            txtCEP.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cbxUF.Text = "";

            tabelaCliente.DataSource = dao.listarCliente();

        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            //colorindo o datagrid com as cores da sua preferência
            tabelaCliente.DefaultCellStyle.ForeColor = Color.Black;

            ClienteDAO dao = new ClienteDAO();
            tabelaCliente.DataSource = dao.listarCliente();

            
        }

        private void tabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegando dados das linhas selecionadas e tranformando em string
            txtCodigo.Text = tabelaCliente.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaCliente.CurrentRow.Cells[1].Value.ToString();
            txtRG.Text = tabelaCliente.CurrentRow.Cells[2].Value.ToString();
            txtCPF.Text = tabelaCliente.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = tabelaCliente.CurrentRow.Cells[4].Value.ToString();
            txtTelefone.Text = tabelaCliente.CurrentRow.Cells[5].Value.ToString();
            txtCelular.Text = tabelaCliente.CurrentRow.Cells[6].Value.ToString();
            txtCEP.Text = tabelaCliente.CurrentRow.Cells[7].Value.ToString();
            txtEndereco.Text = tabelaCliente.CurrentRow.Cells[8].Value.ToString();
            txtNumero.Text = tabelaCliente.CurrentRow.Cells[9].Value.ToString();
            txtComplemento.Text = tabelaCliente.CurrentRow.Cells[10].Value.ToString();
            txtBairro.Text = tabelaCliente.CurrentRow.Cells[11].Value.ToString();
            txtCidade.Text = tabelaCliente.CurrentRow.Cells[12].Value.ToString();
            cbxUF.Text = tabelaCliente.CurrentRow.Cells[13].Value.ToString();

            //Alterando para a Aba indicada
            tabClientes.SelectedTab = tabPage1;

            btnSalvar.Enabled = false;
            btnExcluir.Enabled = true;
            btnEditar.Enabled = true;
            txtPesquisa.Text = "";
            

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();

            obj.codigo = int.Parse(txtCodigo.Text);

            ClienteDAO dao = new ClienteDAO();

            dao.excluirCliente(obj);

            txtNome.Text = "";
            txtRG.Text = "";
            txtCPF.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
            txtCelular.Text = "";
            txtCEP.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cbxUF.Text = "";
            txtCodigo.Text = "";

            tabelaCliente.DataSource = dao.listarCliente();

            tabClientes.SelectedTab = tabPage2;

            btnSalvar.Enabled = true;
            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            Cliente obj = new Cliente();

            obj.nome = txtNome.Text;
            obj.rg = txtRG.Text;
            obj.cpf = txtCPF.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCEP.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComplemento.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbxUF.Text;
            obj.codigo = int.Parse(txtCodigo.Text);

            ClienteDAO dao = new ClienteDAO();
            dao.alterarCliente(obj);

            txtNome.Text = "";
            txtRG.Text = "";
            txtCPF.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
            txtCelular.Text = "";
            txtCEP.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cbxUF.Text = "";

            tabelaCliente.DataSource = dao.listarCliente();

            btnSalvar.Enabled = true;
            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;
            txtCodigo.Text = "";

            tabClientes.SelectedTab = tabPage2;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text;

            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.buscarCliente(nome);

            if(tabelaCliente.Rows.Count == 0)
            {
                tabelaCliente.DataSource = dao.listarCliente();
            }
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";

            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.listarClientePorNome(nome);
        }

        private void btnPesquisaCEP_Click(object sender, EventArgs e)
        {
            try
            {
                string cep = txtCEP.Text;
                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";

                DataSet dados = new DataSet();

                dados.ReadXml(xml);

                txtEndereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                cbxUF.Text = dados.Tables[0].Rows[0]["uf"].ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("Endereço não encontrado por favor digite manualmente");
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tabClientes.SelectedTab = tabPage1;

            new Helpers().LimparTela(this);

            btnSalvar.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }
    }
}

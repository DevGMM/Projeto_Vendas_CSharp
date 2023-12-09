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
    public partial class FrmFuncionarios : Form
    {
        public FrmFuncionarios()
        {
            InitializeComponent();

            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            txtCodigo.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Funcionario obj = new Funcionario();

            obj.nome = txtNome.Text;
            obj.rg = txtRG.Text;
            obj.cpf = txtCPF.Text;
            obj.email = txtEmail.Text;
            obj.senha = txtSenha.Text;
            obj.cargo = cbxCargo.Text;
            obj.nivel_acesso = cbxNivel.Text;
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCEP.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComplemento.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbxUF.Text;

            FuncionarioDAO dao = new FuncionarioDAO();

            dao.cadastrarFuncionario(obj);

            tabelaFuncionário.DataSource = dao.listarFuncionario();

            new Helpers().LimparTela(this);

        }

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            FuncionarioDAO dao = new FuncionarioDAO();

            tabelaFuncionário.DataSource = dao.listarFuncionario();
        }

        private void tabelaFuncionário_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = tabelaFuncionário.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaFuncionário.CurrentRow.Cells[1].Value.ToString();
            txtRG.Text = tabelaFuncionário.CurrentRow.Cells[2].Value.ToString();
            txtCPF.Text = tabelaFuncionário.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = tabelaFuncionário.CurrentRow.Cells[4].Value.ToString();
            txtSenha.Text = tabelaFuncionário.CurrentRow.Cells[5].Value.ToString();
            cbxCargo.Text = tabelaFuncionário.CurrentRow.Cells[6].Value.ToString();
            cbxNivel.Text = tabelaFuncionário.CurrentRow.Cells[7].Value.ToString();
            txtTelefone.Text = tabelaFuncionário.CurrentRow.Cells[8].Value.ToString();
            txtCelular.Text = tabelaFuncionário.CurrentRow.Cells[9].Value.ToString();
            txtCEP.Text = tabelaFuncionário.CurrentRow.Cells[10].Value.ToString();
            txtEndereco.Text = tabelaFuncionário.CurrentRow.Cells[11].Value.ToString();
            txtNumero.Text = tabelaFuncionário.CurrentRow.Cells[12].Value.ToString();
            txtComplemento.Text = tabelaFuncionário.CurrentRow.Cells[13].Value.ToString();
            txtBairro.Text = tabelaFuncionário.CurrentRow.Cells[14].Value.ToString();
            txtCidade.Text = tabelaFuncionário.CurrentRow.Cells[15].Value.ToString();
            cbxUF.Text = tabelaFuncionário.CurrentRow.Cells[16].Value.ToString();

            tabFuncionarios.SelectedTab = tabPage1;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Funcionario obj = new Funcionario();
            obj.codigo = int.Parse(txtCodigo.Text);

            FuncionarioDAO dao = new FuncionarioDAO();

            dao.deletarFuncionario(obj);

            tabelaFuncionário.DataSource = dao.listarFuncionario();

            new Helpers().LimparTela(this);

            tabFuncionarios.SelectedTab = tabPage2;
            btnSalvar.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Funcionario obj = new Funcionario();

            obj.codigo = int.Parse(txtCodigo.Text);
            obj.nome = txtNome.Text;
            obj.rg = txtRG.Text;
            obj.cpf = txtCPF.Text;
            obj.email = txtEmail.Text;
            obj.senha = txtSenha.Text;
            obj.cargo = cbxCargo.Text;
            obj.nivel_acesso = cbxNivel.Text;
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCEP.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComplemento.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbxUF.Text;

            FuncionarioDAO dao = new FuncionarioDAO();

            dao.alterarFuncionario(obj);

            new Helpers().LimparTela(this);

            tabelaFuncionário.DataSource = dao.listarFuncionario();

            tabFuncionarios.SelectedTab = tabPage2;
            btnSalvar.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text;

            FuncionarioDAO dao = new FuncionarioDAO();

            tabelaFuncionário.DataSource = dao.buscarFuncionario(nome);

            if(tabelaFuncionário.Rows.Count == 0 || txtPesquisa.Text == string.Empty)
            {
                MessageBox.Show("Funcionário não encontrado!!");
                tabelaFuncionário.DataSource = dao.listarFuncionario();
            }
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";

            FuncionarioDAO dao = new FuncionarioDAO();

            tabelaFuncionário.DataSource = dao.listarFuncionarioPorNome(nome);
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
            new Helpers().LimparTela(this);

            btnSalvar.Enabled = true;
            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;
        }
    }
}

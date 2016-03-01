using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilRougeDAO.DAO;

namespace FilRougeDAO
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            ClientDAO cli_DAO = new ClientDAO(Properties.Settings.Default.chaine);

            List<Client> liste = cli_DAO.ListCli();


            foreach (Client item in liste)
            {



                comboBox1.Items.Add(item);
                comboBox1.DisplayMember = "Nomclient";
                comboBox1.ValueMember = item.IdClient.ToString();

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Client cli = new Client();

            cli =(Client) comboBox1.SelectedItem;

            CommandeDAO g = new CommandeDAO(Properties.Settings.Default.chaine);

            dataGridView1.DataSource = g.List_Com(cli);



        }
    }
}

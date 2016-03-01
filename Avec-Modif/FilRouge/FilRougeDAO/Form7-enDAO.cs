using FilRougeDAO.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilRougeDAO
{
    public partial class Form7_enDAO : Form
    {
        public Form7_enDAO()
        {
            InitializeComponent();
        }

        private void Form7_enDAO_Load(object sender, EventArgs e)
        {




            RubriqueDAO d = new RubriqueDAO(Properties.Settings.Default.chaine);

            List<Rubrique> f = d.List();

            foreach (Rubrique item in f)
            {


                TreeNode tNode = new TreeNode(item.NomRubrique);
                
                treeView2.Nodes.Add(tNode);
                SsRubriqueDAO d2 = new SsRubriqueDAO(Properties.Settings.Default.chaine);

                List<SsRubrique> f2 = d2.List(item);

                foreach (SsRubrique item2 in f2)
                {


                    TreeNode tNode2 = new TreeNode(item2.NomSousrubrique);
                   
                    tNode.Nodes.Add(tNode2);



                    InstrumentDAO d3 = new InstrumentDAO(Properties.Settings.Default.chaine);

                    List<Instrument> f3 = d3.List(item2);

                    foreach (Instrument item3 in f3)
                    {


                        TreeNode tNode3 = new TreeNode(item3.NomProdCourt);
                        
                        tNode2.Nodes.Add(tNode3);



                    }



                }

            }
            

        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(treeView2.SelectedNode.Text);
            //treeView2.SelectedNode.Expand();
            
        }
    }
}

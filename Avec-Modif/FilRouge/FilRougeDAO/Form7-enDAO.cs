using FilRougeDAO.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
                tNode.Tag = item.Idrubrique;

                treeView2.Nodes.Add(tNode);


                SsRubriqueDAO d2 = new SsRubriqueDAO(Properties.Settings.Default.chaine);

                List<SsRubrique> f2 = d2.List(item);

                foreach (SsRubrique item2 in f2)
                {


                    TreeNode tNode2 = new TreeNode(item2.NomSousrubrique);
                    tNode2.Tag = item2.IdSousRubrique;

                    tNode.Nodes.Add(tNode2);



                    InstrumentDAO d3 = new InstrumentDAO(Properties.Settings.Default.chaine);

                    List<Instrument> f3 = d3.List(item2);

                    foreach (Instrument item3 in f3)
                    {


                        TreeNode tNode3 = new TreeNode(item3.NomProdCourt);
                        tNode3.Tag = item3.IdProduit;

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

        private void button1_Click(object sender, EventArgs e)
        {


            //TreeNode nodes;

            //int i = treeView2.GetNodeCount(true);

            //MessageBox.Show(i.ToString());


            //int myNodeCount = treeView2.SelectedNode.GetNodeCount(true);

            //decimal myChildPercentage = ((decimal)myNodeCount /(decimal)treeView2.GetNodeCount(true)) * 100;

            //MessageBox.Show("The '" + treeView2.SelectedNode.FullPath + "' node has "+ myNodeCount.ToString() + " child nodes.\nThat is "+ string.Format("{0:###.##}", myChildPercentage)+ "% of the total tree nodes in the tree view control.");


            ////DirectoryInfo dir = new DirectoryInfo();

            ReplaceTextInAllNodes(treeView2.Nodes, "violon", "WITHME");







        }



        private void ReplaceTextInAllNodes(TreeNodeCollection treeNodes, string textToReplace, string newText)
        {
            foreach (TreeNode aNode in treeNodes)
            {
                aNode.Text = aNode.Text.Replace(textToReplace, newText);  //ici remplacement

                if (aNode.Nodes.Count > 0)
                    ReplaceTextInAllNodes(aNode.Nodes, textToReplace, newText);
            }
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {


            treeView2.SelectedNode.Text = textBox1.Text;


        }

        private void annulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView2.SelectedNode.Remove();
        }

        private void treeView2_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            
            if (e.Node.Level == 0)
            {
               

               // MessageBox.Show(e.Node.Tag + " dans rubrique " + e.Node.Text + " avant et apres "+ e.Label);

                RubriqueDAO d2 = new RubriqueDAO(Properties.Settings.Default.chaine);

                d2.update(Convert.ToInt32(e.Node.Tag), e.Label);


            }
            else
            {
                if (e.Node.Level == 1)
                {
                 //   MessageBox.Show(e.Node.Tag + " dans sous rubrique ");

                    SsRubriqueDAO d3 = new SsRubriqueDAO(Properties.Settings.Default.chaine);

                    d3.update(Convert.ToInt32(e.Node.Tag), e.Label);

                }
                else
                {
                   // MessageBox.Show(e.Node.Tag + " dans instrument ");

                    InstrumentDAO d4 = new InstrumentDAO(Properties.Settings.Default.chaine);

                    d4.update(Convert.ToInt32(e.Node.Tag), e.Label);

                }


            }



            //voir propriété level

            //if (e.Label != null)
            //{
            //    if (e.Label.Length > 0)
            //    {
            //        if (e.Label.IndexOfAny(new char[] { '@', '.', ',', '!' }) == -1)
            //        {
            //            // Stop editing without canceling the label change.
            //            e.Node.EndEdit(false);
            //            MessageBox.Show("modification effectuée");


            //        }
            //        else
            //        {
            //            /* Cancel the label edit action, inform the user, and 
            //               place the node in edit mode again. */
            //            e.CancelEdit = true;
            //            MessageBox.Show("Invalid tree node label.\n" +
            //               "The invalid characters are: '@','.', ',', '!'",
            //               "Node Label Edit");
            //            e.Node.BeginEdit();
            //        }
            //    }
            //    else
            //    {
            //        /* Cancel the label edit action, inform the user, and 
            //           place the node in edit mode again. */
            //        e.CancelEdit = true;
            //        MessageBox.Show("Invalid tree node label.\nThe label cannot be blank",
            //           "Node Label Edit");
            //        e.Node.BeginEdit();
            //    }

            //}
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {


            //if (treeView2.SelectedNode.Parent.Depth != -1)
            //{

            //    Message.Text += "Its parent node is " + LinksTreeView.SelectedNode.Parent.Text + ".";

            //}
            //else
            //{

            //    Message.Text += "This is a root node and does not have a parent node.";

            //}


            //if (e.Node.Parent != null && e.Node.Parent.GetType() == typeof(TreeNode))
            //{
            //    label2.Text = "Il faut gérer les rubriques";


            //}

            //if (e.Node.Parent.Parent != null && e.Node.Parent.GetType() == typeof(TreeNode))
            //{
            //    label2.Text = "Il faut gérer les sous rubriques";


            //}

            //if (e.Node.Parent.Parent.Parent != null && e.Node.Parent.GetType() == typeof(TreeNode))
            //{
            //    label2.Text = "Il faut gérer les instruments";


            //}








            if (e.Node.Parent != null && e.Node.Parent.GetType() == typeof(TreeNode))
            {
                label2.Text = "Parent: " + e.Node.Parent.Text + "\n" + "Index Position: " + e.Node.Parent.Index.ToString() + " level= " + e.Node.Level;
            }
            else
            {
                label2.Text = "No parent node. " + e.Node.Level;
                //cas des rubriques
            }
        }
    }
}

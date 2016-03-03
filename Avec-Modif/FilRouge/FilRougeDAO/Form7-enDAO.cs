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

treeView2.AllowDrop = true;


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
            groupBox1.Visible = true;
            groupBox1.Text = "Ajouter";
            MessageBox.Show(treeView2.SelectedNode.Text);
            //treeView2.SelectedNode.Expand();
            //groupBox1.Visible = false;

            


        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox1.Text = "Supprimer";

            //groupBox1.Visible = false;
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox1.Text = "Modifier";

           // groupBox1.Visible = false;
        }

        private void treeView2_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView2_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = treeView2.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            treeView2.SelectedNode = treeView2.GetNodeAt(targetPoint);
        }

        private void treeView2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void treeView2_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = treeView2.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = treeView2.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                }

                // If it is a copy operation, clone the dragged node 
                // and add it to the node at the drop location.
                else if (e.Effect == DragDropEffects.Copy)
                {
                    targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                }

                // Expand the node at the location 
                // to show the dropped node.
                targetNode.Expand();
            }
        }
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }
    }
}

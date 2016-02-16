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
using System.IO;

namespace FilRougeDAO
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            RubriqueDAO d = new RubriqueDAO(Properties.Settings.Default.chaine);

            listBox1.DataSource = d.List();
            listBox1.DisplayMember = "NomRubrique";


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Rubrique g = (Rubrique)listBox1.SelectedItem;

                SsRubriqueDAO p = new SsRubriqueDAO(Properties.Settings.Default.chaine);

                listBox2.DataSource = p.List(g);
                listBox2.DisplayMember = "NomSousRubrique";

                
                
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                SsRubrique g = (SsRubrique)listBox2.SelectedItem;

                InstrumentDAO p = new InstrumentDAO(Properties.Settings.Default.chaine);

                listBox3.DataSource = p.List(g);
                listBox3.DisplayMember = "NomProdCourt";

                

            }


           
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex != -1)
            {
                Instrument g = (Instrument)listBox3.SelectedItem;

                FileStream fs = new FileStream(@"C:\Users\stagiaire\Dropbox\FilRouge\Avec-Modif\Image\" +g.Imageprod, FileMode.Open);
                pictureBox1.Image = Image.FromStream(fs);
                fs.Close();

                

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using JobXML;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "Trimble JobXML files (*.jxl)|*.jxl";
            dlg.FileName = "test.jxl";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;


            var jx = new JOBFile();
            jx.jobName = "JobName";

            var rnd = new Random();

            var pList = new List<Point>();
            pList.Add(new Point()
            {
                ID = rnd.Next().ToString(),
                Name = rnd.Next().ToString(),
                SurveyMethod = surveyMethodType.KeyedIn,
                Classification = classificationType.Normal
            });
            pList.Add(new Point()
            {
                ID = rnd.Next().ToString(),
                Name = rnd.Next().ToString(),
                SurveyMethod = surveyMethodType.KeyedIn,
                Classification = classificationType.Normal
            });
            pList.Add(new Point()
            {
                ID = rnd.Next().ToString(),
                Name = rnd.Next().ToString(),
                SurveyMethod = surveyMethodType.KeyedIn,
                Classification = classificationType.Normal
            });


            jx.Reductions = new Reductions();
            jx.Reductions.Items = pList.ToArray();


            try
            {
                var xs = new XmlSerializer(typeof(JOBFile));
                using (var stm = dlg.OpenFile())
                {
                    xs.Serialize(stm, jx);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Trimble JobXML files (*.jxl)|*.jxl";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(JOBFile));
            JOBFile job;

            using (var stm = dlg.OpenFile())
            {
                job = (JOBFile)xs.Deserialize(stm);
            }

            propertyGrid.SelectedObject = job;
            MessageBox.Show(job.jobName);
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Trimble JobXML \r https://github.com/kubaszostak/");
        }
    }
}

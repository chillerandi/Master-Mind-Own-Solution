using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace Master_Mind
{
    public partial class GameForm : DevExpress.XtraEditors.XtraForm
    {
        public GameForm()
        {
            InitializeComponent();
            gridControl1.DataSource = CreateTable(10);
            gridView1.Columns["Colour1"].ColumnEdit = new RepositoryItemPictureEdit();
            gridView1.Columns["Colour2"].ColumnEdit = new RepositoryItemPictureEdit();
            gridView1.Columns["Colour3"].ColumnEdit = new RepositoryItemPictureEdit();
            gridView1.Columns["Colour4"].ColumnEdit = new RepositoryItemPictureEdit();
            gridView1.Columns["Colour5"].ColumnEdit = new RepositoryItemPictureEdit();
            gridView1.Columns["Colour6"].ColumnEdit = new RepositoryItemPictureEdit();
        }


        private DataTable CreateTable(int RowCount) { 
        Image[] images = new Image[] {
            Master_Mind.Properties.Resources.Rot_Pin,
            Master_Mind.Properties.Resources.Gelb_Pin,
            Master_Mind.Properties.Resources.Blau_Pin,
            Master_Mind.Properties.Resources.Pink_Pin,
            Master_Mind.Properties.Resources.Grün_Pin,
            Master_Mind.Properties.Resources.Hellblau_Pin
        };

            DataTable tbl = new DataTable();
            tbl.Columns.Add("Colour1", typeof(Image));
            tbl.Columns.Add("Colour2", typeof(Image));
            tbl.Columns.Add("Colour3", typeof(Image));
            tbl.Columns.Add("Colour4", typeof(Image));
            tbl.Columns.Add("Colour5", typeof(Image));
            tbl.Columns.Add("Colour6", typeof(Image));
            for (int i = 0; i < RowCount; i++) {
                tbl.Rows.Add( images[i % images.Length] );
            }
               
            return tbl;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
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

namespace MasterMind_GUI
{
    public partial class GameForm : DevExpress.XtraEditors.XtraForm
    {
        public GameForm()
        {
            InitializeComponent();
            dataGridView2.DataSource = CreateTable(30, Color.Beige);
            //gridView1.Columns["Colour1"].ColumnEdit = new RepositoryItemPictureEdit();
            //gridView1.Columns["Colour2"].ColumnEdit = new RepositoryItemPictureEdit();
            //gridView1.Columns["Colour3"].ColumnEdit = new RepositoryItemPictureEdit();
            //gridView1.Columns["Colour4"].ColumnEdit = new RepositoryItemPictureEdit();
            //gridView1.Columns["Colour5"].ColumnEdit = new RepositoryItemPictureEdit();
            //gridView1.Columns["Colour6"].ColumnEdit = new RepositoryItemPictureEdit();

            //gridView1.Columns["Colour1"].ColumnEdit = new RepositoryItemColorEdit();
            //gridView1.Columns["Colour2"].ColumnEdit = new RepositoryItemColorEdit();
            //gridView1.Columns["Colour3"].ColumnEdit = new RepositoryItemColorEdit();
            //gridView1.Columns["Colour4"].ColumnEdit = new RepositoryItemColorEdit();
            //gridView1.Columns["Colour5"].ColumnEdit = new RepositoryItemColorEdit();
            //gridView1.Columns["Colour6"].ColumnEdit = new RepositoryItemColorEdit();
        }

        //DataGridView dataGridView2 = new DataGridView();
        

        private DataTable CreateTable(int RowCount, Color BgColor)
        {
            
                Image[] images = new Image[] {
            Mastermind_GUI.Properties.Resources.Loch,
            Mastermind_GUI.Properties.Resources.Rot_Pin,
            Mastermind_GUI.Properties.Resources.Gelb_Pin,
            Mastermind_GUI.Properties.Resources.Blau_Pin,
            Mastermind_GUI.Properties.Resources.Pink_Pin,
            Mastermind_GUI.Properties.Resources.Grün_Pin,
            Mastermind_GUI.Properties.Resources.Hellblau_Pin
        };

            //DataTable tbl = new DataTable();
            //tbl.Columns.Add("Colour1", typeof(Image));
            //tbl.Columns.Add("Colour2", typeof(Image));
            //tbl.Columns.Add("Colour3", typeof(Image));
            //tbl.Columns.Add("Colour4", typeof(Image));
            //tbl.Columns.Add("Colour5", typeof(Image));
            //tbl.Columns.Add("Colour6", typeof(Image));

            DataTable tbl = new DataTable();
            tbl.Columns.Add("Colour1", typeof(Color));
            tbl.Columns.Add("Colour2", typeof(Color));
            tbl.Columns.Add("Colour3", typeof(Color));
            tbl.Columns.Add("Colour4", typeof(Color));
            tbl.Columns.Add("Colour5", typeof(Color));
            tbl.Columns.Add("Colour6", typeof(Color));
            for (int i = 0; i < RowCount; i++) {
                tbl.Rows.Add(/*Color.Beige, Color.Beige, Color.Beige, Color.Beige, Color.Beige, Color.Beige */);
            }
            //foreach (DataGridItem item in gridControl1.Rows) {
            //    item.BackColor = Color.Red;
            //}

            //foreach (DataGridViewCell cell in dataGridView2.Rows) {
            //    cell.BackColor = Color.Red;
            //}

            return tbl;
        }

       

    //private void gridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    //{
    //    DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
    //    CellStyle.BackColor = Color.Red;
    //    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = CellStyle;
    //}

    //private void gridControl1_Click(object sender, DataGridViewCellEventArgs e)
    //    {
    //        DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
    //        CellStyle.BackColor = Color.Red;
    //        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = CellStyle;
    //    }

        //private void GameForm_Load(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
        //    CellStyle.BackColor = Color.Red;
        //    dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = CellStyle;
        //}

        //private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
        //    CellStyle.BackColor = Color.Red;
        //    dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = CellStyle;
        //}


        //public enum Color { Red, Yellow, Blue, Pink, Green, LightBlue }



        //private void gridControl1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{

        //    DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
        //    CellStyle.BackColor = Color.Red;
        //    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = CellStyle;

        //}

        // public event DataGridViewCellEventHandler CellClick;


        //private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        //{

        //    Color c = (Color)(new Random()).Next(0, 3);
        //    switch (c) {
        //        case Color.Beige:
        //            c = Color.Red;
        //            break;
        //        case Color.Red:
        //            c = Color.Yellow;
        //            break;
        //        case Color.Yellow:
        //            c = Color.Blue;
        //            break;
        //        case Color.Blue:
        //            c = Color.Pink;
        //            break;
        //        case Color.Pink:
        //            c = Color.Green;
        //            break;
        //        case Color.Green:
        //            c = Color.LightBlue;
        //            break;
        //        case Color.LightBlue:
        //            c = Color.Red;
        //            break;
        //        default:
        //            c = Color.Red;
        //            break;

        //    }
        //}

        //public Color c = Color.Beige;

        //public enum Color { Beige, Red, Yellow, Green, Blue, Pink, LightBlue }


        //private void gridControl1_Click(object sender, EventArgs e)
        //{

        //    Color c = (Color)(new Random()).Next(0, 3);
        //    switch (c) {
        //        case Color.Beige:
        //            c = Color.Red;
        //            break;
        //        case Color.Red:
        //            c = Color.Yellow;
        //            break;
        //        case Color.Yellow:
        //            c = Color.Blue;
        //            break;
        //        case Color.Blue:
        //            c = Color.Pink;
        //            break;
        //        case Color.Pink:
        //            c = Color.Green;
        //            break;
        //        case Color.Green:
        //            c = Color.LightBlue;
        //            break;
        //        case Color.LightBlue:
        //            c = Color.Red;
        //            break;
        //        default:
        //            c = Color.Red;
        //            break;
        //    }
    }

}

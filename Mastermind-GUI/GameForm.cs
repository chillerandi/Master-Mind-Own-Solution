using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Mastermind_GUI.ViewModels;

namespace MasterMind_GUI
{
    public partial class GameForm : DevExpress.XtraEditors.XtraForm
    {
        Brush[] brushes = new Brush[] { Brushes.Red, Brushes.Yellow, Brushes.Green, Brushes.Pink, Brushes.Blue, Brushes.LightBlue };

        private MouseEventHandler mouseClick;
        private int ClickCount = 0;
        private int RowCount = 0;
        Brush[] UserInput = new Brush[] { };

        GameVM model { get; set; }

        public GameForm(FJ.Interfaces.Factory factory, GameVM gameVM)
        {
            InitializeComponent();
            this.MouseClick += mouseClick;
            gridControl1.DataSource = CreateTable(30);
            model = gameVM;
        }
       
        private DataTable CreateTable(int RowCount)
        {
            // -------------------------Table müsste Teil des VM sein
            // --------------------------BindingList statt DataTable???
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Colour1", typeof(Brush));
            tbl.Columns.Add("Colour2", typeof(Brush));
            tbl.Columns.Add("Colour3", typeof(Brush));
            tbl.Columns.Add("Colour4", typeof(Brush));
            tbl.Columns.Add("Colour5", typeof(Brush));
            tbl.Columns.Add("Colour6", typeof(Brush));
            for (int i = 0; i < RowCount; i++) {
                tbl.Rows.Add(Brushes.LightGray, Brushes.LightGray, Brushes.LightGray, Brushes.LightGray, Brushes.LightGray, Brushes.LightGray);
            }
            return tbl;
        }

        private void gridControl1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            GridView currentView = sender as GridView;
            Rectangle r = e.Bounds;
            var Background = (Brush)currentView.GetRowCellValue(e.RowHandle, e.Column);
            e.Graphics.FillRectangle(Background, r);
            e.Handled = true;
        }

        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            GridControl grid = sender as GridControl;
            if (grid == null) return;
            // Get a View at the current point.
            BaseView view = grid.GetViewAt(e.Location);
            // Retrieve information on the current View element.
            BaseHitInfo baseHI = view.CalcHitInfo(e.Location);
            GridHitInfo gridHI = baseHI as GridHitInfo;
            if (!gridHI.InRowCell) {
                return;
            }
            var index = gridView1.GetDataSourceRowIndex(gridHI.RowHandle);
            var table = grid.DataSource as DataTable; 
            
            // Rows.Getfield routine um zu sehen, welche Farbe gesetzt ist, danach hoch inkrementieren (IndexOf)
                       
            table.Rows[index].SetField(gridHI.Column.AbsoluteIndex, brushes[ClickCount]);
            
            ClickCount++;
            if(ClickCount == 6) { ClickCount = 0; }
        }

        private void ButtonValidate_Click(object sender, EventArgs e)
        {

        }
    }
}



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
using MasterMind_Kernel;

namespace MasterMind_GUI
{
    public partial class GameForm : DevExpress.XtraEditors.XtraForm
    {     
        public GameForm(FJ.Interfaces.Factory factory, GameVM gameVM)
        {
            InitializeComponent();                                  
            model = gameVM;
            model.model.Start(4, 10);
            matcherBindingSource.DataSource = model;
            gridControl1.DataSource = model.CreateTable(10);            
        }

        Brush[] brushes = new Brush[] { Brushes.Red, Brushes.Yellow, Brushes.Green, Brushes.Pink, Brushes.Blue, Brushes.LightBlue };
        //Brush[] UserInput = new Brush[] { };     

        public GameVM model { get; private set; }

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
            var current = table.Rows[index].ItemArray[gridHI.Column.AbsoluteIndex];
            var currentIndex = Array.IndexOf(brushes, current)+1;
            if(currentIndex >= brushes.Length) { currentIndex = 0; }
            table.Rows[index].SetField(gridHI.Column.AbsoluteIndex, brushes[currentIndex]);
        }

        private void ButtonValidate_Click(object sender, EventArgs e)
        {
            model.MakeGuess();           
        }

        private void Button_Red_Click(object sender, EventArgs e)
        {

        }

        
    }
}



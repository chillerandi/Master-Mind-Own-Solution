using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Mastermind_GUI.ViewModels;
using MasterMind_Kernel;
using DevExpress.XtraEditors;

namespace MasterMind_GUI
{
    public partial class GameForm : XtraForm
    {
        public GameForm(GameVM gameVM, GuessViewModel guessViewModel)
        {
            InitializeComponent();
            GuessViewModel_ = guessViewModel;
            model = gameVM;
            model.model.Start(4, 12);
            matcherBindingSource.DataSource = model;
            guessesBindingSource.DataSource = GuessViewModel_.Guesses;
        }

        public GameVM model { get; private set; }
        public int CurrentIndex { get; private set; }
        public GuessViewModel GuessViewModel_ { get; private set; }
        public int[] selectedRow { get; private set; }

        private void gridControl1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            GridView currentView = sender as GridView;
            Rectangle r = e.Bounds;
            var Background = (currentView.GetRowCellValue(e.RowHandle, e.Column)) as Brush;
            if (Background == null) { return; }
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
            if (!gridHI.InRowCell) { return; }
            var index = gridView1.GetDataSourceRowIndex(gridHI.RowHandle);
            var table = grid.DataSource as BindingSource;
            var row = table[index] as RowViewModel;            
            switch (gridHI.Column.AbsoluteIndex) {
                case 0:
                    row.Column1 = GuessViewModel_.brushes[CurrentIndex];
                    break;
                case 1:
                    row.Column2 = GuessViewModel_.brushes[CurrentIndex];
                    break;
                case 2:
                    row.Column3 = GuessViewModel_.brushes[CurrentIndex];
                    break;
                case 3:
                    row.Column4 = GuessViewModel_.brushes[CurrentIndex];
                    break;
            }
        }

        private void ButtonValidate_Click(object sender, EventArgs e)
        {
            GuessViewModel_.MakeGuess(model.model);
            if (model.model.State == Game.GameState.won) { MessageBox.Show("Du hast gewonnen!!!"); }
            if (model.model.State == Game.GameState.lost) { MessageBox.Show("Du hast verloren!!!"); }
        }

        private void ColorButtonClick(object sender, EventArgs e)
        {
            var Button = sender as SimpleButton;
            CurrentIndex = Int32.Parse(Button.Tag.ToString());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }
    }
}



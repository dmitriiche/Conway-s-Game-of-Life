using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class CellGroupModel
    {
		private List<ICellModel> _cells;

		public int CellsCountX = 10;
		public int CellsCountY = 10;

		public List<ICellModel> CellsList
		{
			get { return _cells; }
			set { _cells = value; }
		}

		// Cells map array first item is x coordinate next is y
		private ICellModel[,] Cells; 

        private int _generation;

        public CellGroupModel(int rows, int columns)
        {
			Cells = new CellModel[rows, columns];
			GenerateNewCellsAndNeighbours();
			Generation = 0;
		}

        public int Generation
        {
            get { return _generation; }
            set { _generation = value; }
        }

        private void GenerateNewCellsAndNeighbours()
		{
			Random rnd = new Random();

			for(var y = 0; y < CellsCountY; y++)
			{
				for(var x = 0; x < CellsCountX; x++)
				{
					CellStatus newStastus = (CellStatus)rnd.Next(0, 2);
					ICellModel cell = new CellModel(x, y, newStastus);
					Cells[x, y] = cell;
					CellsList.Append(cell);
				}
			}
			FindNeighbours();
		}

		private void NextStep()
		{
			Generation += 1;

			int unchangedCells = 0;
			int changedCells = 0;
			int aliveCells = 0;
			int emptyCells = 0;

			// Update next status 
			foreach (var cell in _cells)
			{
				int liveNeighbours = cell.Neighbours.Where(item => item.CurrentStatus == CellStatus.Alive).Count();

				switch (cell.CurrentStatus)
				{
					case CellStatus.Alive:
						if (liveNeighbours < 2 || liveNeighbours > 3)
						{
							cell.NextStatus = CellStatus.Death;
						}
						break;
					case CellStatus.Death:
					case CellStatus.Empty:
						if (liveNeighbours == 3)
						{
							cell.NextStatus = CellStatus.Alive;
						}
						break;
				}

				if (cell.NextStatus == CellStatus.Unknown)
                {
					cell.NextStatus = cell.CurrentStatus;
					unchangedCells += 1;
				}
                else
                {
					changedCells += 1;
                }

				switch (cell.NextStatus)
				{
					case CellStatus.Alive:
						aliveCells += 1;
						break;
					case CellStatus.Death:
					case CellStatus.Empty:
						emptyCells += 1;
						break;
				}
			}
		}

		//y
		//3 30 31 32 33
		//2 20 21 22 23
		//1 10 11 12 13
		//0 00 01 02 03
		//  0  1  2  3  x
        private void FindNeighbours()
        {
            for (int y = 0; y < CellsCountY; y++)
            {
                for (int x = 0; x < CellsCountX; x++)
                {
					var cell = Cells[x, y];

					int leftX = (x - 1) < 0 ? CellsCountX - 1 : (x - 1);
					int rightX = (x + 1) >= CellsCountX ? 0 : (x + 1);
					int bottomY = (y - 1) < 0 ? CellsCountY - 1 : (y - 1);
					int topY = (y + 1) >= CellsCountY ? 0 : (y + 1);
					//Left_Bottom 

					cell.Left_Bottom = Cells[leftX, bottomY];
					//Left 
					cell.Left = Cells[leftX, y];
					//  Left_Top 
					cell.Left_Top = Cells[leftX, topY];
					//  Top 
					cell.Top = Cells[x, topY];

					//  Right_Top 
					cell.Right_Top = Cells[rightX, topY];
					//  Right 
					cell.Right_Top = Cells[rightX, y];
					//  Right_Bottom
					cell.Right_Bottom = Cells[rightX, bottomY];
					//	Bottom 
					cell.Bottom = Cells[x, bottomY];
				}	  
            }
        }
    }
}
using System;
using System.Collections.Generic;
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

		public List<ICellModel> Cells
		{
			get { return _cells; }
			set { _cells = value; }
		}

		private void GenerateNewCells()
		{
			Random rnd = new Random();

			for(var x = 0; x < CellsCountX; x++)
			{
				for(var y = 0; y < CellsCountY; y++)
				{
					CellStatus newStastus = (CellStatus)rnd.Next(0, 2);
					ICellModel cell = new CellModel(x, y, newStastus);
				}
			}
		}
    }
}

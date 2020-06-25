using System.Collections.Generic;

namespace GameOfLife
{
    interface ICellModel
    {
        CellStatus CurrentStatus { get; set; }
        CellStatus NextStatus { get; set; }
        int X { get; }
        int Y { get; }
        ICellModel Left_Bottom { get; set; }
        ICellModel Left { get; set; }
        ICellModel Left_Top { get; set; }
        ICellModel Top { get; set; }
        ICellModel Right_Top { get; set; }
        ICellModel Right { get; set; }
        ICellModel Right_Bottom { get; set; }
        ICellModel Bottom { get; set; }
        List<ICellModel> Neighbours { get; }

        void SwapStatus();
    }
}
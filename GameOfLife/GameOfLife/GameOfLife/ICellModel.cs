namespace GameOfLife
{
    interface ICellModel
    {
        CellStatus CurrentStatus { get; set; }
        CellStatus NextStatus { get; set; }
        int X { get; }
        int Y { get; }

        void SwapStatus();
    }
}
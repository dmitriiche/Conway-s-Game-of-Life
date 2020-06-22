
namespace GameOfLife
{
    class CellModel : ICellModel
    {
        public int X { get; }
        public int Y { get; }

        private CellStatus _currentStatus;
        private CellStatus _nextStatus;

        public CellModel(int x, int y, CellStatus currentStatus)
        {
            X = x;
            Y = y;
            CurrentStatus = currentStatus;
        }

        public CellStatus CurrentStatus
        {
            get { return _currentStatus; }
            set { _currentStatus = value; }
        }

        public CellStatus NextStatus
        {
            get { return _nextStatus; }
            set { _nextStatus = value; }
        }

        public void SwapStatus()
        {
            CurrentStatus = NextStatus;
            NextStatus = CellStatus.Unknown;
        }
    }
}

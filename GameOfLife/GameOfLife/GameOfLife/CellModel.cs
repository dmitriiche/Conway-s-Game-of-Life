
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Windows.Documents;

namespace GameOfLife
{
    class CellModel : ICellModel
    {
        public int X { get; }
        public int Y { get; }

        private CellStatus _currentStatus;
        private CellStatus _nextStatus;
        private List<ICellModel> _neighbours;

        public CellModel(int x, int y, CellStatus currentStatus)
        {
            X = x;
            Y = y;
            CurrentStatus = currentStatus;
            Neighbours = new List<ICellModel>
            {
                Left_Bottom,
                Left,
                Left_Top,
                Top,
                Right_Top,
                Right,
                Right_Bottom,
                Bottom
            };
        }

        public List<ICellModel> Neighbours
        {
            get 
            {
                if(_neighbours == null)
                {
                    _neighbours = new List<ICellModel>
                    {
                        Left_Bottom,
                        Left,
                        Left_Top,
                        Top,
                        Right_Top,
                        Right,
                        Right_Bottom,
                        Bottom
                    };
                }
                return _neighbours;
            }
            private set
            {
                _neighbours = value;
            }
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

        public ICellModel Left_Bottom { get; set; }
        public ICellModel Left { get; set; }
        public ICellModel Left_Top { get; set; }
        public ICellModel Top { get; set; }
        public ICellModel Right_Top { get; set; }
        public ICellModel Right { get; set; }
        public ICellModel Right_Bottom { get; set; }
        public ICellModel Bottom { get; set; }
    }
}

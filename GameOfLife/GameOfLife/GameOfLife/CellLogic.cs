using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class CellLogick
    {
        private CellGroupModel _cellGroup;

        public CellGroupModel CellGroup
        {
            get 
            {
                if (_cellGroup == null)
                {
                    _cellGroup = new CellGroupModel();
                }
                return _cellGroup; 
            } 
            set { _cellGroup = value; }
        }

        void nextStep()
        {
            foreach (var cell in collection)
            {

            }
        }
    }
}

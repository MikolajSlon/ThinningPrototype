using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMM
{
    class KMM
    {
        private List<int> _deletionArray = new List<int>() {
            3, 5, 7, 12, 13, 14, 15, 20,
            21, 22, 23, 28, 29, 30, 31, 48,
            52, 53, 54, 55, 56, 60, 61, 62,
            63, 65, 67, 69, 71, 77, 79, 80,
            81, 83, 84, 85, 86, 87, 88, 89,
            91, 92, 93, 94, 95, 97, 99, 101,
            103, 109, 111, 112, 113, 115, 116, 117,
            118, 119, 120, 121, 123, 124, 125, 126,
            127, 131, 133, 135, 141, 143, 149, 151,
            157, 159, 181, 183, 189, 191, 192, 193,
            195, 197, 199, 205, 207, 208, 209, 211,
            212, 213, 214, 215, 216, 217, 219, 220,
            221, 222, 223, 224, 225, 227, 229, 231,
            237, 239, 240, 241, 243, 244, 245, 246,
            247, 248, 249, 251, 252, 253, 254, 255, };
        private List<int> _kernel = new List<int>() {
            128, 1, 2,
            64, 4,
            32, 16, 8 };
        private Bitmap _bmp;

        private NumberList _points;

        public KMM(Bitmap bmp)
        {
            _points = new NumberList();
            _bmp = bmp;
        }

        public Bitmap calculate()
        {
            bool flag = true;
            int previousCycle = -1;
            List<Tuple<int, int>> toDelete = new List<Tuple<int, int>>();
            markBlack();
            while (flag)
            {
                calculateNumberPoints();
                int N = 4;
                foreach (NumberPoint p in _points.getNumbers())
                {
                    if (p.value == N)
                    {
                        if (IsInDeletionArray(p.X, p.Y))
                        {
                            toDelete.Add(new Tuple<int, int>(p.X, p.Y));
                            int index = _points.List.FindIndex(q => q.X == p.X && q.Y == p.Y);
                            _points.List[index].value = 0;
                        }
                        else
                        {
                            int index = _points.List.FindIndex(q => q.X == p.X && q.Y == p.Y);
                            _points.List[index].value = 1;
                        }
                    }
                }
                N = 2;
                foreach (NumberPoint p in _points.getNumbers())
                {
                    if (p.value == N)
                    {
                        if (IsInDeletionArray(p.X, p.Y))
                        {
                            toDelete.Add(new Tuple<int, int>(p.X, p.Y));
                            int index = _points.List.FindIndex(q => q.X == p.X && q.Y == p.Y);
                            _points.List[index].value = 0;
                        }
                        else
                        {
                            int index = _points.List.FindIndex(q => q.X == p.X && q.Y == p.Y);
                            _points.List[index].value = 1;
                        }
                    }
                }
                N = 3;
                foreach (NumberPoint p in _points.getNumbers())
                {
                    if (p.value == N)
                    {
                        if (IsInDeletionArray(p.X, p.Y))
                        {
                            toDelete.Add(new Tuple<int, int>(p.X, p.Y));
                            int index = _points.List.FindIndex(q => q.X == p.X && q.Y == p.Y);
                            _points.List[index].value = 0;
                        }
                        else
                        {
                            int index = _points.List.FindIndex(q => q.X == p.X && q.Y == p.Y);
                            _points.List[index].value = 1;
                        }
                    }
                }
                int numberCount = _points.getNumbers().Count;
                if(previousCycle == numberCount)
                {
                    flag = false;
                }
                else
                {
                    previousCycle = numberCount;
                }
            }
            for (int i = 0; i < _bmp.Width; i++)
            {
                for (int j = 0; j < _bmp.Height; j++)
                {
                    if (_points.List.FirstOrDefault(p => p.X == i && p.Y ==j).value != 0)   //is black
                    {
                        _bmp.SetPixel(i, j, Color.Black);
                    }
                    else
                    {
                        _bmp.SetPixel(i, j, Color.White);
                    }
                }
            }
            return _bmp;
        }
        private void markBlack()
        {
            for (int i = 0; i < _bmp.Width; i++)
            {
                for (int j = 0; j < _bmp.Height; j++)
                {
                    Color newColor = _bmp.GetPixel(i, j);
                    if (newColor == Color.FromArgb(0, 0, 0))   //is black
                    {
                        _points.List.Add(new NumberPoint(i, j, 1));
                    }
                    else
                    {
                        _points.List.Add(new NumberPoint(i, j, 0));

                    }
                }
            }
        }
        private void calculateNumberPoints()
        {
            List<NumberPoint> list = _points.getOnes();
            int i = 0;
            foreach (NumberPoint p in list)
            {
                
                int[] closeNeighbours = _points.getCloseNeighbours(p.X, p.Y);
                int[] cornerNeighbours = _points.getCornerNeighbours(p.X, p.Y);
                int index;
                if (closeNeighbours.Contains(0))
                {
                    index = _points.List.FindIndex(q => q.X == p.X && q.Y == p.Y);
                    _points.List[index].value = 2;
                }else if (cornerNeighbours.Contains(0))
                {
                    index = _points.List.FindIndex(q => q.X == p.X && q.Y == p.Y);
                    _points.List[index].value = 3;
                }
                i++;
            }
            list = _points.getNumbers();
            foreach(NumberPoint p in list)
            {
                if (_points.isFour(p.X, p.Y))
                {
                    int index = _points.List.FindIndex(q => q.X == p.X && q.Y == p.Y);
                    _points.List[index].value = 4;
                }
            }
        }

        private bool IsInDeletionArray(int x, int y)
        {
            int sum = 0; 
            int[] neighbours = _points.getNeighbours(x, y);
            if (neighbours[0] != 0)
            {
                sum += 128;
            }
            if (neighbours[1] != 0)
            {
                sum += 64;
            }
            if (neighbours[2] != 0)
            {
                sum += 32;
            }
            if (neighbours[3] != 0)
            {
                sum += 1;
            }
            if (neighbours[4] != 0)
            {
                sum += 2;
            }
            if (neighbours[5] != 0)
            {
                sum += 4;
            }
            if (neighbours[6] != 0)
            {
                sum += 8;
            }
            if (neighbours[7] != 0)
            {
                sum += 16;
            }
            /*
            sum += (neighbours[1] / neighbours[1]) * 64;
            sum += (neighbours[2] / neighbours[2]) * 32;
            sum += (neighbours[3] / neighbours[3]) * 1;
            sum += (neighbours[4] / neighbours[4]) * 2;
            sum += (neighbours[5] / neighbours[5]) * 4;
            sum += (neighbours[6] / neighbours[6]) * 8;
            sum += (neighbours[7] / neighbours[7]) * 16;
            */        
            if(_deletionArray.Contains(sum))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

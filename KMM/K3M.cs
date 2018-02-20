using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMM
{
    class K3M
    {
        private List<List<int>> _arrays = new List<List<int>>();
        private List<int> _thining = new List<int>() {
            3, 6, 7, 12, 14, 15, 24, 28, 30, 31, 48, 56,
            60, 62, 63, 96, 112, 120, 124, 126, 127, 129, 131,
            135, 143, 159, 191, 192, 193, 195, 199, 207, 223,
            224, 225, 227, 231, 239, 240, 241, 243, 247, 248,
            249, 251, 252, 253, 254};

        List<int> _a0 = new List<int>() {
                3, 6, 7, 12, 14, 15, 24, 28, 30, 31, 48, 56, 60,
                62, 63, 96, 112, 120, 124, 126, 127, 129, 131, 135,
                143, 159, 191, 192, 193, 195, 199, 207, 223, 224,
                225, 227, 231, 239, 240, 241, 243, 247, 248, 249,
                251, 252, 253, 254};
        private List<int> _kernel = new List<int>() {
            128, 1, 2,
            64, 0, 4,
            32, 16, 8 };
        private Bitmap _bmp;

        private NumberList _points;

        public K3M(Bitmap bmp)
        {
            _points = new NumberList();
            _bmp = bmp;
            List<int> a1 = new List<int>() { 7, 14, 28, 56, 112, 131, 193, 224 };
            _arrays.Add(a1);
            List<int> a2 = new List<int>() {
                7, 14, 15, 28, 30, 56, 60, 112, 120, 131, 135,
                193, 195, 224, 225, 240};
            _arrays.Add(a2);
            List<int> a3 = new List<int>() {
                7, 14, 15, 28, 30, 31, 56, 60, 62, 112, 120,
                124, 131, 135, 143, 193, 195, 199, 224, 225, 227,
                240, 241, 248};
            _arrays.Add(a3);
            List<int> a4 = new List<int>() {
                7, 14, 15, 28, 30, 31, 56, 60, 62, 63, 112, 120,
                124, 126, 131, 135, 143, 159, 193, 195, 199, 207,
                224, 225, 227, 231, 240, 241, 243, 248, 249, 252};            _arrays.Add(a4);
            List<int> a5 = new List<int>()
            { 7, 14, 15, 28, 30, 31, 56, 60, 62, 63, 112, 120,
            124, 126, 131, 135, 143, 159, 191, 193, 195, 199,
            207, 224, 225, 227, 231, 239, 240, 241, 243, 248,
            249, 251, 252, 254};
            _arrays.Add(a5);
        }

        public Bitmap calculate()
        {
            bool flag = true;
            int count = -1;
            markBlack();
            while (flag)
            {
                F1();
                Phases();
                if(count == _points.List.Count)
                {
                    flag = false;
                }
                else
                {
                    count = _points.List.Count;
                }
            }
            Thining();
            for (int i = 0; i < _bmp.Width; i++)
            {
                for (int j = 0; j < _bmp.Height; j++)
                {
                    if (_points.List.FirstOrDefault(p => p.X == i && p.Y == j).value != 0)   //is black
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

        private void F1()
        {
            int index;
            List<NumberPoint> list = _points.getOnes();
            foreach (NumberPoint p in list)
            {
                int[] neighbours = _points.K3MNeighbours(p.X, p.Y);
                int sum = calculateWeight(neighbours);
                if(_a0.Contains(sum))
                {
                    // mark as border
                    index = _points.List.FindIndex(q => q.X == p.X && q.Y == p.Y);
                    _points.List[index].value = 2;
                }
            }
        }

        private void Phases()
        {
            int index;
            foreach(List<int> table in _arrays)
            {
                List<NumberPoint> list = _points.getTwos();
                foreach(NumberPoint p in list)
                {
                    int[] neighbours = _points.K3MNeighbours(p.X, p.Y);
                    int sum = calculateWeight(neighbours);
                    if(table.Contains(sum))
                    {
                        //remove
                        index = _points.List.FindIndex(q => q.X == p.X && q.Y == p.Y);
                        _points.List[index].value = 0;
                    }
                }
            }
        }

        private void Thining()
        {
            int index;
            List<NumberPoint> list = _points.getNumbers();
            foreach (NumberPoint p in list)
            {
                int[] neighbours = _points.K3MNeighbours(p.X, p.Y);
                int sum = calculateWeight(neighbours);
                if (_thining.Contains(sum))
                {
                    //remove
                    index = _points.List.FindIndex(q => q.X == p.X && q.Y == p.Y);
                    _points.List[index].value = 0;
                }
            }
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
        private int calculateWeight(int[] neighbours)
        {
            int sum = 0;
            for(int i = 0; i < _kernel.Count; i++)
            {
                sum += neighbours[i] * _kernel[i];
            }
            return sum;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMM
{
    class NumberList
    {
        public NumberList(List<NumberPoint> list)
        {
            List = list;
        }
        public NumberList()
        {
            List = new List<NumberPoint>();
        }

        public List<NumberPoint> List { get; set; }

        public List<NumberPoint> getNumbers()
        {
            IEnumerable<NumberPoint> collection = List.Where(p => p.value != 0);
            List<NumberPoint> list = collection.ToList<NumberPoint>();
            return list;
        }
        public List<NumberPoint> getOnes()
        {
            IEnumerable<NumberPoint> collection = List.Where(p => p.value == 1);
            List<NumberPoint> list = collection.ToList<NumberPoint>();
            return list;
        }
        public List<NumberPoint> getTwos()
        {
            IEnumerable<NumberPoint> collection = List.Where(p => p.value == 2);
            List<NumberPoint> list = collection.ToList<NumberPoint>();
            return list;
        }
        public int[] getNeighbours(int x, int y)
        {
            int[] neighbours = new int[8];
            try
            {
                neighbours[0] = List.FirstOrDefault(p => p.X == (x - 1) && p.Y == (y-1)).value;
            }
            catch
            {
                neighbours[0] = 0;
            }
            try
            {
                neighbours[1] = List.FirstOrDefault(p => p.X == (x - 1) && p.Y == (y)).value;
            }
            catch
            {
                neighbours[1] = 0;
            }
            try
            {
                neighbours[2] = List.FirstOrDefault(p => p.X == (x - 1) && p.Y == (y + 1)).value;
            }
            catch
            {
                neighbours[2] = 0;
            }
            try
            {
                neighbours[3] = List.FirstOrDefault(p => p.X == (x) && p.Y == (y - 1)).value;
            }
            catch
            {
                neighbours[3] = 0;
            }
            try
            {
                neighbours[4] = List.FirstOrDefault(p => p.X == (x + 1) && p.Y == (y - 1)).value;
            }
            catch
            {
                neighbours[4] = 0;
            }
            try
            {
                neighbours[5] = List.FirstOrDefault(p => p.X == (x + 1) && p.Y == (y)).value;
            }
            catch
            {
                neighbours[5] = 0;
            }
            try
            {
                neighbours[6] = List.FirstOrDefault(p => p.X == (x + 1) && p.Y == (y + 1)).value;
            }
            catch
            {
                neighbours[6] = 0;
            }
            try
            {
                neighbours[7] = List.FirstOrDefault(p => p.X == (x) && p.Y == (y + 1)).value;
            }
            catch
            {
                neighbours[7] = 0;
            }
            /*
            neighbours[0] = List.FirstOrDefault(p => p.X == (x - 1) && p.Y == (y-1)).value;
            neighbours[1] = List.FirstOrDefault(p => p.X == (x - 1) && p.Y == (y)).value;
            neighbours[2] = List.FirstOrDefault(p => p.X == (x - 1) && p.Y == (y + 1)).value;
            neighbours[3] = List.FirstOrDefault(p => p.X == (x) && p.Y == (y - 1)).value;
            neighbours[4] = List.FirstOrDefault(p => p.X == (x + 1) && p.Y == (y - 1)).value;
            neighbours[5] = List.FirstOrDefault(p => p.X == (x + 1) && p.Y == (y)).value;
            neighbours[6] = List.FirstOrDefault(p => p.X == (x + 1) && p.Y == (y + 1)).value;
            neighbours[7] = List.FirstOrDefault(p => p.X == (x) && p.Y == (y + 1)).value;
            */        
            return neighbours;
        }
        public int[] getCloseNeighbours(int x, int y)
        {
            int[] neighbours = new int[4];
            try {
                neighbours[0] = List.FirstOrDefault(p => p.X == (x - 1) && p.Y == (y)).value;
            }
            catch {
                neighbours[0] = 0;
            }
            try
            {
                neighbours[1] = List.FirstOrDefault(p => p.X == (x) && p.Y == (y - 1)).value;
            }
            catch
            {
                neighbours[1] = 0;
            }
            try
            {
                neighbours[2] = List.FirstOrDefault(p => p.X == (x + 1) && p.Y == (y)).value;
            }
            catch
            {
                neighbours[2] = 0;
            }
            try
            {
                neighbours[3] = List.FirstOrDefault(p => p.X == (x) && p.Y == (y + 1)).value;
            }
            catch
            {
                neighbours[3] = 0;
            }
            return neighbours;
        }
        public int[] getCornerNeighbours(int x, int y)
        {
            int[] neighbours = new int[4];
            try
            {
                neighbours[0] = List.FirstOrDefault(p => p.X == (x - 1) && p.Y == (y - 1)).value;
            }
            catch
            {
                neighbours[0] = 0;
            }
            try
            {
                neighbours[1] = List.FirstOrDefault(p => p.X == (x - 1) && p.Y == (y + 1)).value;
            }
            catch
            {
                neighbours[1] = 0;
            }
            try
            {
                neighbours[2] = List.FirstOrDefault(p => p.X == (x + 1) && p.Y == (y - 1)).value;
            }
            catch
            {
                neighbours[2] = 0;
            }
            try
            {
                neighbours[3] = List.FirstOrDefault(p => p.X == (x + 1) && p.Y == (y + 1)).value;
            }
            catch
            {
                neighbours[3] = 0;
            }
            return neighbours;
        }

        public bool isFour(int x, int y)
        {
            int count = 0;
            int[] neighbours = getNeighbours(x, y);
            for(int i  =0; i < 8; i++)
            {
                if(neighbours[i] != 0)
                {
                    count++;
                }
            }
            if(count >= 2 && count <=4)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public int[] K3MNeighbours(int x, int y)
        {
            int[] neighbours = new int[9];
            NumberPoint point = List.FirstOrDefault(p => p.X == (x - 1) && p.Y == (y - 1));
            if(point != null)
            {
                if(point.value != 0)
                {
                    neighbours[0] = 1;
                }
                else
                {
                    neighbours[0] = 0;
                }
            }
            else
            {
                neighbours[0] = 0;
            }
            point = List.FirstOrDefault(p => p.X == (x) && p.Y == (y - 1));
            if (point != null)
            {
                if (point.value != 0)
                {
                    neighbours[1] = 1;
                }
                else
                {
                    neighbours[1] = 0;
                }
            }
            else
            {
                neighbours[1] = 0;
            }
            point = List.FirstOrDefault(p => p.X == (x+1) && p.Y == (y - 1));
            if (point != null)
            {
                if (point.value != 0)
                {
                    neighbours[2] = 1;
                }
                else
                {
                    neighbours[2] = 0;
                }
            }
            else
            {
                neighbours[2] = 0;
            }
            point = List.FirstOrDefault(p => p.X == (x - 1) && p.Y == (y));
            if (point != null)
            {
                if (point.value != 0)
                {
                    neighbours[3] = 1;
                }
                else
                {
                    neighbours[3] = 0;
                }
            }
            else
            {
                neighbours[3] = 0;
            }
            point = List.FirstOrDefault(p => p.X == (x) && p.Y == (y));
            if (point != null)
            {
                if (point.value != 0)
                {
                    neighbours[4] = 1;
                }
                else
                {
                    neighbours[4] = 0;
                }
            }
            else
            {
                neighbours[4] = 0;
            }
            point = List.FirstOrDefault(p => p.X == (x + 1) && p.Y == (y));
            if (point != null)
            {
                if (point.value != 0)
                {
                    neighbours[5] = 1;
                }
                else
                {
                    neighbours[5] = 0;
                }
            }
            else
            {
                neighbours[5] = 0;
            }
            point = List.FirstOrDefault(p => p.X == (x - 1) && p.Y == (y + 1));
            if (point != null)
            {
                if (point.value != 0)
                {
                    neighbours[6] = 1;
                }
                else
                {
                    neighbours[6] = 0;
                }
            }
            else
            {
                neighbours[6] = 0;
            }
            point = List.FirstOrDefault(p => p.X == (x) && p.Y == (y + 1));
            if (point != null)
            {
                if (point.value != 0)
                {
                    neighbours[7] = 1;
                }
                else
                {
                    neighbours[7] = 0;
                }
            }
            else
            {
                neighbours[7] = 0;
            }
            point = List.FirstOrDefault(p => p.X == (x + 1) && p.Y == (y + 1));
            if (point != null)
            {
                if (point.value != 0)
                {
                    neighbours[8] = 1;
                }
                else
                {
                    neighbours[8] = 0;
                }
            }
            else
            {
                neighbours[8] = 0;
            }
            return neighbours;
        }
    }
}

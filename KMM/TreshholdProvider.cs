using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMM
{
    public class TreshholdProvider
    {
        const int MIN = 0;
        const int MAX = 255;
        List<int> intervals;
        List<double> intervalTreshholds;
        double treshold;
        public TreshholdProvider(int k, double treshold = 120)
        {
            intervals = new List<int>();
            this.treshold = treshold;
            for (int i =0; i< k +1; i++)
            {
                intervals.Add((i * MAX) / (k - 1));
            }
        }

        public Color processPixel(Color pixel)
        {
            int pixelValue = ToGrayscale(pixel);
            int intervalNumber = (pixelValue * (intervals.Count - 1)) / MAX;
            if(intervalNumber == (intervals.Count -1))
            {
                intervalNumber -= 1;
            }
            int tresholdNumber = intervals[intervalNumber] + Convert.ToInt32( treshold * (Convert.ToDouble(intervals[intervalNumber + 1] - intervals[intervalNumber])));
            int choosenInterval;
            if (pixelValue >= tresholdNumber)
            {
                choosenInterval = intervals[intervalNumber + 1];
            }
            else
            {
                choosenInterval = intervals[intervalNumber];
            }
            Color returnValue = Color.FromArgb(choosenInterval, choosenInterval, choosenInterval);
            return returnValue;
        }

        public Color processPixelAverageDithering(Color pixel)
        {
            int pixelValue = ToGrayscale(pixel);
            int intervalNumber = (pixelValue * (intervals.Count - 1)) / MAX;
            if (intervalNumber == (intervals.Count - 1))
            {
                intervalNumber -= 1;
            }
            int tresholdNumber = intervals[intervalNumber] + Convert.ToInt32(intervalTreshholds[intervalNumber] * (Convert.ToDouble(intervals[intervalNumber + 1] - intervals[intervalNumber])));
            int choosenInterval;
            if (pixelValue >= tresholdNumber)
            {
                choosenInterval = intervals[intervalNumber + 1];
            }
            else
            {
                choosenInterval = intervals[intervalNumber];
            }
            Color returnValue = Color.FromArgb(choosenInterval, choosenInterval, choosenInterval);
            return returnValue;
        }
        private int ToGrayscale(Color color)
        {
            return Convert.ToInt32(color.R * 0.3 + color.G * 0.58 + 0.12 * color.B);
        }

        public void calCulateTresholds(Bitmap bmp)
        {
            Dictionary<int, List<int>> grouped = new Dictionary<int, List<int>>();
            intervalTreshholds = new List<double>();
            for(int i =0; i< intervals.Count; i++)
            {
                grouped.Add(i, new List<int>());
            }
            for(int i = 0; i < bmp.Width; i++)
            {
                for(int j = 0; j< bmp.Height; j++)
                {
                    Color pixel = bmp.GetPixel(i,j);
                    int pixelValue = ToGrayscale(pixel);
                    int intervalNumber = (pixelValue * (intervals.Count - 1)) / MAX;
                    if (intervalNumber == (intervals.Count - 1))
                    {
                        intervalNumber -= 1;
                    }
                    grouped[intervalNumber].Add(pixelValue);
                }
            }
            for(int i =0; i< grouped.Count; i++)
            {

                List<int> list = grouped[i];
                if (list.Count != 0)
                {
                    double av = grouped[i].Average();
                    intervalTreshholds.Add(av);
                }else
                {
                    intervalTreshholds.Add(0);
                }

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMM
{
    public class BindableMap : INotifyPropertyChanged
    {
        private Bitmap bitmap;

        public BindableMap()
        {
            bitmap = new Bitmap(1,1);
        }
        public Bitmap Bitmap
        {
            get { return bitmap; }
            set
            {
                bitmap = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("FirstName"));
            }
        }

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }

        #endregion
    }
}

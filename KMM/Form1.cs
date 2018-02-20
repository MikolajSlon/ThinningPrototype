using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMM
{
    public partial class Form1 : Form
    {
        BindableMap bindPictureBefore;
        BindableMap bindPictureAfter;

        public Form1()
        {
            InitializeComponent();
        }

        private void kmmButton_Click(object sender, EventArgs e)
        {
            Information.Text = "Calculating please wait";
            Information.ForeColor = Color.Red;
            Information.Refresh();
            applyTreshhold(2, 0.5);
            KMM kmm = new KMM(bindPictureAfter.Bitmap);
            Bitmap bmp = kmm.calculate();
            bindPictureAfter.Bitmap = new Bitmap(bmp);
            pictureAfter.Image = bindPictureAfter.Bitmap;
            Information.Text = "Waiting for input";
            Information.ForeColor = Color.Black;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                bindPictureBefore = new BindableMap();
                bindPictureAfter = new BindableMap();
                Bitmap bmp = new Bitmap(dlg.FileName);
                bindPictureBefore.Bitmap = new Bitmap(bmp, pictureBefore.Size);
                bindPictureAfter.Bitmap = new Bitmap(bmp, pictureAfter.Size);
                bindPictureAfter.Bitmap = new Bitmap(bmp);
                bindPictureBefore.Bitmap = new Bitmap(bmp);

                pictureAfter.Image = bindPictureAfter.Bitmap;
                pictureBefore.Image = bindPictureBefore.Bitmap;
            }
            dlg.Dispose();
        }

        private void applyTreshhold(int k, double t)
        {
            TreshholdProvider treshhold = new TreshholdProvider(k, t);
            for (int i = 0; i < bindPictureBefore.Bitmap.Width; i++)
            {
                for (int j = 0; j < bindPictureBefore.Bitmap.Height; j++)
                {
                    Color newColor = bindPictureBefore.Bitmap.GetPixel(i, j);
                    newColor = treshhold.processPixel(newColor);
                    bindPictureAfter.Bitmap.SetPixel(i, j, newColor);
                }
            }
            pictureAfter.Refresh();
        }

        private void k3mButton_Click(object sender, EventArgs e)
        {
            Information.Text = "Calculating please wait";
            Information.ForeColor = Color.Red;
            Information.Refresh();
            applyTreshhold(2, 0.5);
            K3M k3m = new K3M(bindPictureAfter.Bitmap);
            Bitmap bmp = k3m.calculate();
            bindPictureAfter.Bitmap = new Bitmap(bmp);
            pictureAfter.Image = bindPictureAfter.Bitmap;
            Information.ForeColor = Color.Black;
            Information.Text = "Waiting for input";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

       public string[] images = {"https://cdn.pcwallart.com/images/beautiful-nature-animals-wallpaper-3.jpg",
                               "https://cdn.allwallpaper.in/wallpapers/1920x1080/185/animals-nature-tigers-widescreen-wild-1920x1080-wallpaper.jpg",
                              "https://cdn.pcwallart.com/images/beautiful-nature-animals-wallpaper-3.jpg",
                              "https://cdn.pcwallart.com/images/beautiful-nature-animals-wallpaper-3.jpg",
                              "https://cdn.pcwallart.com/images/beautiful-nature-animals-wallpaper-3.jpg",
                              "https://cdn.pcwallart.com/images/beautiful-nature-animals-wallpaper-3.jpg",
                              "https://cdn.pcwallart.com/images/beautiful-nature-animals-wallpaper-3.jpg",
                              "https://cdn.pcwallart.com/images/beautiful-nature-animals-wallpaper-3.jpg",
                              "https://cdn.pcwallart.com/images/beautiful-nature-animals-wallpaper-3.jpg",
                               "https://cdn.pcwallart.com/images/beautiful-nature-animals-wallpaper-3.jpg"};

       int count = 0;
       System.Timers.Timer timer;
       int x = 20, y = 20, maxHeight = -1;
       PictureBox picbx;
       List<PictureBox> picboxList = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
            pulser(11);
            timer = new System.Timers.Timer();
            timer.Interval = 500;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
         
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
            var str = images[count];
            count = count + 1;
            pulse(str,count);
            if (count == 10)
            {
                timer.Stop();
            }

        }

        public void pulse(string imgine,int i)
        {

            picboxList[i].Image = Image.FromFile("D:/238850_700b.jpg");
            picboxList[i].ErrorImage = Image.FromFile("D:/loading.gif");
            picboxList[i].InitialImage = Image.FromFile("D:/loading.gif");
            picboxList[i].BackgroundImage = Image.FromFile("D:/loading.gif");
          
        }



        public void pulser(int count)
        {

            for (int i = 0; i < count; i++)
            {
                picbx = new PictureBox();
                picbx.Image = Image.FromFile("D:/loading.gif");
                picbx.ErrorImage = Image.FromFile("D:/loading.gif");
                picbx.Location = new Point(x, y);
                picbx.SizeMode = PictureBoxSizeMode.StretchImage;
                picbx.InitialImage = Image.FromFile("D:/loading.gif");
                picboxList.Add(picbx);
                x += picbx.Width + 10;
                maxHeight = Math.Max(picbx.Height, maxHeight);
                if (x > this.ClientSize.Width - 100)
                {
                    x = 20;
                    y += maxHeight + 10;
                }

                //flowLayoutPanel1.Invoke((MethodInvoker)delegate
                //{
                    this.flowLayoutPanel1.Controls.Add(picbx);
                    this.flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
                    this.flowLayoutPanel1.WrapContents = true;
                    this.flowLayoutPanel1.AutoScroll = true;
                    //var size = this.flowLayoutPanel1.Size;
                    //System.Drawing.Size s = new Size(size.Height+100,size.Width+100);
                    //    this.flowLayoutPanel1.Size=s; 

                //});
            }
             


        }




        //private Image LoadImage(string url)
        //{
        //    System.Net.WebRequest request =
        //        System.Net.WebRequest.Create(url);

        //    System.Net.WebResponse response = request.GetResponse();
        //    System.IO.Stream responseStream =
        //        response.GetResponseStream();

        //    Bitmap bmp = new Bitmap(responseStream);

        //    responseStream.Dispose();

        //    return bmp;
        //}

        //public async Task<Image> LongRunningOperation(string s)
        //{
        //    await Task.Delay(10); //1 seconds delay
        //    return LoadImage(s);
        //}
    }
}

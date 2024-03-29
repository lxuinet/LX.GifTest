﻿using LX;

namespace LX.GifTest
{
    class Program
    {
        static void Main(string[] args)
        {
            App.OnRun += delegate
            {
                var pictureBox = new PictureBox();

                // Color(0, 51, 102, 255) - gif background color
                pictureBox.Image = Image.LoadFromResource("*.cat.gif", new Color(0, 51, 102, 255));
                pictureBox.AddToRoot(Alignment.Fill);

                // play animation, you can create 
                pictureBox.Play();

                // You can create your own animation by simply adding frames to any image (Image.Frames)
                // and setting the intervals for playing frames (Image.Delay)

                var timerBox = new Label();
                timerBox.Font = new Font("OpenSans-Bold.ttf", 200, 0, 0);
                timerBox.AddTo(pictureBox, Alignment.TopRight);

                // change back color every 5 seconds
                pictureBox.StartTimer().Tick += (object sender, Timer e) =>
                {
                    var total = (int)e.TotalElapsed.TotalSeconds - ((int)e.TotalElapsed.TotalSeconds / 10) * 10;
                    pictureBox.Color = total < 5 ? Color.White : Color.Black;
                    timerBox.Text = (total < 5 ? 5 - total : 10 - total).ToString();
                };
            };
            App.Run();
        }
    }
}

using LX;

namespace LX.GifTest
{
    class Program
    {
        static void Main(string[] args)
        {
            App.OnRun += delegate
            {
                var pictureBox = new PictureBox();
                pictureBox.Image = Image.LoadFromResource("*.cat.gif", new Color(0, 51, 102, 255));
                pictureBox.AddToRoot(Alignment.Fill);
                pictureBox.Play();

                // change back color every 5 seconds
                pictureBox.StartTimer().Tick += (object sender, Timer e) =>
                {
                    var total = (int)e.TotalElapsed.TotalSeconds - ((int)e.TotalElapsed.TotalSeconds / 10) * 10;
                    pictureBox.Color = total < 5 ? Color.White : Color.Black;
                };
            };
            App.Run();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame
{
    class Star2 : BaseObject
    {
        public Star2(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }


        public override void Draw()
        {
            Image image = AsteroidGame.Properties.Resources.Star;
            SplashScreen.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }


        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = SplashScreen.Widht + Size.Width;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame
{
    class Base1 : BaseObject
    {

        public Base1(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            //Рисуем круг используя картинку
            Image image = AsteroidGame.Properties.Resources.Ellipse;
            SplashScreen.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);

        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > SplashScreen.Widht) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > SplashScreen.Height) Dir.Y = -Dir.Y;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace AsteroidGame
{
    public class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;

        }
        public virtual void Draw()
        {
            //Рисуем круг используя картинку
            Image image = AsteroidGame.Properties.Resources.Ellipse;
            SplashScreen.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
            // Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
            //Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Widht - Size.Width * 2) Dir.X = -Dir.X;
            if (Pos.X > SplashScreen.Widht - Size.Width * 2) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height - Size.Height * 2) Dir.Y = -Dir.Y;
            if (Pos.Y > SplashScreen.Height - Size.Height * 2) Dir.Y = -Dir.Y;
        }
    }
}

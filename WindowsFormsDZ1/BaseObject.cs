using System;
using System.Drawing;
/// <summary>
/// Гаврилов В. А.
/// </summary>
namespace Asteroids
{
    class BaseObject
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
            //Game.Buffer.Graphics.DrawEllipse(Pens.Red, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(Image.FromFile(@"C:\Users\00000\source\repos\WindowsFormsDZ1\WindowsFormsDZ1\asteroid50.png"), Pos.X, Pos.Y, Size.Width, Size.Height);

        }
        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawImage(Image.FromFile(@"C:\Users\00000\source\repos\WindowsFormsDZ1\WindowsFormsDZ1\star50.png"), Pos.X, Pos.Y, Size.Width, Size.Height);

        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
            }
        }
    }
    class Fire : BaseObject
    {
        public Fire(Point pos, Point dir, Size size):base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image.FromFile(@"C:\Users\00000\source\repos\WindowsFormsDZ1\WindowsFormsDZ1\fire50.png"), Pos.X, Pos.Y, Size.Width, Size.Height);
        }

    }
    class Corabl : BaseObject
    {
        public Corabl(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image.FromFile(@"C:\Users\00000\source\repos\WindowsFormsDZ1\WindowsFormsDZ1\corabl100.png"), Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X >= Game.Width / 8) Dir.X = -Dir.X;
            if (Pos.X <= Game.Width/10) Dir.X = -Dir.X;

        }
    }
}
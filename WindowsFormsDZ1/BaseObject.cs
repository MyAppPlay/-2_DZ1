using System;
using System.Drawing;
/// <summary>
/// Гаврилов В. А.
/// </summary>
namespace Asteroids
{
    abstract class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public abstract void Draw();

        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }

    class Asteroid : BaseObject
    {
        /// <summary>
        /// Класс описывающий, поведение астероидов
        /// </summary>
        Image asteroid;
        public int Power { get; set; }

        public Asteroid(Point pos, Point dir, Size size): base(pos, dir, size)
        {
            asteroid = Image.FromFile("asteroid50.png");
            Power = 1;
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(asteroid, Pos.X, Pos.Y, Size.Width, Size.Height);

        }
        public override void Update()
        {
            base.Update();
        }
    }
    
    class Bullet : BaseObject
    {
        /// <summary>
        /// Класс, описывающий поведение пули
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + 3;
        }
    }
    class Star : BaseObject
    {
        Image star;
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            star = Image.FromFile("star50.png");
        }
        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawImage(star, Pos.X, Pos.Y, Size.Width, Size.Height);

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
        Image fire;
        public Fire(Point pos, Point dir, Size size):base(pos, dir, size)
        {
            fire = Image.FromFile("fire50.png");
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(fire, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

    }
    class Corabl : BaseObject
    {
        Image corabl;
        public Corabl(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            corabl = Image.FromFile("corabl100.png");
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(corabl, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X >= Game.Width / 8) Dir.X = -Dir.X;
            if (Pos.X <= Game.Width/10) Dir.X = -Dir.X;

        }
    }
}
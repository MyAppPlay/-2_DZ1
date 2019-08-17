using System;
using System.Windows.Forms;
using System.Drawing;
/// <summary>
/// Гаврилов В. А.
/// </summary> 
/// 
namespace Asteroids
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static Image cosmos;

        private static Bullet _bullet;
        private static Asteroid[] _asteroids;
        private static Fire[] _fires;
        public static BaseObject[] _objs;
        private static Star[] _stars;

        static Game()
        {
            
        }
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            cosmos = Image.FromFile("cosmos.jpg");
            

           Load();

            Timer timer = new Timer { Interval = 60 };
            timer.Start();
            timer.Tick += Timer_Tick; ;

        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
        public static void Draw()
        {
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Blue);
            //Buffer.Graphics.DrawRectangle(Pens.Red, new Rectangle(50, 50, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 150, 150));
            //Buffer.Render();

            //Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(cosmos, 0, 0, Game.Width, Game.Height);

            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }
            Buffer.Render();
        }


        public static void Load()
        {
            //int b = 5;
            Random rand = new Random();
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _fires = new Fire[10];
            _asteroids = new Asteroid[3];
            _stars = new Star[100];
            _objs = new BaseObject[40];

            for (int i = 0; i < _objs.Length; i++)
            {
                int r = rand.Next(5, 50);
                _objs[i] = new Star(new Point(1000, rand.Next(0, Height)), new Point(-r, r), new Size(5, 5));
                //_objs[i] = new Asteroid(new Point(1000, rand.Next(0, Height)), new Point(-r, r), new Size(50, 50));
            }
            for (int a = 0; a < _asteroids.Length; a++)
            {
                int c = rand.Next(5, 50);
                _asteroids[a] = new Asteroid(new Point(1000, rand.Next(0, Height)), new Point(-1, 1), new Size(50, 50));
            }
            //for (int i = 0; i < _fires.Length; i++)
            //{
            //    _fires[i] = new Fire(new Point(1000, rand.Next(0, Height)), new Point(-1, 1), new Size(100, 100));
            //}
            //for(int i = 0; i < _stars.Length;i++)
            //{
            //    new Star(new Point(1000, rand.Next(0, Height)), new Point(-1, 1), new Size(5, 5));
            //}


        }

    }
}

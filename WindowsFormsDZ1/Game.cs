using System;
using System.Windows.Forms;
using System.Drawing;
/// <summary>
/// Гаврилов В. А.
/// </summary> 
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
        public static BaseObject[] _objs;
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

            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(Image.FromFile(@"C:\Users\00000\source\repos\WindowsFormsDZ1\WindowsFormsDZ1\cosmos.jpg"), 0, 0, Game.Width, Game.Height); 

            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }
            
                Buffer.Render();
        }


        public static void Load()
        {
            int a = 5;       //Переменная для определения координаты 
            int b = 5;
            Random rand = new Random();

            
                _objs = new BaseObject[40];
            for (int i = 0; i < _objs.Length/2; i++)
            {
                if (i % 2 == 0)
                {
                    int c = rand.Next(Game.Height); //Случайные координаты
                    int d = rand.Next(Game.Width);

                    _objs[i] = new BaseObject(new Point(d, c), new Point(-i + 5, -i + 3), new Size(50, 50));
                    b += Game.Width / (_objs.Length / 2);
                }
                else
                {
            int c = rand.Next(Game.Height); //Случайные координаты
            int d = rand.Next(Game.Width);

                    _objs[i] = new Fire(new Point(600, b), new Point(c/a/2, i), new Size(20, 20));
                }

            }
            for (int i = _objs.Length / 2; i < _objs.Length; i++)
            {
                int c = rand.Next(Game.Height); //Случайные координаты
                int d = rand.Next(Game.Width);
                if (i % 2 == 0)
                {
                    _objs[i] = new Star(new Point(c, i+a), new Point(-i + c / 100, 0), new Size(10, 10));
                    a += Game.Width / (_objs.Length / 2);
                }
                else if(i==_objs.Length-1)
                {
                    
                 _objs[i] = new Corabl(new Point(100, Game.Height/2), new Point(1, 0), new Size(150, 50));

                }
                 else   _objs[i] = new Star(new Point(d, c), new Point(-i + c / 50, 0), new Size(15, 15));

            }


        }
        
    }
}

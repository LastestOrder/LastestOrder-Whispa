using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidGame
{
    class SplashScreen
    {

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Widht { get; set; }
        public static int Height { get; set; }
        static SplashScreen()
        {
        }
        public static void Init(Form form)
        {

            //Графическое устройство для вывода графики
            Graphics gr;
            //Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            gr = form.CreateGraphics();
            //Создаем объект (поверхность рисования) и связываем его с формой
            //Запоминаем размеры формы
            Widht = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            //Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(gr, new Rectangle(0, 0, Widht, Height));
            Start(form);
            Records(form);
            Exit(form);
            Load();
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;


        }
        public static void Start(Form form)
        {

            Button start = new Button();

            //start.Size = new Size(125, 32);
            start.Height = 50;
            start.Width = 150;
            start.Name = "Start";
            start.Visible = true;
            start.Location = new Point(100, 100);
            //start.Location = new Point(Widht / 2 - start.Size.Width, Height / 2 - start.Size.Height);
            start.TabIndex = 0;
            start.Text = "Start Game";
            start.BackColor = Color.Black;
            start.ForeColor = Color.White;
            //start.UseVisualStyleBackColor = true;
            //start.Click += new EventHandler(Start_Click);
            form.Controls.Add(start);

        }
        public void Start_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Click me again.  That felt good.");
            //Buffer.Graphics.Clear(Color.Black);
            //Game.Init(form);
            //form.Show();
            //Game.Draw();
        }
        public static void Records(Form form)
        {

            Button records = new Button();

            //start.Size = new Size(125, 32);
            records.Height = 50;
            records.Width = 150;
            records.Name = "Records";
            records.Visible = true;
            records.Location = new Point(100, 200);
            //start.Location = new Point(Widht / 2 - start.Size.Width, Height / 2 - start.Size.Height);
            records.TabIndex = 1;
            records.Text = "Records";
            records.BackColor = Color.Black;
            records.ForeColor = Color.White;
            //start.UseVisualStyleBackColor = true;

            form.Controls.Add(records);

        }
        public static void Exit(Form form)
        {

            Button exit = new Button();

            //start.Size = new Size(125, 32);
            exit.Height = 50;
            exit.Width = 150;
            exit.Name = "Exit";
            exit.Visible = true;
            exit.Location = new Point(100, 300);
            //start.Location = new Point(Widht / 2 - start.Size.Width, Height / 2 - start.Size.Height);
            exit.TabIndex = 2;
            exit.Text = "Exit Game";
            exit.BackColor = Color.Black;
            exit.ForeColor = Color.White;
            //start.UseVisualStyleBackColor = true;

            form.Controls.Add(exit);

        }
        private static void Timer_Tick(object sender, EventArgs s)
        {
            Draw();
            Update();
        }

        public static BaseObject[] _objs;
        public static void Load()
        {
            _objs = new BaseObject[40];
            for (int i = 0; i < _objs.Length / 2; i++)
                _objs[i] = new Base1(new Point(600, i * 20), new Point(-i, 20), new Size(10, 10));
            for (int i = _objs.Length / 2; i < _objs.Length; i++)
                _objs[i] = new Star2(new Point(600, (_objs.Length - i) * 20), new Point(-i, 0), new Size(5, 5));
        }

        public static void Draw()
        {

            // проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
    }
}

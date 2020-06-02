using System;

namespace Фоновая_5._1
{

    class Triangle
    {
        protected int a;
        protected int b;
        protected double beta;
        public Triangle()
        {
            a = 15;
            b = 4;
            beta = 60;
        }
        public Triangle(int a, int b, double beta)
        {
            this.a = a;
            this.b = b;
            this.beta = beta;
        }
        public virtual int atr
        {
            get { return a; }
            set
            {
                a = value;
                Console.WriteLine("a = {0}", a);
            }
        }
        public virtual int btr
        {
            get { return b; }
            set
            {
                b = value;
            }
        }
        public virtual double betatr
        {
            get { return beta; }
            set
            {
                try
                {
                    beta = value;
                }
                catch
                {
                    Console.WriteLine("...Изменения не внесены. Вы осуществили неправльный ввод...");
                }
            }
        }
        public double StoronaC
        {
            get
            {
                return Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(beta* 2 * Math.PI / 360));
            }
        }
        public virtual bool isSpecialCaseTriangle
        {
            get
            {
                if (a == b || StoronaC == a || StoronaC == b) return true;
                else return false;
            }
        }
        public double MidleLine
        {
            get
            {
                return StoronaC / 2;
            }
        }
        public virtual double Area()
        {
            return a * b * Math.Sin(beta * 2 * Math.PI / 360) / 2;
        }
        public virtual void Show()
        {
            Console.WriteLine("Сторона а = {0}, сторона b = {1}, угол = {2} градусов", a, b, beta);
        }
        public virtual double perimetr
        {
            get { return a + b + StoronaC; }
        }
        /*public static Triangle creation()
        {
            int ac, bc; double betac;
            try
            {
                Console.WriteLine("Задайти параметры треугольника. В случае неправильного ввода данных их значения будут заданы по умолчанию.");
                Console.WriteLine("Введите целое значение стороны a:");
                ac = int.Parse(Console.ReadLine());
                if (ac <= 0) throw new Exception("Значение стороны не может быть отрицательным!");
                Console.WriteLine("Введите целое значение стороны b:");
                bc = int.Parse(Console.ReadLine());
                if (bc <= 0) throw new Exception("Значение стороны не может быть отрицательным!");
                Console.WriteLine("Введите значение угла beta:");
                betac = Convert.ToDouble(Console.ReadLine());
                if (betac >= 180 || betac <= 0) throw new Exception("Значение угла введено не правильно: 0 < beta < 180)");
            }
            catch (Exception err)
            {
                Console.WriteLine("Ошибка: {0}", err.Message);
                return new Triangle(3, 4, 60);
            }
            return new Triangle(ac, bc, betac);
        }*/
    }
    class PrTriangle : Triangle
    {
        public PrTriangle():base()
        {
            this.beta = 90;
        }
        public PrTriangle(int a, int b) : base(a, b, 90)
        {

        }
        public override bool isSpecialCaseTriangle
        {
            get
            {
                if (StoronaC / a == StoronaC / b) return true;
                return false;
            }
        }
        public override double betatr
        {
            get { return beta; }
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Данный треугольник прямоугольный");
        }
        public static PrTriangle creation()
        {
            Console.WriteLine("...СОЗДАНИЕ ПРЯМОУГОЛЬНОГО ТРЕУГОЛЬНИКА...");
            int st1, st2;
            try
            {
                Console.WriteLine("Введите первую сторону. В случае неправильного ввода она будет равна 3, а вторая - 4");
                st1 = int.Parse(Console.ReadLine());
                if (st1 <= 0) throw new Exception("Сторона не может иметь неположительное значение");
                Console.WriteLine("Введите 2 сторону, по умолчанию она задастся 4");
                st2 = int.Parse(Console.ReadLine());
                if (st2 <= 0) throw new Exception("Сторона не может иметь неположительное значение");
            }
            catch (Exception err)
            {
                Console.WriteLine("Ошибка: {0}", err.Message);
                st1 = 3;
                st2 = 4;
            }
            return new PrTriangle(st1, st2);
        }
    }
    class RavnostorTriangle : Triangle
    {
        public RavnostorTriangle() : base()
        {
            this.beta = 60;
            this.a = b;
        }
        public RavnostorTriangle(int a) : base(a, a, 60)
        {
        }
        public override double betatr
        {
            get { return beta; }
        }
        public override int atr
        {
            get
            {
                return a;
            }
            set
            {
                try
                {
                    a = value;
                    if (atr != btr)
                    {
                        Console.WriteLine("a = {0}", a);
                        btr = value;
                        Console.WriteLine("b = {0}", b);
                    }
                }
                catch
                {
                    Console.WriteLine("...Изменения не внесены, так как вы ввели недопустимые значения...");
                }
            }
        }
        public override int btr
        {
            get
            {
                return b;
            }
            set
            {
                try
                {
                    b = value;
                    if (btr != atr)
                    {
                        atr = value;
                    }
                }
                catch
                {
                    Console.WriteLine("...Изменения не внесены, так как вы ввели недопустимые значения...");
                }
            }

        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Треугольник равносторонний");
        }
        public override double perimetr
        {
            get { return 3 * a; }
        }
        public override double Area()
        {
            return a * a * Math.Sqrt(3) / 4;
        }
        public static RavnostorTriangle creation()
        {
            int st;
            Console.WriteLine("...СОЗДАНИЕ РАВНОСТОРОННЕГО ТРЕУГОЛЬНИКА...");
            try
            {
                Console.WriteLine("Введите стороны. В случае неправильного ввода она по умолчанию станет 6");
                st = int.Parse(Console.ReadLine());
                if (st <= 0) throw new Exception("Недопустимое значение стороны.");
            }
            catch (Exception err)
            {
                Console.WriteLine("Ошибка: {0}", err.Message);
                st = 6;
            }
            return new RavnostorTriangle(st);
        }
    }
    class Program
    {
        static void Main()
            {
                Triangle[] tria = new Triangle[2];
                tria[0] = PrTriangle.creation();
                Console.WriteLine("...создание успешно завершено...");
                tria[1] = RavnostorTriangle.creation();
                int i = 0;
                int answer;
                while (true)
                {
                    Console.WriteLine(@"Выберите действие (В случае неправильного ввода по умолчанию выполнится [1]):
[1] - вывести всю информацию о треугольниках
[2] - задать сторону равностороннего треугольника 
[3] - изменить первую сторону прямоугольного треугольника
[4] - изменить вторую сторону прямоугольного треугольника");
                    try
                {
                    answer = int.Parse(Console.ReadLine());
                    if (answer < 1 || answer > 4) throw new Exception("Такого пункта в программе нет");
                }
                catch (Exception err)
                {
                    Console.WriteLine("Ошибка: {0}", err.Message);
                    answer = 1;
                }
                    if (answer == 1)
                {
                    i = 0;
                    foreach (Triangle x in tria)
                    {
                        Console.WriteLine("Данные {0} треугольника:", i + 1);
                        x.Show();
                        Console.WriteLine("Площадь треугольника = {0:0.00}", x.Area());
                        Console.WriteLine("Периметр треугольника = {0:0.00}", x.perimetr);
                        Console.WriteLine("Сторона c = {0}", x.StoronaC);
                        Console.WriteLine("Средняя линия, параллельная с = {0}", x.MidleLine);
                        Console.WriteLine();
                        if (x.isSpecialCaseTriangle == true) Console.Write("Стороны треугольника равны => он равнобедренный");
                        i++;
                    }
                }
                    else if (answer == 2)
                {
                    Console.WriteLine("Введите значение стороны:");
                    try
                    {
                        answer = int.Parse(Console.ReadLine());
                        if (answer <= 0) throw new Exception("Значение стороны не может быть <=0");
                        tria[1].atr = answer;
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("Ошибка: {0}", err.Message);
                        Console.WriteLine("...изменения не внесены...");
                    }
                }
                    else if (answer == 3)
                {
                    Console.WriteLine("Введите значение стороны:");
                    try
                    {
                        answer = int.Parse(Console.ReadLine());
                        if (answer <= 0) throw new Exception("Значение стороны не может быть <=0");
                        tria[0].atr = answer;
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("Ошибка: {0}", err.Message);
                        Console.WriteLine("...изменения не внесены...");
                    }
                }
                    else if (answer == 4)
                {
                    Console.WriteLine("Введите значение стороны:");
                    try
                    {
                        answer = int.Parse(Console.ReadLine());
                        if (answer <= 0) throw new Exception("Значение стороны не может быть <=0");
                        tria[0].btr = answer;
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("Ошибка: {0}", err.Message);
                        Console.WriteLine("...изменения не внесены...");
                    }
                }
                }
            }
    }
}


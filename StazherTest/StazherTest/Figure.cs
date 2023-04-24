namespace StazherTest
{
    public class Figure //Идея класса: определение типа фигуры определяется по данным которые получает
        //конструктор при объявлении класса.
    {
        //класс можно легко модифицировать для поддержки большего количества фигур посредством добавления
        //дополнительных полей
        public double _side1 { get; set; }
        public double _side2 { get; set; }
        public double _side3 { get; set; }
        public string _type { get; set; }
        public double Area { get; set; }

        public List<double> _sidesList { get; set; }

        public Figure() //Конструктор с нулевым количеством аргументов: в основном для обработки случая - исключения
        {
            _side1= 0;
            _side2= 0;
            _side3= 0;
            Area= -1;
            _type = "NoFigure";
            _sidesList = new List<double>(); //Лист понадобится для сортировки сторон по величине, можно адаптировать и под другие
            //роли, коли потребуется.
        }
        public Figure(double value) //Если одно значение, то введённое число - радиус, а фигура - круг
        {
            _side1 = value;
            _side2 = 0;
            _side3 = 0;
            Area = 0.0;
            _type = "Circle";
            _sidesList = new List<double>();
        }

        public Figure(double value1, double value2, double value3) //Если три значения, то введённые числа - стороны треугольника
        {
            _side1 = value1;
            _side2 = value2;
            _side3 = value3;
            Area = 0.0;

            if (_side1 <= 0 || _side2 <= 0 || _side3 <= 0 || _side1 + _side2 <= _side3 ||
                _side1 + _side3 <= _side2 || _side2 + _side3 <= _side1)
            {
                _type = "IncorrectTriangle";
            }
            else
            {
                _type = "Triangle";
            }
            _sidesList = new List<double>{ _side1, _side2, _side3 };
            _sidesList.Sort();
        }

        public double FindArea() //Метод вычисления площади можно легко модифицировать посредством добавлений новых 
            //case в switch.
        {
            switch (_type)
            {
                case "Circle":
                    Area = Math.PI * Math.Pow(_side1, 2);
                    break;

                case "Triangle": //Проверка на то что треугольник прямоугольный
                    if (Math.Pow(_sidesList[_sidesList.Count-1], 2) == Math.Pow(_sidesList[0], 2) + Math.Pow(_sidesList[1], 2)) // c^2 = a^2+b^2?
                    {
                        Area = (_sidesList[0] * _sidesList[1]) / 2; //S = ab/2
                    }
                    else
                    {
                        double p = (_side1 + _side2 + _side3) / 2; //полупериметр
                        Area = Math.Sqrt(p * (p - _side1) * (p - _side2) * (p - _side3)); //Формула герона (Квадратный корень из p(p-a)(p-b)(p-c))s
                    }
                    break;

                default:
                    Area = -1;
                    break;
            }
            return Area;
        }
        public void PrintArea()
        {
            if (Area > 0.0)
            {
                Console.WriteLine(Area.ToString());
            }
            else 
            {
                Console.WriteLine("Area is null or less than 0! Something's wrong!");
            }
        }

    }
}
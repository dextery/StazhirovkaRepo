using StazherTest;

namespace StazherTask.UnitTest
{
    [TestClass]
    public class FigureTests //Unit тесты
    {
        Random rnd = new Random();
        [TestMethod]
        public void FindArea_Circle_Returns_Value()
        {
            //Arrange - инициализация объектов
            var figure = new Figure(rnd.Next(0, 10));

            //Act - вызов метода который тестируется
            var area = figure.FindArea();
            double value;
            bool result = Double.TryParse(area.ToString(), out value);
            //Assert - определение верности результата
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FindArea_Triangle_Returns_Value()
        {
            var figure = new Figure(7, 8, 9);

            var area = figure.FindArea();
            double value;
            bool result = Double.TryParse(area.ToString(), out value);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FindArea_Triangle_CanDetermineFalse()
        {
            var figure = new Figure(7, 8, 20);
            string type = figure._type;
            int isEqual = String.Compare(type, "IncorrectTriangle");
            bool correct = isEqual == 0 ? (true) : (false);

            Assert.IsTrue(correct);

        }
        [TestMethod]
        public void FindArea_Triangle_Handles_Upright()
        {
            var figure = new Figure(3, 4, 5);

            var area = figure.FindArea();
            double value;
            bool result = Double.TryParse(area.ToString(), out value);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FindArea_NoArguments_Handling()
        {
            var figure = new Figure();

            var area = figure.FindArea();
            double value;
            bool correct = area < 0 ? (true) : (false);

            Assert.IsTrue(correct);
        }
    }
}
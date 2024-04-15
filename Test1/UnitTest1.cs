using TPW.View;
using NUnit.Framework;
using System.Windows.Controls;
using System.Threading;

namespace Test1
{
    [TestFixture, Apartment(ApartmentState.STA)]
    public class Tests
    {
        private MainWindow mainWindow;
        private TextBlock textBlock;

        [SetUp]
        public void Setup()
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
            textBlock = mainWindow.FindName("TextBlock1") as TextBlock;
        }

        [Test]
        public void ContentTest()
        {
            Assert.That(textBlock.Text, Is.EqualTo("Programowanie wspó³bie¿ne"));
        }
    }
}
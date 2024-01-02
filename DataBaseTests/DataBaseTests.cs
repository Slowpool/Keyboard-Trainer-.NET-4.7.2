using Keyboard_Trainer;
using System.Diagnostics;

namespace DataBaseTests
{
    public class Tests
    {
        private DataBase database;

        [SetUp]
        public void Setup()
        {
            database = new DataBase("server=localhost;" +
                "port=3306;" +
                "user=root;" +
                "password=password;" +
                "database=keyboardtrainer;");
        }

        [Test]
        public void GetRandomWordTest1()
        {
            string word = database.GetRandomWord(Languages.English);
            Console.WriteLine(word);

            Assert.That(word.Length, Is.GreaterThan(1));
        }

        //[Test]
        //[Ignore("uncompiled")]
        //public void ConstructorTest1()
        //{
        //    database.wordsAmount
        //    Assert.That(word.Length, Is.GreaterThan(1));
        //}

        [Test]
        public void ConstructorTest2()
        {
            string word = database.GetRandomWord(Languages.English);
            Console.WriteLine(word);

            Assert.That(word.Length, Is.GreaterThan(1));
        }

    }
}
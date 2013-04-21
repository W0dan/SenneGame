using System.Windows;
using Moq;
using NUnit.Framework;
using SenneGameWpf;
using SenneGameWpf.Monsters;

namespace GameTest.Given_a_Monster
{
    [TestFixture]
    public class When_Beweeg_naar_boven_is_called
    {
        [Test]
        public void Then_the_monster_should_move_naar_boven()
        {
            var speelveld = new Mock<ISpel>();

            var waarBenIk = new Point(20, 20);
            var sut = new Heks(speelveld.Object, waarBenIk);

            sut.Beweeg_naar_boven();

            Assert.AreEqual(new Point(20, 15), sut.Waar_zijt_ge);
        }
    }
}

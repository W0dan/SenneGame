using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Hindernissen;
using SenneGameWpf.Monsters;

namespace SenneGameWpf.Levels
{
    public abstract class VerborgenKamer
    {
        private readonly Level _level;
        private readonly Point _offsetPosition;
        private readonly Size _size;
        private readonly Random _random = new Random();
        private readonly List<Hindernis> _hindernissen;
        public List<Monster> Monsterkes { get; private set; }
        private bool _isOntdekt;

        protected Level Level { get { return _level; } }

        protected Point TranslatePoint(Point point)
        {
            return new Point(point.X + _offsetPosition.X, point.Y + _offsetPosition.Y);
        }

        protected Point TranslatePoint(int x, int y)
        {
            return new Point(x + _offsetPosition.X, y + _offsetPosition.Y);
        }

        protected VerborgenKamer(Level level, Point offsetPosition, Size size)
        {
            _level = level;
            _offsetPosition = offsetPosition;
            _size = size;
            Monsterkes = new List<Monster>();
            _hindernissen = new List<Hindernis>();
        }

        public virtual void Ontdek()
        {
            _isOntdekt = true;
        }

        public IEnumerable<Hindernis> Hindernissen
        {
            get
            {
                return !_isOntdekt
                    ? new List<Hindernis>()
                    : _hindernissen;
            }
        }

        protected Monster AddMonster<T>(int x, int y)
            where T : Monster, new()
        {
            return _level.AddMonster<T>(x + (int)_offsetPosition.X, y + (int)_offsetPosition.Y);
        }

        protected Monster AddMonster<T>(Point point)
            where T : Monster, new()
        {
            return _level.AddMonster<T>(point);
        }

        protected virtual Hindernis AddTegel(int x, int y)
        {
            Hindernis result = null;

            switch (_random.Next(4))
            {
                case 0:
                    result = new Tegel_0_0(x + (int)_offsetPosition.X, y + (int)_offsetPosition.Y);
                    break;
                case 1:
                    result = new Tegel_0_1(x + (int)_offsetPosition.X, y + (int)_offsetPosition.Y);
                    break;
                case 2:
                    result = new Tegel_0_2(x + (int)_offsetPosition.X, y + (int)_offsetPosition.Y);
                    break;
                case 3:
                    result = new Tegel_0_3(x + (int)_offsetPosition.X, y + (int)_offsetPosition.Y);
                    break;
            }
            _hindernissen.Add(result);

            return result;
        }

        protected void AddVerborgenKamer(VerborgenKamer verborgenKamer, Point ingangPosition)
        {
            Level.AddVerborgenKamer(verborgenKamer, new Point(ingangPosition.X + _offsetPosition.X, ingangPosition.Y + _offsetPosition.Y));
        }

        protected virtual Hindernis AddSteen(int x, int y)
        {
            var result = new Hindernis(x + (int)_offsetPosition.X, y + (int)_offsetPosition.Y);
            _hindernissen.Add(result);
            return result;
        }

        public virtual Drawing Teken_jezelf()
        {
            if (!_isOntdekt)
                return new DrawingGroup();

            var verborgenKamer = new DrawingGroup();

            verborgenKamer.Children.Add(Teken_achtergrond());

            return verborgenKamer;
        }

        private ImageDrawing Teken_achtergrond()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/background-01.jpg");
            return new ImageDrawing(imageSource, new Rect(_offsetPosition.X, _offsetPosition.Y, _size.Width, _size.Height));
        }

    }
}
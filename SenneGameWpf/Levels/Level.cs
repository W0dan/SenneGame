using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Hindernissen;
using SenneGameWpf.Monsters;

namespace SenneGameWpf.Levels
{
    public abstract class Level
    {
        private readonly Random _random = new Random();
        private readonly ISpel _spel;
        private Ventje _ventje;
        public abstract List<Hindernis> Hindernissen { get; }

        public abstract Hindernis Uitgang { get; }

        public abstract Point Plek_waar_ventje_begint { get; }

        public List<Monster> Monsterkes { get; private set; }

        public Ventje Ventje
        {
            get { return _ventje; }
        }

        protected Level(ISpel spel)
        {
            _spel = spel;
            spel.Level = this;
            Monsterkes = new List<Monster>();
        }

        protected Monster AddMonster<T>(int x, int y)
            where T : Monster, new()
        {
            return AddMonster<T>(new Point(x, y));
        }

        protected Monster AddMonster<T>(Point point)
            where T : Monster, new()
        {
            var monster = Monster.CreateMonster<T>(_spel, point);
            Monsterkes.Add(monster);
            return monster;
        }

        protected virtual Hindernis AddTegel(int x, int y)
        {
            Hindernis result = null;

            switch (_random.Next(4))
            {
                case 0:
                    result = new Tegel_0_0(x, y);
                    break;
                case 1:
                    result = new Tegel_0_1(x, y);
                    break;
                case 2:
                    result = new Tegel_0_2(x, y);
                    break;
                case 3:
                    result = new Tegel_0_3(x, y);
                    break;
            }
            Hindernissen.Add(result);

            return result;
        }

        protected void ZetVentje(ISpel spel)
        {
            _ventje = spel.Zet_ventje(Plek_waar_ventje_begint);
        }

        public virtual Drawing Teken_jezelf()
        {
            var level = new DrawingGroup();

            var rect = new RectangleGeometry(new Rect(0, 0, 200, 200));
            var background = new GeometryDrawing(Brushes.Wheat, new Pen(), rect);

            level.Children.Add(background);

            level.Children.Add(Teken_monsterkes_en_hindernissen());

            return level;
        }

        protected Drawing Teken_monsterkes_en_hindernissen()
        {
            var speelveld = new DrawingGroup();

            foreach (var hindernis in Hindernissen)
                speelveld.Children.Add(hindernis.Teken_jezelf());

            foreach (var monsterke in Monsterkes.Where(m => !m.Is_dood))
                speelveld.Children.Add(monsterke.Teken_jezelf());

            return speelveld;
        }

    }
}
﻿using System;
using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Monsters
{
    public abstract class Monster
    {
        public static Monster CreateMonster<T>(ISpel spel, Point point)
            where T : Monster, new()
        {
            var monster = new T { Spel = spel };
            monster.Ga_hier_staan(point);
            return monster;
        }

        protected static readonly Random Randomizer = new Random();

        protected ISpel Spel;
        private Size _hoe_groot_ben_ik;
        protected Point WaarBenIk;
        protected bool Ben_dood;
        private readonly int _snelheid;

        protected Monster()
            : this(new Size(10, 10), 5)
        {
        }

        protected Monster(Size hoeGrootBenIk, int snelheid)
        {
            _hoe_groot_ben_ik = hoeGrootBenIk;
            _snelheid = snelheid;
        }

        public void Ga_hier_staan(Point point)
        {
            WaarBenIk = point;
        }

        public Point Waar_zijt_ge { get { return WaarBenIk; } }

        public double Breedte { get { return _hoe_groot_ben_ik.Width; } }

        public double Hoogte { get { return _hoe_groot_ben_ik.Height; } }

        public bool Is_dood { get { return Ben_dood; } }

        public abstract Drawing Teken_jezelf();

        public virtual void Beweeg()
        {
            var direction = Randomizer.Next(4);

            switch (direction)
            {
                case 0:
                    Beweeg_naar_rechts();
                    break;
                case 1:
                    Beweeg_naar_boven();
                    break;
                case 2:
                    Beweeg_naar_beneden();
                    break;
                case 3:
                    Beweeg_naar_links();
                    break;
            }
        }

        public void Beweeg_naar_boven()
        {
            Beweeg_naar(new Point(WaarBenIk.X, WaarBenIk.Y - _snelheid));
        }

        public void Beweeg_naar_beneden()
        {
            Beweeg_naar(new Point(WaarBenIk.X, WaarBenIk.Y + _snelheid));
        }

        public void Beweeg_naar_links()
        {
            Beweeg_naar(new Point(WaarBenIk.X - _snelheid, WaarBenIk.Y));
        }

        public void Beweeg_naar_rechts()
        {
            Beweeg_naar(new Point(WaarBenIk.X + _snelheid, WaarBenIk.Y));
        }

        private void Beweeg_naar(Point ik_wil_naar)
        {
            if (Spel.Is_hier_het_ventje(ik_wil_naar, _hoe_groot_ben_ik))
            {
                Spel.Ventje_is_geraakt();
                return;
            }

            if (Spel.Is_er_een_hindernis_in_de_weg(ik_wil_naar, _hoe_groot_ben_ik))
            {
                Beweeg();
                return;
            }

            if (Spel.Is_er_een_monster_in_de_weg(ik_wil_naar, _hoe_groot_ben_ik, this))
            {
                return;
            }

            WaarBenIk = ik_wil_naar;
        }

        public abstract void Ben_geraakt();
    }
}
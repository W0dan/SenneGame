﻿using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Hindernissen
{
    public class Tegel_0_1 : Hindernis
    {
        public Tegel_0_1(double x, double y)
            : base(x, y)
        {
        }

        public override Drawing Teken_jezelf()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/tile_0_1.png");

            return new ImageDrawing(imageSource, new Rect(X - 5, Y - 5, 10, 10));
        }

    }
}
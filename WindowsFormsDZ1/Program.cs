﻿using System;
using System.Windows.Forms;
/// <summary>
/// Гаврилов В. А.
/// </summary>
namespace Asteroids
{
     class Program
    {
        static void Main()
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            form.Show();
            Game.Draw();

            Application.Run(form);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            updateCanvas();
        }

        private void updateCanvas()
        {
            Canvas myCanvas = new Canvas();
            myCanvas.Background = Brushes.LightSteelBlue;
            

            for(var i=0; i<10; i++)
            {
                Rectangle r = new Rectangle();
                MainCanvas.Children.Add(r);
                //Canvas.SetTop(r, );
                Canvas.SetLeft(r, (i*22));
            }
        }
    }
}
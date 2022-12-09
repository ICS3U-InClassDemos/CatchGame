﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchGame
{
    public partial class Form1 : Form
    {
        Rectangle hero = new Rectangle(280, 540, 40, 10);
        int heroSpeed = 10;

        List<Rectangle> balls = new List<Rectangle>();
        int ballSize = 10;
        int ballSpeed = 8;

        int score = 0;
        int time = 500;

        bool leftDown = false;
        bool rightDown = false;

        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        Random randGen = new Random();
        int randValue = 0;

        int groundHeight = 50;

        public Form1()
        {
            InitializeComponent();
            balls.Add(new Rectangle(3, 0, ballSize, ballSize));
            balls.Add(new Rectangle(200, 0, ballSize, ballSize));
            balls.Add(new Rectangle(400, 0, ballSize, ballSize));

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
            }

        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            //move player
            if (leftDown == true && hero.X > 0)
            {
                hero.X -= heroSpeed;
            }

            if (rightDown == true && hero.X < this.Width - hero.Width)
            {
                hero.X += heroSpeed;
            }

            //move ball objects
            for (int i = 0; i < balls.Count; i++)
            {
                int y =  balls[i].Y + ballSpeed;
                balls[i] = new Rectangle(balls[i].X, y, ballSize, ballSize);
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //update labels
            timeLabel.Text = $"Time Left: {time}";
            scoreLabel.Text = $"Score: {score}";

            //draw ground
            e.Graphics.FillRectangle(greenBrush, 0, this.Height - groundHeight,
                this.Width, groundHeight);

            //draw hero
            e.Graphics.FillRectangle(whiteBrush, hero);

            //draw balls
            for (int i = 0; i < balls.Count(); i++)
            {
                e.Graphics.FillEllipse(greenBrush, balls[i]);
            }

        }
    }
}

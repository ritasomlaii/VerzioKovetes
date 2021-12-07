using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldsHardestGame;

namespace EvoluciosAlgoritmus_D0ZBSJ
{
    public partial class Form1 : Form
    {
        GameController gc = new GameController();
        GameArea ga;

        int populationSize = 100;
        int numberOfSteps = 10;
        int numberOfStepsIncrement = 10;
        int generation = 1;
        public Form1()
        {
            InitializeComponent();

            ga = gc.ActivateDisplay();
            this.Controls.Add(ga);

            //gc.AddPlayer();
            //gc.Start(true);

            gc.GameOver += Gc_GameOver;

            for (int i = 0; i < populationSize; i++)
            {
                gc.AddPlayer(numberOfSteps);
            }
            gc.Start();
        }

        private void Gc_GameOver(object sender)
        {
            generation++;
            lblgen.BringToFront();
            lblgen.Text = string.Format("{0}.generáció", generation);

        }
    }
}

using Mikroszimulacio_D0ZBSJ.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mikroszimulacio_D0ZBSJ
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        Random rng = new Random(1500);
        public Form1()
        {
            InitializeComponent();


            Population = GetPopulation(@"C:\Temp\nép.csv");

            dGProba.DataSource = Population;

            for (int year = 2005; year <= 2024; year++)
            {
                for (int pop = 0; pop < Population.Count(); pop++)
                {

                }

                int numberOfMale = (from x in Population
                                    where x.Gender == Gender.male && x.IsAlive
                                    select x).Count();
                int numberOfFemales = (from x in Population
                                       where x.Gender == Gender.woman && x.IsAlive
                                       select x).Count();
                Console.WriteLine(string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, numberOfMale, numberOfFemales));
            }
        }

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;
        }
    }
}

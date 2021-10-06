using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace D0ZBSJ_4het
{
    public partial class Form1 : Form
    {
        List<Flat> flats;
        RealEstateEntities context = new RealEstateEntities();

        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;
        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
        }

        public void LoadData()
        {
            flats = context.Flats.ToList();
        }

        public void CreateExcel()
        {
            try
            {
                // Excel elindítása és az applikáció objektum betöltése
                xlApp = new Excel.Application();

                // Új munkafüzet
                xlWB = xlApp.Workbooks.Add(Missing.Value);

                // Új munkalap
                xlSheet = xlWB.ActiveSheet;

                // Tábla létrehozása
                CreateTable(); 

                // Control átadása a felhasználónak
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex) // Hibakezelés a beépített hibaüzenettel
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                // Hiba esetén az Excel applikáció bezárása automatikusan
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }
        

        public void CreateTable()
        {
            string[] headers = new string[] 
            {
                "Kód",
                "Eladó",
                "Oldal",
                "Kerület",
                "Lift",
                "Szobák száma",
                "Alapterület (m2)",
                "Ár (mFt)",
                //"Négyzetméter ár (Ft/m2)",
                "plusz"
            };


            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[1, 1] = headers[0];
            }

            object[,] values = new object[flats.Count, headers.Length];

            var counter = 0;
            var index = 0;
            foreach (var item in flats)
            {
                index = 0;
                values[counter, index++] = item.Code;
                values[counter, index++] = item.Vendor;
                values[counter, index++] = item.Side;
                values[counter, index++] = item.District;
                values[counter, index++] = item.Elevator;
                values[counter, index++] = item.NumberOfRooms;
                values[counter, index++] = item.FloorArea;
                values[counter, index++] = item.Price;
                //values[counter, index++] = item.;
                values[counter, index++] = "";
                counter++;                   
            }

            xlSheet.get_Range(
                        GetCell(2, 1),
                        GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;
        }

        public string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }
    }
}

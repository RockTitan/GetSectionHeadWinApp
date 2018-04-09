using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Text.RegularExpressions;

namespace GetSectionHeadWinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputFile = @"C:\Users\RockTitan\Desktop\C# Practice\MDT test\AllSections.txt";
            string content = string.Empty;
            using (StreamReader sr = new StreamReader(inputFile))
            {
                content = sr.ReadToEnd();
                sr.Close();
            }

            //var patternSectionHeader = @"(?<SecHead>[A-Z]*[2]*[A-Z]+)(?<T1>[0-9\.\/\-]+[ABCDEM]?)(?<D1>[Xx\*])?(?<T2>[0-9\.\/\-]+[ABCDEM]?)?(?<D2>[Xx\*])?(?<T3>[0-9\.\/\-]+[ABCDEM]?)?(?<D3>[Xx\*])?(?<T4>[0-9\.\/\-]+[ABCM]?)?(?<T5>[DPTW]+[0-9]*)?";
            var patternSectionHeader = @"(?<SecHead>[OXBHDCUPNISTWMLJEFR]*[2]?[WFMCLTRSAHNUBRPDIEOX]+)(?<T1>[0-9\.\/\-]+[ABCDEM]?)(?<D1>[Xx\*])?(?<T2>[0-9\.\/\-]+[ABCDEM]?)?(?<D2>[Xx\*])?(?<T3>[0-9\.\/\-]+[ABCDEM]?)?(?<D3>[Xx\*])?(?<T4>[0-9\.\/\-]+[ABCM]?)?(?<T5>[DPTW]+[0-9]*)?";
            var MatSection = Regex.Matches(content, patternSectionHeader);


            string output = string.Empty;
            foreach (Match match in MatSection)
            {
                string SectionHeader = match.Groups["SecHead"].Value;
                output += SectionHeader + "\n";
            }

            string outputFile = @"C:\Users\RockTitan\Desktop\C# Practice\MDT test\AllSectionHead.txt";
            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                sw.WriteLine(output);
                sw.Close();
            }
        }
    }
}

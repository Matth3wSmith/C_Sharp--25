using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat_10_20
{
    internal class DarusAuto:Teherauto
    {
        public string marka;
        public string szin;
        public string rendszam;
        public DarusAuto(bool terepes, string marka, string szin, string rendszam) : base(terepes)
        {
            this.marka = marka;
            this.szin = szin;   
            this.rendszam = rendszam;

        }
        public override string Altipus
        {
            set { this.altipus = "Darus"; }
        }

        public override int Kerekszam
        {
            set { this.kerekszam = value; }
        }

        public override string ToString()
        {
            return $"A darusató rendszáma: {rendszam}\n" +
                $"\tMárkája: {marka}\n" +
                $"\tSzíne: {szin}\n" +
                $"\tKerekek száma: {kerekszam}\n" +
                $"\tTípusa: {tipus}\n" +
                $"\tAltípusa: {altipus}\n" +
                $"\tTerepes-e: {terepes}";
        }
    }
}

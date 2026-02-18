using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PexesoAplikaceWF
{
    public class AI
    {
        public enum Obtiznost
        {
            Lehka,
            Normalni,
            Tezka
        }

        private Obtiznost obtiznost;
        private Random rng;
        private Dictionary<int, List<Button>> pamet;

        public AI(Obtiznost zvolenaObtiznost)
        {
            obtiznost = zvolenaObtiznost;
            rng = new Random();
            pamet = new Dictionary<int, List<Button>>();
        }

        public void VidelJsemKartu(Button karta)
        {
            if (obtiznost == Obtiznost.Lehka) return;

            int sanceZapamatovani = 0;

            if (obtiznost == Obtiznost.Normalni) sanceZapamatovani = 40;
            if (obtiznost == Obtiznost.Tezka) sanceZapamatovani = 90;

            if (rng.Next(0, 100) < sanceZapamatovani)
            {
                int id = (int)karta.Tag;
                if (!pamet.ContainsKey(id))
                {
                    pamet[id] = new List<Button>();
                }

                if (!pamet[id].Contains(karta))
                {
                    pamet[id].Add(karta);
                }
            }
        }

        public void OdstranKartyZPameti(List<Button> karty)
        {
            foreach (Button btn in karty)
            {
                int id = (int)btn.Tag;
                if (pamet.ContainsKey(id))
                {
                    pamet[id].Remove(btn);
                    if (pamet[id].Count == 0)
                    {
                        pamet.Remove(id);
                    }
                }
            }
        }

        public List<Button> NavrhniTah(List<Button> dostupneKarty)
        {
            if (obtiznost == Obtiznost.Lehka)
            {
                return dostupneKarty.OrderBy(x => rng.Next()).Take(3).ToList();
            }

            foreach (KeyValuePair<int, List<Button>> zaznam in pamet)
            {
                List<Button> znameKarty = zaznam.Value.Where(k => dostupneKarty.Contains(k)).ToList();

                if (znameKarty.Count == 3)
                {
                    return znameKarty;
                }
            }

            foreach (KeyValuePair<int, List<Button>> zaznam in pamet)
            {
                List<Button> znameKarty = zaznam.Value.Where(k => dostupneKarty.Contains(k)).ToList();

                if (znameKarty.Count == 2)
                {
                    List<Button> vysledek = new List<Button>(znameKarty);
                    List<Button> zbytek = dostupneKarty.Except(vysledek).ToList();

                    if (zbytek.Count > 0)
                    {
                        vysledek.Add(zbytek[rng.Next(zbytek.Count)]);
                        return vysledek;
                    }
                }
            }

            List<Button> nahodnyVyber = new List<Button>();
            Button prvni = dostupneKarty[rng.Next(dostupneKarty.Count)];
            nahodnyVyber.Add(prvni);

            int hledaneId = (int)prvni.Tag;

            if (pamet.ContainsKey(hledaneId))
            {
                List<Button> znameShody = pamet[hledaneId].Where(k => k != prvni && dostupneKarty.Contains(k)).ToList();
                foreach (Button shoda in znameShody)
                {
                    if (nahodnyVyber.Count < 3)
                    {
                        nahodnyVyber.Add(shoda);
                    }
                }
            }

            while (nahodnyVyber.Count < 3)
            {
                List<Button> zbytek = dostupneKarty.Except(nahodnyVyber).ToList();
                if (zbytek.Count == 0) break;
                nahodnyVyber.Add(zbytek[rng.Next(zbytek.Count)]);
            }

            return nahodnyVyber;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PEXESO.Resources
{
    public class AI

    // 0 - lehká, 1 - normální, 2 - těžká
    {
        #region Deklarace + Konstruktor
        private byte obtiznost;
        private Random rnd;
        private Button[,] pamet;

        public AI(byte zvolenaObtiznost)
        {
            obtiznost = zvolenaObtiznost;
            rnd = new Random();
            pamet = new Button[100, 3];
        }
        #endregion
        #region Prace s kartami
        public void VidelJsemKartu(Button karta)
        {
            if (obtiznost == 0)
            {
                return;
            }

            int sanceZapamatovani = 0;

            if (obtiznost == 1)
            {
                sanceZapamatovani = 20;
            }
            else if (obtiznost == 2)
            {
                sanceZapamatovani = 55;
            }

            if (rnd.Next(0, 100) < sanceZapamatovani)
            {
                int id = (int)karta.Tag;

                
                bool uzZapsano = false;
                for (int i = 0; i < 3; i++)
                {
                    if (pamet[id, i] == karta)
                    {
                        uzZapsano = true;
                    }
                }

                
                if (uzZapsano == false)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pamet[id, i] == null)
                        {
                            pamet[id, i] = karta;
                            break; 
                        }
                    }
                }
            }
        }

        public void OdstranKartyZPameti(List<Button> karty)
        {
            
            foreach (Button btn in karty)
            {
                int id = (int)btn.Tag;
                for (int i = 0; i < 3; i++)
                {
                    if (pamet[id, i] == btn)
                    {
                        pamet[id, i] = null;
                    }
                }
            }
        }

        #endregion
        #region Paměť + Tah
        private void AktualizujPametPodleHry(List<Button> dostupneKarty)
        {
            for (int radek = 0; radek < 100; radek++)
            {
                for (int sloupec = 0; sloupec < 3; sloupec++)
                {
                    if (pamet[radek, sloupec] != null)
                    {
                        bool staleDostupna = false;
                        foreach (Button k in dostupneKarty)
                        {
                            if (k == pamet[radek, sloupec])
                            {
                                staleDostupna = true;
                            }
                        }

                        if (staleDostupna == false)
                        {
                            pamet[radek, sloupec] = null;
                        }
                    }
                }
            }
        }

        public List<Button> NavrhniTah(List<Button> dostupneKarty)
        {
            List<Button> vybraneKarty = new List<Button>();

            if (obtiznost == 0)
            {
                
                while (vybraneKarty.Count < 3)
                {
                    Button nahodna = dostupneKarty[rnd.Next(dostupneKarty.Count)];

                    bool uzVybrana = false;
                    foreach (Button v in vybraneKarty)
                    {
                        if (v == nahodna)
                        {
                            uzVybrana = true;
                        }
                    }

                    if (uzVybrana == false)
                    {
                        vybraneKarty.Add(nahodna);
                        Main main = new Main();
                        main.prehratZvuk(1);
                    }
                }
                return vybraneKarty;
            }

            
            AktualizujPametPodleHry(dostupneKarty);

           
            for (int i = 0; i < 100; i++)
            {
                if (pamet[i, 0] != null)
                {
                    if (pamet[i, 1] != null)
                    {
                        if (pamet[i, 2] != null)
                        {
                            
                            vybraneKarty.Add(pamet[i, 0]);
                            vybraneKarty.Add(pamet[i, 1]);
                            vybraneKarty.Add(pamet[i, 2]);
                            return vybraneKarty;
                        }
                    }
                }
            }

            
            Button prvniKarta = dostupneKarty[rnd.Next(dostupneKarty.Count)];
            vybraneKarty.Add(prvniKarta);

            int hledaneId = (int)prvniKarta.Tag;

            
            for (int i = 0; i < 3; i++)
            {
                if (pamet[hledaneId, i] != null)
                {
                    if (pamet[hledaneId, i] != prvniKarta)
                    {
                        bool kartaUzVeVyberu = false;
                        foreach (Button b in vybraneKarty)
                        {
                            if (b == pamet[hledaneId, i])
                            {
                                kartaUzVeVyberu = true;
                            }
                        }

                        if (kartaUzVeVyberu == false)
                        {
                            vybraneKarty.Add(pamet[hledaneId, i]);
                        }
                    }
                }
            }

            
            while (vybraneKarty.Count < 3)
            {
                Button nahodneDoplneni = dostupneKarty[rnd.Next(dostupneKarty.Count)];
                bool kartaUzVeVyberu = false;
                foreach (Button b in vybraneKarty)
                {
                    if (b == nahodneDoplneni)
                    {
                        kartaUzVeVyberu = true;
                    }
                }

                if (kartaUzVeVyberu == false)
                {
                    vybraneKarty.Add(nahodneDoplneni);
                }
            }

            return vybraneKarty;
        }
        #endregion
    }
}
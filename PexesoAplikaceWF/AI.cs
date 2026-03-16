using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PEXESO.Resources
{
    public class AI

    // 0 - lehká, 1 - normální, 2 - těžká
    {
        private byte obtiznost;
        private Random rnd; // Random pojmenovat vždy rnd
        private Button[,] pamet; // 2D pole [100 tagů, 3 fyzické karty]

        public AI(byte zvolenaObtiznost)
        {
            obtiznost = zvolenaObtiznost;
            rnd = new Random();
            pamet = new Button[100, 3];
        }

        public void VidelJsemKartu(Button karta)
        {
            if (obtiznost == 0) // Lehká
            {
                return; // Lehká si nepamatuje nic
            }

            int sanceZapamatovani = 0;

            if (obtiznost == 1) // Normální
            {
                sanceZapamatovani = 20; // 20% šance na zapamatování
            }
            else if (obtiznost == 2) // Těžká
            {
                sanceZapamatovani = 55; // 55% šance na zapamatování
            }

            if (rnd.Next(0, 100) < sanceZapamatovani)//Pokud je náhodný číslo menší než 
            {
                int id = (int)karta.Tag;

                // Kontrola, zda už kartu v paměti nemáme zapsanou z dřívějška
                bool uzZapsano = false;
                for (int i = 0; i < 3; i++)
                {
                    if (pamet[id, i] == karta)
                    {
                        uzZapsano = true;
                    }
                }

                // Pokud není, najdeme první volný sloupeček (null) a uložíme si ji
                if (uzZapsano == false)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pamet[id, i] == null)
                        {
                            pamet[id, i] = karta;
                            break; // Dál už nehledáme, uloženo
                        }
                    }
                }
            }
        }

        public void OdstranKartyZPameti(List<Button> karty)
        {
            // Pokud kdokoliv získá bod, tyto karty už nejsou ve hře. Vynulujeme jejich paměť.
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

        // Pomocná metoda pro kompletní pročištění paměti před tahem (kdyby nám protihráč něco vyfoukl)
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

            if (obtiznost == 0) // Lehká obtížnost
            {
                // Lehká jen vybere 3 naprosto náhodné karty (přes cykly bez LINQ)
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

            // Normální a Těžká si nejdřív zkontrolují paměť
            AktualizujPametPodleHry(dostupneKarty);

            // 1. KROK: Hledání JISTOTY (Mám k nějakému ID už uložené všechny 3 karty?)
            for (int i = 0; i < 100; i++)
            {
                if (pamet[i, 0] != null)
                {
                    if (pamet[i, 1] != null)
                    {
                        if (pamet[i, 2] != null)
                        {
                            // Máme plnou trojici!
                            vybraneKarty.Add(pamet[i, 0]);
                            vybraneKarty.Add(pamet[i, 1]);
                            vybraneKarty.Add(pamet[i, 2]);
                            return vybraneKarty;
                        }
                    }
                }
            }

            // 2. KROK: Pokud není 100% jistota, vezme první kartu náhodně a zkusí dohledat zbytek
            Button prvniKarta = dostupneKarty[rnd.Next(dostupneKarty.Count)];
            vybraneKarty.Add(prvniKarta);

            int hledaneId = (int)prvniKarta.Tag;

            // Podíváme se, jestli v paměti k tomuto tagu nemáme zbylé (jednu nebo dvě) karty
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

            // 3. KROK: Doplnění zbytku tahů naprosto náhodně (pokud paměť nepomohla najít celou trojici)
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
    }
}
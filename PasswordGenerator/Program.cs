using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Longueur du mot de passe : ");
            int pswdLength = getNumberPositif(Console.ReadLine());

            Console.Write("Nombre de mot de passe à générer : ");
            int pswdNumber = getNumberPositif(Console.ReadLine());

            pswdGenChoice();

            Console.Write("Votre choix : ");
            int choice = getGenChoice(Console.ReadLine());

            for (int i = 0; i < pswdNumber; i++)
            {
                string pswd = new string(generatePswd(pswdLength, choice));
                Console.WriteLine("Mot de passe n°" + (i+1) + " : " + pswd);
            }
        }
        
        private static int getNumberPositif(string entry)
        {
            bool state = int.TryParse(entry, out int q);
            bool positif = isPositiv(q);

            while (state == false || positif == false)
            {
                Console.Write("Valeur entrée incorrecte, veuillez entrer un nombre entier POSITIF : ");
                entry = Console.ReadLine();
                state = int.TryParse(entry, out q);
                positif = isPositiv(q);
            }

            return q;
        }

        /*
         * @description Vérifie que le nombre est positif ou non
         * @return bool positif ou non
         */

        private static bool isPositiv(int number)
        {
            if (number > 0)
                return true;
            else
                return false;
        }

        private static void pswdGenChoice()
        {
            Console.WriteLine("Vous voulez un mot de passe avec :\n");
            Console.WriteLine("1 - Uniquement des caractères en minuscule\n2 - Des caractères en minuscules et majuscules\n3 - " +
                "Des caractères et des chiffres\n4 - Caractères, chiffres et caractères spéciaux");
        }

        private static int getGenChoice(string entry)
        {
            bool state = int.TryParse(entry, out int q);
            bool positif = isPositiv(q);

            while (state == false || positif == false || q>4 )
            {
                Console.Write("Valeur entrée incorrecte, veuillez entrer un nombre entier entre 1 et 4 : ");
                entry = Console.ReadLine();
                state = int.TryParse(entry, out q);
                positif = isPositiv(q);
            }

            return q;
        }

        private static char[] generatePswd(int size, int type)
        {
            char[] mdp = new char[size];

            string chars1 = "abcdefghijklmnopqrstuvwxyz";
            string chars2 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string chars3 = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string chars4 = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";

            for (int i = 0; i < size; i++)
            {
                if (type == 1)
                {
                    Random rand = new Random();
                    int num = rand.Next(0, chars1.Length);
                    mdp[i] = chars1[num];
                }
                else if (type == 2)
                {
                    Random rand = new Random();
                    int num = rand.Next(0, chars2.Length);
                    mdp[i] = chars2[num];
                }
                else if (type == 3)
                {
                    Random rand = new Random();
                    int num = rand.Next(0, chars3.Length);
                    mdp[i] = chars3[num];
                }
                else
                {
                    Random rand = new Random();
                    int num = rand.Next(0, chars4.Length);
                    mdp[i] = chars4[num];
                }
            }

           

            return mdp;
        }
    }
}

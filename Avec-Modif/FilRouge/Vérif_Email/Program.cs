using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace Vérif_Email
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            Méthode du regex

            Regex rg = new Regex(@"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9]+)*$"); //a valider
            Console.WriteLine("Entrer votre adresse");

            if(rg.IsMatch(Console.ReadLine()))
            {
                Console.WriteLine("ok");
            }else
            {
                Console.WriteLine("pas ok");

            }
*/






            /*Méthode substring*/
            bool result = false;

            Console.WriteLine("Quelle est votre adresse email?");

            String reponse = Console.ReadLine();
            Console.WriteLine();

            result = Verification(reponse);

            if (result)
            {
                int position = reponse.IndexOf("@");
                //Console.WriteLine("@ en position" + position);

                String newreponse = reponse.Substring(position + 1, (reponse.Length - position - 1));

                Domaine(newreponse);
                //Console.WriteLine(newreponse);
                // Console.WriteLine();




            }

            Console.ReadKey();

        }
        static void Domaine(string carac)
        {
            int presence=0;
            for (int i = 0; i < carac.Length; i++)
            {
                if(carac[i]=='.')
                {
                    presence++;
                }
            }

            if (presence!=1)
            {
                Console.WriteLine("Il y trop ou il manque un point dans le nom de domaine");

            }else
            {
                //comptons les caractères avant le point et apres.
               // Console.WriteLine(carac);
                //Console.WriteLine("longueur de carac" + carac.Length);


                int position = carac.IndexOf(".");
                //Console.WriteLine("Position de . : " + position);


                String avant = carac.Substring(0, (position));  
                //Console.WriteLine(avant);
                
                String apres = carac.Substring(position+1, carac.Length-position-1);
               // Console.WriteLine(apres);

                if (avant.Length < 2 || apres.Length < 2)
                {

                    Console.WriteLine("Problème avec la saisie du nom de domaine");


                }else
                {
                    Console.WriteLine("Tout est correcte");
                }
            }
        }

       public static Boolean Verification(string carac)
        {
            int avant = 0;
            int i=0, j = 0, presenc=0;
            //Console.WriteLine(carac.Length);

            if(carac.Length==0) //test pour une saisie vide
            {
                Console.WriteLine("Vous n'avez rien saisit");
                return false;
            }else
            {
                for (int o = 0; o < carac.Length; o++) //test du nombre de @
                {
                    if (carac[o] == '@')
                    {
                        presenc++;

                    }
                }
                if(presenc!=1)
                {
                    Console.WriteLine("Nombre incorrecte de @");
                    return false;

                }else
                {
                    while(i!=carac.Length)
                    {
                        while(carac[j]!='@')
                        {
                            avant++;
                            j++;
                            // Console.WriteLine("avant vaut: " + avant + " j vaut " + j);
                        }
                        // Console.WriteLine(carac[i] + " " + i);
                            i++;
                    }
                    if (avant<2) //test du nombre de caractere avant @
                    {
                        Console.WriteLine("nombre de caractère avant @ insuffisant");
                        return false;
                    }else
                    {
                        return true;

                    }

              
                }
            }
        }
        
    }
}

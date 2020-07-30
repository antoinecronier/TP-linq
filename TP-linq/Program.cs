using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_linq.Entities;
using TP_linq.Utils;

namespace TP_linq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Q1
            Console.WriteLine("Question 1");
            // Afficher le nombre de personne s'appelant Dupond ou Dupont.

            #region Reponse
            var q1 = FakeDb.Instance.Users.Count(x => x.Lastname.Equals("Dupond") || x.Lastname.Equals("Dupont"));
            Console.WriteLine("Réponse question 1\n\tNombre de personne s'appelant \"Dupond\" ou \"Dupont\" : " + q1);
            #endregion
            #endregion
            #region Q2
            Console.WriteLine("Question 2");
            // Afficher les personnes enregistré avec le role Automobiliste.

            #region Reponse
            var q2 = FakeDb.Instance.Users
                .Where(x => x.Roles.Select(y => y.Name).Any(y => y.Equals("Automobiliste")));

            Console.WriteLine("Réponse question 2");
            foreach (var item in q2)
            {
                Console.WriteLine($"\t { item.Firstname } { item.Lastname }");
            }
            #endregion
            #endregion
            #region Q3
            Console.WriteLine("Question 3");
            // Afficher les plaques d'immatriculation de toutes les voitures (une seule fois par voiture) liées à au moins un utilisateur.

            #region Reponse
            var q3 = FakeDb.Instance.Users.SelectMany(x => x.Cars).Distinct().Select(x => x.Registration);
            Console.WriteLine("Réponse question 3");
            foreach (var item in q3)
            {
                Console.WriteLine($"\t { item }");
            }
            #endregion
            #endregion
            #region Q4
            // Afficher la ou les voiture(s) avec le plus de kilomètre

            #region Reponse
            var q4 = FakeDb.Instance.Users.SelectMany(x => x.Cars).Distinct().Where(x => x.Mileage == FakeDb.Instance.Users.SelectMany(y => y.Cars).Distinct().Max(y => y.Mileage));

            Console.WriteLine("Réponse question 4");
            foreach (var item in q4)
            {
                Console.WriteLine($"\t { item.Id } { item.Mileage } {item.Registration}");
            }

            #endregion
            #endregion
            #region Q5
            // Afficher le classement des types de voiture par nombre de voiture unique présentes du plus grand au plus petit.

            #region Reponse
            var q5 = FakeDb.Instance.Users.SelectMany(x => x.Cars).Distinct().GroupBy(x => x.Type).OrderByDescending(x => x.Count());

            Console.WriteLine("Réponse question 5");
            foreach (var item in q5)
            {
                Console.WriteLine($"\t { item.Key.Name } avec { item.Count() } voitures");
            }

            #endregion
            #endregion
            #region Q6
            // Afficher les "Garagiste" liés à 4 voitures ou plus.

            #region Reponse
            var q6 = FakeDb.Instance.Users.Where(x => x.Roles.Select(y => y.Name).Contains("Garagiste")).Where(x => x.Cars.Count() >= 4);

            Console.WriteLine("Réponse question 6");
            foreach (var item in q6)
            {
                Console.WriteLine($"\t { item.Firstname } { item.Lastname }");
            }

            #endregion
            #endregion
            #region Q7
            // Afficher les "Controlleur" et la liste des voitures aux quelles ils sont liés.

            #region Reponse
            var q7 = FakeDb.Instance.Users.Where(x => x.Roles.Select(y => y.Name).Contains("Controlleur"));

            Console.WriteLine("Réponse question 7");
            foreach (var item in q7)
            {
                Console.WriteLine($"\t { item.Firstname } { item.Lastname } ");
                foreach (var car in item.Cars)
                {
                    Console.WriteLine($"\t\t { car.Id } { car.Mileage } {car.Registration}");
                }
            }

            #endregion
            #endregion
            Console.ReadKey();
        }
    }
}

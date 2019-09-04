using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MtgApiManager.Lib.Service;
using MTGToolbox.Core;
using MTGToolbox.Repository;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MTGToolbox.CardLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MTGToolboxContext>();
            string connectionString = ConfigurationManager.AppSettings.Get("connectionString");

            optionsBuilder.UseSqlServer(connectionString);

            MTGToolboxContext context = new MTGToolboxContext(optionsBuilder.Options);

            if (args.Length == 0)
            {
                System.Console.WriteLine("Retrieving card sets. To get all cards for a given set, pass the set code.");

                LoadSets(context);
            }
            else
            {
                string setCode = args[0];
                LoadCards(context, setCode);
            }

            return;
        }

        static void LoadCards(MTGToolboxContext context, string setCode)
        {
            CardRepository cardRepository = new CardRepository(context);
            SetRepository setRepository = new SetRepository(context);

            CardService cardService = new CardService();

            Set set = setRepository.GetSetByCode(setCode);

            int cardResultsPage = 1;
            var cardResults = cardService.Where(x => x.Set, setCode).Where(x => x.Page, cardResultsPage).All();

            do
            {
                foreach (var item in cardResults.Value)
                {
                    Card card = new Card();
                    card.Name = item.Name;

                    card.ImageFile = item.ImageUrl?.ToString();

                    card.SetCards = new List<SetCards> { new SetCards { Set = set, Card = card, Rarity = item.Rarity, ImageFile = item.ImageUrl?.ToString() } };

                    cardRepository.AddCard(card);
                }

                cardResultsPage += 1;
                cardResults = cardService.Where(x => x.Set, setCode).Where(x => x.Page, cardResultsPage).All();

            } while (cardResults.Value.Count > 1);

            cardRepository.Save();
        }

        static void LoadSets(MTGToolboxContext context)
        {
            SetRepository setRepository = new SetRepository(context);

            SetService setService = new SetService();

            var setResults = setService.All();

            if (setResults.IsSuccess)
            {
                foreach (var item in setResults.Value)
                {
                    Set set = new Set();
                    set.Code = item.Code;
                    set.Name = item.Name;

                    setRepository.AddSet(set);
                }
                setRepository.Save();
            }

        }
    }
}

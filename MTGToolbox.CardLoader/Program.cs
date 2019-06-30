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

            ISet set = setRepository.GetSetByCode(setCode);

            var cardResults = cardService.Where(x => x.Set, setCode).All();

            if (cardResults.IsSuccess)
            {
                foreach (var item in cardResults.Value)
                {
                    ICard card = new Card();
                    card.Name = item.Name;

                    if (item.MultiverseId != null)
                        card.ImageFile = item.ImageUrl.ToString();

                    cardRepository.AddCard(card);

                    SetCards setCards = new SetCards(set, card, item.Rarity);
                }

                cardRepository.Save();
            }

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

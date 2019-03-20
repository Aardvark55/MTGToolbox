using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTGToolbox.Repository;

namespace MTGToolbox.Web.Controllers
{
    public class DeckController : Controller
    {
        private readonly IDeckRepository _deckRepository;

        public DeckController(IDeckRepository deck)
        {
            _deckRepository = deck;
        }

        public IActionResult Index()
        {
            var decks = _deckRepository.GetDecks();

            return View(decks);
        }
    }
}
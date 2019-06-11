using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTGToolbox.Repository;
using Microsoft.EntityFrameworkCore;

namespace MTGToolbox.Web.Controllers
{
    public class DeckController : Controller
    {
        private readonly IDeckRepository _deckRepository;

        public DeckController(IDeckRepository deckRepository)
        {
            _deckRepository = deckRepository;
        }

        public IActionResult Index()
        {
            var decks = _deckRepository.GetDecks();

            return View(decks);
        }

        [Route("[controller]/[action]/{deckId}")]
        public IActionResult DeckList(int deckId)
        {
            var deck = _deckRepository.GetDeckById(deckId);

            return View(deck);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameInform.Models;

namespace GameInform.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        GameContext db = new GameContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Games
            IEnumerable<Game> games = db.Games;
            // передаем все объекты в динамическое свойство Games в ViewBag
            ViewBag.Games = games;
            // возвращаем представление
            return View();
        }

		public ActionResult Review(int id)
		{
			IEnumerable<Review> reviews = db.Reviews.Where(a => a.GameId == id);
			ViewBag.Name = db.Games.FirstOrDefault(p => p.Id == id).Name;
			ViewBag.Reviews = reviews;
			ViewBag.Id = id;
			return View();
		}


		[HttpGet]
		public ActionResult AddReview(int id)
		{
			ViewBag.GameId = id;
			return View();
		}
		[HttpPost]
		public RedirectResult AddReview(Review review)
		{
			// добавляем информацию о покупке в базу данных
			db.Reviews.Add(review);
			// сохраняем в бд все изменения
			db.SaveChanges();
			return Redirect("/Home");
		}

		public RedirectResult DeleteReview(int id)
		{
			var s = db.Reviews.FirstOrDefault(p => p.ReviewId == id);

			db.Reviews.Remove(s);
			db.SaveChanges();

			return Redirect("/Home");
		}


		[HttpPost]
		public ActionResult GenreSearch(string genre)
		{
			var b = db.Games.Where(a => a.Genre.Contains(genre)).ToList();
			if (b.Count <= 0)
			{
				return HttpNotFound();
			}
			return PartialView(b);
		}

		[HttpGet]
		public ActionResult AddGame()
		{
			//ViewBag.GameId = id;
			return View();
		}

		[HttpPost]
		public RedirectResult AddGame(Game game)
		{
			// добавляем информацию о покупке в базу данных
			db.Games.Add(game);
			// сохраняем в бд все изменения
			db.SaveChanges();
			return Redirect("/Home");
		}

		public RedirectResult DeleteGame(int id)
		{
			var s = db.Games.FirstOrDefault(p => p.Id == id);

			db.Games.Remove(s);
			db.SaveChanges();

			return Redirect("/Home");
		}
	}
}
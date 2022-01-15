using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HelloAngularApp.Models;

namespace HelloAngularApp.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GameController : Controller
    {
        ApplicationContext db;
        public GameController(ApplicationContext context)
        {
            db = context;
            if (!db.Games.Any())
            {
                db.Games.Add(new Game { Name = "Genshin Impact", Genre = "Action/RPG", Rating = 84, Description = "Действие Genshin Impact происходит в фэнтезийном мире Тейват, который является домом для семи различных народов, каждый из которых связан с отдельной стихией и управляется отдельным богом, называемым во вселенной игры «Архонт». История следует за Путешественником, который ходит по бесчисленным мирам со своим братом-близнецом, прежде чем разлучиться в Тейвате. Вместе со своей спутницей-компаньоном Паймон Путешественник отправляется на поиски своего потерянного брата, одновременно участвуя в делах народов Тейвата." });
                db.Games.Add(new Game { Name = "Apex Legends", Genre = "Battle Royal", Rating = 35, Description = "Это многопользовательская онлайн-игра в жанре «королевская битва», которая сталкивает на одной карте до 60 игроков, действующих группами по три человека " });
                db.Games.Add(new Game { Name = "Minecraft", Genre = "Survival", Rating = 89, Description = "Стратегия, позволяющая построить любую конструкцию из имеющихся в наличии блоков. Разумеется, имеется и мультиплеер, позволяющий заняться строительством нескольким игрокам одновременно. На выбор игроков — бесплатная и платные версии, разумеется, в корне отличающиеся списком доступных возможностей." });
                db.Games.Add(new Game { Name = "The Long Dark", Genre = "Survival", Rating = 91, Description = "События The Long Dark развиваются в Северной Америке, после катастрофы, уничтожившей национальную инфраструктуру. Авторы называют ее «песочницей с видом от первого лица». В первом эпизоде мы будем играть за пилота Уильяма Маккензи, по воле судьбы оказавшегося в заснеженной глуши." });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return db.Games.ToList();
        }

        [HttpGet("{id}")]
        public Game Get(int id)
        {
            Game game = db.Games.FirstOrDefault(x => x.Id == id);
            return game;
        }

        [HttpPost]
        public IActionResult Post(Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return Ok(game);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Game game)
        {
            if (ModelState.IsValid)
            {
                db.Update(game);
                db.SaveChanges();
                return Ok(game);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Game game = db.Games.FirstOrDefault(x => x.Id == id);
            if (game != null)
            {
                db.Games.Remove(game);
                db.SaveChanges();
            }
            return Ok(game);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GameInform.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<GameContext>
    {
        protected override void Seed(GameContext db)
        {
            db.Games.Add(new Game { Name = "Genshin Impact", Picture = "Content/genshin_impact.jpg", Genre = "Action/RPG", Rating = 84, Description = "Действие Genshin Impact происходит в фэнтезийном мире Тейват, который является домом для семи различных народов, каждый из которых связан с отдельной стихией и управляется отдельным богом, называемым во вселенной игры «Архонт». История следует за Путешественником, который ходит по бесчисленным мирам со своим братом-близнецом, прежде чем разлучиться в Тейвате. Вместе со своей спутницей-компаньоном Паймон Путешественник отправляется на поиски своего потерянного брата, одновременно участвуя в делах народов Тейвата." });
            db.Games.Add(new Game { Name = "Apex Legends", Picture = "Content/apex_legends.jpg", Genre = "Battle Royal", Rating = 35, Description = "Это многопользовательская онлайн-игра в жанре «королевская битва», которая сталкивает на одной карте до 60 игроков, действующих группами по три человека " });
            db.Games.Add(new Game { Name = "Minecraft", Picture = "Content/minecraft.jpg", Genre = "Survival", Rating = 89, Description = "Стратегия, позволяющая построить любую конструкцию из имеющихся в наличии блоков. Разумеется, имеется и мультиплеер, позволяющий заняться строительством нескольким игрокам одновременно. На выбор игроков — бесплатная и платные версии, разумеется, в корне отличающиеся списком доступных возможностей." });
            db.Games.Add(new Game { Name = "The Long Dark", Picture = "Content/the_long_dark.jpg", Genre = "Survival", Rating = 91, Description = "События The Long Dark развиваются в Северной Америке, после катастрофы, уничтожившей национальную инфраструктуру. Авторы называют ее «песочницей с видом от первого лица». В первом эпизоде мы будем играть за пилота Уильяма Маккензи, по воле судьбы оказавшегося в заснеженной глуши." });

            base.Seed(db);
        }
    }
}
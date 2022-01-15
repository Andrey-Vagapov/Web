using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloAngularApp.Models
{
    public class Game
    {
        //ID игры
        public int Id { get; set; }
        //Название
        public string Name { get; set; }
        //Описание
        public string Description { get; set; }
        //Жанр
        public string Genre { get; set; }
        //Рейтинг
        public int Rating { get; set; }
    }
}

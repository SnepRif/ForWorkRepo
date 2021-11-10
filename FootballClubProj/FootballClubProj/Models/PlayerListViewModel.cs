using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballClubProj.Models
{
    public class PlayerListViewModel
    {
        /// <summary>
        /// Хранит отсортированных игроков
        /// </summary>
        public IEnumerable<Player> Players { get; set; }

        /// <summary>
        /// Критерий сортировки
        /// </summary>
        public SelectList Teams { get; set; }

        /// <summary>
        /// Критерий сортировки
        /// </summary>
        public SelectList Positions { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newProject.Models
{
    public class PlayerWithItemsDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<ItemDto>? Items { get; set; }
    }
}
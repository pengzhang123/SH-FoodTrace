using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model.BaseDto
{
    public class ComboxTreeDto
    {
        public ComboxTreeDto()
        {
            //this.state = "closed";

            this.children = new List<ComboxTreeDto>();
        }

        public ComboxTreeDto(string id, string text)
            : this()
        {
            this.id = id;
            this.text = text;
        }
        public string id { get; set; }
	    public string  text { get; set; }

        public List<ComboxTreeDto> children { get; set; } 

    }
}

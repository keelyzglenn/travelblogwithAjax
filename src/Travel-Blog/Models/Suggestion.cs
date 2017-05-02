using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    [Table("Suggestions")]
    public class Suggestion
    {
        [Key]
        public int SuggestionId { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public int Upvote { get; set; }

        public Suggestion()
        {

        }
        public Suggestion(string destination, string description, int upvote, int id =0)
        {
            Destination = destination;
            Description = description;
            Upvote = upvote;
            SuggestionId = id;
        }

        public override bool Equals(System.Object otherSuggestion)
        {
            if (!(otherSuggestion is Suggestion))
            {
                return false;
            }
            else
            {
                Suggestion newSuggestion = (Suggestion)otherSuggestion;
                return this.SuggestionId.Equals(newSuggestion.SuggestionId);
            }
        }

        public override int GetHashCode()
        {
            return this.SuggestionId.GetHashCode();
        }
    }
}
